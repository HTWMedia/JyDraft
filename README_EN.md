
[中文](README.md) | English

# JyDraft

**JyDraft** is a toolkit for **generating Jianying / CapCut draft files and rendering them directly into videos**.
It allows you to programmatically generate draft files and render videos in the cloud **without installing the CapCut client**.

👉 Precompiled rendering tools can be downloaded from the **Releases** page.

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

### 4️⃣ Assemble and Export the Draft

```csharp
script
    .AddSegment(audioSegment)
    .AddSegment(videoSegment);

var json = script.Dumps();
```

---

## 🚀 Draft-to-Video Automated Rendering API

### Authentication (API Key)

**Apply for API Key**

```
POST https://htwmedia.dpdns.org/auth/applykey?email=user@example.com
```

Header:

```
X-App-Source: HDraft
```

All subsequent requests must include:

```
X-API-KEY: <your API key>
```

---

## 🔐 Encrypted Draft Decryption API

```
POST https://htwmedia.dpdns.org/home/DecryptDraft
```

### Request

* Method: `POST`
* Content-Type: `multipart/form-data`

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

## 💻 Python Example (Decrypt Draft)

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

## 📡 API Summary

| Endpoint                 | Method | Description             |
| ------------------------ | ------ | ----------------------- |
| /auth/applykey           | POST   | Apply for API Key       |
| /home/DecryptDraft       | POST   | Decrypt encrypted draft |
| /home/UploadDraftPackage | POST   | Upload draft and assets |
| /home/startrender        | POST   | Start rendering         |
| /home/getstatus          | GET    | Query rendering status  |

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

## 📄 License

For learning and technical research purposes only.
Do **not** use this project in any way that violates CapCut / Jianying terms of service or applicable laws.



