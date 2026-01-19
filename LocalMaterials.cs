
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft
{
    public class CropSettings
    {
        // 各属性均在0-1之间
        public float UpperLeftX { get; set; }
        public float UpperLeftY { get; set; }
        public float UpperRightX { get; set; }
        public float UpperRightY { get; set; }
        public float LowerLeftX { get; set; }
        public float LowerLeftY { get; set; }
        public float LowerRightX { get; set; }
        public float LowerRightY { get; set; }

        public CropSettings(
            float upperLeftX = 0.0f, float upperLeftY = 0.0f,
            float upperRightX = 1.0f, float upperRightY = 0.0f,
            float lowerLeftX = 0.0f, float lowerLeftY = 1.0f,
            float lowerRightX = 1.0f, float lowerRightY = 1.0f)
        {
            UpperLeftX = upperLeftX;
            UpperLeftY = upperLeftY;
            UpperRightX = upperRightX;
            UpperRightY = upperRightY;
            LowerLeftX = lowerLeftX;
            LowerLeftY = lowerLeftY;
            LowerRightX = lowerRightX;
            LowerRightY = lowerRightY;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "upper_left_x", UpperLeftX },
                { "upper_left_y", UpperLeftY },
                { "upper_right_x", UpperRightX },
                { "upper_right_y", UpperRightY },
                { "lower_left_x", LowerLeftX },
                { "lower_left_y", LowerLeftY },
                { "lower_right_x", LowerRightX },
                { "lower_right_y", LowerRightY }
            };
        }
    }

    public class VideoMaterial
    {
        public string MaterialId { get; set; }
        public string LocalMaterialId { get; set; } = "";
        public string MaterialName { get; set; }
        public string Path { get; set; }
        public long Duration { get; set; } // 微秒
        public int Height { get; set; }
        public int Width { get; set; }
        public CropSettings CropSettings { get; set; }
        public string MaterialType { get; set; } // "video" or "photo"

        public VideoMaterial(string path, string materialName = null, CropSettings cropSettings = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"找不到 {path}");

            Path = System.IO.Path.GetFullPath(path);
            MaterialName = materialName ?? System.IO.Path.GetFileName(path);
            MaterialId = Guid.NewGuid().ToString().ToUpper();
            CropSettings = cropSettings ?? new CropSettings();

            string ext = System.IO.Path.GetExtension(path).ToLower();

            // 用第三方库读取媒体信息，以下为伪代码
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });


            var mediaInfo = new MediaInfo.MediaInfoWrapper(path, null);

            // bool canParse = true; // 伪逻辑
            bool canParse = true;
            if (!canParse)
                throw new ArgumentException($"不支持的视频素材类型 '{ext}'");

            // 以下为伪代码，具体属性和方法需查阅 C# 的媒体信息库
            if (mediaInfo.HasVideo)
            {
                MaterialType = "video";
                Duration = (long)mediaInfo.Duration * 1000;
                Width = mediaInfo.Width;
                Height = mediaInfo.Height;
            }
            else if (ext == ".gif")
            {
                // 需要用其他库（如 ImageSharp 或 ImageMagick）读取 gif
                MaterialType = "gif";
                Duration = 5000000;
                Width = /*gif width*/ 0;
                Height = /*gif height*/ 0;
            }
            else if (ext == ".jpg" || ext == ".jpeg" || ext == "png")
            {
                MaterialType = "photo";
                Duration = 10800000; // 3小时
                Width = 0;
                Height = 0;
            }
            else
            {
                throw new ArgumentException($"输入的素材文件 {path} 没有视频轨道或图片轨道");
            }
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "id", MaterialId },
                { "type", MaterialType },
                { "path", Path },
                { "media_path", "" },
                { "local_id", "" },
                { "has_audio", false },
                { "reverse_path", "" },
                { "intensifies_path", "" },
                { "reverse_intensifies_path", "" },
                { "intensifies_audio_path", "" },
                { "cartoon_path", "" },
                { "width", Width },
                { "height", Height },
                { "category_id", "" },
                { "category_name", "" },
                { "material_id", "" },
                { "material_name", MaterialName },
                { "material_url", "" },
                { "crop_ratio", "free" },
                { "crop_scale", 1 },
                { "extra_type_option", 0 },
                { "source", 0 },
                { "source_platform", 0 },
                { "formula_id","" },
                { "check_flag", 65535 },
                { "is_unified_beauty_mode", false },
                { "picture_from", "none" },
                { "picture_set_category_id", "" },
                { "picture_set_category_name", "" },
                { "team_id","" },
                { "local_material_id", "" },
                { "origin_material_id", "" },
                { "request_id","" },
                { "is_ai_generate_content",false },
                { "aigc_type", "none" },
                { "duration", Duration },
                { "crop",CropSettings.ExportJson()},
                { "audio_fade", null },
                { "stable", new Dictionary<string,object> {
                    { "stable_level", 0 },
                    { "matrix_path", "" },
                    { "time_range", new Dictionary<string,object>{
                        { "start", 0 },
                        { "duration", 0 }
                    }
                } }},
            { "matting",new Dictionary<string,object> {
                    {"path", "" },
                {"has_use_quick_brush", false },
                {"has_use_quick_eraser", false },
                {"flag", 0 },
                {"interactiveTime",Array.Empty<object>()},
                {"strokes", Array.Empty<object>() }

            } },
            { "gameplay", null},
            { "video_algorithm",new Dictionary<string,object> {
                    {"path", "" },
                {"time_range", null },
                {"motion_blur_config", null },
                {"deflicker", null },
                {"noise_reduction", null },
                {"quality_enhance", null },
                {"algorithms",Array.Empty<object>() }
            } },
            { "object_locked", null},
            { "smart_motion", null},
            { "freeze", null}
            };
            //return new Dictionary<string, object>
            //{
            //    { "audio_fade", null },
            //    { "category_id", "" },
            //    { "category_name", "" },
            //    { "check_flag", 63487 },
            //    { "crop", CropSettings.ExportJson() },
            //    { "crop_ratio", "free" },
            //    { "crop_scale", 1.0 },
            //    { "duration", Duration },
            //    { "height", Height },
            //    { "id", MaterialId },
            //    { "local_material_id", "" },
            //    { "material_id", MaterialId },
            //    { "material_name", MaterialName },
            //    { "media_path", "" },
            //    { "path", Path },
            //    { "type", MaterialType },
            //    { "width", Width }
            //};
        }

        // 用 MD5 生成和 Python uuid3 类似的16字节hex字符串
        private static string CreateUUID(string name)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(name));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }

    public class AudioMaterial
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string Path { get; set; }
        public long Duration { get; set; } // 微秒

        public AudioMaterial(string path, string materialName = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"找不到 {path}");

            Path = System.IO.Path.GetFullPath(path);

            MaterialName = materialName ?? System.IO.Path.GetFileName(path);
            MaterialId = Guid.NewGuid().ToString().ToUpper();

            bool canParse = true;
            if (!canParse)
                throw new ArgumentException($"不支持的音频素材类型 {System.IO.Path.GetExtension(path)}");

            // 用第三方库读取音频信息，以下为伪代码
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });


            var mediaInfo = new MediaInfo.MediaInfoWrapper(path,null);

            if (mediaInfo.HasVideo)
                throw new ArgumentException("音频素材不应包含视频轨道");
            if (mediaInfo.AudioStreams==null)
                throw new ArgumentException($"给定的素材文件 {path} 没有音频轨道");

            Duration = (long)(mediaInfo.Duration*1000);

        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "app_id", 0 },
                { "category_id", "" },
                { "category_name", "" },
                { "check_flag", 1 },
                { "copyright_limit_type", "none" },
                { "duration", Duration },
                { "effect_id", "" },
                { "formula_id", "" },
                { "id", MaterialId },
                { "intensifies_path", "" },
                { "is_ai_clone_tone", false },
                { "is_text_edit_overdub", false },
                { "is_ugc", false },
                { "local_material_id", "" },
                { "music_id", MaterialId },
                { "name", MaterialName },
                { "path", Path },
                { "query", "" },
                { "request_id", "" },
                { "resource_id", "" },
                { "search_id", "" },
                { "source_from", "" },
                { "source_platform", 0 },
                { "team_id", "" },
                { "text_id", "" },
                { "tone_category_id", "" },
                { "tone_category_name", "" },
                { "tone_effect_id", "" },
                { "tone_effect_name", "" },
                { "tone_platform", "" },
                { "tone_second_category_id", "" },
                { "tone_second_category_name", "" },
                { "tone_speaker", "" },
                { "tone_type", "" },
                { "type", "music" },
                { "video_id", "" },
                { "wave_points", new List<object>() }
            };
        }

        private static string CreateUUID(string name)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(name));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
