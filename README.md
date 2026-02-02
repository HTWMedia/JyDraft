[English](README_EN.md) | 中文

# JyDraft

**JyDraft** 是一个用于 **生成剪映（Jianying / CapCut）草稿（Draft）并基于草稿直接渲染导出视频** 的工具集。
支持通过代码生成草稿文件，并使用独立工具在 **无需安装剪映客户端** 的情况下，将草稿及素材进行云端渲染并导出视频。

👉 可在右侧 **Releases** 页面下载已编译好的导出工具。

---

## ✨ 功能特性

* 使用 C# 代码生成剪映草稿（draft_content.json）
* 支持音频、视频、GIF、文本轨道与片段
* 支持转场、动画、字幕气泡、背景填充等效果
* 支持 **加密草稿自动解密**
* 支持 **多草稿并发导出**
* 无需安装剪映客户端
* 云端渲染，对本地机器性能要求低

---

## 📦 使用说明

## 一、生成剪映草稿

下面示例展示了如何通过代码生成一个完整的剪映草稿，并最终导出为 JSON 字符串。

### 1️⃣ 创建草稿文件

```csharp
var script = new ScriptFile(1920, 1080);
script.Content["id"] = draftId;

// 添加轨道
script
    .AddTrack(TrackTypeName.audio)
    .AddTrack(TrackTypeName.video)
    .AddTrack(TrackTypeName.text);
```

### 2️⃣ 准备素材

```csharp
var assetDir = @"D:\pyJianYingDraft\readme_assets\tutorial";

var audioPath = Path.Combine(assetDir, "audio.mp3");
var audioMaterial = new AudioMaterial(audioPath);

var videoPath = Path.Combine(assetDir, "video.mp4");
var videoMaterial = new VideoMaterial(videoPath);

var gifPath = Path.Combine(assetDir, "sticker.gif");
var gifMaterial = new VideoMaterial(gifPath);
```

### 3️⃣ 创建片段并添加效果

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

### 4️⃣ 添加文本字幕

```csharp
var textSegment = new TextSegment(
    "据说 pyJianYingDraft 效果还不错？",
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

### 5️⃣ 组装并导出草稿

```csharp
script
    .AddSegment(audioSegment)
    .AddSegment(videoSegment)
    .AddSegment(gifSegment)
    .AddSegment(textSegment);

var json = script.Dumps();
```

---

## 二、草稿渲染与视频导出（HDraft API）

# 🚀 Draft-to-Video 自动渲染 API 服务

## 📌 简介

一个专业的 **自动化视频渲染 API 服务**
支持通过 **JSON 草稿文件** 与 **媒体素材** 自动合成并生成视频
适用于批量生成、自动化流水线和系统集成

---

## 🔑 身份验证（API Key）

### 1️⃣ 申请 API Key

POST
[https://htwmedia.dpdns.org/auth/applykey?email=user@example.com](https://htwmedia.dpdns.org/auth/applykey?email=user@example.com)

请求头：

X-App-Source: HDraft

> 请将 email 替换为真实邮箱，用于接收 API Key

---

### 2️⃣ API Key 使用方式

所有后续接口请求必须在 Header 中携带：

X-API-KEY: `<你的 API Key>`

---

## 🔐 三、加密草稿解密接口

用于将 **剪映 / CapCut 的加密草稿文件** 解密为可读的 `draft_content.json`

### 接口地址

POST
[https://htwmedia.dpdns.org/home/DecryptDraft](https://htwmedia.dpdns.org/home/DecryptDraft)

### 请求参数

| 参数名      | 类型   | 说明           |
| -------- | ---- | ------------ |
| jsonFile | File | 加密草稿 JSON 文件 |

### 返回示例

```json
{
  "success": true,
  "msg": "decrypt success",
  "draft_content": "{...}"
}
```

---

### Python 示例（解密草稿）

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

## 四、完整渲染流程示例（Python）

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
    data={'title':'示例'},
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

## 📡 接口总览

| 接口                       | 方法   | 说明         |
| ------------------------ | ---- | ---------- |
| /auth/applykey           | POST | 申请 API Key |
| /home/DecryptDraft       | POST | 解密草稿       |
| /home/UploadDraftPackage | POST | 上传草稿与素材    |
| /home/startrender        | POST | 启动渲染       |
| /home/getstatus          | GET  | 查询进度       |

---

## ❗ 常见错误码

| 错误码 | 说明         |
| --- | ---------- |
| 401 | API Key 无效 |
| 400 | 参数错误       |
| 500 | 服务端异常      |

---

## 📄 License

仅用于学习与技术研究，请勿用于任何违反剪映 / CapCut 用户协议或相关法律法规的用途。

---

如果你需要 **README_EN.md 同步英文版** 或 **C# HttpClient 示例**，我可以直接按同一规范补齐。
