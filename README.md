# JyDraft
生成剪映(jianying)草稿(draft)及由草稿直接渲染导出视频工具，可在右侧release中下载。

# 使用方法：
#1.生成草稿。如下：

var script = new ScriptFile(1920, 1080);
script.Content["id"] = draftId;

//添加音频、视频和文本轨道
script.AddTrack(TrackTypeName.audio).AddTrack(TrackTypeName.video).AddTrack(TrackTypeName.text);

var asset_dir = "D:\\pyJianYingDraft\\readme_assets\\tutorial";
var audioPath = Path.Combine(asset_dir, "audio.mp3");
var audio_material = new AudioMaterial(audioPath);
//var audioMD5 = await AssetUpload(audioPath);
//audio_material.Path = "/" + audioMD5;
//package_assets.Add(new { md5 = audioMD5, meta = "{\"visible\":true}", source_path = audio_material.Path, size = File.ReadAllBytes(audioPath).Length });

var videoPath = Path.Combine(asset_dir, "video.mp4");
var video_material = new VideoMaterial(videoPath);
//var videoMD5 = await AssetUpload(videoPath);
//video_material.Path = "/" + videoMD5 + Path.GetExtension(videoPath);
//package_assets.Add(new { md5 = videoMD5, meta = "{\"visible\":true}", source_path = video_material.Path, size = File.ReadAllBytes(videoPath).Length });

var gifPath = Path.Combine(asset_dir, "sticker.gif");
var gif_material = new VideoMaterial(gifPath);
//var gifMD5 = await AssetUpload(gifPath);
//gif_material.Path = "/" + gifMD5 + Path.GetExtension(gifPath);
//package_assets.Add(new { md5 = gifMD5, meta = "{\"visible\":true}", source_path = gif_material.Path, size = File.ReadAllBytes(gifPath).Length });

var audio_segmemt = new AudioSegment(audio_material, TimeUtil.Trange(0, "5s"), volume: 0.6f);
audio_segmemt.AddFade("1s", 0);

var video_segment = new VideoSegment(video_material, TimeUtil.Trange(0, "4.2s"));
video_segment.AddAnimation(IntroType.斜切);

var git_segment = new VideoSegment(gif_material, TimeUtil.Trange(video_segment.End, gif_material.Duration));
git_segment.AddBackgroundFilling("blur", 0.0625); //添加一个模糊背景填充效果, 模糊程度等同于剪映中第一档

video_segment.AddTransition(TransitionType.信号故障);

script.AddSegment(audio_segmemt).AddSegment(video_segment).AddSegment(git_segment);

var text_segment = new TextSegment("据说pyJianYingDraft效果还不错?",
	video_segment.TargetTimerange,
	font: FontType.文轩体,
	style: new TextStyle(color: [1.0f, 1.0f, 0.0f]),
	clipSettings: new ClipSettings(transformY: -0.8f));

text_segment.AddAnimation(Text_outro.故障闪动, "out", duration: TimeUtil.Tim("1s"));
text_segment.AddBubble("361595", "6742029398926430728");

script.AddSegment(text_segment);

var json = script.Dumps();

此json字符串即生成的草稿文件字符串。

#2.由草稿及素材云端渲染及导出视频，可在右侧release中下载导出视频工具，该工具有以下特点：

********HDraft工具用于将剪映草稿批量并发导出视频，使用说明如下********

1.使用前在config.ini中配置草稿路径，可配置多个，用|分开，如C:\Users\xx\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\1月19日\draft_content.json|C:\Users\xx\AppData\Local\JianyingPro\User Data\Projects\com.lveditor.draft\1月18日\draft_content.json

2.加密的草稿此工具会自动解密。也可以用代码生成的草稿。

3.导出过程中有若干个步骤，会有提示说明，方便追踪。

4.使用前请确保草稿及相关素材可访问，并配置正确。

5.工具支持并发导出，并且可在不安装剪映的情况下 使用。渲染的过程在云端，对使用机器无特别高的性能要求。

6.导出的视频会放在草稿所在的目录，名字以“生成视频+当前时间戳.mp4”形式存在。



