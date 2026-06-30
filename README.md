[English](README_EN.md) | 中文

# JyDraft

**JyDraft** 是一个用于 **生成Jianying草稿（Draft）并基于草稿直接渲染导出视频** 的工具集。
支持通过代码生成草稿文件，并使用独立工具在 **无需安装剪映客户端** 的情况下，将草稿及素材进行云端渲染并导出视频。

👉 可在 GitHub 右侧 **Releases** 页面下载已编译好的 HDraft 导出工具。

---

## ✨ 功能特性

* 使用 C# 代码生成草稿（`draft_content.json`）
* 支持音频、视频、GIF、文本轨道与片段
* 支持转场、动画、字幕气泡、背景填充等效果
* ✅ 支持 **加密草稿自动解密**
* 支持 **多草稿并发导出**
* 无需安装剪映客户端
* 云端渲染，对本地机器性能要求低

---

## 📦 使用说明

## 一、生成剪映草稿

下面示例展示了如何通过代码生成一个完整的草稿，并最终导出为 JSON 字符串。

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
    "据说 JyDraft 效果还不错？",
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

一个专业的 **自动化视频渲染 API 服务**，
支持通过 **JSON 草稿文件** 与 **媒体素材** 自动合成并生成视频，
适用于批量生成、自动化流水线和系统集成。

---

## 🔑 身份验证（API Key）

### 1️⃣ 获取 AuthKey

访问网站，通过 **"获取AuthKey"** 菜单直接获取：

➡️ **https://htwmedia.dpdns.org/Home/GetApiKey**

输入邮箱，点击按钮，AuthKey 将发送到您的邮箱。

> 也可以使用传统接口获取：
> ```
> POST https://htwmedia.dpdns.org/auth/applykey?email=你的邮箱
> 请求头：X-App-Source: HDraft
> ```

### 2️⃣ 在请求中使用 AuthKey

所有后续 API 请求的 Header 中必须携带：

```
X-API-KEY: <你的 AuthKey>
```

或

```
AuthKey: <你的 AuthKey>
```

---

## 🖥️ 在线体验

无需写代码，直接在浏览器中试用完整流程：

1. 访问 **https://htwmedia.dpdns.org/WebAI/Index** 进入"在线体验"
2. 登录邮箱账号
3. 在 **"草稿成片"** 功能中上传草稿 ZIP 包
4. 等待云端渲染完成，下载视频

适合在对接 API 之前先验证你的草稿包是否正确。

---

## 📦 HDraft 命令行工具

**HDraft** 是已编译好的命令行工具，支持批量导出草稿而无需写代码：

