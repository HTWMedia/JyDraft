English | [中文](README.md)

# JyDraft

**JyDraft** is a toolkit for **programmatically generating Jianying (CapCut China) draft files** and **rendering/exporting videos directly from drafts**.

It allows you to create `draft_content.json` via code and export videos using a standalone tool, **without installing the Jianying client**.  
Rendering is performed in the cloud, with minimal local hardware requirements.

👉 Prebuilt export tools are available in the **Releases** section.

---

## ✨ Features

- Generate Jianying draft files (`draft_content.json`) using C#
- Supports audio, video, GIF, and text tracks
- Supports transitions, animations, subtitle bubbles, and background filling
- Automatically decrypts encrypted drafts
- Batch and concurrent draft exporting
- No Jianying installation required
- Cloud-based rendering with low local performance requirements

---

## 📦 Usage Guide

### 1. Generate a Jianying Draft

The following example demonstrates how to create a complete Jianying draft via code and export it as a JSON string.

#### 1️⃣ Create the Draft File

```csharp
var script = new ScriptFile(1920, 1080);
script.Content["id"] = draftId;

// Add tracks
script
    .AddTrack(TrackTypeName.audio)
    .AddTrack(TrackTypeName.video)
    .AddTrack(TrackTypeName.text);
```

---

#### 2️⃣ Prepare Assets

```csharp
var assetDir = @"D:\pyJianYingDraft\readme_assets\tutorial";

// Audio asset
var audioPath = Path.Combine(assetDir, "audio.mp3");
var audioMaterial = new AudioMaterial(audioPath);

// Video asset
var videoPath = Path.Combine(assetDir, "video.mp4");
var videoMaterial = new VideoMaterial(videoPath);

// GIF / Sticker asset
var gifPath = Path.Combine(assetDir, "sticker.gif");
var gifMaterial = new VideoMaterial(gifPath);
```

> If cloud asset upload is required, you may upload the assets first and replace the `Path` field accordingly.  
> Upload-related logic is intentionally left extensible.

---

#### 3️⃣ Create Segments and Apply Effects

```csharp
// Audio segment
var audioSegment = new AudioSegment(
    audioMaterial,
    TimeUtil.Trange(0, "5s"),
    volume: 0.6f
);
audioSegment.AddFade("1s", 0);

// Video segment
var videoSegment = new VideoSegment(
    videoMaterial,
    TimeUtil.Trange(0, "4.2s")
);
videoSegment.AddAnimation(IntroType.斜切);
videoSegment.AddTransition(TransitionType.信号故障);

// GIF segment
var gifSegment = new VideoSegment(
    gifMaterial,
    TimeUtil.Trange(videoSegment.End, gifMaterial.Duration)
);
gifSegment.AddBackgroundFilling("blur", 0.0625);
```

---

#### 4️⃣ Add Text / Subtitle

```csharp
var textSegment = new TextSegment(
    "It seems pyJianYingDraft works pretty well?",
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

---

#### 5️⃣ Assemble and Export Draft

```csharp
script
    .AddSegment(audioSegment)
    .AddSegment(videoSegment)
    .AddSegment(gifSegment)
    .AddSegment(textSegment);

var json = script.Dumps();
```

The resulting `json` string is the complete **Jianying draft file (`draft_content.json`)**.

---

## 2. Render and Export Videos (HDraft Tool)

# 🚀 Draft-to-Video API Service

## 📌 Overview

A professional API service for **automated video rendering** from **JSON drafts** and **media assets**.
Designed for programmatic video generation, batch rendering, and pipeline integration.

---

## 🔑 Authentication

### Apply for API Key

POST /auth/applykey?email=user@example.com

Required Header:
X-App-Source: HDraft

### Request Usage

All subsequent API requests must include:

X-API-KEY: <your_received_key>

---

## 💻 Code Examples

### C# Example

```csharp
var client = new DraftVideoClient();
await client.RequestApiKeyAsync("user@example.com");

client.SetApiKey("your_email_key");

string[] assets = Directory.GetFiles("./assets");
Guid draftId = await client.UploadDraftAsync(
    "My Project",
    "./draft.json",
    assets
);

await client.PollRenderStatusAsync(draftId);
```

### Python Example

```python
import requests, time

BASE_URL = "http://localhost"
API_KEY = "your_key"

headers = {"X-API-KEY": API_KEY}

files = [('jsonFile', open('draft.json','rb'))]
files.append(('assets', open('video.mp4','rb')))

r = requests.post(
    f"{BASE_URL}/home/UploadDraftPackage",
    headers=headers,
    data={'title':'Demo'},
    files=files
)

draft_id = r.json()['draftId']

task_id = requests.post(
    f"{BASE_URL}/home/startrender",
    params={'draftId': draft_id},
    headers=headers
).json()['taskId']

while True:
    status = requests.get(
        f"{BASE_URL}/home/getstatus",
        params={'taskId': task_id},
        headers=headers
    ).json()
    if status['status'] == 'completed':
        print(status['downloadUrl'])
        break
    time.sleep(5)
```

---

## 📡 API Endpoints

| Route | Method | Description |
|------|--------|-------------|
| /auth/applykey | POST | Apply for API Key |
| /home/UploadDraftPackage | POST | Upload draft and assets |
| /home/startrender | POST | Start render task |
| /home/getstatus | GET | Query render status |

---

## ❗ Error Codes

| Code | Meaning |
|-----|--------|
| 401 | Invalid or missing API Key |
| 400 | Invalid parameters |
| 500 | Internal server error |

## ⚠️ Notes

- Ensure all draft files and referenced assets are accessible
- Incorrect asset paths will cause export failures
- Maximum concurrency may depend on cloud-side limitations

---

## 📄 License

This project is intended **for learning and technical research only**.  
Do not use it in ways that violate Jianying / CapCut terms of service or applicable laws.
