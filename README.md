# JyDraft

**JyDraft** 是一个用于 **生成剪映（Jianying / CapCut）草稿（Draft）并基于草稿直接渲染导出视频** 的工具集。  
支持通过代码生成草稿文件，并使用独立工具在 **无需安装剪映客户端** 的情况下，将草稿及素材进行云端渲染并导出视频。

👉 可在右侧 **Releases** 页面下载已编译好的导出工具。

---

## ✨ 功能特性

- 使用 C# 代码生成剪映草稿（draft_content.json）
- 支持音频、视频、GIF、文本轨道与片段
- 支持转场、动画、字幕气泡、背景填充等效果
- 支持 **加密草稿自动解密**
- 支持 **多草稿并发导出**
- 无需安装剪映客户端
- 云端渲染，对本地机器性能要求低

---

## 📦 使用说明

### 一、生成剪映草稿

下面示例展示了如何通过代码生成一个完整的剪映草稿，并最终导出为 JSON 字符串。

#### 1️⃣ 创建草稿文件

```csharp
var script = new ScriptFile(1920, 1080);
script.Content["id"] = draftId;

// 添加轨道
script
    .AddTrack(TrackTypeName.audio)
    .AddTrack(TrackTypeName.video)
    .AddTrack(TrackTypeName.text);
```

#### 2️⃣ 准备素材

```csharp
var assetDir = @"D:\pyJianYingDraft\readme_assets\tutorial";

var audioPath = Path.Combine(assetDir, "audio.mp3");
var audioMaterial = new AudioMaterial(audioPath);

var videoPath = Path.Combine(assetDir, "video.mp4");
var videoMaterial = new VideoMaterial(videoPath);

var gifPath = Path.Combine(assetDir, "sticker.gif");
var gifMaterial = new VideoMaterial(gifPath);
```

#### 3️⃣ 创建片段并添加效果

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

#### 4️⃣ 添加文本字幕

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

#### 5️⃣ 组装并导出草稿

```csharp
script
    .AddSegment(audioSegment)
    .AddSegment(videoSegment)
    .AddSegment(gifSegment)
    .AddSegment(textSegment);

var json = script.Dumps();
```

---

## 二、草稿渲染与视频导出（HDraft 工具）

### 使用步骤

#### 1️⃣ 配置草稿路径

```ini
C:\Users\xx\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\1月19日\draft_content.json|
C:\Users\xx\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\1月18日\draft_content.json
```

#### 2️⃣ 工具特性说明

- 自动识别并解密 **加密草稿**
- 支持代码生成的草稿文件
- 导出过程分步骤提示，便于排查问题
- 支持多草稿 **并发导出**
- 无需安装剪映客户端
- 云端渲染，对本地机器性能要求低

#### 3️⃣ 导出结果

- 导出的视频文件位于 **草稿所在目录**
- 文件命名格式：

```
生成视频_时间戳.mp4
```

---

## 📄 License

仅用于学习与技术研究，请勿用于任何违反剪映 / CapCut 用户协议或相关法律法规的用途。
