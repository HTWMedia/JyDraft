using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JyDraft
{
    public enum ExportResolution
    {
        RES_8K,
        RES_4K,
        RES_2K,
        RES_1080P,
        RES_720P,
        RES_480P
    }

    public static class ExportResolutionExtensions
    {
        public static string GetValue(this ExportResolution res)
        {
            return res switch
            {
                ExportResolution.RES_8K => "8K",
                ExportResolution.RES_4K => "4K",
                ExportResolution.RES_2K => "2K",
                ExportResolution.RES_1080P => "1080P",
                ExportResolution.RES_720P => "720P",
                ExportResolution.RES_480P => "480P",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public enum ExportFramerate
    {
        FR_24,
        FR_25,
        FR_30,
        FR_50,
        FR_60
    }

    public static class ExportFramerateExtensions
    {
        public static string GetValue(this ExportFramerate fr)
        {
            return fr switch
            {
                ExportFramerate.FR_24 => "24fps",
                ExportFramerate.FR_25 => "25fps",
                ExportFramerate.FR_30 => "30fps",
                ExportFramerate.FR_50 => "50fps",
                ExportFramerate.FR_60 => "60fps",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public static class ControlFinder
    {
        // 委托表示：传入 Control 和深度 返回bool
        public static Func<Control, int, bool> DescMatcher(string targetDesc, int depth = 2, bool exact = false)
        {
            targetDesc = targetDesc.ToLowerInvariant();
            return (control, currentDepth) =>
            {
                if (currentDepth != depth) return false;
                string fullDesc = control.GetPropertyValue(30159).ToLowerInvariant();
                return exact ? targetDesc == fullDesc : fullDesc.Contains(targetDesc);
            };
        }

        public static Func<Control, int, bool> ClassNameMatcher(string className, int depth = 1, bool exact = false)
        {
            className = className.ToLowerInvariant();
            return (control, currentDepth) =>
            {
                if (currentDepth != depth) return false;
                string currClassName = control.ClassName.ToLowerInvariant();
                return exact ? className == currClassName : currClassName.Contains(className);
            };
        }
    }

    // 假设 Control 是 UI 自动化控件基类，需根据你实际UI框架调整
    public class Control
    {
        public string ClassName { get; set; }
        public string Name { get; set; }
        public bool Exists(double timeoutSeconds) => throw new NotImplementedException();
        public void Click(bool simulateMove = false) => throw new NotImplementedException();
        public string GetPropertyValue(int propId) => throw new NotImplementedException();
        public Control GetParentControl() => throw new NotImplementedException();
        public Control GetSiblingControl(Func<Control, bool> predicate) => throw new NotImplementedException();
        public Control TextControl(int searchDepth = 1, Func<Control, int, bool> compare = null) => throw new NotImplementedException();
        public Control GroupControl(int searchDepth = 1, Func<Control, int, bool> compare = null) => throw new NotImplementedException();
        public Control WindowControl(int searchDepth = 1, string name = null) => throw new NotImplementedException();
        public void SetTopmost(bool topmost) => throw new NotImplementedException();
        public void SetActive() => throw new NotImplementedException();
    }

    public class JianyingController
    {
        private Control app;
        private string appStatus; // "home", "edit", "pre_export"

        public JianyingController()
        {
            GetWindow();
        }

        public void ExportDraft(string draftName, string outputPath = null,
            ExportResolution? resolution = null, ExportFramerate? framerate = null, double timeout = 1200)
        {
            Console.WriteLine($"开始导出 {draftName} 至 {outputPath}");
            GetWindow();
            SwitchToHome();

            var draftNameText = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher($"HomePageDraftTitle:{draftName}", exact: true));
            if (!draftNameText.Exists(0))
                throw new Exception($"未找到名为{draftName}的剪映草稿");  // DraftNotFound 可自定义异常

            var draftBtn = draftNameText.GetParentControl();
            if (draftBtn == null) throw new Exception("草稿按钮不存在");
            draftBtn.Click(false);
            Thread.Sleep(10000);
            GetWindow();

            var exportBtn = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("MainWindowTitleBarExportBtn"));
            if (!exportBtn.Exists(0))
                throw new Exception("未在编辑窗口中找到导出按钮");  // AutomationError
            exportBtn.Click(false);
            Thread.Sleep(10000);
            GetWindow();

            var exportPathSib = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("ExportPath"));
            if (!exportPathSib.Exists(0))
                throw new Exception("未找到导出路径框");

            var exportPathText = exportPathSib.GetSiblingControl(ctrl => true);
            if (exportPathText == null)
                throw new Exception("导出路径文本控件未找到");
            string exportPath = exportPathText.GetPropertyValue(30159);

            if (resolution.HasValue)
            {
                var settingGroup = app.GroupControl(searchDepth: 1, compare: ControlFinder.ClassNameMatcher("PanelSettingsGroup_QMLTYPE"));
                if (!settingGroup.Exists(0))
                    throw new Exception("未找到导出设置组");
                var resolutionBtn = settingGroup.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("ExportSharpnessInput"));
                if (!resolutionBtn.Exists(0.5))
                    throw new Exception("未找到导出分辨率下拉框");
                resolutionBtn.Click(false);
                Thread.Sleep(500);
                var resolutionItem = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher(resolution.Value.GetValue()));
                if (!resolutionItem.Exists(0.5))
                    throw new Exception($"未找到{resolution.Value.GetValue()}分辨率选项");
                resolutionItem.Click(false);
                Thread.Sleep(500);
            }

            if (framerate.HasValue)
            {
                var settingGroup = app.GroupControl(searchDepth: 1, compare: ControlFinder.ClassNameMatcher("PanelSettingsGroup_QMLTYPE"));
                if (!settingGroup.Exists(0))
                    throw new Exception("未找到导出设置组");
                var framerateBtn = settingGroup.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("FrameRateInput"));
                if (!framerateBtn.Exists(0.5))
                    throw new Exception("未找到导出帧率下拉框");
                framerateBtn.Click(false);
                Thread.Sleep(500);
                var framerateItem = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher(framerate.Value.GetValue()));
                if (!framerateItem.Exists(0.5))
                    throw new Exception($"未找到{framerate.Value.GetValue()}帧率选项");
                framerateItem.Click(false);
                Thread.Sleep(500);
            }

            var exportOkBtn = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("ExportOkBtn", exact: true));
            if (!exportOkBtn.Exists(0))
                throw new Exception("未在导出窗口中找到导出按钮");
            exportOkBtn.Click(false);
            Thread.Sleep(5000);

            var startTime = DateTime.Now;
            while (true)
            {
                GetWindow();
                if (appStatus != "pre_export")
                    continue;

                var succeedCloseBtn = app.TextControl(searchDepth: 2, compare: ControlFinder.DescMatcher("ExportSucceedCloseBtn"));
                if (succeedCloseBtn.Exists(0))
                {
                    succeedCloseBtn.Click(false);
                    break;
                }

                if ((DateTime.Now - startTime).TotalSeconds > timeout)
                    throw new Exception($"导出超时, 时限为{timeout}秒");

                Thread.Sleep(1000);
            }
            Thread.Sleep(2000);

            GetWindow();
            SwitchToHome();
            Thread.Sleep(2000);

            if (!string.IsNullOrEmpty(outputPath))
            {
                File.Move(exportPath, outputPath);
            }

            Console.WriteLine($"导出 {draftName} 至 {outputPath} 完成");
        }

        public void SwitchToHome()
        {
            if (appStatus == "home")
                return;
            if (appStatus != "edit")
                throw new Exception("仅支持从编辑模式切换到主页");
            var closeBtn = app.GroupControl(searchDepth: 1, compare: (c, depth) => c.ClassName == "TitleBarButton").GetSiblingControl(c => true); // foundIndex=3的概念根据实际UI实现调整
            closeBtn.Click(false);
            Thread.Sleep(2000);
            GetWindow();
        }

        public void GetWindow()
        {
            if (app != null && app.Exists(0))
                app.SetTopmost(false);

            // 假设这里实现查找主窗口
            app = new Control(); // 你需要替换成真正的窗口查找代码，带上 Compare 比较器

            if (!app.Exists(0))
                throw new Exception("剪映窗口未找到");

            var exportWindow = app.WindowControl(searchDepth: 1, name: "导出");
            if (exportWindow.Exists(0))
            {
                app = exportWindow;
                appStatus = "pre_export";
            }
            else
            {
                // 这里根据窗体ClassName判断状态，伪代码如下
                if (app.Name != "剪映专业版")
                {
                    throw new Exception("不是剪映专业版窗口");
                }
                if (app.ClassName.ToLower().Contains("homepage"))
                    appStatus = "home";
                else if (app.ClassName.ToLower().Contains("mainwindow"))
                    appStatus = "edit";
                else
                    appStatus = "";
            }

            app.SetActive();
            app.SetTopmost(true);
        }
    }
}
