
[中文](README.md) | English

# JyDraft

**JyDraft** is a toolkit for **generating Jianying / CapCut draft files and rendering them directly into videos**.
It allows you to programmatically generate draft files and render videos in the cloud **without installing the CapCut client**.

👉 Precompiled rendering tools can be downloaded from the **Releases** page on the right.

---

## ✨ Features

* Generate CapCut draft files (`draft_content.json`) using C#
* Support for audio, video, GIF, and text tracks and segments
* Support transitions, animations, subtitle bubbles, background filling, and more
* ✅ Built-in support for **automatic decryption of encrypted drafts**
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

var gifSegment = new VideoSegment(
    gifMaterial,
    TimeUtil.Trange(videoSegment.End, gifMaterial.Duration)
);
gifSegment.AddBackgroundFilling("blur", 0.0625);
```

### 4️⃣ Add Text Subtitles

```csharp
var textSegment = new TextSegment(
    "It is said that JyDraft works pretty well?",
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
    .AddSegment(gifSegment)
    .AddSegment(textSegment);

var json = script.Dumps();
```

---

## 2. Draft Rendering & Video Export (HDraft API)

# 🚀 Draft-to-Video Automated Rendering API

## 📌 Overview

A professional **automated video rendering API service** that supports generating videos directly from **JSON draft files** and **media assets**.
Ideal for batch generation, automation pipelines, and system integration.

---

## 🔑 Authentication (API Key)

### 1️⃣ Apply for an API Key

**POST**

```
https://htwmedia.dpdns.org/auth/applykey?email=user@example.com
```

**Required Header**

```
X-App-Source: HDraft
```

> Replace `user@example.com` with your real email address to receive the API Key.

---

### 2️⃣ Using the API Key

All subsequent API requests must include the following header:

```
X-API-KEY: <your API key>
```

---

## 🔐 3. Encrypted Draft Decryption API

Used to decrypt **encrypted CapCut / Jianying draft files** into readable `draft_content.json`.

### Endpoint

**POST**

```
https://htwmedia.dpdns.org/home/DecryptDraft
```

### Parameters

| Name     | Type | Description               |
| -------- | ---- | ------------------------- |
| jsonFile | File | Encrypted draft JSON file |

### Response Example

```json
{
  "success": true,
  "msg": "decrypt success",
  "draft_content": "{...}"
}
```

---

### Python Example (Decrypt Draft)

```python
import requests

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "your_api_key"

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

## 4. Complete Rendering Workflow Example (Python)

```python
import requests, time

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "your_api_key"

headers = {"X-API-KEY": API_KEY}

files = [
    ('jsonFile', open('draft.json','rb')),
    ('assets', open('video.mp4','rb'))
]

res = requests.post(
    f"{BASE_URL}/home/UploadDraftPackage",
    headers=headers,
    data={'title':'Demo'},
    files=files
)

draft_id = res.json()['draftId']

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

## 📡 API Summary

| Endpoint                 | Method | Description             |
| ------------------------ | ------ | ----------------------- |
| /auth/applykey           | POST   | Apply for API Key       |
| /home/DecryptDraft       | POST   | Decrypt encrypted draft |
| /home/UploadDraftPackage | POST   | Upload draft and assets |
| /home/startrender        | POST   | Start rendering         |
| /home/getstatus          | GET    | Query rendering status  |

---

## ❗ Common Error Codes

| Code | Description                |
| ---- | -------------------------- |
| 401  | Invalid or missing API Key |
| 400  | Invalid parameters         |
| 500  | Internal server error      |

---

## 📄 License

For learning and technical research purposes only.
Do **not** use this project in any way that violates CapCut / Jianying terms of service or applicable laws.


