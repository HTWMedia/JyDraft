[中文](README.md) | English

# JyDraft

**JyDraft** is a toolkit for **generating Jianying / CapCut draft files and rendering them directly into videos**.
It allows you to programmatically generate draft files and render videos in the cloud **without installing the CapCut client**.

👉 Precompiled HDraft CLI tools can be downloaded from the **Releases** page on the right side of GitHub.

---

## ✨ Features

* Generate CapCut draft files (`draft_content.json`) using C#
* Support for audio, video, GIF, and text tracks and segments
* Support transitions, animations, subtitle bubbles, background filling, and more
* Built-in support for **automatic decryption of encrypted drafts**
* Support **concurrent rendering of multiple drafts**
* No CapCut client installation required
* Cloud-based rendering with low local hardware requirements

---

## 📦 Usage Guide

## 1. Generate a CapCut Draft

The following example demonstrates how to generate a complete CapCut draft using code and export it as a JSON string.

### 1️⃣ Create a Draft File

```csharp
var script = new ScriptFile(1920, 1080);
script.Content["id"] = draftId;

// Add tracks
script
    .AddTrack(TrackTypeName.audio)
    .AddTrack(TrackTypeName.video)
    .AddTrack(TrackTypeName.text);
```

### 2️⃣ Prepare Assets

```csharp
var assetDir = @"D:\pyJianYingDraft\readme_assets\tutorial";

var audioPath = Path.Combine(assetDir, "audio.mp3");
var audioMaterial = new AudioMaterial(audioPath);

var videoPath = Path.Combine(assetDir, "video.mp4");
var videoMaterial = new VideoMaterial(videoPath);

var gifPath = Path.Combine(assetDir, "sticker.gif");
var gifMaterial = new VideoMaterial(gifPath);
```

### 3️⃣ Create Segments and Apply Effects

```csharp
var audioSegment = new AudioSegment(
    audioMaterial,
    TimeUtil.Trange(0, "5s"),
    volume: 0.6f
);
audioSegment.AddFade("1s", 0);

var videoSegment = new VideoSegment(
    videoMaterial,
    TimeUtil.Trange(0, "4.2s")
);
videoSegment.AddAnimation(IntroType.斜切);
videoSegment.AddTransition(TransitionType.信号故障);
```

### 4️⃣ Add Text

```csharp
var textSegment = new TextSegment(
    "JyDraft works great!",
    videoSegment.TargetTimerange,
    font: FontType.文轩体,
    style: new TextStyle(color: new[] { 1.0f, 1.0f, 0.0f }),
    clipSettings: new ClipSettings(transformY: -0.8f)
);

textSegment.AddAnimation(
    Text_outro.故障闪动,
    "out",
    duration: TimeUtil.Tim("1s")
);
textSegment.AddBubble("361595", "6742029398926430728");
```

### 5️⃣ Assemble and Export the Draft

```csharp
script
    .AddSegment(audioSegment)
    .AddSegment(videoSegment)
    .AddSegment(textSegment);

var json = script.Dumps();
```

---

## 🚀 Draft-to-Video Automated Rendering API

### 🔑 Authentication (API Key)

#### 1️⃣ Get AuthKey

Visit the website and obtain your AuthKey directly from the **"获取AuthKey"** menu:

➡️ **https://htwmedia.dpdns.org/Home/GetApiKey**

Enter your email and click the button — the AuthKey will be sent to your email inbox.

> Alternatively, you can still use the legacy API:
> ```
> POST https://htwmedia.dpdns.org/auth/applykey?email=your@email.com
> Header: X-App-Source: HDraft
> ```

#### 2️⃣ Use AuthKey in API Calls

Include the AuthKey in every API request header:

```
X-API-KEY: <your authkey>
```

or

```
AuthKey: <your authkey>
```

---

### 🖥️ Try Online Before Coding

You can test the full draft-to-video pipeline directly in your browser:

1. Go to **https://htwmedia.dpdns.org/WebAI/Index**
2. Log in with your email
3. Use the **"草稿成片" (Draft to Video)** feature under the **"在线体验"** menu
4. Upload your draft ZIP package and wait for the rendered video

This is a great way to validate your draft package before automating with the API.

---

### 📦 HDraft CLI Tool

The **HDraft** command-line tool allows you to batch-export drafts without writing any code:

