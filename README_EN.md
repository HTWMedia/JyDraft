<div align="center">

# HDraft · Batch Render Jianying / CapCut Drafts

**Turn "export drafts one by one in CapCut" into a single command.**

Your drafts already live in CapCut's project folder — but exporting them means clicking
through each one and waiting. HDraft reads draft projects directly, decrypts them,
collects assets, uploads them, renders in the cloud concurrently, and writes the
finished video back next to the draft.

[![Release](https://img.shields.io/github/v/release/HTWMedia/JyDraft?label=HDraft)](https://github.com/HTWMedia/JyDraft/releases)
[![Downloads](https://img.shields.io/github/downloads/HTWMedia/JyDraft/total)](https://github.com/HTWMedia/JyDraft/releases)
[![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20macOS-lightgrey.svg)](https://github.com/HTWMedia/JyDraft/releases)

English ｜ [简体中文](README.md) ｜ [Download](https://github.com/HTWMedia/JyDraft/releases)

</div>

---

## Why it exists

CapCut (Jianying) is great for editing — and painful for batch exporting:

| Today | With HDraft |
| --- | --- |
| Open CapCut → open draft → export → wait → next one | List your drafts, run one command, walk away |
| One export at a time, babysitting the progress bar | Multiple drafts processed concurrently |
| Export maxes out your CPU / GPU | Rendering happens in the cloud; your machine only packs and uploads |
| Batching, scheduling, or integrating is nearly impossible | CLI + HTTP API — scriptable and composable by design |

**Good for**: daily matrix accounts (dozens of similar drafts per batch), templated
mass production, wiring rendering into your own pipeline, or rendering on a machine
that has no CapCut installed at all.

---

## 30-second start

### 1. Download

Grab the archive for your platform from
[Releases](https://github.com/HTWMedia/JyDraft/releases) and unzip — no installer:

| Platform | File |
| --- | --- |
| Windows x64 | `HDraft_win-x64.zip` |
| macOS Intel | `HDraft_osx-x64.zip` |
| macOS Apple Silicon | `HDraft_osx-arm64.zip` |

> First launch on macOS may show "cannot verify the developer": run
> `xattr -dr com.apple.quarantine /path/to/HDraft`, or right-click the app → Open.

### 2. Get an AuthKey

Visit <https://htwmedia.dpdns.org/Home/GetApiKey>, enter your email, and the key is
mailed to you. The AuthKey is only an **anti-abuse gate** — new accounts start with a
1-month free quota.

### 3. Point it at your drafts

Edit `config.ini` next to the executable:

```ini
(!do not delete this line)  DraftPath：C:\Users\you\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\Feb-09\draft_content.json
authKey:your-key
```

- Separate multiple drafts with a pipe `|`;
- You can also pass a **folder** — HDraft scans its subdirectories for drafts;
- Keep the `(!do not delete this line)` marker at the start of the first line.

> Prefer not to edit files? Just run `HDraft` and type the AuthKey and draft paths
> when prompted.

### 4. Run

```bash
HDraft                      # start processing (reads config.ini)
HDraft --draft <path>       # override the draft file/folder for this run
HDraft --jobs 2             # how many drafts at once (default: by account tier)
HDraft --no-pause           # exit without waiting for a key press (scripts / CI)
HDraft --help               # usage
```

Each step is printed so you can follow along. Finished videos land in the **draft's own
folder**, named like `渲染视频20261030153012.mp4`.

#### Concurrency and quota

- Concurrency is chosen automatically by **account tier** (free 1, personal 2, studio 4,
  enterprise 10); `--jobs N` overrides it;
- When the server rate-limits you (429), HDraft waits for the `Retry-After` it sends;
- Quota is charged when a render is submitted; failed tasks are not charged.

#### Resume after interruption

Once a render is submitted, its taskId is stored in `hdraft_tasks.json` next to the
executable. If the program is closed, the network drops, or the download fails, **running
the same command again will not resubmit the render**: an in-progress task keeps being
polled, a finished one is downloaded directly — no quota is charged twice. The record is
invalidated when the draft content changes; pass `--no-resume` to force a resubmission.

#### Exit codes

| Code | Meaning |
| --- | --- |
| 0 | All succeeded |
| 1 | Some drafts failed |
| 2 | Configuration or usage error |
| 3 | AuthKey rejected |
| 4 | Quota exhausted |

It also prints "成功 X，失败 Y，跳过 Z" at the end, which makes scripting and CI easy.

---

## What actually happens

```
Draft project folder
   │  ① read draft_content.json (auto-decrypt if encrypted)
   │  ② parse the draft, collect referenced video / image / audio assets
   │  ③ convert GIFs to their first PNG frame
   ▼
Upload assets to the cloud (local machine only packs; concurrency depends on account tier)
   ▼
④ Cloud rendering: create task → poll progress
   ▼
⑤ Download the result → write next to the draft → clean up temp files
```

Details you may care about:

- **Encrypted drafts are handled for you** — CapCut encrypts drafts since 5.9; no manual step;
- **Drafts don't have to come from CapCut** — a generated `draft_content.json` renders just as well (see below);
- **Your machine stays usable** — rendering is cloud-side; once upload finishes you can close the window;
- **Assets are not retained** — temporary cloud assets are deleted when the task ends.

---

## Where drafts come from

### ① Reuse your CapCut project drafts (most common)

Default location on Windows:

```
C:\Users\<you>\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\<draft-name>\draft_content.json
```

Not sure? Right-click the draft in CapCut → "Open draft folder".

### ② Generate drafts from code (batching / templating)

The repo ships a lightweight C# draft-generation library (`ScriptFile.cs`,
`VideoSegment.cs`, `AudioSegment.cs`, …) — you can assemble a whole video without ever
opening CapCut. `JyDraft.csproj` is included, so a clone builds directly:

```bash
dotnet build      # produces JyDraft.dll; deps are pinned: Newtonsoft.Json / Microsoft.Extensions.Logging / MediaInfo.Wrapper.Core
```

```csharp
var script = new ScriptFile(1920, 1080);          // canvas size
script.Content["id"] = draftId;

script.AddTrack(TrackTypeName.audio)
      .AddTrack(TrackTypeName.video)
      .AddTrack(TrackTypeName.text);

var audioSegment = new AudioSegment(
    new AudioMaterial(@"D:\assets\audio.mp3"),
    TimeUtil.Trange(0, "5s"),
    volume: 0.6f);
audioSegment.AddFade("1s", 0);                    // fade in

var videoSegment = new VideoSegment(
    new VideoMaterial(@"D:\assets\video.mp4"),
    TimeUtil.Trange(0, "4.2s"));
videoSegment.AddAnimation(IntroType.斜切);        // intro animation
videoSegment.AddTransition(TransitionType.信号故障); // transition

var textSegment = new TextSegment(
    "Heard HDraft works pretty well?",
    videoSegment.TargetTimerange,
    font: FontType.文轩体,
    style: new TextStyle(color: new[] { 1.0f, 1.0f, 0.0f }),
    clipSettings: new ClipSettings(transformY: -0.8f));

script.AddSegment(audioSegment)
      .AddSegment(videoSegment)
      .AddSegment(textSegment);

var json = script.Dumps();                        // write out as draft_content.json
```

Supported: audio / video / image / GIF / text tracks and segments, keyframes,
transitions, animations, subtitle bubbles, background filling, filters and effects
(metadata for effects lives under `meta/`).

### ③ Decrypt an encrypted draft

If all you have is an encrypted `draft_content.json` and you want to inspect or tweak it
before rendering, call the `DecryptDraft` endpoint (see integration below) to get
plaintext JSON back.

---

## Integrating it

The CLI covers most cases. If you want to embed rendering into your own platform,
schedule it, or build on top of it, use the HTTP API. Every request carries the header
`AuthKey: <your key>` (`X-API-KEY` also accepted).

### Simple flow: upload a ZIP

Best when the package is small and you want the fewest lines of code.

| Step | Endpoint | Notes |
| --- | --- | --- |
| 1 | `POST /Home/UploadDraftPackage` | `multipart/form-data` ZIP containing `draft_content.json` + all assets |
| 2 | `POST /Home/StartRender?draftId={id}` | Starts rendering, returns `taskId` |
| 3 | `GET /Home/GetStatus?taskId={id}` | Poll `Status` / `Progress` / `DownloadUrl` |

ZIP layout (asset paths must match the references inside the JSON):

```
my_draft.zip
├── draft_content.json
├── video.mp4
├── audio.mp3
└── image.png
```

### Chunked flow: upload assets one by one (what HDraft itself uses)

Better for large files, instant-upload dedupe, resumable transfers, or when you manage
assets yourself.

```text
POST /Home/CreateAssetUpload   { md5, size, crc32, filename, file_type } → upload_id / space_id / token
      ↓ stream bytes to cloud storage
POST /Home/CommitAssetUpload   { upload_id, space_id, md5, filename, size } → asset_id
      ↓ (repeat for every asset)
POST /Home/SaveDraft           { draftJson, title, packageAssets } → draftId
POST /Home/RenderDraft         { draftId } → taskId
GET  /Home/GetStatus?taskId=…  → Status / Progress / DownloadUrl
```

`GetStatus` response example:

```json
{ "Status": "completed", "Progress": 100, "DownloadUrl": "https://..." }
```

### Other endpoints

| Endpoint | Method | Notes |
| --- | --- | --- |
| `/Home/GetApiKey` | GET | Web page to request an AuthKey (recommended) |
| `/auth/applykey?email=` | POST | Request an AuthKey via API (sent by email) |
| `/Home/DecryptDraft` | POST | Upload an encrypted draft JSON via `multipart/form-data`, get plaintext `draft_content` |

> The API keeps evolving — trust the actual response over this page. Questions welcome as issues.

---

## FAQ

<details>
<summary><b>Do I need CapCut installed?</b></summary>

No. HDraft reads CapCut's draft project files and renders in the cloud, so it runs fine
on machines — or servers — without CapCut.
</details>

<details>
<summary><b>How do I find my draft path?</b></summary>

Right-click the draft in CapCut → "Open draft folder"; `draft_content.json` is inside.
You can also put a **folder path** into `config.ini` and HDraft will scan subdirectories.
</details>

<details>
<summary><b>It says assets are missing / my render is missing clips?</b></summary>

Referenced assets must still exist and be readable. Moving assets or switching machines
is the usual cause — open the draft once in CapCut to confirm it previews, then hand it
to HDraft.
</details>

<details>
<summary><b>How many run in parallel? How long does it take?</b></summary>

Concurrency is decided by your **account tier** (free 1, personal 2, studio 4,
enterprise 10); override it with `--jobs N`. Per-video time depends on cloud queue and
clip length; in batch scenarios the total is usually far faster than exporting by hand.
</details>

<details>
<summary><b>Where do the videos go?</b></summary>

Into the **draft's own folder**, named like `渲染视频20261030153012.mp4`.
</details>

<details>
<summary><b>Are my assets kept?</b></summary>

Not long-term. Cloud rendering requires the draft and its assets to be uploaded to
Jianying's cloud and this project's server during rendering; temporary cloud assets are
deleted when the task ends (success or failure), and local temp files are cleaned up too.
If your assets are sensitive or unreleased, weigh that before using cloud rendering.
</details>

<details>
<summary><b>Render fails with 200403 / library music?</b></summary>

If the draft uses music from the Jianying library (material carrying `music_id` /
`effect_id`), the render fails with `200403 create render task failed` — that music is
licensed to the original account, and the rendering account cannot resolve it. Replace it
with a **local audio file** and export again. In testing, the same draft rendered fine
after removing only the library-music track.
</details>

<details>
<summary><b>macOS says "cannot verify the developer"?</b></summary>

The binaries are not signed/notarized by Apple. Run
`xattr -dr com.apple.quarantine /path/to/HDraft`, or right-click the app in Finder → Open.
</details>

## Error codes

| Code | Meaning | What to do |
| --- | --- | --- |
| 401 | AuthKey missing or invalid | Re-request and fill it in |
| 402 | Free quota exhausted | Top up on the platform and retry |
| 400 | Bad request parameters | Check draft package structure and fields |
| 500 | Internal server error | Retry; open an issue if it persists |

---

## Related

- [HTWMedia/HTWClient](https://github.com/HTWMedia/HTWClient) — the open-source desktop
  client covering the full loop: topic research → creation → editing → multi-platform
  publishing. Use HDraft when all you need is batch draft exporting; use HTWClient for
  the whole workbench.

## Contributing

Issues and PRs welcome. The draft-generation library lives at the repo root — if you
discover new draft fields or effect parameters, please contribute them to `meta/`.

## Community

Interested in CapCut / Jianying draft internals, encryption, or automated rendering
pipelines? Join the chat:

![Community group](qrcode_1785752822479.jpg)

> Technical discussion only — no advertising, please.

## License

The code in this repository is released under the [Apache License 2.0](LICENSE).

## Disclaimer

- This is an independent third-party tool. It is not affiliated with, authorized by, or
  endorsed by the operators of Jianying / CapCut.
- You are responsible for ensuring you have the rights to the drafts, assets, and videos
  you process, and for complying with the Jianying / CapCut terms of service and
  applicable law. Account and legal risk arising from use is borne by the user.
- Music from the Jianying library (`music_id` / `effect_id` pointing at library material)
  is licensed to the original account; rendering under a different account may return
  `200403`. Use local audio, or re-add the music in the target account.
