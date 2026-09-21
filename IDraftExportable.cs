using System.Collections.Generic;

namespace JyDraft
{
    /// <summary>
    /// 能把自己导出成剪映草稿 JSON 片段的对象。
    /// 有了它，素材池里那些「可能是滤镜、也可能是文本气泡」的异构列表
    /// （原 <c>List&lt;object&gt;</c>）就有了统一且类型安全的写法。
    /// </summary>
    public interface IDraftExportable
    {
        Dictionary<string, object> ExportJson();
    }
}