1. 从 GitHub 右侧 **[Releases](https://github.com/HTWMedia/JyDraft/releases)** 下载最新版 `HDraft.exe`
2. 编辑 `config.ini`，配置草稿路径（多个草稿用 `|` 分隔）
3. 直接运行 `HDraft.exe`

工具特性：
- 支持并发导出多个草稿
- 自动解密加密草稿
- 无需安装剪映客户端

---

## 🔐 加密草稿解密接口

用于将 **剪映 / CapCut 的加密草稿文件** 解密为可读的 `draft_content.json`。

### 接口地址

```
POST https://htwmedia.dpdns.org/home/DecryptDraft
```

### 请求方式

* `POST`
* `Content-Type: multipart/form-data`
* 请求头：`X-API-KEY: <你的 AuthKey>`

### 请求参数

| 参数名      | 类型   | 必填 | 说明                       |
| -------- | ---- | -- | ------------------------ |
| jsonFile | File | 是  | 剪映 / CapCut 加密草稿 JSON 文件 |

> ⚠️ 注意：
>
> * **必须以文件上传形式提交**
> * 不是 URL 参数
> * 不是 base64 字符串

### 返回示例

```json
{
  "success": true,
  "msg": "decrypt success",
  "draft_content": "{...}"
}
```

---

## 📦 完整的渲染流程

### 第一步：打包草稿

将草稿 JSON 及所有素材放入一个 ZIP 包：

```
my_draft.zip
├── draft_content.json      # 必须：草稿 JSON
├── video.mp4               # 草稿引用的视频素材
├── audio.mp3               # 草稿引用的音频素材
├── image.png               # 草稿引用的图片素材
└── ...                     # 其他草稿引用的素材文件
```

> `draft_content.json` 可以是使用 JyDraft 代码生成的，也可以是从加密草稿解密得到的。素材文件的路径需与 `draft_content.json` 中的引用路径一致。

### 第二步：上传草稿包

```
POST https://htwmedia.dpdns.org/home/UploadDraftPackage
Content-Type: multipart/form-data
X-API-KEY: <你的 AuthKey>
```

| 参数   | 类型   | 必填 | 说明                        |
| ------ | ------ | ---- | --------------------------- |
| file   | File   | 是   | 包含草稿 JSON + 所有素材的 ZIP 包 |

返回示例：
```json
{
  "success": true,
  "draftId": "{DRAFT_ID}",
  "files": 5
}
```

### 第三步：启动渲染

```
POST https://htwmedia.dpdns.org/home/StartRender?draftId={DRAFT_ID}
X-API-KEY: <你的 AuthKey>
```

返回示例：
```json
{
  "success": true,
  "taskId": "{TASK_ID}"
}
```

### 第四步：查询渲染进度

```
GET https://htwmedia.dpdns.org/home/GetStatus?taskId={TASK_ID}
X-API-KEY: <你的 AuthKey>
```

渲染中：
```json
{
  "Status": "running",
  "Progress": 45,
  "DownloadUrl": null
}
```

渲染完成：
```json
{
  "Status": "completed",
  "Progress": 100,
  "DownloadUrl": "https://..."
}
```

---

## 💻 Python 完整流程示例

```python
import requests
import time

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "你的AuthKey"

headers = {"X-API-KEY": API_KEY}

# 第一步：上传草稿包（包含 draft_content.json + 所有素材的 ZIP）
with open("my_draft.zip", "rb") as f:
    res = requests.post(
        f"{BASE_URL}/home/UploadDraftPackage",
        headers=headers,
        files={"file": f}
    )

data = res.json()
draft_id = data["draftId"]
print(f"草稿上传成功: {draft_id}")

# 第二步：启动渲染
res = requests.post(
    f"{BASE_URL}/home/StartRender",
    headers=headers,
    params={"draftId": draft_id}
)
task_id = res.json()["taskId"]
print(f"渲染任务已创建: {task_id}")

# 第三步：轮询渲染进度
while True:
    res = requests.get(
        f"{BASE_URL}/home/GetStatus",
        headers=headers,
        params={"taskId": task_id}
    )
    status = res.json()

    if status["Status"] == "completed":
        print(f"视频已生成: {status['DownloadUrl']}")
        # 下载视频
        video_res = requests.get(status["DownloadUrl"])
        with open("output.mp4", "wb") as f:
            f.write(video_res.content)
        break
    elif status["Status"] in ("failed", "cancelled"):
        print("渲染失败")
        break
    else:
        print(f"渲染进度: {status.get('Progress', 0)}%")
        time.sleep(5)
```

### Python 示例（解密草稿）

```python
import requests

BASE_URL = "https://htwmedia.dpdns.org"
API_KEY = "你的AuthKey"

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

## 📡 接口总览

| 接口                       | 方法   | 说明         |
| ------------------------ | ---- | ---------- |
| /auth/applykey           | POST | 申请 API Key（邮件发送） |
| /Home/GetApiKey          | GET  | 网站获取 AuthKey（推荐） |
| /home/UploadDraftPackage | POST | 上传草稿 ZIP 包    |
| /home/StartRender        | POST | 启动渲染       |
| /home/GetStatus          | GET  | 查询渲染进度     |
| /home/DecryptDraft       | POST | 解密加密草稿     |

---

## 💬 讨论群 / 技术交流

如果你对以下内容感兴趣：

* 剪映 / CapCut 草稿结构分析
* 草稿加密 / 解密原理
* 自动化渲染流程
* JyDraft 的二次开发与扩展

欢迎扫码加入 **技术讨论群** 👇

![JyDraft 技术讨论群二维码](community_qr.png)

> 本群仅用于 **技术交流与经验分享**，
> 请勿发布广告或无关内容。

---

## ❗ 常见错误码

| 错误码 | 说明            |
| --- | ------------- |
| 401 | AuthKey 无效或缺失 |
| 402 | AuthKey 已到期    |
| 400 | 参数错误          |
| 500 | 服务器内部错误       |

---

## 📄 License

仅用于学习与技术研究，请勿用于任何违反剪映 / CapCut 用户协议或相关法律法规的用途。