1. Download the latest `HDraft.exe` from **[Releases](https://github.com/HTWMedia/JyDraft/releases)** (right sidebar on GitHub)
2. Configure `config.ini` with your draft paths (separate multiple drafts with `|`)
3. Run `HDraft.exe` — it will automatically decrypt encrypted drafts, upload and render them

The tool supports:
- Concurrent rendering of multiple drafts
- Automatic decryption of encrypted drafts
- No CapCut client installation required

---

## 🔐 Encrypted Draft Decryption API

```
POST https://htwmedia.dpdns.org/home/DecryptDraft
```

### Request

* Method: `POST`
* Content-Type: `multipart/form-data`
* Headers: `X-API-KEY: <your authkey>`

### Parameters

| Name     | Type | Required | Description                                 |
| -------- | ---- | -------- | ------------------------------------------- |
| jsonFile | File | Yes      | Encrypted Jianying / CapCut draft JSON file |

> ⚠️ Notes:
>
> * The draft must be uploaded as a **file**
> * URL parameters are **not supported**
> * Base64 payloads are **not supported**

---

## 📦 Complete Rendering Flow

### Step 1: Package Your Draft

Create a ZIP file containing:

```
my_draft.zip
├── draft_content.json      # Required: your draft JSON
├── video.mp4               # Video asset referenced in draft
├── audio.mp3               # Audio asset referenced in draft
├── image.png               # Image asset referenced in draft
└── ...                     # Any other files referenced in draft
```

> The `draft_content.json` can be generated using JyDraft's C# code, or decrypted from an encrypted CapCut draft. Assets should be placed at paths matching those in the `draft_content.json` file.

### Step 2: Upload Draft Package

```
POST https://htwmedia.dpdns.org/home/UploadDraftPackage
Content-Type: multipart/form-data
X-API-KEY: <your authkey>
```

| Parameter | Type | Required | Description                        |
| --------- | ---- | -------- | ---------------------------------- |
| file      | File | Yes      | ZIP package of draft + all assets  |

Response:
```json
{
  "success": true,
  "draftId": "{DRAFT_ID}",
  "files": 5
}
```

### Step 3: Start Rendering

```
POST https://htwmedia.dpdns.org/home/StartRender?draftId={DRAFT_ID}
X-API-KEY: <your authkey>
```

Response:
```json
{
  "success": true,
  "taskId": "{TASK_ID}"
}
```

### Step 4: Query Rendering Status

```
GET https://htwmedia.dpdns.org/home/GetStatus?taskId={TASK_ID}
X-API-KEY: <your authkey>
```

Response (in progress):
```json
{
  "Status": "running",
  "Progress": 45,
  "DownloadUrl": null
}
```

Response (completed):
```json
{
  "Status": "completed",
  "Progress": 100,
  "DownloadUrl": "https://..."
}
```

---

## 💻 Python Example (Complete Flow)

```python
import requests
import time

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "your_authkey"

headers = {"X-API-KEY": API_KEY}

# Step 1: Upload draft package (ZIP containing draft_content.json + assets)
with open("my_draft.zip", "rb") as f:
    res = requests.post(
        f"{BASE_URL}/home/UploadDraftPackage",
        headers=headers,
        files={"file": f}
    )

data = res.json()
draft_id = data["draftId"]
print(f"Draft uploaded: {draft_id}")

# Step 2: Start rendering
res = requests.post(
    f"{BASE_URL}/home/StartRender",
    headers=headers,
    params={"draftId": draft_id}
)
task_id = res.json()["taskId"]
print(f"Task created: {task_id}")

# Step 3: Poll until complete
while True:
    res = requests.get(
        f"{BASE_URL}/home/GetStatus",
        headers=headers,
        params={"taskId": task_id}
    )
    status = res.json()

    if status["Status"] == "completed":
        print(f"Video ready: {status['DownloadUrl']}")
        video_res = requests.get(status["DownloadUrl"])
        with open("output.mp4", "wb") as f:
            f.write(video_res.content)
        break
    elif status["Status"] in ("failed", "cancelled"):
        print("Rendering failed")
        break
    else:
        print(f"Progress: {status.get('Progress', 0)}%")
        time.sleep(5)
```

### Python Example (Decrypt Draft)

```python
import requests

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "your_authkey"

headers = {"X-API-KEY": API_KEY}
files = {"jsonFile": open("encrypted_draft.json", "rb")}

res = requests.post(
    f"{BASE_URL}/home/DecryptDraft",
    headers=headers,
    files=files
)

data = res.json()
if data["success"]:
    with open("draft_content.json", "w", encoding="utf-8") as f:
        f.write(data["draft_content"])
```

---

## 📡 API Summary

| Endpoint                 | Method | Description                           |
| ------------------------ | ------ | ------------------------------------- |
| /auth/applykey           | POST   | Apply for API Key (email delivery)    |
| /Home/GetApiKey          | GET    | Get AuthKey from website (recommended)|
| /home/UploadDraftPackage | POST   | Upload draft ZIP package              |
| /home/StartRender        | POST   | Start rendering a draft               |
| /home/GetStatus          | GET    | Query rendering progress/result       |
| /home/DecryptDraft       | POST   | Decrypt encrypted draft               |

---

## 💬 Community & Discussion Group

If you are interested in:

* CapCut / Jianying draft structure analysis
* Draft encryption & decryption
* Automated rendering pipelines
* JyDraft development & extensions

Feel free to join our **discussion group** by scanning the QR code below 👇

![JyDraft Community QR Code](community_qr.png)

> The group is mainly used for **technical discussion and experience sharing**.
> Please keep conversations focused and respectful.

---

## ❗ Common Error Codes

| Code | Description                          |
| ---- | ------------------------------------ |
| 401  | AuthKey missing or invalid           |
| 402  | AuthKey expired                      |
| 400  | Invalid parameters                   |
| 500  | Server internal error                |

---

## 📄 License

For learning and technical research purposes only.
Do **not** use this project in any way that violates CapCut / Jianying terms of service or applicable laws.
