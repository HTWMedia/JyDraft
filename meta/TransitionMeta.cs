using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    /// <summary>
    /// 转场元数据
    /// </summary>
    public class TransitionMeta
    {
        /// <summary>转场名称</summary>
        public string Name { get; set; }

        /// <summary>是否为VIP特权</summary>
        public bool IsVip { get; set; }

        /// <summary>资源ID</summary>
        public string ResourceId { get; set; }

        /// <summary>效果ID</summary>
        public string EffectId { get; set; }

        /// <summary>MD5</summary>
        public string Md5 { get; set; }

        /// <summary>默认持续时间（单位：微秒）</summary>
        public int DefaultDuration { get; set; }

        /// <summary>是否允许重叠</summary>
        public bool IsOverlap { get; set; }

        /// <summary>
        /// 构造转场元数据
        /// </summary>
        public TransitionMeta(string name, bool isVip, string resourceId, string effectId, string md5, double defaultDurationSeconds, bool isOverlap)
        {
            Name = name;
            IsVip = isVip;
            ResourceId = resourceId;
            EffectId = effectId;
            Md5 = md5;
            DefaultDuration = (int)Math.Round(defaultDurationSeconds * 1e6);
            IsOverlap = isOverlap;
        }
    }

    /// <summary>
    /// 转场类型
    /// </summary>
    public static class TransitionType // 原Effect_enum结构不明，采用静态类和静态只读对象
    {
        /// <summary>3D空间，默认时长: 1.50s</summary>
        public static readonly TransitionMeta _3D空间 = new TransitionMeta("3D空间", false, "7049979667406656014", "1506926", "aaecc038f6543411f601608fc5539f0b", 1.5, true);

        /// <summary>上移，默认时长: 0.50s</summary>
        public static readonly TransitionMeta 上移 = new TransitionMeta("上移", false, "6724846395116753416", "2917279", "df9bc16697464de201a4924de49234a2", 0.5, true);

        /// <summary>下移，默认时长: 0.50s</summary>
        public static readonly TransitionMeta 下移 = new TransitionMeta("下移", false, "6724849276100284942", "2917280", "9c042543d4846e7c17e8f950ce6f91c2", 0.5, true);

        /// <summary>中心旋转，默认时长: 0.50s</summary>
        public static readonly TransitionMeta 中心旋转 = new TransitionMeta("中心旋转", false, "6858191434294497805", "878914", "b43f5b2e59f966a3b110222773c2942d", 0.5, false);

        /// <summary>云朵，默认时长: 0.50s</summary>
        public static readonly TransitionMeta 云朵 = new TransitionMeta("云朵", false, "6955722927161479694", "2912469", "283bb4bbe729f19f933cb705024a0983", 0.5, true);

        public static readonly TransitionMeta 倒影 = new TransitionMeta("倒影", false, "6748313807031898627", "369691", "0ee10b771dc0443c41a90bb9fd6b3c25", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 冰雪结晶 = new TransitionMeta("冰雪结晶", false, "6919369228701143559", "1017910", "a0fd9d6eb0cb5596cac4f54d0ba59eaf", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 冲鸭 = new TransitionMeta("冲鸭", false, "7030714241359286821", "1441672", "784b284f040f61ae95f4e8e660f3a873", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 分割 = new TransitionMeta("分割", false, "6968372308419285540", "4211683", "ca45695f29bacf2dc29a6eb959e9e968", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 分割_II = new TransitionMeta("分割 II", false, "6969782622868214302", "4211740", "5ba1cb89bcf4a0898f86494864348e13", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 分割_III = new TransitionMeta("分割 III", false, "6969793843403166215", "4211739", "942fd71d67ca576384b2cd068157ca45", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 分割_IV = new TransitionMeta("分割 IV", false, "6969793934356648455", "4211738", "62d08c08542fe62e6a8429f9501e76fa", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 前后对比_II = new TransitionMeta("前后对比 II", false, "7299290706277831218", "28895844", "64e8f4a060901fd4349301f97fbdd172", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 动漫云朵 = new TransitionMeta("动漫云朵", false, "6777178865119793678", "2911876", "e835cbc7fa7b15af90a2a7090bbf68c3", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 动漫漩涡 = new TransitionMeta("动漫漩涡", false, "6858191448827761160", "878913", "fa7ba99b13036c0ff167ea3b7d5c31a2", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 动漫火焰 = new TransitionMeta("动漫火焰", false, "6777178765643485709", "2911875", "8e7c247c5ebd58aa5c3582273e9c840b", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 动漫闪电 = new TransitionMeta("动漫闪电", false, "6777178696609436174", "2911874", "3fd5d0c7c48668ba5305c57ac0b5d596", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 压缩 = new TransitionMeta("压缩", false, "6751618376780485133", "4212466", "337d4cd9be4e1860bd1e7e50a9a93841", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 叠加 = new TransitionMeta("叠加", false, "6914112332205396488", "1003369", "4f7e4bd421e382860b49e3e34eb4e4aa", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 叠化 = new TransitionMeta("叠化", false, "6724845717472416269", "322577", "2d641adc4bb63e37e3a0067d8c8cc3c3", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 右移 = new TransitionMeta("右移", false, "6726711296063967748", "2917287", "4cfd965c25e33c7df9b2c1b3b4cbdf31", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 向上 = new TransitionMeta("向上", false, "6724227090872275463", "359459", "349746a951e130fe896415f51c9eb36a", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 向上擦除 = new TransitionMeta("向上擦除", false, "6724849456891564557", "2917281", "9a2e4ebf7309c80be332e3c62594dcd6", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向下 = new TransitionMeta("向下", false, "6724227330190873100", "359449", "9c263958ef3b5762db6ffd94a665f9e8", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 向下擦除 = new TransitionMeta("向下擦除", false, "6724849752921346573", "2917282", "ce1fb8739d1fbff3d86498fc18321933", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向下流动 = new TransitionMeta("向下流动", false, "6858191469807669773", "878912", "45f28ed2995ca15cfe027784b55d34f2", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向右 = new TransitionMeta("向右", false, "6724227599616184836", "359527", "55af58a9b04ff458c3a9ae3ddb358152", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 向右上 = new TransitionMeta("向右上", false, "6724227870559834635", "359567", "19d72649fe9bc3b272e1d874a93a0e9b", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向右下 = new TransitionMeta("向右下", false, "6724228621742903815", "359537", "4291e21aefc6d87a232441d38cabacc5", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向右拉伸 = new TransitionMeta("向右拉伸", false, "6987299127025472031", "4211782", "6c3d17aa182e6238ee3a48c2fdf4a627", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向右擦除 = new TransitionMeta("向右擦除", false, "6724849898857959950", "2917284", "a10153bd2b569c49ddd7c055e8c9eba9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向右流动 = new TransitionMeta("向右流动", false, "6858191483573375495", "878911", "8d3508f6e570dc73d3e771d234796cb8", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左 = new TransitionMeta("向左", false, "6724227717195108867", "359529", "323fadc45da03741e6b393b3e3b34e75", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左上 = new TransitionMeta("向左上", false, "6724230442679013902", "359533", "4ed73d43829eb496f6885ac0b882a391", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左下 = new TransitionMeta("向左下", false, "6724230577211314695", "359535", "c76650d4ea9bc4e3b0530c9b9f05f28e", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左拉伸 = new TransitionMeta("向左拉伸", false, "6987201429622493732", "4211781", "b0dd96c3c203104a2df46d83dd91b7bd", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左擦除 = new TransitionMeta("向左擦除", false, "6724849999336706573", "2917283", "316c2a1c1783f51505c793b13381b445", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 吸入 = new TransitionMeta("吸入", false, "7246288124110705209", "15653345", "fb75bf696e19a04795ae9a06b43a09f2", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 回忆下滑 = new TransitionMeta("回忆下滑", false, "7309840407406318117", "33106283", "7e8f1b10bb9979d7ed184d29f301b93d", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 圆形分割_II = new TransitionMeta("圆形分割 II", false, "7317206886053319194", "37127313", "05017adee9a3798b4fb207bb3206187e", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 圆形扫描 = new TransitionMeta("圆形扫描", false, "6851775006418932238", "813992", "0260ab98d7a840c3344cb5b3e70b7d4b", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 圆形遮罩 = new TransitionMeta("圆形遮罩", false, "6725767129519362573", "2916676", "a7eb1d47f97049b17f49669622d07f3d", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 圆形遮罩_II = new TransitionMeta("圆形遮罩 II", false, "6724850215364334083", "2916675", "2772ad7c8c7e30c6421be7c2e5dd3f15", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 复古放映 = new TransitionMeta("复古放映", false, "7237068402945167909", "14192091", "44c3d405f4961d843c74c69e241df643", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 岁月的痕迹 = new TransitionMeta("岁月的痕迹", false, "6982750240663147044", "1185194", "0b228af1ebde4909bb6ff545ddd89023", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 左下角_II = new TransitionMeta("左下角 II", false, "7304868316252738098", "30874190", "e0296196f0ec6666a33b33fead4f63d6", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 左移 = new TransitionMeta("左移", false, "6726711499676455435", "2917286", "9562c0ea301229d43f9dca6f6590f306", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 开幕 = new TransitionMeta("开幕", false, "6750893890712113677", "391781", "d5f097e701ddaa984a590249896fc51a", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 弹幕转场 = new TransitionMeta("弹幕转场", false, "7028877116259176974", "1433950", "7b5385070a42a218f194d9daddb59f32", 4.000000, false);
        //默认时长: 4.00s//
        public static readonly TransitionMeta 弹跳 = new TransitionMeta("弹跳", false, "6747865141120864779", "368205", "4b3b8b53bc1f947d57a30489d81387eb", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 打板转场_I = new TransitionMeta("打板转场 I", false, "7028143517570437668", "1432322", "355d5c4df581f6c4940c9b999e010f81", 4.000000, false);
        //默认时长: 4.00s//
        public static readonly TransitionMeta 打板转场_II = new TransitionMeta("打板转场 II", false, "7029592645538157086", "1437264", "021dfc9a6541d8d08bac631749f9e87d", 4.000000, false);
        //默认时长: 4.00s//
        public static readonly TransitionMeta 抖动 = new TransitionMeta("抖动", false, "7252544245444121148", "17223925", "a1b79bbc99afca7c9e5372cd050ad61d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 抖动_II = new TransitionMeta("抖动 II", false, "7252544309830881851", "17223924", "37319b02a398332e7159f323ea93ba88", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 抠像旋转 = new TransitionMeta("抠像旋转", false, "7386584387128660506", "73423370", "290a8f067f8039b1060df3d1e8d07ca0", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 拉伸 = new TransitionMeta("拉伸", false, "7231391397717217851", "13402655", "4fd21b4a2e6382ee8851c51c8f65ed73", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 拉伸_II = new TransitionMeta("拉伸 II", false, "7259735372039459389", "19137130", "d28fee612c51edf28da804983d220f8d", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 拉远 = new TransitionMeta("拉远", false, "6724226338418332167", "359365", "9661d5321722495c0a98959a0d617b0f", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 拍摄器 = new TransitionMeta("拍摄器", false, "7100849808784495135", "2057168", "b64bebe75d492161875d4fd54725b31d", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 推近 = new TransitionMeta("推近", false, "6724226861666144779", "359359", "4d5a316f2eae582e7d0604b47feb8c32", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 撕纸拉屏 = new TransitionMeta("撕纸拉屏", false, "7254847807465460280", "17934952", "c500d2310388b63f3a4e66ff0b15f6dc", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 放射 = new TransitionMeta("放射", false, "6724239584663704071", "4212630", "06cc8d49c558d57e21207f68a6a7dbc0", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 故障 = new TransitionMeta("故障", false, "6725771847444468236", "2918080", "7bec08ae5dae8806e3ba0c66622d0fd3", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 斜向分割 = new TransitionMeta("斜向分割", false, "7085250093527339557", "4211687", "6ae9eb3ee4b08afa67e3d079a2ece505", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 星星 = new TransitionMeta("星星", false, "6751564373317128708", "2916678", "5ad3a484b1784e3f5391bf3fa7b188f4", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 星星_II = new TransitionMeta("星星 II", false, "6789847494898487822", "2916679", "16a4697aef243c1524e9581fb2f038c9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 模糊 = new TransitionMeta("模糊", false, "6911569618171597320", "4212596", "fc1352435f88c6f284b6c6dce8552ffe", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 横向分割 = new TransitionMeta("横向分割", false, "7083771238564237861", "4211685", "aa0aa4a72fc236611d3fd4bf75a12ca3", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 横向拉幕 = new TransitionMeta("横向拉幕", false, "6724492948144132621", "2917278", "de63aa2d5225bb6a65b5bab8702aa1f5", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 横线 = new TransitionMeta("横线", false, "6724845810892149251", "2918076", "36c1c8edb0171ea082c98d38ffa8bd36", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 气泡转场 = new TransitionMeta("气泡转场", false, "7028880945671311903", "1433968", "66489506132d1314f3c7264bcd947cad", 4.000000, false);
        //默认时长: 4.00s//
        public static readonly TransitionMeta 水波卷动 = new TransitionMeta("水波卷动", false, "6858191497280360973", "878910", "cf9bac91349a227a6155eca9d94a8af8", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 水波向右 = new TransitionMeta("水波向右", false, "6858191510865711629", "878909", "e9301bacebc6dc444aa4e6f835dd4a31", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 水波向左 = new TransitionMeta("水波向左", false, "6858191524312650248", "878908", "6b6499879310b6d29e9595799829cb15", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 泛光 = new TransitionMeta("泛光", false, "6914112263645303303", "4202527", "c978e2e22e9a9768813f5fd8d486b792", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 泛白 = new TransitionMeta("泛白", false, "6949828109663212045", "4202528", "1bf6b83628ff6416a4d87865107b739e", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 波点向右 = new TransitionMeta("波点向右", false, "6858191541706428941", "878907", "74c13e6250cdff7a4e860625d1098e0c", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 渐变擦除 = new TransitionMeta("渐变擦除", false, "6919369138800431629", "1017911", "2fff9b60c929559bce574ab8ef2c14a7", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 滑动 = new TransitionMeta("滑动", false, "6757982416649851399", "4212349", "b99916e2936aeb2e56892ca617888694", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 漩涡 = new TransitionMeta("漩涡", false, "6851810799510360583", "4211780", "31d2de43e6711a9eeb831d60529d0393", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 爱心 = new TransitionMeta("爱心", false, "6748289440130535947", "2916677", "2382e2096918b63a0f8e75f720d7d892", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 爱心_II = new TransitionMeta("爱心 II", false, "6789846472343949837", "2916682", "0c04684566638932cb6f6d86cdfabda6", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 爱心上升 = new TransitionMeta("爱心上升", false, "6789846246069637640", "2916681", "2a3c5439ce79e6113843a2b7135bd21a", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 电视故障_I = new TransitionMeta("电视故障 I", false, "7046293801123451405", "2918081", "feaf2e85b909a123ea71728f9b61fb03", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 电视故障_II = new TransitionMeta("电视故障 II", false, "7042278078415901192", "2918082", "a082bdaea1122bbf1aba730278d50250", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 画笔擦除 = new TransitionMeta("画笔擦除", false, "6789846828788486664", "2912467", "4fafb5343d5c9e726278e90b5e0c1c93", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 白光快闪 = new TransitionMeta("白光快闪", false, "7343136487182963211", "49272367", "c1f7073a94d22565ace1ab3023d1c154", 0.400000, true);
        //默认时长: 0.40s//
        public static readonly TransitionMeta 白色墨花 = new TransitionMeta("白色墨花", false, "6858191556055142919", "878906", "775ccf71576e2b8fb075f0e61e980923", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 白色烟雾 = new TransitionMeta("白色烟雾", false, "6885646856672514567", "947664", "9b679b32ec03c42932fa37b10c141bda", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 百叶窗 = new TransitionMeta("百叶窗", false, "6789847331060584974", "521326", "9f37c3f6f5e84b37b3a0560803a16c30", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 眨眼 = new TransitionMeta("眨眼", false, "6864867302936941064", "2917719", "bf695506c8091f7a01ee7b1323a4d601", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 矩形分割 = new TransitionMeta("矩形分割", false, "6858191571196580359", "878905", "82d6235324f8c5f830f8ccf7b1cc036b", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 窗格 = new TransitionMeta("窗格", false, "6747989545448378888", "368721", "cd6a7ff53319efa1c57690f61c8737a0", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 立方体 = new TransitionMeta("立方体", false, "6785042367498949127", "519784", "be45578bb628a21eaae268a8d8df868f", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 竖向分割 = new TransitionMeta("竖向分割", false, "7083771107706147364", "4211686", "7cc017d4e1b6ab58ec4b6900432522ff", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 竖向拉幕 = new TransitionMeta("竖向拉幕", false, "6726711903684399619", "2917285", "84f91be5a43cc6a9d03505a465418206", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 竖向模糊 = new TransitionMeta("竖向模糊", false, "7125661387568714247", "3796327", "cda4099e3f207ef1509f27d0b1ab01c1", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 竖向模糊_II = new TransitionMeta("竖向模糊 II", false, "7280837008421818936", "23404229", "85e381982a94778e003f3acc9527d5cf", 0.660000, true);
        //默认时长: 0.66s//
        public static readonly TransitionMeta 竖线 = new TransitionMeta("竖线", false, "6724846536041173511", "2918077", "75019c1486b2366675d95602f58430e2", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 箭头向右 = new TransitionMeta("箭头向右", false, "6858191587554365966", "878904", "fa0cfb9e822393af86c6df4a8477cd63", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 粒子 = new TransitionMeta("粒子", false, "6855565313715474952", "4212632", "389d08f0700dd3e646a1e92289d84d58", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 翻篇 = new TransitionMeta("翻篇", false, "7034446419641504264", "4212350", "e3a2c5e0bd63416b5f64e489beb8a702", 1.300000, true);
        //默认时长: 1.30s//
        public static readonly TransitionMeta 翻页 = new TransitionMeta("翻页", false, "6747979085894390279", "368701", "413b2cafe7a0c6309286845c559b3066", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 色差逆时针 = new TransitionMeta("色差逆时针", false, "6940500629013926413", "1069274", "b235f0bc4c9eb6e090358c09c7b0ffb0", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 色差顺时针 = new TransitionMeta("色差顺时针", false, "6940520116035523080", "1069374", "8661a7a8b19762d35506cd6513d8ed3e", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 色彩溶解 = new TransitionMeta("色彩溶解", false, "6724846004274729480", "322583", "b5f962a334dcc141bbc3dae0f5777564", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 色彩溶解_II = new TransitionMeta("色彩溶解 II", false, "6724866927933526542", "322625", "8179e342f9b24dd1817c56f7ef1f8f9b", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 色彩溶解_III = new TransitionMeta("色彩溶解 III", false, "6724867032312975875", "322627", "293a03bd140d09b0c616f879bda235e1", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 蓝色线条 = new TransitionMeta("蓝色线条", false, "6858191605384352263", "878903", "d4d2996c3f6cf97fb8602f825d98a4da", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 逆时针旋转 = new TransitionMeta("逆时针旋转", false, "6724226603372515853", "359437", "048170ae8df06f9d6964691b1e472c6a", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 逆时针旋转_II = new TransitionMeta("逆时针旋转 II", false, "7252544659245765179", "17224251", "1b2c634ea54e81de34cb6d31848908af", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 镜像翻转 = new TransitionMeta("镜像翻转", false, "6848792278710882824", "2917288", "1109c08965141f90b9174c38e85c8cab", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 闪白 = new TransitionMeta("闪白", false, "6724845376098013708", "322575", "b033ea56618d5b0f098071fb326bb02a", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 闪白_II = new TransitionMeta("闪白 II", false, "7306818286413419017", "31619869", "9a1089fc9fefe2a79a71c37c1bc5831a", 0.300000, true);
        //默认时长: 0.30s//
        public static readonly TransitionMeta 闪黑 = new TransitionMeta("闪黑", false, "6724239388189921806", "321493", "3bca53e9f3dfa2c184fbee96438ea097", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 雪花故障 = new TransitionMeta("雪花故障", false, "6724866446842663431", "2918079", "71cabe836d9c88afd44f43654ba67fa7", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 雾化 = new TransitionMeta("雾化", false, "7216171159589491259", "11387229", "945e1560e2c65277b4bd4127cd479746", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 震动 = new TransitionMeta("震动", false, "7198100561235808825", "9261771", "e46204ca1e4fcf76d1b1c86e852e862d", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 顺时针旋转 = new TransitionMeta("顺时针旋转", false, "6724226684721041932", "359421", "d6d0c76fb82ca2a355de138d94a94780", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 顺时针旋转_II = new TransitionMeta("顺时针旋转 II", false, "7252544556799889975", "17224317", "5e81c58bf217a2bdaf479275e412ea93", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 频闪 = new TransitionMeta("频闪", false, "7083767957662208549", "1674710", "35a76b77dd0812f7012911109db35799", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 风车 = new TransitionMeta("风车", false, "6748286529921094157", "369485", "367b8b51b2eeb63eb2009bf5b356bc2f", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 马赛克 = new TransitionMeta("马赛克", false, "6724866519022440967", "4212631", "eed93b26d9cd6296b10d2f5065ee396e", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 黑色块 = new TransitionMeta("黑色块", false, "6724866346569437710", "2918078", "357e865f3bb0c6529ee882ebf279d7c6", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 黑色烟雾 = new TransitionMeta("黑色烟雾", false, "6885647017452769805", "947663", "fa02f80c28a9671a206c2ccf17b41c58", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 万花筒 = new TransitionMeta("万花筒", true, "7257806429086552632", "18722268", "0aa1d28fdb90725586089436e6ccd243", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 三屏放大 = new TransitionMeta("三屏放大", true, "7320254175466492467", "38586528", "b59a3df958aeeba78f1ceb075be189f0", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 三屏滑入 = new TransitionMeta("三屏滑入", true, "7312438185261273650", "34443818", "09dc4fee56acca3e6f1c104277b8695d", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 三屏闪切 = new TransitionMeta("三屏闪切", true, "7252599996254523959", "17242682", "2bc234d945f15d93f3d292e64042d69d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 下滑 = new TransitionMeta("下滑", true, "7309694074015977993", "32998125", "9c54ccb7b27ab98f7c3bb03a5d4acc4b", 0.550000, true);
        //默认时长: 0.55s//
        public static readonly TransitionMeta 云朵_II = new TransitionMeta("云朵 II", true, "6955760408737092132", "2912470", "5a8914a3658f88265bbeda060a7c79aa", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 亮点模糊 = new TransitionMeta("亮点模糊", true, "7123135366504124936", "3705757", "b48f47c097e83842d1c0f919d9c67af6", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 便利贴 = new TransitionMeta("便利贴", true, "7302023728441856549", "29871972", "a5a04de1e339c4d4907e26ff6b229563", 1.100000, true);
        //默认时长: 1.10s//
        public static readonly TransitionMeta 信号故障 = new TransitionMeta("信号故障", true, "7288149307197231676", "25265947", "f23f60f3bee4fac6368268a1406ccaf7", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 信号故障_II = new TransitionMeta("信号故障 II", true, "7342791345162949183", "49094731", "b5537d48d5d72d9707bb4641d51ecc73", 0.670000, false);
        //默认时长: 0.67s//
        public static readonly TransitionMeta 倾斜拉伸 = new TransitionMeta("倾斜拉伸", true, "7383960886131560960", "72481265", "c87e594192131b1b82e1c34cd383f807", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 倾斜模糊 = new TransitionMeta("倾斜模糊", true, "7355762441533264394", "56268173", "0b88f86366c21c3ebd2bcc8df140810d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 像素冲屏 = new TransitionMeta("像素冲屏", true, "6981689835534684702", "1182216", "b7f8e6cd03560d1f52e1270dcf7c9ba4", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 光束 = new TransitionMeta("光束", true, "6982127832042312206", "4202531", "84525ee78728b5cce44c8404d9f50b0d", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 全息投影 = new TransitionMeta("全息投影", true, "7298230450768581129", "28518430", "95a2a049736e0843b5984e0090276f7b", 0.400000, true);
        //默认时长: 0.40s//
        public static readonly TransitionMeta 六边形变焦 = new TransitionMeta("六边形变焦", true, "7182413216276812346", "7824963", "faf521d87b90c79031bfd08d687df52a", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 冲屏扭曲 = new TransitionMeta("冲屏扭曲", true, "7359133728313971227", "58099421", "2fb5734ab118c745bfa0596264533e54", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 几何分割 = new TransitionMeta("几何分割", true, "7130139199394550303", "3985085", "4f6209fcc7e8746a7c1e43d8a1704827", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 分屏下滑 = new TransitionMeta("分屏下滑", true, "7337974537683735080", "46873416", "eb4e4368773f40a8c807e77497acab4f", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 前后对比 = new TransitionMeta("前后对比", true, "7205856572994490935", "10139297", "f38bc39938f58a4ee3f9c7bfcf4f524f", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 剧烈摇晃 = new TransitionMeta("剧烈摇晃", true, "7367356130307084838", "63047898", "4ffdc4b55688e65262a229d5e7b987ca", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 卡片弹出 = new TransitionMeta("卡片弹出", true, "7384334283659285032", "72605929", "67660fa9cdb387454a59d3a747cff6ef", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 可爱爆炸 = new TransitionMeta("可爱爆炸", true, "7187674415268631101", "8375167", "75942cf09b7e84526a357898a47c18bb", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 吃掉 = new TransitionMeta("吃掉", true, "7372506069328728585", "66629623", "64b8f472cc109cccd9c50e210331af43", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 后台切换 = new TransitionMeta("后台切换", true, "7320129407799005734", "38530921", "c5092413343f5e808ffc27ab8b02e7c4", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 向上波动 = new TransitionMeta("向上波动", true, "7148734739807998495", "4861515", "69a520845b900b142b203cf2e677abd5", 5.000000, true);
        //默认时长: 5.00s//
        public static readonly TransitionMeta 向下抖动 = new TransitionMeta("向下抖动", true, "7338709911791997480", "47241669", "1a44879e265bc89746e30f59d2ff0245", 1.300000, true);
        //默认时长: 1.30s//
        public static readonly TransitionMeta 向下拖拽 = new TransitionMeta("向下拖拽", true, "7199528468244075067", "9382531", "f1d490e1e2a87013bee63a8aa4191f9f", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 向左拉屏 = new TransitionMeta("向左拉屏", true, "7089311972235153950", "1722934", "21538bc8fa278603f8e944fc405a65c9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 向左波动 = new TransitionMeta("向左波动", true, "7126772940451877406", "3971081", "cbffe80a580575becb3beb3bcbd5cc09", 5.000000, true);
        //默认时长: 5.00s//
        public static readonly TransitionMeta 喜欢 = new TransitionMeta("喜欢", true, "7070430644563612191", "1600478", "945ee55ddc4b7c9762b55c0ee302bdce", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 四屏转换 = new TransitionMeta("四屏转换", true, "7337612480610308649", "46644610", "e7bd3aacd0daeafdf20d93d4a171a846", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 回忆 = new TransitionMeta("回忆", true, "6748220149284737550", "4211778", "48a73d2ca44a59d8faf88ab0c4bb39f6", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 回忆_II = new TransitionMeta("回忆 II", true, "6748220462746046989", "4211779", "bfb17d87ed3db6332a6e0855299809d9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 回忆拉屏 = new TransitionMeta("回忆拉屏", true, "7184682990901924410", "8027945", "3bc26bcea93ea43b349c60c28bea394f", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 回忆拉屏_II = new TransitionMeta("回忆拉屏 II", true, "7306440470119322139", "31456359", "2464d4afc9c5f43072935915c6a86c29", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 圆形分割 = new TransitionMeta("圆形分割", true, "7083435788322476581", "4211684", "2bb3ad90a4eb3a2563b87c300e0ae8a1", 1.500000, false);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 圣诞树 = new TransitionMeta("圣诞树", true, "7302357935902954035", "29976594", "8c40262df8758d19446264aa5749008a", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 复古叠影 = new TransitionMeta("复古叠影", true, "7200638304591548985", "9529419", "078be6db2b8d8abded47cbd72f5635df", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 复古放映_II = new TransitionMeta("复古放映 II", true, "7240050497804046908", "14607947", "9891a08898646c3795cab650979bf0dc", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 复古漏光 = new TransitionMeta("复古漏光", true, "7181752495150993957", "8104139", "0af78adb0da721bbe253b096b8152851", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 复古漏光_II = new TransitionMeta("复古漏光 II", true, "7287881053534949943", "25193261", "1789e06f18340fbcbd30e6757f10ba75", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 复古胶片 = new TransitionMeta("复古胶片", true, "7261814111816651322", "19552395", "c5686c7e832a5e8c178c5cadb42d9ab4", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 多层环形 = new TransitionMeta("多层环形", true, "7373523970538082866", "67116644", "cf6da6be1066054f86c4524fa6494d8e", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 多屏定格 = new TransitionMeta("多屏定格", true, "7287860606395224613", "25184085", "c12aeac3828eb06fd5d0f865ee7041d1", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 大圆盘 = new TransitionMeta("大圆盘", true, "7362104359682839055", "59713023", "9d6a02b47846369cec6d19a35826570d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 射灯 = new TransitionMeta("射灯", true, "7368775489445433883", "63886272", "23706ad60c2258a524da320eca564d12", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 小喇叭 = new TransitionMeta("小喇叭", true, "7070430823597478407", "1600476", "3707101142d3069789f3d821cdb7bc35", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 小恶魔 = new TransitionMeta("小恶魔", true, "7075598043252265509", "1628344", "c9a87dfafa58fbc0d401fc182fbaf6fc", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 幻影 = new TransitionMeta("幻影", true, "7218040359715082809", "11634125", "4a1a61e615eb94e37e2c198dd4602107", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 幻觉 = new TransitionMeta("幻觉", true, "7395044376621093391", "76465118", "cb9796c59a719185df8c9c5d1922b061", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 开心 = new TransitionMeta("开心", true, "7073053544839909919", "1610838", "0d80e7d2b7171236732668e91b849120", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 弹出 = new TransitionMeta("弹出", true, "7394709307842892303", "76381219", "5c7ab5f82d4253e2225b57ba734edd3a", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 弹动发光 = new TransitionMeta("弹动发光", true, "7347897562436735503", "51950360", "31bdfcfe5852df71426d22fc02293698", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 彩色像素 = new TransitionMeta("彩色像素", true, "7096015235953201701", "4212518", "d91c7ef4be8808bddec8a1a119f78da7", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 微抖动 = new TransitionMeta("微抖动", true, "7368739347845091877", "63860874", "9870ae40f2c8a325debc06d25ef46895", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 心形叠化 = new TransitionMeta("心形叠化", true, "7264829174601224764", "20224653", "24559e84f2cfae6bbfd86d47bb8f60f9", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 快速缩放 = new TransitionMeta("快速缩放", true, "7382154814144123392", "71890617", "bbedbf5ac1b865d1e1395d4d402ce5fa", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 快门 = new TransitionMeta("快门", true, "6882983860615778823", "2917720", "2df569fefb5004c041af5509c10d6c53", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 扫光 = new TransitionMeta("扫光", true, "7106765945305043463", "4202535", "333aa7e9d8b24e358ea60784ce47b6fe", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 扭曲溶解 = new TransitionMeta("扭曲溶解", true, "7374259106502152741", "67617874", "756df14869da51538ed41e2bfac3b779", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 扭转弹动 = new TransitionMeta("扭转弹动", true, "7344986966145896994", "50231600", "e5d36f065e3f0e8801c43a625a7d9947", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 抖动放大 = new TransitionMeta("抖动放大", true, "7260415521852494397", "19272888", "e4cafc076ecab223a39a26fe6f05b6db", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 抖动缩小 = new TransitionMeta("抖动缩小", true, "7291972229087105563", "26488746", "6e78a0c97c60562573a30342882a240f", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 抖动缩小__II = new TransitionMeta("抖动缩小  II", true, "7316783851206873651", "36841926", "137d3f03fbd4dddbc6a2a0dd1f371e17", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 抽象前景 = new TransitionMeta("抽象前景", true, "7104215831919202853", "2459634", "88b3ead3e00313684cd868d51c1173c9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 抽象前景_II = new TransitionMeta("抽象前景 II", true, "7108564115529929229", "2870170", "b8628f4b1d6fc27447dfad6a5f25beb4", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 拉开 = new TransitionMeta("拉开", true, "7384323685026370098", "72601002", "828b81127e669508f999900bff18cf2a", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 拉框入屏 = new TransitionMeta("拉框入屏", true, "7297077423487586826", "28115429", "bfc8a51d2b304be3dd36a68331f8d0f8", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 拍摄器_II = new TransitionMeta("拍摄器 II", true, "7109727014780670495", "2958464", "5483f878a302c6d7879bd566cebab543", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 拍摄器_III = new TransitionMeta("拍摄器 III", true, "7107542030976291336", "2792048", "36c9b870a00e16365421398ac4e51652", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 推近_II = new TransitionMeta("推近 II", true, "7290852476259930685", "26135688", "94815943a86e741a5fec1737fbb46d60", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 推远_II = new TransitionMeta("推远 II", true, "7360987817066893862", "59043083", "0a10553e75180add06fd336bf16fa8aa", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 摄像机 = new TransitionMeta("摄像机", true, "7070047850960261668", "1598384", "bb0b9fa428e5a3fde828c03022b5082d", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 摇晃描边 = new TransitionMeta("摇晃描边", true, "7372137986877559335", "66403340", "0a5449cf1ca4c9fb473ff664ea23185b", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 摇晃震动 = new TransitionMeta("摇晃震动", true, "7343618757530489379", "49545855", "c911cc41c158afbd43636d1aa465e1d2", 1.300000, true);
        //默认时长: 1.30s//
        public static readonly TransitionMeta 摇镜 = new TransitionMeta("摇镜", true, "7305969268259033609", "31254345", "f215c106100f76dcf6c550d0f8217ecb", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 撕纸 = new TransitionMeta("撕纸", true, "6875627914444935694", "2912468", "131ae40c737ab9f5c79e35e3639a4bad", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 撕纸掉落 = new TransitionMeta("撕纸掉落", true, "7218114518314914365", "11661051", "42fa2f7a99a392e2801ad5ec5f62d73a", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 收缩抖动 = new TransitionMeta("收缩抖动", true, "7347676775633130024", "51859926", "88939867fef0a71b39f549558d724d31", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 放大左移 = new TransitionMeta("放大左移", true, "7347582471111709236", "51784590", "a2c4ddc0f96c5694e941d738ed52cdf4", 1.300000, true);
        //默认时长: 1.30s//
        public static readonly TransitionMeta 放大镜 = new TransitionMeta("放大镜", true, "7313974602156216858", "35244988", "91aee5fc06c85dda958101a677f19c0b", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 故障模糊 = new TransitionMeta("故障模糊", true, "7302270954602762789", "29927992", "fc3fae70595c7bb6f943aca08dc7b9f1", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 数字矩阵 = new TransitionMeta("数字矩阵", true, "7268870949548593725", "20983534", "f39bf079c6066cbfee7c5eca1491b276", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 斜向模糊 = new TransitionMeta("斜向模糊", true, "7125661284762128910", "3796323", "b14d9650ca6eef79d6b19c16c65166d3", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 斜向闪光 = new TransitionMeta("斜向闪光", true, "7384331194978013711", "72603864", "eba796256a96c4ff0d1b331a8819c6f2", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 斜线翻页 = new TransitionMeta("斜线翻页", true, "7339900424956154403", "47905855", "46d525166125a781ce8cf9c6e6370454", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 新篇章 = new TransitionMeta("新篇章", true, "7174756125902901797", "7089439", "74716b2d52b85799f78903818eb3c98f", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 新篇章_II = new TransitionMeta("新篇章 II", true, "7174754977544409657", "7089435", "6c1c52a50f842600c69417cf38adc113", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 方形分割 = new TransitionMeta("方形分割", true, "7127901205820346917", "3895735", "9f29e50ac72b66f4b0320ee1ea9d112f", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 方形模糊 = new TransitionMeta("方形模糊", true, "7122721406210544164", "3686479", "8e3579bda4787d20d8c8ab1b0c68112d", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 方形模糊_II = new TransitionMeta("方形模糊 II", true, "7384005295770440201", "72501238", "301fe868bf7b1549d6d07af9405beb4a", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 旋焦 = new TransitionMeta("旋焦", true, "7215424325036282428", "11286537", "917c209246e975d4f10d9b8c8c78035f", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 旋转圆球 = new TransitionMeta("旋转圆球", true, "7377722094806635048", "69481298", "34211e59f420adb42bc00b9a8d36bb6a", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 旋转圆盘 = new TransitionMeta("旋转圆盘", true, "7261828356386067005", "19556167", "86ce95075986170812258b247969c972", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 旋转圆盘_II = new TransitionMeta("旋转圆盘 II", true, "7262674749258469949", "19727008", "17d1ac181dd7b623059b8aed82d2ef13", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 旋转快门 = new TransitionMeta("旋转快门", true, "7350577049968316979", "53358879", "f2b536b7d3f17bc58e0e4957f517ece0", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 旋转拨盘 = new TransitionMeta("旋转拨盘", true, "7368844683256009242", "63924504", "88ac2494e5cdec7f874c4157555d2d2b", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 旋转模糊 = new TransitionMeta("旋转模糊", true, "7332480491058106943", "44259414", "1a28e7fbb2a177240786bd945fb9ca7e", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 旋转穿越 = new TransitionMeta("旋转穿越", true, "7343092798993732148", "49228871", "e05493559e59bf7f4c4a9ea5a5d212de", 1.800000, true);
        //默认时长: 1.80s//
        public static readonly TransitionMeta 旋转纵深 = new TransitionMeta("旋转纵深", true, "7368687055225754153", "63822177", "e717dfe6ccb3c6a6c6a6f70987b1a894", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 旋转翻页 = new TransitionMeta("旋转翻页", true, "7320577375752688165", "38717232", "31a897fbdd402adaf84724fb28ef606b", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 旋转震动 = new TransitionMeta("旋转震动", true, "7326861725213397514", "41492871", "70bea2644a8dc8bc2b24102d8fa90ca4", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 无限穿越_I = new TransitionMeta("无限穿越 I", true, "7036984568536109581", "1465694", "3ee3fc9318dc2315d250f0baa1763e5b", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 无限穿越_II = new TransitionMeta("无限穿越 II", true, "7034717113130422791", "1458828", "b87498756c478952cf7c804234f97bbb", 1.600000, true);
        //默认时长: 1.60s//
        public static readonly TransitionMeta 旧胶片 = new TransitionMeta("旧胶片", true, "7099310030138118687", "1933296", "782110cae96a4f9ed73f6a85d0610a7a", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 旧胶片_II = new TransitionMeta("旧胶片 II", true, "7111634884153578014", "3114014", "79901fab61f0b8c2960c73a78e84e5a3", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 时光穿梭 = new TransitionMeta("时光穿梭", true, "7306853312400200229", "31645629", "74eab27c1dc1a568b851a2e543682058", 1.100000, true);
        //默认时长: 1.10s//
        public static readonly TransitionMeta 星光 = new TransitionMeta("星光", true, "7177201869612126777", "7339355", "2215320b9ba4138c53f1f7b9d0c58b54", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 星光叠化 = new TransitionMeta("星光叠化", true, "7321658733497422363", "39173243", "f6d691dd1f991655b2826964c3883772", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 星星_III = new TransitionMeta("星星 III", true, "7293358903176204851", "26885516", "1ece838a7bfd2c8b1b0daf25d5776d22", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 星星吸入 = new TransitionMeta("星星吸入", true, "7312716430875562506", "34540914", "6ce2a58bc6a3df532a3c1ca890c97394", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 星星模糊 = new TransitionMeta("星星模糊", true, "7206157339253019197", "10169537", "28556f2cabd470e0da1a9ddf16d76198", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 春日光斑 = new TransitionMeta("春日光斑", true, "7330599151685603875", "43351778", "5d872c46167c2f25f897ae1fc7625c8d", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 暧昧光晕 = new TransitionMeta("暧昧光晕", true, "7268613185337299513", "20954940", "ab82749d799477631ae63c081ad569d1", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 曝光拉丝 = new TransitionMeta("曝光拉丝", true, "7308617539452408358", "32432969", "56eaaf319007193c199f17554890abb4", 2.000000, true);
        //默认时长: 2.00s//
        public static readonly TransitionMeta 曝光摇镜 = new TransitionMeta("曝光摇镜", true, "7283720497513108025", "24147753", "e0ee1d0a29d1138f7a3b673ffbad91d5", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 未来光谱 = new TransitionMeta("未来光谱", true, "7176890183940313658", "7307905", "7974c984bf60d60079cc03be5928f74d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 未来光谱II = new TransitionMeta("未来光谱II", true, "7176914791267570232", "7312585", "524895c4bce265b44ffa8ac92bf0dd6a", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 条形模糊 = new TransitionMeta("条形模糊", true, "7122387202725646862", "3675841", "0a5742430e336b3a1e1b6ff9983c5d25", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 模糊放大 = new TransitionMeta("模糊放大", true, "7301280654015074842", "29614872", "7c0ef1a54495f7cd9343efe2acc57b26", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 模糊缩小 = new TransitionMeta("模糊缩小", true, "7297133348567126566", "28141206", "742e708ac73c3a335a41133684c488ed", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 横条挤压 = new TransitionMeta("横条挤压", true, "7369507828668568116", "64687184", "6bbc30d59ef4fd16e4ba6656129cfd95", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 横移模糊 = new TransitionMeta("横移模糊", true, "7316901787762430491", "36950128", "aa2ce5c9b13a62881d04f9c23aa30678", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 水墨 = new TransitionMeta("水墨", true, "6789847231873683976", "2912466", "d1dd3dd8905f0b96be756bd34be1a84d", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 水滴 = new TransitionMeta("水滴", true, "7218875183413596730", "11765299", "d5fa6a1daecd2c45b0414626a69e7674", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 水滴_II = new TransitionMeta("水滴 II", true, "7231860840452854332", "13482623", "eebf40246476d57ccbf8bbdf15864864", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 水滴_III = new TransitionMeta("水滴 III", true, "7337571999885038130", "46608908", "32eea5171000b838f2eb74941fb751d7", 1.100000, true);
        //默认时长: 1.10s//
        public static readonly TransitionMeta 汇聚 = new TransitionMeta("汇聚", true, "7308666709932511753", "32470148", "3bb1668888e7e87764d03b15733370fb", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 泡泡模糊 = new TransitionMeta("泡泡模糊", true, "7159097688955294222", "5663559", "10478b300821fa6eccadf67b07b63208", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 波光粼粼 = new TransitionMeta("波光粼粼", true, "7361758664182469157", "59511491", "da913924bc6975821de103b371d540ff", 1.166600, true);
        //默认时长: 1.17s//
        public static readonly TransitionMeta 波动 = new TransitionMeta("波动", true, "7169480114860724773", "6500749", "af314da6343d025cc0f5d668d2fa0a7b", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 波动_II = new TransitionMeta("波动 II", true, "7308652550574576138", "32459394", "dd709d2dd83add664f3cbd45893438f7", 0.400000, true);
        //默认时长: 0.40s//
        public static readonly TransitionMeta 波动故障 = new TransitionMeta("波动故障", true, "7223312837320380983", "12349835", "bd7d819531a9d2b044f823080aa0fc1c", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 流光 = new TransitionMeta("流光", true, "7316789832833831461", "36847370", "686a5ae873f34ac400ee8ad6a8658d68", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 涂鸦放大 = new TransitionMeta("涂鸦放大", true, "7239925851335168569", "14573363", "2a29109cf3c013e6f7770a28cba4154a", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 溶解推进 = new TransitionMeta("溶解推进", true, "7348406367394206271", "52246665", "e6c9fda251c612d8cdf69ddef055e410", 0.806000, true);
        //默认时长: 0.81s//
        public static readonly TransitionMeta 滑动弹出 = new TransitionMeta("滑动弹出", true, "7343237606043292200", "49343171", "bb190e71a692bc20d9060b22b4311896", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 滑动放大 = new TransitionMeta("滑动放大", true, "7327132595190239759", "41576555", "a746b6b7c2e83275d90864d0b28173aa", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 滑块拼贴 = new TransitionMeta("滑块拼贴", true, "7239990715307004477", "14594823", "c8552ba32a7e8804013a8a1b977e23c1", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 漩涡扭曲 = new TransitionMeta("漩涡扭曲", true, "7308653984888132123", "32460372", "fedeb478c6e4d39282dfe1ad13ee653a", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 炫光 = new TransitionMeta("炫光", true, "6726707814028284423", "4202524", "a3fd6266c293496fd9480884a93fb90e", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 炫光_II = new TransitionMeta("炫光 II", true, "6950255790762496548", "4202530", "aafb556352016d087cddd1939ada20f8", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 炫光_III = new TransitionMeta("炫光 III", true, "6950255930160189988", "4202529", "5ed29701053e9f7640ecf8dcfc34c7cc", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 炫光弹动 = new TransitionMeta("炫光弹动", true, "7348337133838406194", "52201950", "113a7490b314d57a7dea4826e056ff99", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 炫光扫描 = new TransitionMeta("炫光扫描", true, "7371717412736995903", "66131585", "4bd676f9001765af20ac02b252da5575", 1.466660, true);
        //默认时长: 1.47s//
        public static readonly TransitionMeta 炸弹 = new TransitionMeta("炸弹", true, "7076321483282190878", "1632990", "e0a1a6b556395c054ce97d73b6d1ef25", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 烟雾弹 = new TransitionMeta("烟雾弹", true, "7366189026677625359", "62284094", "58dced44162cefabdc709058b7583d65", 1.400000, true);
        //默认时长: 1.40s//
        public static readonly TransitionMeta 热成像 = new TransitionMeta("热成像", true, "7112344011737666061", "3141662", "9ddbaf68f325c10f04ba84f22272cf40", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 燃烧 = new TransitionMeta("燃烧", true, "7089309494550729253", "1722848", "0f42e514001c30186e1c9c68e1ebfee9", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 燃烧_II = new TransitionMeta("燃烧 II", true, "7089307363806548510", "1722824", "164c1073bde892dcd9f21d8026fb3cbd", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 燃烧_III = new TransitionMeta("燃烧 III", true, "7088523814102897188", "1714536", "da10f2f4ae0aa70ad4d61b2c750aef6b", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 爆米花 = new TransitionMeta("爆米花", true, "7075173004560306724", "1623902", "3b70ab38b467c15d463b018b05a420e2", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 爆闪 = new TransitionMeta("爆闪", true, "7255132261584998969", "18010162", "68768628ef11bee5b3887f0dbd7f7c6c", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 爆闪_II = new TransitionMeta("爆闪 II", true, "7259635767096382011", "19102212", "96e672a98b09ef157224e8b1399ae316", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 爱心冲击 = new TransitionMeta("爱心冲击", true, "6789846355742298632", "2916680", "6ca91f7bba738e2e4a67cbf8104eb7b0", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 爱心模糊 = new TransitionMeta("爱心模糊", true, "7226945634312393274", "12851969", "3dfdf5cbfe44b5271b9e41acb15ddc37", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 爱心气球 = new TransitionMeta("爱心气球", true, "7267895649599754808", "20810100", "6b969705ffc616c0ad03c1e0fc039bd7", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 环形色散 = new TransitionMeta("环形色散", true, "7384745397022888488", "72761824", "608a4f0f4729821ff115f72bfb57a909", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 玻璃破碎 = new TransitionMeta("玻璃破碎", true, "7242225450628420133", "14930013", "55aa86f7d52f2e3471574b51aedfffe8", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 玻璃破碎_II = new TransitionMeta("玻璃破碎 II", true, "7249622034878042661", "16373363", "f77fe839adb1ca6cddc086834a514b79", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 珠光模糊 = new TransitionMeta("珠光模糊", true, "7181370814594290234", "7738323", "75984d0cab40abfd59ec5d7ede711496", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 生气 = new TransitionMeta("生气", true, "7070430937900651016", "1600475", "be7a4f8a24aafb10db343e51e72fead2", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 电光 = new TransitionMeta("电光", true, "7186953120490983997", "8298317", "6142261f8bd0361a56d15a3d408c20ab", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 电光_II = new TransitionMeta("电光 II", true, "7292990637350064690", "26773684", "e8a9edb89dae57afad5dfd6b707a6b57", 1.300000, true);
        //默认时长: 1.30s//
        public static readonly TransitionMeta 百叶窗_II = new TransitionMeta("百叶窗 II", true, "7389190159989740072", "74345085", "0786c1d4057bf47fbdb5f6bfeab8a0f3", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 相片切换 = new TransitionMeta("相片切换", true, "7324946677305971226", "40583461", "0bcab7309cd00dc17a95071b62282d0a", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 相片拼贴 = new TransitionMeta("相片拼贴", true, "7212523710685647420", "10917367", "bdff0041ed99b812568c15e5a7c5d798", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 空间弹动 = new TransitionMeta("空间弹动", true, "7265321906830578235", "20330329", "e86c774726c177ee17fd90f63750cf78", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间弹动_II = new TransitionMeta("空间弹动 II", true, "7269664953584325179", "21121644", "adf0c9abb5c1399909318bb603f28ad1", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间弹动_III = new TransitionMeta("空间弹动 III", true, "7265322078276948535", "20330339", "d8c4ad960be7cfbe8093fa26076ce000", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间弹动_IV = new TransitionMeta("空间弹动 IV", true, "7270393974517404215", "21261060", "fb42b8f0a30fe4a0c81c292460aabdbd", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间旋转 = new TransitionMeta("空间旋转", true, "7127563142359421471", "3878325", "07c37c8bcf40b83415aa6f223de2cd8a", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间旋转_II = new TransitionMeta("空间旋转 II", true, "7137983390896099871", "4360464", "43927ed137278ab2c3cf8a4933cb4169", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间旋转_III = new TransitionMeta("空间旋转 III", true, "7138602593751667207", "4382158", "7baa76e42959ee273c278389d359fc59", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 空间翻转 = new TransitionMeta("空间翻转", true, "7218870491400901157", "11764147", "0ea4c7c316341196f21440967330f063", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 空间翻转_II = new TransitionMeta("空间翻转 II", true, "7223591053973000761", "12371701", "ee9309f01cc53522243198c4ba69ab96", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 空间跳跃 = new TransitionMeta("空间跳跃", true, "7309399317662405146", "32858947", "82c5ef6e77c7178c7ca45d8549b87578", 0.633000, true);
        //默认时长: 0.63s//
        public static readonly TransitionMeta 穿越 = new TransitionMeta("穿越", true, "7152422191944962567", "5083535", "80fb974789637e8175557c7c3e649c0e", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 穿越_II = new TransitionMeta("穿越 II", true, "7152354215132664357", "5076093", "aa3181f829fe16f72540cc0ec7dfb171", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 穿越_III = new TransitionMeta("穿越 III", true, "7341295618863665690", "48498880", "6d6fa95fe1414d4b4a45db9ddec0ee9b", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 立体翻转 = new TransitionMeta("立体翻转", true, "7353088031705797159", "54820217", "3746e458c37ab10f2aaa1ac83dee99f6", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 立体翻页 = new TransitionMeta("立体翻页", true, "7156512800867619335", "5379189", "ac010354774404d6b8e092120ab76772", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 立体翻页_II = new TransitionMeta("立体翻页 II", true, "7156527319274754568", "5381749", "a033fe7038252ba812a4377ff3326acf", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 竖向拉伸 = new TransitionMeta("竖向拉伸", true, "7384005384349946418", "72501228", "ac2563343aceb1b399c6b97b2b21f567", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 竖移模糊 = new TransitionMeta("竖移模糊", true, "7270505237935297085", "21300860", "4f77c735f448ec5f6df27f21d88e4ee6", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 粉色反转片 = new TransitionMeta("粉色反转片", true, "7200360240393491000", "9504701", "80529c6e270d25d9fa6e4babb45346c7", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 纸团 = new TransitionMeta("纸团", true, "7238905266912105019", "14451527", "283ecb29f26d13d371658f0b8b476776", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 翻转冲屏 = new TransitionMeta("翻转冲屏", true, "7275914638267519525", "22253379", "c1ebaab317335c387d342a3d0b42a65b", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 翻页_II = new TransitionMeta("翻页 II", true, "7221478593803588152", "12108759", "7720214c69eaa3203c3edda2027b28d4", 0.900000, true);
        //默认时长: 0.90s//
        public static readonly TransitionMeta 聚光灯 = new TransitionMeta("聚光灯", true, "7325700559556579878", "40923539", "43853a772e195442e07760b04fb236dd", 1.100000, true);
        //默认时长: 1.10s//
        public static readonly TransitionMeta 胶片定格 = new TransitionMeta("胶片定格", true, "7211146962513433147", "10764691", "1a96476b4a04acd24a1b5a7f293fc2eb", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 胶片擦除 = new TransitionMeta("胶片擦除", true, "7308265370480022026", "32274061", "4bbb3dcb507832529d7a18020c8fc88d", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 胶片融化 = new TransitionMeta("胶片融化", true, "7346474643827462667", "51067351", "563d0dfa49528bb59646384d8a18552a", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 胶片闪光 = new TransitionMeta("胶片闪光", true, "7356486482271408666", "56656394", "d3eb0fe7d4088694cc0f9ca02cad07b2", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 色块故障 = new TransitionMeta("色块故障", true, "7104539089629614606", "2483334", "1f60c6b995a4cf2212dfd9038f738706", 3.000000, false);
        //默认时长: 3.00s//
        public static readonly TransitionMeta 色差故障 = new TransitionMeta("色差故障", true, "6724239785205961228", "2918075", "9de90519d59e432b81c38423aa0393d7", 1.000000, false);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 色彩溶解_IV = new TransitionMeta("色彩溶解 IV", true, "7171714374912971271", "6736571", "a113cd4e04b969f3d988d76899885d42", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 色彩溶解_V = new TransitionMeta("色彩溶解 V", true, "7171714652248740365", "6736575", "da37129b95501377039f01acfded91fc", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 色散晃镜 = new TransitionMeta("色散晃镜", true, "7340477409478578738", "48127374", "554ea6d10cd7fbb24ccd24bd91d8c7e1", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 色散闪烁 = new TransitionMeta("色散闪烁", true, "7234416277974946365", "13830295", "2d9f72076aeefe8f52dfd1a012cd5127", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 色散闪烁_II = new TransitionMeta("色散闪烁 II", true, "7281584246882308665", "23586159", "5f501bb3da1bcbd2ffadca8b916eba81", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 荧光爆闪 = new TransitionMeta("荧光爆闪", true, "7342499359503684150", "48938221", "a2d70591b5f8dcc52298426ca626c931", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 菱格翻转 = new TransitionMeta("菱格翻转", true, "6983867136510792206", "1187052", "99c0d1524575c7f7020cd77d36a6b008", 1.450000, true);
        //默认时长: 1.45s//
        public static readonly TransitionMeta 蓝光扫描 = new TransitionMeta("蓝光扫描", true, "7275176500381356599", "22119723", "95462badbbb87bd7dc4e1d7b04e58306", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 蓝色反转片 = new TransitionMeta("蓝色反转片", true, "7200358812316865085", "9504705", "41e718fd6dbac560c6c7a23afc66e50b", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 融化 = new TransitionMeta("融化", true, "7198096122970116663", "9261283", "a0db335169668ca09f5244aa487730c0", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 融化_II = new TransitionMeta("融化 II", true, "7200339965442527803", "9503051", "74a83d45bdccf5d27bd4b55ddd2733f3", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 负片下滑 = new TransitionMeta("负片下滑", true, "7302412902181376539", "29999964", "e2db0036d057c27aea3460f3442aedf9", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 超赞 = new TransitionMeta("超赞", true, "7070430749547041293", "1600477", "e0bd13b237d73eb121473c442c752a23", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 透镜故障 = new TransitionMeta("透镜故障", true, "7097849004062413343", "1889546", "bc652327bcde0e6bf9db8a89d371dd05", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 重叠上滑 = new TransitionMeta("重叠上滑", true, "7232587870672785980", "13582109", "aea42365eeb8cd0df3e4e422cde45e8a", 1.200000, true);
        //默认时长: 1.20s//
        public static readonly TransitionMeta 金色光斑 = new TransitionMeta("金色光斑", true, "7317211103652483621", "37131315", "f9224f91ef353fefa3bae96af26a447e", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 钱兔无量 = new TransitionMeta("钱兔无量", true, "7189608212193088060", "8605167", "a6c068f7790c563231b8df2b5796d60c", 1.500000, true);
        //默认时长: 1.50s//
        public static readonly TransitionMeta 长曝光 = new TransitionMeta("长曝光", true, "7306435255286633010", "31452163", "c239e26c5f99cf83cabd28f63d04b93f", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 闪光灯 = new TransitionMeta("闪光灯", true, "6986584807543149063", "4202532", "9abfb7452d046a1dafd4d9525b58ec3a", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 闪光灯_II = new TransitionMeta("闪光灯 II", true, "7244074212158083641", "15250161", "1fcc7fccf7829d94f2747938fcb84706", 1.900000, true);
        //默认时长: 1.90s//
        public static readonly TransitionMeta 闪光灯_III = new TransitionMeta("闪光灯 III", true, "7246234663755190839", "15638113", "5af30d0f877301d5235b925ccbda0703", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 闪动光斑 = new TransitionMeta("闪动光斑", true, "6777178510050988551", "4202525", "06560e9ea51f532b18b7e5ae23bd2b9c", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 闪动光斑_II = new TransitionMeta("闪动光斑 II", true, "7148374073716773407", "4840333", "ffeb2bd8b46b0a212c1fbf004aeac626", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 闪回 = new TransitionMeta("闪回", true, "7250427149318885945", "16638473", "0a22de17ce5c2fd97f2bd77aa115de77", 0.200000, true);
        //默认时长: 0.20s//
        public static readonly TransitionMeta 闪屏故障 = new TransitionMeta("闪屏故障", true, "7348352782744687130", "52211013", "a76337e1d1e2301f5d13fd7c90c41282", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 闪黑_II = new TransitionMeta("闪黑 II", true, "7264932863613604412", "20257185", "1ecd9bf4057919c5aa78002f97e715de", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 闹钟 = new TransitionMeta("闹钟", true, "7074854214479909390", "1621980", "eabbd46c7d68fe93406dd55d4178a574", 0.500000, false);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 雪雾 = new TransitionMeta("雪雾", true, "7309372378096603699", "32838061", "776c40711e9f0f6f32570bc12ea50f91", 1.700000, true);
        //默认时长: 1.70s//
        public static readonly TransitionMeta 震动_II = new TransitionMeta("震动 II", true, "7195815265337086520", "9041507", "f5685f90de96d6541417f0331f84de8a", 1.000000, true);
        //默认时长: 1.00s//
        public static readonly TransitionMeta 震动缩小 = new TransitionMeta("震动缩小", true, "7339865466506056207", "47887388", "3cb961ebfd78ef43742e78bca2d04d06", 1.100000, true);
        //默认时长: 1.10s//
        public static readonly TransitionMeta 霓虹闪光 = new TransitionMeta("霓虹闪光", true, "7337938801882305074", "46839548", "60cee393e1ddf8c117ca6856e474d47d", 0.600000, true);
        //默认时长: 0.60s//
        public static readonly TransitionMeta 霓虹闪光_II = new TransitionMeta("霓虹闪光 II", true, "7337946710041170470", "46846588", "b87a9bf7d6c8e93cc9873ccb47ffc4d0", 0.500000, true);
        //默认时长: 0.50s//
        public static readonly TransitionMeta 飘雪 = new TransitionMeta("飘雪", true, "7169510140138230285", "6506905", "b373d6de281f9cc9cec4b52b0f498517", 2.000000, true);
        //默认时长: 2.00s//
        public static readonly TransitionMeta 飘雪_II = new TransitionMeta("飘雪 II", true, "7170983464416580133", "6658449", "f6e6d83024f30ae2ecf739e15e98813a", 2.000000, true);
        //默认时长: 2.00s//
        public static readonly TransitionMeta 马赛克_II = new TransitionMeta("马赛克 II", true, "7322278354579624486", "39369063", "c2c4fdb0da65e27a073eaba6fcf8dd2a", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 鱼眼 = new TransitionMeta("鱼眼", true, "7158359902950265352", "5508285", "0319d3f53fd0e79e7e7165f27d7eb9bb", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 鱼眼_II = new TransitionMeta("鱼眼 II", true, "7152723523721499167", "5096381", "6705e7c01ad8518db1428a34b1357d8f", 0.800000, true);
        //默认时长: 0.80s//
        public static readonly TransitionMeta 鱼眼_III = new TransitionMeta("鱼眼 III", true, "7270399429297836605", "21261750", "cdaf9cd4712f5f8061110dfed13738fd", 1.333300, true);
        //默认时长: 1.33s//
        public static readonly TransitionMeta 黑白摇镜 = new TransitionMeta("黑白摇镜", true, "7306819191724577331", "31620427", "cc6bea0aa49c6824aa42d0448d6d0080", 0.700000, true);
        //默认时长: 0.70s//
        public static readonly TransitionMeta 黑色反转片 = new TransitionMeta("黑色反转片", true, "7202075814085530149", "9683173", "8e31bcdedda0fe123ad1a71a967ecaa1", 0.800000, true);
        //默认时长: 0.80s//
    }
}
