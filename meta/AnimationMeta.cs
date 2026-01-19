using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    public class AnimationMeta
    {
        /// <summary>
        /// 动画标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否为VIP动画
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// 动画时长（微秒）
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 效果ID
        /// </summary>
        public string EffectId { get; set; }

        /// <summary>
        /// 文件MD5
        /// </summary>
        public string Md5 { get; set; }

        public AnimationMeta(string title, bool isVip, double durationSeconds, string resourceId, string effectId, string md5)
        {
            Title = title;
            IsVip = isVip;
            Duration = (int)Math.Round(durationSeconds * 1e6); // 秒转微秒
            ResourceId = resourceId;
            EffectId = effectId;
            Md5 = md5;
        }
    }

    //映自带的视频/图片入场动画类型
    public static class IntroType
    {
        // 免费入场动画
        public static readonly AnimationMeta 缩小 = new AnimationMeta("缩小", false, 0.500, "6798332584276267527", "624755", "7e0e6b55704b7fc20588fee77058e95c");
        public static readonly AnimationMeta 渐显 = new AnimationMeta("渐显", false, 0.500, "6798320778182922760", "624705", "af863de1e359fd4f54bb78f2e2749e1f");
        public static readonly AnimationMeta 放大 = new AnimationMeta("放大", false, 0.500, "6798332733694153230", "624751", "028a77e121c22a4dd130a46a0ed90714");
        public static readonly AnimationMeta 旋转 = new AnimationMeta("旋转", false, 0.500, "6798334070653719054", "624731", "b3018b8ae12d4a9421d81a3b263b7e88");
        public static readonly AnimationMeta Kira游动 = new AnimationMeta("Kira游动", false, 2.267, "7311984593387655731", "34176967", "05daa2cb2b53e1830a0e657ede749daf");
        public static readonly AnimationMeta 抖动下降 = new AnimationMeta("抖动下降", false, 0.500, "6991764455931515422", "1206320", "9b04ce5965c78218e918f043cf12a879");
        public static readonly AnimationMeta 镜像翻转 = new AnimationMeta("镜像翻转", false, 0.500, "6797338697625768455", "646003", "55ec076a5d62f7e80655e60c43f68f80");
        public static readonly AnimationMeta 旋转开幕 = new AnimationMeta("旋转开幕", false, 1.000, "7186944542409495099", "8295043", "407822a27a67612c3caa3e4223aa32d3");
        public static readonly AnimationMeta 折叠开幕 = new AnimationMeta("折叠开幕", false, 1.500, "7239273897491698232", "14506065", "17e0225f852c0798063d82440ca54185");
        public static readonly AnimationMeta 漩涡旋转 = new AnimationMeta("漩涡旋转", false, 0.500, "6782010677520241165", "703281", "6e922bdebed1d87f9a63ba285a5dd792");
        public static readonly AnimationMeta 跳转开幕 = new AnimationMeta("跳转开幕", false, 0.733, "7279999334001676857", "23185431", "817876a62d2d05e4eef9ac4cfa9c70fe");
        public static readonly AnimationMeta 轻微抖动 = new AnimationMeta("轻微抖动", false, 0.500, "6739418227031413256", "431664", "7ec99bda70fa6922395d65235991f9e5");
        public static readonly AnimationMeta 轻微抖动_II = new AnimationMeta("轻微抖动 II", false, 0.500, "6739418677910704651", "431650", "8e29ab0a86dac5719300064821e8b63d");
        public static readonly AnimationMeta 轻微抖动_III = new AnimationMeta("轻微抖动 III", false, 0.500, "6781683302672634382", "503136", "8482055860ab20c23102d78aa3486a7a");
        public static readonly AnimationMeta 上下抖动 = new AnimationMeta("上下抖动", false, 0.500, "6739418390030455300", "431652", "bff95de5e1e4803ea64a52632bcfb361");
        public static readonly AnimationMeta 左右抖动 = new AnimationMeta("左右抖动", false, 0.500, "6739418540421419524", "431654", "7572d7461e38d73c578aa8e4dca7163a");
        public static readonly AnimationMeta 斜切 = new AnimationMeta("斜切", false, 0.700, "7210657307938525751", "10696371", "a385761197d457f4599d231421045230");
        public static readonly AnimationMeta 钟摆 = new AnimationMeta("钟摆", false, 0.500, "6803260897117606414", "636115", "6b9d17389864da0a68d347365023849a");
        public static readonly AnimationMeta 雨刷 = new AnimationMeta("雨刷", false, 0.500, "6802871256849846791", "634681", "0a8846e691446c6b2f583086567579a5");
        public static readonly AnimationMeta 雨刷_II = new AnimationMeta("雨刷 II", false, 0.500, "6805748897768542727", "640101", "f67c2ccd81956813d5b1303625bed354");
        public static readonly AnimationMeta 向上转入 = new AnimationMeta("向上转入", false, 0.500, "6808401616564130312", "645307", "0247c3715de210fa89a4fc9f2f03b63c");
        public static readonly AnimationMeta 向上转入_II = new AnimationMeta("向上转入 II", false, 0.500, "6818747060649464327", "701961", "c66f550e7ab2de4ef4eb1ee7e7002fa3");
        public static readonly AnimationMeta 向左转入 = new AnimationMeta("向左转入", false, 0.500, "6816560956647150093", "699157", "aca9db228bf685cd9f02eb966252846e");
        public static readonly AnimationMeta 向右转入 = new AnimationMeta("向右转入", false, 0.500, "6805019065761927694", "638825", "c447b8637ba24ae1111b087e8d5a5739");
        public static readonly AnimationMeta 向上滑动 = new AnimationMeta("向上滑动", false, 0.500, "6798333487523828238", "624739", "9598ba5dd6e4ce29c7c3ffded39fb3b9");
        public static readonly AnimationMeta 向下滑动 = new AnimationMeta("向下滑动", false, 0.500, "6798333705401143816", "624735", "d34d52d5386e20de654b0fff9ea9704f");
        public static readonly AnimationMeta 向左滑动 = new AnimationMeta("向左滑动", false, 0.500, "6798332871267324423", "624747", "dcae7883ea619dac2661a5f21795cc9f");
        public static readonly AnimationMeta 向右滑动 = new AnimationMeta("向右滑动", false, 0.500, "6798333076469453320", "624743", "e3e2dad87aff58e7944fac67661b56b2");
        public static readonly AnimationMeta 向下甩入 = new AnimationMeta("向下甩入", false, 0.500, "6739338374441603598", "431638", "afb5afec3c42fa627a007ff609c83792");
        public static readonly AnimationMeta 向右甩入 = new AnimationMeta("向右甩入", false, 0.500, "6739338727866241539", "431636", "228f76b86355e74087a9a80647236b88");
        public static readonly AnimationMeta 向左上甩入 = new AnimationMeta("向左上甩入", false, 0.500, "6740122563692728844", "431648", "aa97897803351debd46c9182132c64c5");
        public static readonly AnimationMeta 向右上甩入 = new AnimationMeta("向右上甩入", false, 0.500, "6740122731418751495", "431644", "12ae5b6cc0b2bff43e958d5ca2d574fe");
        public static readonly AnimationMeta 向左下甩入 = new AnimationMeta("向左下甩入", false, 0.500, "6739395445346275853", "431642", "269d5e19ed83faa5f5c72a1401e4564b");
        public static readonly AnimationMeta 向右下甩入 = new AnimationMeta("向右下甩入", false, 0.500, "6739395718223499787", "431640", "f821a402edb042a9d68d825cb804ac6e");
        public static readonly AnimationMeta 动感放大 = new AnimationMeta("动感放大", false, 0.500, "6740867832570974733", "431662", "3d880239a1fa70fbaedcc7fd20794e22");
        public static readonly AnimationMeta 动感缩小 = new AnimationMeta("动感缩小", false, 0.500, "6740868384637850120", "431658", "8357dd30914ef6ba1ba89dd12a83dc3e");
        public static readonly AnimationMeta 轻微放大 = new AnimationMeta("轻微放大", false, 0.500, "6800268825611735559", "629085", "f6c8209ef7142fff6cf9c68573216371");

        // 付费入场动画
        public static readonly AnimationMeta 快速翻页 = new AnimationMeta("快速翻页", true, 0.167, "7296381392340914715", "27878991", "6e1d71ff694a87526f9c5bb2c01c927d");
        public static readonly AnimationMeta 荧光爆闪 = new AnimationMeta("荧光爆闪", true, 1.000, "7347948517471556096", "51992419", "84d6cfae125a71855b500604748f1e19");
        public static readonly AnimationMeta 十字震动 = new AnimationMeta("十字震动", true, 0.800, "7352824361625063987", "54686020", "33d4a2ff79aa2fb88fadd45aee1998e9");
        public static readonly AnimationMeta 爱心碰撞 = new AnimationMeta("爱心碰撞", true, 2.667, "7327872475453198848", "41910725", "119e873890708ee4817c9778dcb20b69");
        public static readonly AnimationMeta 冲撞 = new AnimationMeta("冲撞", true, 2.000, "7215530662986519096", "11320895", "aeadb248c06d074a2d98f425a57999f0");
        public static readonly AnimationMeta 闪屏 = new AnimationMeta("闪屏", true, 1.200, "7242155802209817147", "14904085", "c2f368ce853ab863a12c686bb99bb41e");
        public static readonly AnimationMeta 扫描 = new AnimationMeta("扫描", true, 0.600, "7312335732721324554", "34385508", "191401f0b79c28d7569dfc356ba827b6");
        public static readonly AnimationMeta 震动波纹 = new AnimationMeta("震动波纹", true, 1.500, "7307196313148330547", "31806105", "95760b6f7efe0016546e38852a981f49");
        public static readonly AnimationMeta 分屏翻转 = new AnimationMeta("分屏翻转", true, 0.700, "7257782721575916088", "18711457", "013f6255cb0672198f26962bff3f788b");
        public static readonly AnimationMeta 立体翻转 = new AnimationMeta("立体翻转", true, 1.100, "7346505124820292150", "51089258", "bad88fa72b42b3c12099c31654575952");
        public static readonly AnimationMeta 马赛克 = new AnimationMeta("马赛克", true, 1.000, "7282703408383922745", "23885083", "273c4952c915c9250f0b9edadac34148");
        public static readonly AnimationMeta _2024 = new AnimationMeta("2024", true, 1.500, "7309774750677471794", "33056565", "d68370ce25f28ec80d9c0bb7e51e2324");
        public static readonly AnimationMeta 多层环形 = new AnimationMeta("多层环形", true, 2.000, "7329444938960081460", "42686363", "54801ad31b13853ad1e3ccf945e89973");
        public static readonly AnimationMeta 弹力分割 = new AnimationMeta("弹力分割", true, 1.060, "7267827357627454013", "35994464", "9f5878effce0a857900a4f050ea52318");
        public static readonly AnimationMeta 弹近 = new AnimationMeta("弹近", true, 1.500, "7314144465944318502", "35289246", "30c62d3ccb969173e5fa43511894116b");
        public static readonly AnimationMeta 画出爱心 = new AnimationMeta("画出爱心", true, 1.600, "7248901535894082105", "16211481", "6e5cdc1e7ece582da904ac520440e88a");
        public static readonly AnimationMeta 发光矩形 = new AnimationMeta("发光矩形", true, 1.033, "7346511208171704841", "51093680", "64852509d7cb2a578469b3438b94df52");
        public static readonly AnimationMeta 空间扭曲 = new AnimationMeta("空间扭曲", true, 1.160, "7298688232294715931", "28693486", "da3a08519a9315e3625173b71a4d8ee3");
        public static readonly AnimationMeta 四屏转换 = new AnimationMeta("四屏转换", true, 1.000, "7341283787143123507", "48492378", "fdd9abc8f2abadc0ae6e909779f282e6");
        public static readonly AnimationMeta 展开 = new AnimationMeta("展开", true, 0.500, "7221413342257091133", "12088589", "553acdb325d76533d6ecbd6d621d9b9e");
        public static readonly AnimationMeta 划水 = new AnimationMeta("划水", true, 0.800, "7226632607939695161", "12811781", "57a259c58a4daddacc897c75ec9c10a4");
        public static readonly AnimationMeta 色散波纹 = new AnimationMeta("色散波纹", true, 0.830, "7299029942870741542", "28824874", "2ce459ce040280d7c4f36ab78a3612e5");
        public static readonly AnimationMeta 模糊聚焦 = new AnimationMeta("模糊聚焦", true, 1.200, "7337937899704291866", "46838778", "38841ccaef6186af6d516eeea116b3c6");
        public static readonly AnimationMeta 圆形开幕 = new AnimationMeta("圆形开幕", true, 0.900, "7218210014949806647", "11680735", "2c171ce2c85042bb518cbdc08ced9709");
        public static readonly AnimationMeta 聚合 = new AnimationMeta("聚合", true, 2.000, "7303524763589153306", "30391788", "c3293067129322c884d0865b99cb11bd");
        public static readonly AnimationMeta 砸出波纹 = new AnimationMeta("砸出波纹", true, 1.560, "7255594501694034490", "18159482", "644483b024fc852955dd807da067d8e9");
        public static readonly AnimationMeta 向下甩动 = new AnimationMeta("向下甩动", true, 1.400, "7338320641306661410", "47050546", "060ee66b7f59d3d2c8064be5ae32171c");
        public static readonly AnimationMeta 向上滚动 = new AnimationMeta("向上滚动", true, 1.000, "7312341574988337690", "34388476", "14e7c85bfa04ecbacc1e63ee386840b7");
        public static readonly AnimationMeta 拼图 = new AnimationMeta("拼图", true, 1.067, "7369889381357720102", "64963350", "4b721a1559eb3451d6cc358468537c49");
        public static readonly AnimationMeta 向上闪入 = new AnimationMeta("向上闪入", true, 0.700, "7273389803532456504", "21816946", "ecaffca7c7e1d7744fa296a29f65b366");
        public static readonly AnimationMeta 交错开幕 = new AnimationMeta("交错开幕", true, 1.100, "7280797339042714169", "23387955", "123322fa9ce7c37f0c2c35819f00b524");
        public static readonly AnimationMeta 便利贴 = new AnimationMeta("便利贴", true, 0.900, "7379456870265655859", "70486392", "06613663efa8ef29beadf8746019c823");
        public static readonly AnimationMeta 侧滑 = new AnimationMeta("侧滑", true, 0.600, "7239559299196785209", "14524393", "c67d95e820752346af44e2cb515c0115");
        public static readonly AnimationMeta 横向模糊 = new AnimationMeta("横向模糊", true, 0.500, "7301896031673782835", "29805902", "b8b953ad94b16c47601af887d4ccc8c9");
        public static readonly AnimationMeta 闪现 = new AnimationMeta("闪现", true, 0.440, "7210363235906622012", "10668047", "6a680c49cd11a05f3eb0e5a3fed165f7");
        public static readonly AnimationMeta 水墨 = new AnimationMeta("水墨", true, 2.433, "7321672946466951731", "39180627", "7e5d11c796a2e1bec5feb486e647e60b");
        public static readonly AnimationMeta 交叉震动 = new AnimationMeta("交叉震动", true, 0.833, "7222990639984546360", "12309329", "cde910202607be12ac747e2e76316e7f");
        public static readonly AnimationMeta 抖动横移 = new AnimationMeta("抖动横移", true, 0.567, "7265946978792510010", "20437845", "e4951e1d7abcdbd4e8bf1cf33430def7");
        public static readonly AnimationMeta 抖动变焦 = new AnimationMeta("抖动变焦", true, 0.800, "7156911481563386381", "5414507", "04365018fdc27b7e1175b709a739f800");
        public static readonly AnimationMeta 斜向拉丝 = new AnimationMeta("斜向拉丝", true, 0.667, "7360531434487943743", "58777551", "60ba474a0460cb7e999830c02943e977");
        public static readonly AnimationMeta 拉丝滑入 = new AnimationMeta("拉丝滑入", true, 0.500, "7112725640901562887", "3179668", "913b99e9012d50f629c59a31e030b143");
        public static readonly AnimationMeta 果冻_I = new AnimationMeta("果冻 I", true, 0.800, "7171640017574433294", "6725401", "4ef7f9da6b1331109620381229d55429");
        public static readonly AnimationMeta 果冻_II = new AnimationMeta("果冻 II", true, 0.800, "7171690870788329992", "6732061", "01d346b0f37b87c25c17a53309189432");
        public static readonly AnimationMeta 烟雾弹 = new AnimationMeta("烟雾弹", true, 1.200, "7226641244938572346", "12815013", "8c5e4642b824c252b5a556bbbcbae767");
        public static readonly AnimationMeta 震波 = new AnimationMeta("震波", true, 0.800, "7115301367786246692", "3297068", "8aaccb8f112aa3cacd80fa79fcc1690f");
        public static readonly AnimationMeta 震波_II = new AnimationMeta("震波 II", true, 0.833, "7211042099737662009", "10744265", "f8f236cd1279af3680bcc71dda889d97");
        public static readonly AnimationMeta 震波_III = new AnimationMeta("震波 III", true, 1.700, "7288985830578721336", "25545977", "3be0a1f04cf38bf05ed301ebaeb47ef8");
        public static readonly AnimationMeta 旋转圆球 = new AnimationMeta("旋转圆球", true, 0.800, "7380298290140549647", "70989966", "19b93b0edea19a73d2cf7f818ace3265");
        public static readonly AnimationMeta 转圈圈 = new AnimationMeta("转圈圈", true, 0.800, "7246643852411408952", "15726741", "f2c920e366c3c733f1d86a8473aff310");
        public static readonly AnimationMeta 曝光放射 = new AnimationMeta("曝光放射", true, 0.800, "7158737452939612703", "5529363", "09df65728356189436974e08c42bc578");
        public static readonly AnimationMeta 玻璃聚集 = new AnimationMeta("玻璃聚集", true, 1.700, "7340265236101861915", "48072242", "68c8e8f1eba4f4b2e3d35472f8b4822c");
        public static readonly AnimationMeta 分屏横移 = new AnimationMeta("分屏横移", true, 1.000, "7257878167023522365", "18746326", "dcadf2284399fe6200f77fad9a1ec41a");
        public static readonly AnimationMeta 流金 = new AnimationMeta("流金", true, 1.500, "7322367212142989850", "39438403", "6654a74eb923c201fe18765f18d4b367");
        public static readonly AnimationMeta 心形放大 = new AnimationMeta("心形放大", true, 1.500, "7042968847070007844", "1487080", "3bb1bb084e5ebf25e67fc078d3c6a119");
        public static readonly AnimationMeta 老电视 = new AnimationMeta("老电视", true, 1.400, "7290754106417746491", "26091602", "4cbe6bdc6da704e481a40f44266cee0b");
        public static readonly AnimationMeta 脉冲 = new AnimationMeta("脉冲", true, 0.900, "7379909514847326732", "70764198", "ae7fac0214409e340db6a600e97303da");
        public static readonly AnimationMeta 能量立方 = new AnimationMeta("能量立方", true, 1.333, "7359472053998588425", "58285135", "301b4ffff8510c87b7174161b2642ca3");
        public static readonly AnimationMeta 波纹弹动 = new AnimationMeta("波纹弹动", true, 1.200, "7345731405663441460", "50640360", "b29c4c4dbac023b27bac5d32e642f6bb");
    }

    //剪映自带的视频/图片出场动画类型
    public static class OutroType
    {
        //免费
        public static readonly AnimationMeta 向上转出 = new AnimationMeta("向上转出", false, 0.500, "6818747115934585357", "701963", "7f57dd9488a89da902a998018adafdf5");
        public static readonly AnimationMeta 向上转出_II = new AnimationMeta("向上转出 II", false, 0.500, "6818747169017696781", "701965", "0d37319fa4b20f2584ac32294f48a554");
        public static readonly AnimationMeta 跳转闭幕 = new AnimationMeta("跳转闭幕", false, 0.733, "7280420767378969143", "23302677", "82992a12a8ae1227579be0f66d87d75f");
        public static readonly AnimationMeta 镜像翻转 = new AnimationMeta("镜像翻转", false, 0.500, "6738353628215513613", "645999", "a24594428fdd0c8078b74659fc1f2679");
        public static readonly AnimationMeta 旋转闭幕 = new AnimationMeta("旋转闭幕", false, 1.000, "6942482728335970823", "1221132", "b235b8a2a8647a211494856315cde2a9");
        public static readonly AnimationMeta 漩涡旋转 = new AnimationMeta("漩涡旋转", false, 0.500, "6778418947361346061", "634701", "2f239d1240bc871d05ce582ba201b085");
        public static readonly AnimationMeta 向上滑动 = new AnimationMeta("向上滑动", false, 0.500, "6798333612958683656", "624737", "1b4343c92c2545a50216b85e2a08a6ee");
        public static readonly AnimationMeta 向下滑动 = new AnimationMeta("向下滑动", false, 0.500, "6798333787986989576", "624733", "9eced44ba9f495d053661ebd552088bb");
        public static readonly AnimationMeta 向左滑动 = new AnimationMeta("向左滑动", false, 0.500, "6798332972098392584", "624745", "771fc844822cea60f0623ecff4f4b88a");
        public static readonly AnimationMeta 向右滑动 = new AnimationMeta("向右滑动", false, 0.500, "6798333350487527950", "624741", "d1dcd128f35a8ad365847355f28e259b");
        public static readonly AnimationMeta 折叠闭幕 = new AnimationMeta("折叠闭幕", false, 1.500, "7239273967310082621", "14506017", "f750b9b6c7a756dfdd6785cde5d24d00");
        public static readonly AnimationMeta 轻微放大 = new AnimationMeta("轻微放大", false, 0.500, "6800268611807089166", "629083", "b2a1271b065aa9e6351bfd64ff7d4eea");
        public static readonly AnimationMeta Kira游动 = new AnimationMeta("Kira游动", false, 2.267, "7312343337199997450", "34389264", "2cefeb684db271dc288ec225f0854264");
        public static readonly AnimationMeta 缩小 = new AnimationMeta("缩小", false, 0.500, "6798332648814023181", "624753", "509c5edb2131a88070bf699ad0852e4f");
        public static readonly AnimationMeta 放大 = new AnimationMeta("放大", false, 0.500, "6798332801864176142", "624749", "01497dc221d288e623a10cac94a5ceca");
        public static readonly AnimationMeta 旋转 = new AnimationMeta("旋转", false, 0.500, "6798334141323547143", "624729", "44e26ad0221385965730ae69d947d790");
        public static readonly AnimationMeta 斜切 = new AnimationMeta("斜切", false, 0.700, "7210659943051956797", "10697199", "93fd7d9c4f059c26cd3681dd512c20ed");

        // 付费
        public static readonly AnimationMeta 渐隐 = new AnimationMeta("渐隐", false, 0.500, "6798320902548230669", "624707", "808a065a2319cc6d1d53d9bec791ac6e");
        public static readonly AnimationMeta 空间扭曲 = new AnimationMeta("空间扭曲", true, 0.930, "7298918355841323529", "28775864", "04c885b1dbbcf51bcc01e4df931bff72");
        public static readonly AnimationMeta 弹远 = new AnimationMeta("弹远", true, 1.200, "7314925770181186075", "35749432", "310e6755e6441af5d3405bc80a3be26d");
        public static readonly AnimationMeta 四屏转换 = new AnimationMeta("四屏转换", true, 0.900, "7341284613165158921", "48492502", "cf7d3bd0e7973868861d1e466cb238eb");
        public static readonly AnimationMeta 分屏翻转 = new AnimationMeta("分屏翻转", true, 0.560, "7259341241031070268", "19063130", "392b91fd262e9b95e1dcd18274297393");
        public static readonly AnimationMeta 冲撞 = new AnimationMeta("冲撞", true, 0.767, "7215555273501446716", "11325221", "16e01aa5454653bc89d3b1d8e86ce3a2");
        public static readonly AnimationMeta 旋转圆球 = new AnimationMeta("旋转圆球", true, 0.800, "7381753028732260916", "71750513", "e824e3d74a50eba64dd87ac11b9bbfb8");
        public static readonly AnimationMeta 砸出波纹 = new AnimationMeta("砸出波纹", true, 1.366, "7255599483226952249", "18161234", "87e9baa63de40d76f862bb8aa4349de3");
        public static readonly AnimationMeta 交叉震动 = new AnimationMeta("交叉震动", true, 0.466, "7223227564670587452", "12330095", "3a711c053dcadb7856d19778f72a58c1");
        public static readonly AnimationMeta 能量立方 = new AnimationMeta("能量立方", true, 1.133, "7361364150229930506", "59265410", "f6c5b98ea69f3b2c3265bb3249973250");
        public static readonly AnimationMeta 横向模糊 = new AnimationMeta("横向模糊", true, 0.500, "7301943351320777267", "29824130", "294f0f8ecbe4b4a8b8f2c01f579739f1");
        public static readonly AnimationMeta 多层环形 = new AnimationMeta("多层环形", true, 1.633, "7329445038604161536", "42686393", "c684bdf866bada10acb647e5339397a3");
        public static readonly AnimationMeta 斜向拉丝 = new AnimationMeta("斜向拉丝", true, 0.500, "7360531353458184715", "58777523", "71a267bc37d3dc0afa3aaae12ec995e7");
        public static readonly AnimationMeta 分屏横移 = new AnimationMeta("分屏横移", true, 0.880, "7257879855063110205", "18746674", "7382c7210c95548bfc88486be3964284");
        public static readonly AnimationMeta _2024 = new AnimationMeta("2024", true, 1.000, "7311958876406944266", "34158075", "93bcb64554588e6f3a0a4ffffa0bb3b5");
        public static readonly AnimationMeta 扫描 = new AnimationMeta("扫描", true, 0.633, "7316816362305753609", "36871694", "a89a479b5228737e62ccd7e77059315f");
        public static readonly AnimationMeta 曝光放射 = new AnimationMeta("曝光放射", true, 0.500, "7158753896624558628", "5529791", "70911371ae8ec475600c4e30c9db8994");
        public static readonly AnimationMeta 色散波纹 = new AnimationMeta("色散波纹", true, 0.767, "7305961286762762790", "31248281", "5477505f844e9bad12dc9074631564b1");
        public static readonly AnimationMeta 马赛克 = new AnimationMeta("马赛克", true, 1.000, "7283415427328250405", "24073041", "6be9c2fd05f76e3902a9967139706468");
        public static readonly AnimationMeta 十字震动 = new AnimationMeta("十字震动", true, 0.533, "7352824282289803814", "54685998", "969e17d5d65494d0b10b9111d66802d8");
        public static readonly AnimationMeta 震动波纹 = new AnimationMeta("震动波纹", true, 1.500, "7307196476340310554", "31806349", "cdb162bc674e495b24d38a2cf4bd04b6");
        public static readonly AnimationMeta 弹力分割 = new AnimationMeta("弹力分割", true, 1.060, "7343902820808004123", "49678364", "62adcd0cd61c98d0640e657e63b0be8a");
        public static readonly AnimationMeta 震波_III = new AnimationMeta("震波 III", true, 0.733, "7289005562124046907", "25555607", "59a06bc5a9bfe9c395d45f05ae38435a");
        public static readonly AnimationMeta 立体翻转 = new AnimationMeta("立体翻转", true, 1.100, "7351333213068857892", "53792520", "82f13f68eb475cfaabaf2a674b50ac8a");
        public static readonly AnimationMeta 流金 = new AnimationMeta("流金", true, 1.133, "7322857522648322586", "39682247", "646fc008978735fbf5b5d3cde382fc22");
        public static readonly AnimationMeta 划水 = new AnimationMeta("划水", true, 0.800, "7226632692354257445", "12811717", "f30ab9f83934eafedb4ee01a3d87a995");
        public static readonly AnimationMeta 发光矩形 = new AnimationMeta("发光矩形", true, 1.133, "7346510998771077659", "51093596", "ccac330a683da920a9638b597ce1f869");
        public static readonly AnimationMeta 玻璃爆开 = new AnimationMeta("玻璃爆开", true, 0.733, "7347865496508699170", "51922869", "620f6fe34184e1f3cc2284d830c3d1e8");
        public static readonly AnimationMeta 转圈圈 = new AnimationMeta("转圈圈", true, 0.800, "7246706359381529125", "15754757", "c03fc00075c5b7e53f8bdc0c6f5c360f");
        public static readonly AnimationMeta 烟雾弹 = new AnimationMeta("烟雾弹", true, 0.900, "7229149181762343484", "13090999", "e70e26e7aa770d0deedca54e3eac0323");
        public static readonly AnimationMeta 闪现 = new AnimationMeta("闪现", true, 0.250, "7186978468087730749", "8303609", "f170e9020eaf5a6f6180c6fd30775400");
        public static readonly AnimationMeta 圆形闭幕 = new AnimationMeta("圆形闭幕", true, 0.900, "7218210114052821561", "11680737", "0acd6d992db52febb66a63a3cfc6ea00");
        public static readonly AnimationMeta 飘散 = new AnimationMeta("飘散", true, 2.000, "7305957010518839846", "31245441", "286553fb78795b8044746938e4327d5e");
        public static readonly AnimationMeta 闪屏 = new AnimationMeta("闪屏", true, 0.833, "7243999104114627132", "15215961", "e4ef6b01ae37409046d089c73cd16702");
        public static readonly AnimationMeta 老电视 = new AnimationMeta("老电视", true, 1.600, "7283429462924857914", "24079477", "50d67778f791d56b12ab5c6da30c37b6");
        public static readonly AnimationMeta 向上闪出 = new AnimationMeta("向上闪出", true, 0.700, "7273389599978689079", "21816912", "4e39075df8d20d1d938c5bf23b2604fb");
        public static readonly AnimationMeta 交错闭幕 = new AnimationMeta("交错闭幕", true, 1.100, "7280797214186672701", "23387942", "1804a8bb6a3eb61c8e5720428d4648e7");
        public static readonly AnimationMeta 心形缩小 = new AnimationMeta("心形缩小", true, 1.000, "7034346969086562824", "1463778", "677ec2564241df326a921fa9dc58bd81");
        public static readonly AnimationMeta 水墨 = new AnimationMeta("水墨", true, 2.033, "7322073757080621606", "39326538", "32664ec43aa94c7861104f4e4d401113");
        public static readonly AnimationMeta 折叠 = new AnimationMeta("折叠", true, 0.300, "7221420528148419133", "12091673", "7968ce8b7391c3725f2b7667d0e0f80a");
        public static readonly AnimationMeta 画出爱心 = new AnimationMeta("画出爱心", true, 1.100, "7248951676420231735", "16231427", "ad5c127255cc8f2c941f7406f8a36f19");
        public static readonly AnimationMeta 侧滑 = new AnimationMeta("侧滑", true, 0.400, "7239559574095663671", "14524385", "1a661b1d0728177d889353174bfb0bf8");
        public static readonly AnimationMeta 抖动横移 = new AnimationMeta("抖动横移", true, 0.400, "7265946879060349477", "20437843", "bcebbe81fc2243a3685ab8e550e3415f");
        public static readonly AnimationMeta 便利贴 = new AnimationMeta("便利贴", true, 0.800, "7379884133268328996", "70741835", "ce8f5846f77edba5099b042ef7b6958b");
        public static readonly AnimationMeta 拼图 = new AnimationMeta("拼图", true, 1.100, "7369889275233440265", "64963293", "9e1b296804c2f10ce26fcf727d1dd9af");
        public static readonly AnimationMeta 向下甩动 = new AnimationMeta("向下甩动", true, 1.000, "7338638617322983976", "47191669", "178fe900252c316f5301d805a735ce8e");
        public static readonly AnimationMeta 脉冲 = new AnimationMeta("脉冲", true, 0.800, "7379909625870553654", "70764127", "f916cc354e9c5b80698d612397a0c4f7");
        public static readonly AnimationMeta 向上滚动 = new AnimationMeta("向上滚动", true, 1.000, "7312341715220697650", "34388502", "92d44450f8557fc1d8d93eb6cbe2a832");
        public static readonly AnimationMeta 拉丝滑出 = new AnimationMeta("拉丝滑出", true, 0.500, "7114172789287817758", "3240292", "e3018d5ee625a58fdeaa5ccd75d0e2e2");
        public static readonly AnimationMeta 波纹弹动 = new AnimationMeta("波纹弹动", true, 1.200, "7345803511390540288", "50691424", "660ff84eabd735769a72978914e8e82d");
        public static readonly AnimationMeta 快速翻页 = new AnimationMeta("快速翻页", true, 0.200, "7296416099606729225", "27895223", "00b26549833daf565f2660d0abcb0462");
        public static readonly AnimationMeta 荧光爆闪 = new AnimationMeta("荧光爆闪", true, 0.800, "7347994415576650255", "52020801", "6558ab016ce06546d3c380b43480baab");
        public static readonly AnimationMeta 模糊聚焦 = new AnimationMeta("模糊聚焦", true, 0.833, "7338742568592609801", "47267179", "2cf9380884a5e9853ecdbb4869b01b0e");
        public static readonly AnimationMeta 抖动变焦 = new AnimationMeta("抖动变焦", true, 0.500, "7153942002696983047", "5188733", "6e14698c240bfa454836d26eaa44d3bc");
        public static readonly AnimationMeta 爱心碰撞 = new AnimationMeta("爱心碰撞", true, 2.300, "7328249133079204352", "42112174", "1cf69aac7b9478f5628413aada8c0707");
    }

    //剪映自带的视频/图片组合动画类型, 组合动画一般与视频片段等长
    public static class GroupType
    {
        // 免费组合动画
        public static readonly AnimationMeta 三分割 = new AnimationMeta("三分割", false, 0.500, "6873360856541827591", "922958", "8eec0e58254ae6906c085ffc36570d6f");
        public static readonly AnimationMeta 三分割_II = new AnimationMeta("三分割 II", false, 0.500, "6873360923646497293", "922957", "42db12dd4ef8bdc4098ba3fd321c1de9");
        public static readonly AnimationMeta 上下分割 = new AnimationMeta("上下分割", false, 0.500, "6875935836177699335", "931224", "18312916ab04e01f4aa11f58075a86bb");
        public static readonly AnimationMeta 上下分割_II = new AnimationMeta("上下分割 II", false, 0.500, "6875935919661126157", "3144548", "2b773c5e2856fac177f9ce4b39a87b74");
        public static readonly AnimationMeta 上升旋转 = new AnimationMeta("上升旋转", false, 0.500, "6813965595915063815", "691841", "45d026e340219c0caae01e8c9e0260ba");
        public static readonly AnimationMeta 下降向右 = new AnimationMeta("下降向右", false, 0.500, "6781683518222111239", "503140", "545ed5bde7166e5e18aa5e4ba9662348");
        public static readonly AnimationMeta 下降向左 = new AnimationMeta("下降向左", false, 0.500, "6759351225772151303", "446392", "2ba01976cbb05f3a22bea55ee5fcf3c3");
        public static readonly AnimationMeta 中间分割 = new AnimationMeta("中间分割", false, 0.500, "6856970350270353928", "871868", "39118319d1910ecf60eae3e8c0871e6e");
        public static readonly AnimationMeta 中间分割_II = new AnimationMeta("中间分割 II", false, 0.500, "6856970411352003080", "871867", "d35d05906c0ffe288964f33d96cbbe14");
        public static readonly AnimationMeta 叠叠乐 = new AnimationMeta("叠叠乐", false, 0.500, "6836319728038842894", "872824", "63c0c0634a0c5f99ec74f839421018b0");
        public static readonly AnimationMeta 叠叠乐_II = new AnimationMeta("叠叠乐 II", false, 0.500, "6836319649844433415", "872826", "464c1a4bb1176029ffa3f1b6b7ae25be");
        public static readonly AnimationMeta 叠叠乐_III = new AnimationMeta("叠叠乐 III", false, 0.500, "6836319781004513805", "872828", "8c55f6c4f5abf7d41e55a77fc8f5fdad");
        public static readonly AnimationMeta 叠叠乐_IV = new AnimationMeta("叠叠乐 IV", false, 0.500, "6836319828656001550", "872830", "1b59e3f39c921c7b45f2cfa2daa6c71d");
        public static readonly AnimationMeta 叠叠乐_V = new AnimationMeta("叠叠乐 V", false, 0.500, "6836319888827486728", "872834", "9d5c1a042586999b720b9c4582f15256");
        public static readonly AnimationMeta 叠叠乐_Ⅵ = new AnimationMeta("叠叠乐 Ⅵ", false, 0.500, "6839582631345000967", "872836", "1c05ec01a8c9e8fc640a7b095ccf361d");
        public static readonly AnimationMeta 右拉镜 = new AnimationMeta("右拉镜", false, 0.500, "6772415374165021191", "471347", "0be1223dd51448374c28708e46c2f068");
        public static readonly AnimationMeta 向右下降 = new AnimationMeta("向右下降", false, 0.500, "6781683438396117517", "503138", "8941aec6123fd5424c3514402e3de777");
        public static readonly AnimationMeta 向右缩小 = new AnimationMeta("向右缩小", false, 0.500, "6772415063216099848", "471341", "3367a84172585bcfeaf4c3bb2e16bb79");
        public static readonly AnimationMeta 向左下降 = new AnimationMeta("向左下降", false, 0.500, "6760223716392571395", "447588", "c764dfbf9f82b935b807bc4420af4821");
        public static readonly AnimationMeta 向左缩小 = new AnimationMeta("向左缩小", false, 0.500, "6772415148423385607", "471343", "90c156e54a3a2c68ff282f17197e8403");
        public static readonly AnimationMeta 哈哈镜 = new AnimationMeta("哈哈镜", false, 0.500, "6832226792556728846", "748348", "eee5d8c1dd9be05badb8fecc9ec7b977");
        public static readonly AnimationMeta 哈哈镜_II = new AnimationMeta("哈哈镜 II", false, 0.500, "6832226909875606029", "748350", "87fce972209bc94afafbdaff1a806c00");
        public static readonly AnimationMeta 四格滑动 = new AnimationMeta("四格滑动", false, 0.500, "6883727868451361293", "945730", "591071275e1a96b5a82ff9c95e47d23e");
        public static readonly AnimationMeta 四格翻转 = new AnimationMeta("四格翻转", false, 0.500, "6865578846393995784", "1362932", "88c1ed96cfa3f182a341c27adc7edfdb");
        public static readonly AnimationMeta 四格转动 = new AnimationMeta("四格转动", false, 0.500, "6891835548688716302", "957940", "d6b09575f3c468b2c9b15ad3e149bad7");
        public static readonly AnimationMeta 四格转动_II = new AnimationMeta("四格转动 II", false, 0.500, "6891835601067184653", "957939", "696b72074b5476f6912d2f75c9ac923f");
        public static readonly AnimationMeta 回弹伸缩 = new AnimationMeta("回弹伸缩", false, 0.500, "6795425591014199822", "530249", "b55a407d406d39c8c34dd69178fa6699");
        public static readonly AnimationMeta 夹心饼干 = new AnimationMeta("夹心饼干", false, 0.500, "6868146033247916558", "1362936", "23091e7d56610c4253a186488657cd30");
        public static readonly AnimationMeta 夹心饼干_II = new AnimationMeta("夹心饼干 II", false, 0.500, "6868146123710665223", "1362934", "09b29b56757a17ad7ca31a57eb8b5726");
        public static readonly AnimationMeta 小火车 = new AnimationMeta("小火车", false, 0.500, "6860405888784536072", "885144", "d80771b2b33136a2b531f13bad536e08");
        public static readonly AnimationMeta 小火车_II = new AnimationMeta("小火车 II", false, 0.500, "6860406007160377863", "885143", "60609f186f005e47d27b29aa040dcc39");
        public static readonly AnimationMeta 小火车_III = new AnimationMeta("小火车 III", false, 0.500, "6860406091700769293", "885142", "e41a0312ec6ca0932ba92c163f4ad4f9");
        public static readonly AnimationMeta 小火车_IV = new AnimationMeta("小火车 IV", false, 0.500, "6860406196130550286", "885141", "e5ef14b6031eba52e9be8ff9092e093b");
        public static readonly AnimationMeta 小陀螺 = new AnimationMeta("小陀螺", false, 0.500, "6874487656969933325", "923592", "720beb8cd875bc9bb10b63515d9ac2d6");
        public static readonly AnimationMeta 小陀螺_II = new AnimationMeta("小陀螺 II", false, 0.500, "6874487735059485198", "923591", "95c42369d9e1d09e3b2d453ac0906245");
        public static readonly AnimationMeta 左右分割 = new AnimationMeta("左右分割", false, 0.500, "6886282872680878599", "948476", "3744ef4eef4fadb4630dc0674169c3d0");
        public static readonly AnimationMeta 左右分割_II = new AnimationMeta("左右分割 II", false, 0.500, "6886282936048423431", "948475", "9b880a7edbe927fd0da9a0f94829740f");
        public static readonly AnimationMeta 左拉镜 = new AnimationMeta("左拉镜", false, 0.500, "6772415248973435395", "471345", "49104c483b8eaa891e71e7a2b20c3c41");
        public static readonly AnimationMeta 弹入旋转 = new AnimationMeta("弹入旋转", false, 0.500, "6810286558826992136", "669963", "8c3498b2994796590e6d21d319a459e4");
        public static readonly AnimationMeta 形变右缩 = new AnimationMeta("形变右缩", false, 0.500, "6851395907804467720", "813139", "79bfe1364728f28383b5a4436d7a801e");
        public static readonly AnimationMeta 形变左缩 = new AnimationMeta("形变左缩", false, 0.500, "6851395726937690637", "813140", "1455b7f8a6e2970538e97046e6f2922b");
        public static readonly AnimationMeta 形变缩小 = new AnimationMeta("形变缩小", false, 0.500, "6777260789263766030", "487587", "8fb2439ce140bde6d46e40740ec29a8d");
        public static readonly AnimationMeta 悠悠球 = new AnimationMeta("悠悠球", false, 0.500, "6821451358101574152", "717346", "900be5954b07d6ef66eb6fec1606e19c");
        public static readonly AnimationMeta 悠悠球_II = new AnimationMeta("悠悠球 II", false, 0.500, "6821451462904648200", "717348", "210abff7a9bb030bef04e47317783089");
        public static readonly AnimationMeta 手机 = new AnimationMeta("手机", false, 0.500, "6861892418334102030", "1362928", "55fd386ec6f779110e3b12b89deaa79c");
        public static readonly AnimationMeta 手机_II = new AnimationMeta("手机 II", false, 0.500, "6862918279183208973", "1362926", "b861f8270870663e5c3f8bbb1fced93a");
        public static readonly AnimationMeta 手机_III = new AnimationMeta("手机 III", false, 0.500, "6862918366550561294", "1362924", "e056d0f8601d91d70e20e61bd63793f5");
        public static readonly AnimationMeta 扭曲拉伸 = new AnimationMeta("扭曲拉伸", false, 0.500, "7026278592623415822", "1426278", "ca0a43e525601adf9d14089393610d9c");
        public static readonly AnimationMeta 抖入放大 = new AnimationMeta("抖入放大", false, 0.500, "6761360765925462536", "450264", "8c01759b6ace838086122b8e2b4fc0aa");
        public static readonly AnimationMeta 拉伸扭曲 = new AnimationMeta("拉伸扭曲", false, 0.500, "7025952723027628557", "1425496", "39862f9fa5c934d72d36923f2368de4a");
        public static readonly AnimationMeta 放大弹动 = new AnimationMeta("放大弹动", false, 0.500, "7023931891363353101", "1418682", "18bfc84500372c9a49023c1a77efa6e5");
        public static readonly AnimationMeta 斜转 = new AnimationMeta("斜转", false, 0.500, "6847734302193488392", "872874", "4cc2597d961bafbd3c7877bc3f75f79a");
        public static readonly AnimationMeta 斜转_II = new AnimationMeta("斜转 II", false, 0.500, "6847734360636920327", "872876", "b37e163c186d88db144aacd6280c0811");
        public static readonly AnimationMeta 方片转动 = new AnimationMeta("方片转动", false, 0.500, "6897114113726485000", "968162", "dfc6082d56863c5e700a0a5a17102abc");
        public static readonly AnimationMeta 方片转动_II = new AnimationMeta("方片转动 II", false, 0.500, "6897114201702011405", "968161", "afdb5e78ddf7d480e78cabb527db9241");
        public static readonly AnimationMeta 旋入晃动 = new AnimationMeta("旋入晃动", false, 0.500, "6789167874511475207", "519840", "0ee3fc24d73d3d32a666c46c7f574431");
        public static readonly AnimationMeta 旋出渐隐 = new AnimationMeta("旋出渐隐", false, 0.500, "6824302025698710024", "719940", "13d85c4e8be67525a1e567121aa68170");
        public static readonly AnimationMeta 旋转上升 = new AnimationMeta("旋转上升", false, 0.500, "6813965670716281352", "691843", "56e36c8a8602ef9d2634b173ba95c75d");
        public static readonly AnimationMeta 旋转伸缩 = new AnimationMeta("旋转伸缩", false, 0.500, "6795425422046663182", "530247", "131794c7a6f15ecfde066b5e4d4e6f35");
        public static readonly AnimationMeta 旋转回吸 = new AnimationMeta("旋转回吸", false, 0.500, "6810286613898203661", "669965", "bce87aa9bfbabc1e8c97ed122fa16f49");
        public static readonly AnimationMeta 旋转缩小 = new AnimationMeta("旋转缩小", false, 0.500, "6759046644462785037", "445858", "3ae63cabefdc45ff05fb30def814c79b");
        public static readonly AnimationMeta 旋转降落 = new AnimationMeta("旋转降落", false, 0.500, "6759046515521491464", "445856", "8099feb138226b21ec8ae0a64313fa83");
        public static readonly AnimationMeta 晃动旋出 = new AnimationMeta("晃动旋出", false, 0.500, "6789167998700622350", "519842", "5b25fea3f8bd82496e39be0bb590726c");
        public static readonly AnimationMeta 水晶 = new AnimationMeta("水晶", false, 0.500, "6857333749718192654", "1362920", "de28fd5ff1c5fa607cc09306a5de1fc9");
        public static readonly AnimationMeta 水晶_II = new AnimationMeta("水晶 II", false, 0.500, "6857333869541069325", "1362922", "66d0f40fad32ba15e72d6687f12604f8");
        public static readonly AnimationMeta 波动滑出 = new AnimationMeta("波动滑出", false, 0.500, "7017646605671076359", "1392376", "c546f43ce65a4977ee11010063ee7b50");
        public static readonly AnimationMeta 海盗船 = new AnimationMeta("海盗船", false, 0.500, "6830302168751280648", "1362866", "271eda8d9ae3ff3435206719f32a6c05");
        public static readonly AnimationMeta 海盗船_II = new AnimationMeta("海盗船 II", false, 0.500, "6830302282995732999", "1362868", "13f077dc64c6c938dd8e755b0f9529bd");
        public static readonly AnimationMeta 海盗船_III = new AnimationMeta("海盗船 III", false, 0.500, "6830302335047045639", "1362872", "378d4ce23f6069e6e0752ccd6b201292");
        public static readonly AnimationMeta 海盗船_IV = new AnimationMeta("海盗船 IV", false, 0.500, "6830302424826122765", "1362870", "8bef9d70f593dfa3566ba04e8c19316b");
        public static readonly AnimationMeta 滑入波动 = new AnimationMeta("滑入波动", false, 0.500, "7023747922718102023", "1418546", "7c4a80c235da2050b672f66a0a9e54b3");
        public static readonly AnimationMeta 滑滑梯 = new AnimationMeta("滑滑梯", false, 0.500, "6828829568879563271", "741020", "45a18cb8ead63a3b6a87731adf6ac79e");
        public static readonly AnimationMeta 滑滑梯_II = new AnimationMeta("滑滑梯 II", false, 0.500, "6828829741013799432", "741022", "9c669766b045f246772095114c5ef594");
        public static readonly AnimationMeta 百叶窗 = new AnimationMeta("百叶窗", false, 0.500, "6771299961171612174", "467361", "f6f38be419308a9134467d26829576af");
        public static readonly AnimationMeta 百叶窗_II = new AnimationMeta("百叶窗 II", false, 0.500, "6782101071402635790", "506768", "9812eeaceca9d8a1adba077c8c35c06b");
        public static readonly AnimationMeta 碎块滑动 = new AnimationMeta("碎块滑动", false, 0.500, "6778405418969338382", "490068", "218746bfacd737cf075912452a10100d");
        public static readonly AnimationMeta 碎块滑动_II = new AnimationMeta("碎块滑动 II", false, 0.500, "6778300107113632269", "489860", "1abb69885123e9c59fe5f872c586d17a");
        public static readonly AnimationMeta 立方体 = new AnimationMeta("立方体", false, 0.500, "6837352063496622599", "872856", "71ae450afeb88ae2620473ab790acf0e");
        public static readonly AnimationMeta 立方体_II = new AnimationMeta("立方体 II", false, 0.500, "6834812485023830535", "872858", "efc0e23b864f5fcfbaa77723044c4957");
        public static readonly AnimationMeta 立方体_III = new AnimationMeta("立方体 III", false, 0.500, "6834812541118452237", "872860", "dfc2e372bc454764f0b355904542e228");
        public static readonly AnimationMeta 立方体_IV = new AnimationMeta("立方体 IV", false, 0.500, "6841793140949520910", "872864", "c66bf1692fe1e6bd6dd2e49eddfcd0c0");
        public static readonly AnimationMeta 立方体_V = new AnimationMeta("立方体 V", false, 0.500, "6841793224663634446", "873096", "e3935dbcaf28be18a598eebb8fb79161");
        public static readonly AnimationMeta 绕圈圈 = new AnimationMeta("绕圈圈", false, 0.500, "6850287838441771534", "872868", "98bfd8ca3177b85246b18502832232f0");
        public static readonly AnimationMeta 绕圈圈_II = new AnimationMeta("绕圈圈 II", false, 0.500, "6850287920255865357", "872872", "10eaa3db7b761a9846764a53912d7c77");
        public static readonly AnimationMeta 绕圈圈_III = new AnimationMeta("绕圈圈 III", false, 0.500, "6854782718975152653", "872918", "c2e7ff02916f19a13ada361abddb8f98");
        public static readonly AnimationMeta 绕圈圈_IV = new AnimationMeta("绕圈圈 IV", false, 0.500, "6854782786553778695", "872920", "1e7d503bcf05a17f175759e5c6cfbe7b");
        public static readonly AnimationMeta 缩小弹动 = new AnimationMeta("缩小弹动", false, 0.500, "7017689072978104869", "1392530", "bca5ca47f6f33268fb1de55fa8946519");
        public static readonly AnimationMeta 缩小旋转 = new AnimationMeta("缩小旋转", false, 0.500, "6760119657429996046", "447318", "b5791968245b8246c3e87e4d9816cd3b");
        public static readonly AnimationMeta 缩小转出 = new AnimationMeta("缩小转出", false, 0.500, "6805018974070247950", "638823", "08ab26276c336b284d07b336d5c32aad");
        public static readonly AnimationMeta 缩放 = new AnimationMeta("缩放", false, 0.500, "6759078592740594184", "446078", "091f668bbb6406305614f9de55bf4aa6");
        public static readonly AnimationMeta 缩放_II = new AnimationMeta("缩放 II", false, 0.500, "6779083172429697544", "493000", "bb460b0c6a3c424618718276b25a812b");
        public static readonly AnimationMeta 翻转 = new AnimationMeta("翻转", false, 0.500, "6843309964732142094", "872838", "5f153d35f1c3098fef8325badc40c5e8");
        public static readonly AnimationMeta 翻转_II = new AnimationMeta("翻转 II", false, 0.500, "6843310029689328135", "872840", "befc44f24a2747201d1d75e6a29753ce");
        public static readonly AnimationMeta 翻转_III = new AnimationMeta("翻转 III", false, 0.500, "6843310084743762446", "872842", "b8167fc9e9deb2f638788bfc7539ed7f");
        public static readonly AnimationMeta 翻转_IV = new AnimationMeta("翻转 IV", false, 0.500, "6843310129736061447", "872844", "9636ccab84e8f2c357812a38b785f6e0");
        public static readonly AnimationMeta 翻转_V = new AnimationMeta("翻转 V", false, 0.500, "6843310237902967304", "872848", "4d27983b5b2899b46334d3fd999bc7d8");
        public static readonly AnimationMeta 翻转_VI = new AnimationMeta("翻转 VI", false, 0.500, "6843310299991249421", "872850", "8807b174b58ee897667c08e6bee1a4f8");
        public static readonly AnimationMeta 荡秋千 = new AnimationMeta("荡秋千", false, 0.500, "6811007755785081357", "680643", "565256202d17fda9af7f56e27d099543");
        public static readonly AnimationMeta 荡秋千_II = new AnimationMeta("荡秋千 II", false, 0.500, "6811007833069326862", "680645", "212f5f11d11ee19690df59a096b7c3f8");
        public static readonly AnimationMeta 转入转出 = new AnimationMeta("转入转出", false, 0.500, "6805012562174808590", "638793", "3d26d9df896b72d5ac3926828afcd791");
        public static readonly AnimationMeta 转入转出_II = new AnimationMeta("转入转出 II", false, 0.500, "6818747242258633224", "701967", "ec4ed56911472b95462e4b0b8ac6a103");
        public static readonly AnimationMeta 转圈圈 = new AnimationMeta("转圈圈", false, 0.500, "6829129745226011144", "741502", "40d9b656e338f39f8eb2a7d27a85e036");
        public static readonly AnimationMeta 过山车 = new AnimationMeta("过山车", false, 0.500, "6870060878234915342", "911862", "64e30d2e2577f6a95313ed806807baa7");
        public static readonly AnimationMeta 过山车_II = new AnimationMeta("过山车 II", false, 0.500, "6870060932928639501", "911861", "240042ee2b35aaa7f30b6e0c03e9ac4c");
        public static readonly AnimationMeta 降落旋转 = new AnimationMeta("降落旋转", false, 0.500, "6759075297091392007", "446076", "c5c1d37924b58b5c1e5355db14e72372");
        public static readonly AnimationMeta 魔方 = new AnimationMeta("魔方", false, 0.500, "6870060995365048840", "1362938", "b104d21e0f1b7eb044946f6bf0be1133");
        public static readonly AnimationMeta 魔方_II = new AnimationMeta("魔方 II", false, 0.500, "6870061049559650829", "1362940", "53bc750124a30d746adbf44151116fde");

        // 付费
        public static readonly AnimationMeta 分身 = new AnimationMeta("分身", true, 0.500, "6883761132645913096", "945872", "de31f6d54856f05a0824eab7afac58e7");
        public static readonly AnimationMeta 分身_II = new AnimationMeta("分身 II", true, 0.500, "6883761226950644231", "945871", "22ce9336e5716a87d6a2a980f6b84e78");
        public static readonly AnimationMeta 动感摇晃I = new AnimationMeta("动感摇晃I", true, 0.500, "7173927429394666020", "6983415", "ceb6b5bf10aab23f1066481cefd5adfb");
        public static readonly AnimationMeta 动感摇晃II = new AnimationMeta("动感摇晃II", true, 100.000, "7175103054956466744", "7129471", "4e88c30adc92ca2809d285ab67276467");
        public static readonly AnimationMeta 四格滑动_II = new AnimationMeta("四格滑动 II", true, 0.500, "6883727923845534216", "945729", "e8d17f7948b2805f284d82d6a6992302");
        public static readonly AnimationMeta 四格翻转_II = new AnimationMeta("四格翻转 II", true, 0.500, "6865579178599649806", "1362930", "840aa022c0a9b3b6b4876dd7084372b7");
        public static readonly AnimationMeta 回忆旋转 = new AnimationMeta("回忆旋转", true, 0.500, "7186961278022193722", "8300599", "fa3c068a56733a2149d5c0d03560aad8");
        public static readonly AnimationMeta 坠落 = new AnimationMeta("坠落", true, 0.500, "7235902373971890747", "14020637", "0049e2c104b1ae46dbf717ea73b71234");
        public static readonly AnimationMeta 弹动冲屏 = new AnimationMeta("弹动冲屏", true, 0.500, "7200308690904158778", "9491799", "cc01a66ec4b316b7342fe8fd5cfe5e87");
        public static readonly AnimationMeta 波动吸收 = new AnimationMeta("波动吸收", true, 0.500, "7107468232390349349", "2786424", "ddbc0f962c69263480e6d188bf2f4b63");
        public static readonly AnimationMeta 波动放大 = new AnimationMeta("波动放大", true, 0.500, "7111631619768717860", "3113716", "90f87e49deba3845d73b5855dc3fa442");
        public static readonly AnimationMeta 相框滑动 = new AnimationMeta("相框滑动", true, 0.500, "7206139216038728248", "10166295", "517a71d78782ebc9a9718acfb865fba9");
        public static readonly AnimationMeta 红酒摇晃 = new AnimationMeta("红酒摇晃", true, 0.800, "6903771548436402702", "1417022", "95d79896a437524c4f94dc2902bb3b6c");
        public static readonly AnimationMeta 跳跳糖 = new AnimationMeta("跳跳糖", true, 0.700, "7199944821098680890", "9432783", "fc4e0cc6a2f2c775659fa9493cff9fe8");
        public static readonly AnimationMeta 闪光放大 = new AnimationMeta("闪光放大", true, 0.500, "7166437469909422623", "6210029", "a6495ac2010a3caae003517edcc1d5bc");
        public static readonly AnimationMeta 闪光放大_II = new AnimationMeta("闪光放大 II", true, 0.500, "7166437532568130055", "6210033", "90ad69d3ad224c6e7234ad9ba9eb1467");
    }

    //文字入场动画, 默认时长为0.5秒
    public static class Text_intro
    {
        //免费
        public static readonly AnimationMeta 冲屏位移 = new AnimationMeta("冲屏位移", false, 0.0, "7078181271393800711", "1643884", "fd73ffc26a3f02fa6d957a94b590623a");
        public static readonly AnimationMeta 卡拉OK = new AnimationMeta("卡拉OK", false, 0.0, "6771294855785091588", "1558840", "a6d37c370a463070046c5d9feb0f9dfb");
        public static readonly AnimationMeta 变色输入 = new AnimationMeta("变色输入", false, 0.0, "7397306443147252233", "77035159", "e0e29d6ea015f0d1d38b4a852a1b6202");
        public static readonly AnimationMeta 右上弹入 = new AnimationMeta("右上弹入", false, 0.0, "7074854080388010532", "1621978", "932ea0a91ca337bc1fd566aa17cb9aa7");
        public static readonly AnimationMeta 右下擦开 = new AnimationMeta("右下擦开", false, 0.0, "7088576340361744903", "1715294", "70a3ffbff2b02ede796ee38d95b38db2");
        public static readonly AnimationMeta 向上擦除 = new AnimationMeta("向上擦除", false, 0.0, "6774625910067827212", "1644272", "ee74a3a8afb2167f4403dee957338afe");
        public static readonly AnimationMeta 向上滑动 = new AnimationMeta("向上滑动", false, 0.0, "6763470111253729803", "1644267", "22030c473076074288fd01b17d1c6174");
        public static readonly AnimationMeta 向上翻转 = new AnimationMeta("向上翻转", false, 0.0, "7194703971498332727", "8945307", "0cf2050093a2bbe736ab4b2ee9002dcf");
        public static readonly AnimationMeta 向上重叠 = new AnimationMeta("向上重叠", false, 0.0, "7077500533040222756", "1639676", "b3ea1be4937b7cd032f1775d98b1f06e");
        public static readonly AnimationMeta 向上露出 = new AnimationMeta("向上露出", false, 0.0, "7163514358935327268", "5925717", "3786ff3fcc9795eead5fd5629ff7e4e9");
        public static readonly AnimationMeta 向下擦除 = new AnimationMeta("向下擦除", false, 0.0, "6774626192990409224", "1644273", "bfe1add2d59ee32449a979257d4a3448");
        public static readonly AnimationMeta 向下滑动 = new AnimationMeta("向下滑动", false, 0.0, "6724921985282871816", "1644268", "f5506a1b5ebcf9d0636d7809bf3cb81a");
        public static readonly AnimationMeta 向下露出 = new AnimationMeta("向下露出", false, 0.0, "7163514502128865823", "5925716", "a7b05a11c6bdc7010cc4dc7f1d276407");
        public static readonly AnimationMeta 向下飞入 = new AnimationMeta("向下飞入", false, 0.0, "7088942186561016356", "1719670", "b312472b5a680f49d2d1229cfe07f49d");
        public static readonly AnimationMeta 向右擦除 = new AnimationMeta("向右擦除", false, 0.0, "6771288500240126478", "1644271", "b4a5ba027822ca3e1c9d83d2f5a58a08");
        public static readonly AnimationMeta 向右滑动 = new AnimationMeta("向右滑动", false, 0.0, "6724920136056181256", "1644266", "c49f75ef6e0f886e570f68a00f7c1312");
        public static readonly AnimationMeta 向右缓入 = new AnimationMeta("向右缓入", false, 0.0, "7043778124760224292", "1488722", "2d751bb706b38a030ab7eb3382b2d248");
        public static readonly AnimationMeta 向右集合 = new AnimationMeta("向右集合", false, 0.0, "7081206983461704199", "1661186", "5a78f1024ecdc9a6b69220eac58a0963");
        public static readonly AnimationMeta 向右露出 = new AnimationMeta("向右露出", false, 0.0, "7163514730525495839", "5925714", "6f8e0a5cd98c44b79f9ec09b0b913059");
        public static readonly AnimationMeta 向左擦除 = new AnimationMeta("向左擦除", false, 0.0, "6774626830038077960", "1644270", "4db856992dc60d1220664165d4130042");
        public static readonly AnimationMeta 向左滑动 = new AnimationMeta("向左滑动", false, 0.0, "6763470195894784525", "1644277", "13c954ed3bc583f87e9f79a2325b8e84");
        public static readonly AnimationMeta 向左露出 = new AnimationMeta("向左露出", false, 0.0, "7163514612690719269", "5925715", "b4119cf3405c71bc556e1c5562e22d01");
        public static readonly AnimationMeta 圆形扫描 = new AnimationMeta("圆形扫描", false, 0.0, "6840689010034086407", "1644280", "ac77daf80de65a4beb1164ce44c500c5");
        public static readonly AnimationMeta 复古打字机 = new AnimationMeta("复古打字机", false, 0.0, "7253888335163167291", "17639720", "a69db3276f15fa2affcd98f2236c873d");
        public static readonly AnimationMeta 居中打字 = new AnimationMeta("居中打字", false, 0.0, "7265222187286532667", "20303987", "40f484d3b77321b38d53b30d94c2dce1");
        public static readonly AnimationMeta 左上弹入 = new AnimationMeta("左上弹入", false, 0.0, "7078586233030447629", "1646760", "6467514ec2a8740953d29c3915364a31");
        public static readonly AnimationMeta 左移弹动 = new AnimationMeta("左移弹动", false, 0.0, "7313890082040058406", "35176342", "c21d4019453137cd76e0d847d5d8af96");
        public static readonly AnimationMeta 开幕 = new AnimationMeta("开幕", false, 0.0, "6835571502050447879", "1644279", "99a6fdf1f3b43b15b70c31427e09c8a5");
        public static readonly AnimationMeta 弹入 = new AnimationMeta("弹入", false, 0.0, "6887482184844710413", "1644313", "0533e3aeb2cda562cdd8a86693815443");
        public static readonly AnimationMeta 弹弓 = new AnimationMeta("弹弓", false, 0.0, "6862897343176380942", "1644305", "f9300b314e5bd7df573063b15a1ab081");
        public static readonly AnimationMeta 弹性伸缩 = new AnimationMeta("弹性伸缩", false, 0.0, "6872642189260755463", "1644311", "7d23b7a68a1bf21c7692a35ffa6ddcdc");
        public static readonly AnimationMeta 弹簧 = new AnimationMeta("弹簧", false, 0.0, "6884154692398486023", "1644312", "34d74f1bf451dac1a23158380a5be322");
        public static readonly AnimationMeta 彩色映射 = new AnimationMeta("彩色映射", false, 0.0, "7039655272222036516", "1476514", "46f37098540b9250abdad9bb1282ec83");
        public static readonly AnimationMeta 打字机_I = new AnimationMeta("打字机 I", false, 0.0, "6724920249654710791", "1644275", "7c7cfe92aa22a8e131c94d20f44e97df");
        public static readonly AnimationMeta 打字机_II = new AnimationMeta("打字机 II", false, 0.0, "6724920636403094028", "1644276", "42996c18d556c4de18cc3dc2c7387158");
        public static readonly AnimationMeta 打字机_III = new AnimationMeta("打字机 III", false, 0.0, "6724920521462387207", "1644335", "1b21dfb54b0ccd50e50f383f01d0a193");
        public static readonly AnimationMeta 打字机IV = new AnimationMeta("打字机IV", false, 0.0, "7237409385092223525", "14235879", "6828d67634e66ace1e76c4eb7cc2f8e6");
        public static readonly AnimationMeta 扭曲模糊 = new AnimationMeta("扭曲模糊", false, 0.0, "7089261793406620197", "1722114", "40a9fd02e81930bc0289aeb692c382f6");
        public static readonly AnimationMeta 拖尾 = new AnimationMeta("拖尾", false, 0.0, "7244102915239973432", "15259479", "40884dac1fc802d207c69b05e2987d4d");
        public static readonly AnimationMeta 收拢 = new AnimationMeta("收拢", false, 0.0, "6779879712261935619", "1644261", "b173da2fb68d5f8e7dbb2cc000a50bdd");
        public static readonly AnimationMeta 放大 = new AnimationMeta("放大", false, 0.0, "6724919499042066958", "1644264", "cf0f072aa31d3884ba90362af063f55a");
        public static readonly AnimationMeta 故障打字机 = new AnimationMeta("故障打字机", false, 0.0, "6870061463243854350", "1644308", "b4536942105b69e637dabef4c3ebfc6d");
        public static readonly AnimationMeta 旋入 = new AnimationMeta("旋入", false, 0.0, "6763873859402732039", "1644265", "dc3a54158c51f45a0033a16f5763e047");
        public static readonly AnimationMeta 日出 = new AnimationMeta("日出", false, 0.0, "6779084126457696776", "1644269", "9e39257e0d8b60598d1c09bb31fbc62a");
        public static readonly AnimationMeta 晕开 = new AnimationMeta("晕开", false, 0.0, "7088531060341871141", "1714696", "2f7aebf0f525ef21f8b00070c17d2fc2");
        public static readonly AnimationMeta 模糊 = new AnimationMeta("模糊", false, 0.0, "6923094735116571150", "1644338", "0e57ec99758f1e12636a73c6ec4fb6f5");
        public static readonly AnimationMeta 水墨晕开 = new AnimationMeta("水墨晕开", false, 0.0, "7278295995362841145", "22734325", "5c970b17e18e3441b917a7bcba4d043b");
        public static readonly AnimationMeta 水平翻转 = new AnimationMeta("水平翻转", false, 0.0, "7051512227353858590", "1644340", "9403a81925b4886589f745130a67cb05");
        public static readonly AnimationMeta 波浪弹入 = new AnimationMeta("波浪弹入", false, 0.0, "6917178744775905806", "1644316", "301272b44278c3b5ebe228e8baa8d984");
        public static readonly AnimationMeta 渐显 = new AnimationMeta("渐显", false, 0.0, "6724916044072227332", "1644304", "40859aa05ff9f3e3a3f0de7bfead1c42");
        public static readonly AnimationMeta 溶解 = new AnimationMeta("溶解", false, 0.0, "6872642398095151629", "1644310", "162408e430501a31662f901c51476e59");
        public static readonly AnimationMeta 滑动上升 = new AnimationMeta("滑动上升", false, 0.0, "7275687883011265083", "22226771", "9ab223e5e9a0b9611b04062048173de9");
        public static readonly AnimationMeta 生长 = new AnimationMeta("生长", false, 0.0, "6869302248103481869", "1644307", "b0f76f716f571ecde209056995e96978");
        public static readonly AnimationMeta 甩出 = new AnimationMeta("甩出", false, 0.0, "7244102679851438650", "15261071", "97162e8faa56cf163b8f2c1bfd5ad6e0");
        public static readonly AnimationMeta 站起 = new AnimationMeta("站起", false, 0.0, "7265288917279052344", "20324364", "6f322d7bb7fe6b443197c2bf5d64dd8b");
        public static readonly AnimationMeta 缩小 = new AnimationMeta("缩小", false, 0.0, "6724921217721045515", "1644263", "0b58ad7d0d7cc93080e7bedfd0caa222");
        public static readonly AnimationMeta 缩小_II = new AnimationMeta("缩小 II", false, 0.0, "7041836555903701540", "1644341", "ae803da2a5d2292e0f8be3c8ab3b3788");
        public static readonly AnimationMeta 羽化向右擦开 = new AnimationMeta("羽化向右擦开", false, 0.0, "6897084405781631496", "1644314", "d330712b8f96ce33d450489ea6e459a3");
        public static readonly AnimationMeta 羽化向左擦开 = new AnimationMeta("羽化向左擦开", false, 0.0, "6897084292908716557", "1644315", "a4eefe0afe41cd05acd1beb3d2615b23");
        public static readonly AnimationMeta 翻动 = new AnimationMeta("翻动", false, 0.0, "7308278898330964489", "32283659", "c863f3afe0d73cccc19188d6313b1dae");
        public static readonly AnimationMeta 轻微放大 = new AnimationMeta("轻微放大", false, 0.0, "6763469998330483213", "1644262", "6f5ec0bb82bfd24a72706e2006c0e806");
        public static readonly AnimationMeta 逐字旋转 = new AnimationMeta("逐字旋转", false, 0.0, "7111643562676064805", "3114660", "17a78b3b5c193a3e30431946a8cbd696");
        public static readonly AnimationMeta 逐字显影 = new AnimationMeta("逐字显影", false, 0.0, "7038882772450021896", "1644339", "2f250516dcea1a591656dabc9c40684f");
        public static readonly AnimationMeta 逐字翻转 = new AnimationMeta("逐字翻转", false, 0.0, "7112241904216969765", "3138860", "cdf2df541dea807f4bcb29ede73dd766");
        public static readonly AnimationMeta 闪动 = new AnimationMeta("闪动", false, 0.0, "7035902226602136071", "1644322", "8a1581c846a5933e8a90204219504892");
        public static readonly AnimationMeta 随机弹跳 = new AnimationMeta("随机弹跳", false, 0.0, "7021831463867781662", "1644321", "d49f117c117e7d6b4dcb53bbe9b5ed4a");
        public static readonly AnimationMeta 随机飞入 = new AnimationMeta("随机飞入", false, 0.0, "6872642542765085191", "1644309", "d9ad3796df2b0881ea144f8dfa44e0b1");

        // 付费
        public static readonly AnimationMeta 乱码故障 = new AnimationMeta("乱码故障", true, 0.0, "7325648367747338802", "40877554", "00b40103690bfb45e0125592b6ec0f5c");
        public static readonly AnimationMeta 二段缩放 = new AnimationMeta("二段缩放", true, 0.0, "7238519092997526074", "14394713", "a4cba6840c1bf92bc73bb1bcacf7b76e");
        public static readonly AnimationMeta 便利贴 = new AnimationMeta("便利贴", true, 0.0, "7307207886843679283", "31819229", "4e9265ea4703be87feaf640d79b23f7c");
        public static readonly AnimationMeta 倒数 = new AnimationMeta("倒数", true, 0.0, "7314303157360661018", "35401566", "814df0b29746943fe165ae9b16719cc2");
        public static readonly AnimationMeta 兔子弹跳 = new AnimationMeta("兔子弹跳", true, 0.0, "7187785892382118461", "8398145", "5d157129853f479ea15f75075c1ef070");
        public static readonly AnimationMeta 冰雪飘动 = new AnimationMeta("冰雪飘动", true, 0.0, "7314291622525538843", "35395178", "69dcdf8547a23b2cc92e566ab5e266ec");
        public static readonly AnimationMeta 发光闪入 = new AnimationMeta("发光闪入", true, 0.0, "7308272157442707978", "32278776", "bf803f5695c3775cd2e58797c9c8d229");
        public static readonly AnimationMeta 叠影并入 = new AnimationMeta("叠影并入", true, 0.0, "7259634012774208059", "19101418", "8358578022cd14c6232a99ddee035824");
        public static readonly AnimationMeta 向上弹入 = new AnimationMeta("向上弹入", true, 0.0, "7123116334677758501", "3704299", "28d9145ead32c23742082a37e511370e");
        public static readonly AnimationMeta 向下溶解 = new AnimationMeta("向下溶解", true, 0.0, "7028458557058060831", "1644318", "09fde2de891d18c74949e025bc0dca07");
        public static readonly AnimationMeta 向右模糊_II = new AnimationMeta("向右模糊 II", true, 0.0, "7254503374622560828", "17830700", "6b3c54ef781f16f20204d766b799abec");
        public static readonly AnimationMeta 向左模糊 = new AnimationMeta("向左模糊", true, 0.0, "7112368349257929230", "3147126", "ee5716b5bf9ef16fd99dd7d2d89dbefc");
        public static readonly AnimationMeta 吸入 = new AnimationMeta("吸入", true, 0.0, "7120438380453696031", "3576973", "42a0c7e42275986d92a2d3bbe55dd816");
        public static readonly AnimationMeta 呐喊声波 = new AnimationMeta("呐喊声波", true, 0.0, "7199943069385364005", "9432429", "6f5992c1f47cac9d33468c5e60725d0b");
        public static readonly AnimationMeta 喷绘 = new AnimationMeta("喷绘", true, 0.0, "7120131223036367367", "3563651", "77633d8638e177488dcce84086018c8a");
        public static readonly AnimationMeta 圆柱体滚动 = new AnimationMeta("圆柱体滚动", true, 0.0, "7179035729043919397", "7548913", "7ce47010b9b736d12d264cf73f6c294e");
        public static readonly AnimationMeta 圣诞帽弹跳 = new AnimationMeta("圣诞帽弹跳", true, 0.0, "7169419861158793759", "6492065", "e5de917f45c938a685b73a9e0bb464e1");
        public static readonly AnimationMeta 圣诞树弹跳II = new AnimationMeta("圣诞树弹跳II", true, 0.0, "7174706243267727930", "7080877", "c9be0fbb72056234cdc5f8e082f32c40");
        public static readonly AnimationMeta 弹入跳动 = new AnimationMeta("弹入跳动", true, 0.0, "7184797276181631546", "8058189", "18c035845489b1f6c9a4ffcaf0ec1145");
        public static readonly AnimationMeta 弹性伸缩_II = new AnimationMeta("弹性伸缩 II", true, 0.0, "7308272646913790490", "32279178", "9b0bdc149bbc541e93cddaf94b1dcaa0");
        public static readonly AnimationMeta 心动瞬间 = new AnimationMeta("心动瞬间", true, 0.0, "7332519885999706663", "44271866", "2438d9132c7b04552762ae54066f7d94");
        public static readonly AnimationMeta 慢速放大 = new AnimationMeta("慢速放大", true, 0.0, "7205177922280231479", "10063675", "33d85f938bd55928fa16bede8cf7a26b");
        public static readonly AnimationMeta 打字光标 = new AnimationMeta("打字光标", true, 0.0, "7237411357514011192", "14235878", "12196518b89652860631d196d19b6f45");
        public static readonly AnimationMeta 抖动甩入 = new AnimationMeta("抖动甩入", true, 0.0, "7301945752278798885", "29825712", "8e49d8dde0112aaf071d41e8a56527e1");
        public static readonly AnimationMeta 折叠 = new AnimationMeta("折叠", true, 0.0, "7125298122011447816", "3779439", "9f65c45595fa8c0002f7f49a61637ff2");
        public static readonly AnimationMeta 描边填充 = new AnimationMeta("描边填充", true, 0.0, "7308269965453300262", "32278219", "cb8300f18fdf8b9aab7c1eacd33e92c9");
        public static readonly AnimationMeta 放大震动 = new AnimationMeta("放大震动", true, 0.0, "7267849370727354936", "20801300", "e6f8542e114dcb8b7aea821b1c954941");
        public static readonly AnimationMeta 故障闪动 = new AnimationMeta("故障闪动", true, 0.0, "7244101806710592057", "15261571", "f0c64727504b3975b4656ee2b10760fb");
        public static readonly AnimationMeta 新年打字机 = new AnimationMeta("新年打字机", true, 0.0, "7272754730684650045", "21711818", "a5aa35ae2b69f85c944074dfeadd6c89");
        public static readonly AnimationMeta 旋转缩放 = new AnimationMeta("旋转缩放", true, 0.0, "7243633588493619773", "15140845", "cef0ccebe3406f4c53b64f39825b7bfa");
        public static readonly AnimationMeta 旋转飞入 = new AnimationMeta("旋转飞入", true, 0.0, "6775803763652301326", "1644274", "21984d5e90731f925fc58a59fef355ee");
        public static readonly AnimationMeta 星光闪闪 = new AnimationMeta("星光闪闪", true, 0.0, "7309036302962266675", "32665781", "269e1b23d766c0a3c5c9f792dedfd1a9");
        public static readonly AnimationMeta 星光闪闪_II = new AnimationMeta("星光闪闪 II", true, 0.0, "7319873264375829001", "38428077", "8cddcc9ff610948afbd705259cec8fa9");
        public static readonly AnimationMeta 星星弹跳 = new AnimationMeta("星星弹跳", true, 0.0, "7307189517562155547", "31799385", "e5a1520dee5dd3700da60c62743111e4");
        public static readonly AnimationMeta 模糊发光 = new AnimationMeta("模糊发光", true, 0.0, "7301535952101446170", "29690460", "ea9d91ad5b58f1f9a1e95264f77e9a15");
        public static readonly AnimationMeta 模糊滚动 = new AnimationMeta("模糊滚动", true, 0.0, "7264501462187643450", "20154968", "3eaa7038a9148548a6b2cc6673f77944");
        public static readonly AnimationMeta 模糊缩小 = new AnimationMeta("模糊缩小", true, 0.0, "7294147761765618186", "27144470", "203197cc1ea7d4e7dfb0f24bd256e9fd");
        public static readonly AnimationMeta 汇聚 = new AnimationMeta("汇聚", true, 0.0, "6986931575199896094", "5529369", "2774ee332a759084eaa558bad0cb3a44");
        public static readonly AnimationMeta 波浪弹跳 = new AnimationMeta("波浪弹跳", true, 0.0, "7317536986691015218", "37303562", "e5b79c83b4a12edb15d2389a83c51476");
        public static readonly AnimationMeta 流光扩散 = new AnimationMeta("流光扩散", true, 0.0, "7314566361642963493", "35505526", "49e6ab3f128387addaba317fb98cbed3");
        public static readonly AnimationMeta 滚入 = new AnimationMeta("滚入", true, 0.0, "7026674824537707038", "1644320", "d631585b87e866b31fe20fa8d578b7cd");
        public static readonly AnimationMeta 激光雕刻 = new AnimationMeta("激光雕刻", true, 0.0, "7244102612700631589", "15261101", "affa14b4f89ceb4dd01a69a24b42651f");
        public static readonly AnimationMeta 爱心弹跳 = new AnimationMeta("爱心弹跳", true, 0.0, "6845191009861636616", "1644337", "711434e690c1a1d7ebca4f13b1712f85");
        public static readonly AnimationMeta 玩雪 = new AnimationMeta("玩雪", true, 0.0, "7304943429962699290", "30904546", "501ea62f0702ab65569aa0e923bd8182");
        public static readonly AnimationMeta 环绕滑入 = new AnimationMeta("环绕滑入", true, 0.0, "7261858654561767973", "19562189", "672aae4e963ac36d9b898cb32c964995");
        public static readonly AnimationMeta 生长_II = new AnimationMeta("生长 II", true, 0.0, "7210312869282320933", "10659499", "562300bfab6b00c4853118b058f429a2");
        public static readonly AnimationMeta 电光 = new AnimationMeta("电光", true, 0.0, "7296051582246851109", "27769111", "04055d0e0520eb74c7047073e98fcf9a");
        public static readonly AnimationMeta 电光_II = new AnimationMeta("电光 II", true, 0.0, "7299364098788037171", "28928614", "8c30a310e9ce5bf2b7b5a324c9426b7c");
        public static readonly AnimationMeta 碰碰车 = new AnimationMeta("碰碰车", true, 0.0, "7338602211041088027", "47157536", "ce6822887e702ad1a4b762e267148e38");
        public static readonly AnimationMeta 空翻 = new AnimationMeta("空翻", true, 0.0, "6865175746420150792", "1644306", "c16d544824d736ad0be1a5e109aafc04");
        public static readonly AnimationMeta 缤纷冲屏 = new AnimationMeta("缤纷冲屏", true, 0.0, "7116829842271638053", "3894473", "f6b8859c215e255b61f70cdbcc239b98");
        public static readonly AnimationMeta 缩放_III = new AnimationMeta("缩放 III", true, 0.0, "7211036012401660473", "10743073", "d625a4ef458b7e8c5928cdf04ab952ac");
        public static readonly AnimationMeta 翻页II = new AnimationMeta("翻页II", true, 0.0, "7170343439832191519", "6599721", "69d372ee41a3c968e0a7b55382eb23ff");
        public static readonly AnimationMeta 背景滑入 = new AnimationMeta("背景滑入", true, 0.0, "7306794354255860250", "31601883", "69c170b50c062f8106c01b37682fe19f");
        public static readonly AnimationMeta 色散拖影 = new AnimationMeta("色散拖影", true, 0.0, "7340513927651922458", "48159236", "422b57c27cfd659d0756303189e11599");
        public static readonly AnimationMeta 螺旋上升 = new AnimationMeta("螺旋上升", true, 0.0, "6799873891352187406", "1644278", "d3e255df67130866e0d2de42a703637c");
        public static readonly AnimationMeta 跃进 = new AnimationMeta("跃进", true, 0.0, "7220685840442200634", "11996999", "40bdc1263417f53c712c54cb32438008");
        public static readonly AnimationMeta 跳跳捣蛋鬼 = new AnimationMeta("跳跳捣蛋鬼", true, 0.0, "7200340219109839419", "9503089", "897a0c194e07ace6813a2eba797ac22f");
        public static readonly AnimationMeta 跳跳糖 = new AnimationMeta("跳跳糖", true, 0.0, "7329815894933115432", "42866461", "c8ecf2f107002df92dcefec6ea988843");
        public static readonly AnimationMeta 辉光 = new AnimationMeta("辉光", true, 0.0, "7258179345192063525", "18786330", "cf0046a1d95bfc038ff7982a5dff2abb");
        public static readonly AnimationMeta 辉光扫描 = new AnimationMeta("辉光扫描", true, 0.0, "7316878401590006323", "36927710", "f9a2c9ae931b916a81f204a1b9c31f7c");
        public static readonly AnimationMeta 逐字弹跳 = new AnimationMeta("逐字弹跳", true, 0.0, "7197615431673188921", "9195301", "52b151b0021d9fa91a42e65c2a392517");
        public static readonly AnimationMeta 逐字旋入 = new AnimationMeta("逐字旋入", true, 0.0, "7229520427196879421", "13137035", "9838c6772ddbd48126f30baf74200f99");
        public static readonly AnimationMeta 金粉飘落 = new AnimationMeta("金粉飘落", true, 0.0, "7330561002922054196", "43242964", "25d1da238cd78c05757f2d6036dec895");
        public static readonly AnimationMeta 镂空跳入 = new AnimationMeta("镂空跳入", true, 0.0, "7311620091060163082", "33984693", "6acf25a6cbbe3f564b4ff1a8c666a10f");
        public static readonly AnimationMeta 闪烁集合 = new AnimationMeta("闪烁集合", true, 0.0, "7267886380439573029", "20805754", "6d86be731c4d735a5e612a45b0c8631a");
        public static readonly AnimationMeta 随机上升 = new AnimationMeta("随机上升", true, 0.0, "7233662263805088314", "13720553", "98142c53838b5a382f79cc2d89e30c04");
        public static readonly AnimationMeta 随机弹跳_II = new AnimationMeta("随机弹跳 II", true, 0.0, "7114189305781686797", "3241034", "ff0761c602fa5ec8cc31c48ce57ea003");
        public static readonly AnimationMeta 随机打字机 = new AnimationMeta("随机打字机", true, 0.0, "6926718978064650760", "1644317", "e1f7899554d34dfa3e1e4924f82acc69");
        public static readonly AnimationMeta 随机落下 = new AnimationMeta("随机落下", true, 0.0, "7231443875406025275", "13416707", "a3aa7aa5991ef3c6a3d83a2e1fc6b748");
        public static readonly AnimationMeta 随机集合 = new AnimationMeta("随机集合", true, 0.0, "7223959789175312954", "12416139", "4d1fa3b7aac9aeab107743db10372029");
        public static readonly AnimationMeta 雪光模糊 = new AnimationMeta("雪光模糊", true, 0.0, "7314614905196253705", "35545508", "cb35d22175f67f734290b48bdaf93dd6");
        public static readonly AnimationMeta 音符弹跳 = new AnimationMeta("音符弹跳", true, 0.0, "6841115718172283406", "1644336", "86c6e9061b14fd43049b6232ffc113fa");
        public static readonly AnimationMeta 顶出 = new AnimationMeta("顶出", true, 0.0, "7268221856618910264", "20880936", "7fd6da0e6ff8a46276648dc43faa4f95");
        public static readonly AnimationMeta 预览打字 = new AnimationMeta("预览打字", true, 0.0, "7268152375536259639", "20853726", "964a6cb51a01c0ddeb839010765023a6");
        public static readonly AnimationMeta 飞入 = new AnimationMeta("飞入", true, 0.0, "7029231035007111710", "1644319", "9980148af0641a8501561320ec8f967b");
        public static readonly AnimationMeta 鼠标点击 = new AnimationMeta("鼠标点击", true, 0.0, "7350128013637325353", "53149407", "1ba2fbaaeb30f7756ecd92e0121b7ac0");
    }

    //文字出场动画, 默认时长为0.5秒
    public static class Text_outro
    {
        // 免费
        public static readonly AnimationMeta 右上弹出 = new AnimationMeta("右上弹出", false, 0.0, "7076006676951732767", "1631524", "7b65a6e8a2ef7015dc780dec3524af60");
        public static readonly AnimationMeta 右下擦除 = new AnimationMeta("右下擦除", false, 0.0, "7090146831836910110", "1729286", "5e99fcba0a90d5bde52a85e034469aea");
        public static readonly AnimationMeta 向上擦除 = new AnimationMeta("向上擦除", false, 0.0, "6774625752794010115", "1644609", "d9b04e37f86d6b5cf456f396648e11d4");
        public static readonly AnimationMeta 向上溶解 = new AnimationMeta("向上溶解", false, 0.0, "7026619708627489293", "1644655", "7422f3de89f894522a0b45f3f2196131");
        public static readonly AnimationMeta 向上滑动 = new AnimationMeta("向上滑动", false, 0.0, "6763873533115240968", "1644605", "bbec5aa1ddf8df26276b99cfd9996d76");
        public static readonly AnimationMeta 向下擦除 = new AnimationMeta("向下擦除", false, 0.0, "6774626081791021576", "1644610", "4dafd6a7cbde862044fcbc543ecd818a");
        public static readonly AnimationMeta 向下滑动 = new AnimationMeta("向下滑动", false, 0.0, "6724919284893487619", "1644606", "4b1190ca81551d872f1d6b0e2ce5db2b");
        public static readonly AnimationMeta 向右擦除 = new AnimationMeta("向右擦除", false, 0.0, "6783908820176343566", "1644615", "a48325fce55a7a419b351c8a9826c7a0");
        public static readonly AnimationMeta 向右滑动 = new AnimationMeta("向右滑动", false, 0.0, "6724920744431587853", "1644614", "4026a211f18b0fc6ab9e10d09c8922ba");
        public static readonly AnimationMeta 向右缓出 = new AnimationMeta("向右缓出", false, 0.0, "7023684632591733284", "1451688", "b64ac446b7d95831919258b5799c6b25");
        public static readonly AnimationMeta 向左擦除 = new AnimationMeta("向左擦除", false, 0.0, "6774626748177846791", "1644608", "1160d9bcc8a158a65441bcfc9603bd00");
        public static readonly AnimationMeta 向左滑动 = new AnimationMeta("向左滑动", false, 0.0, "6763873602476446221", "1644613", "a193ecedf73b2b27616ee7da4f599b9b");
        public static readonly AnimationMeta 向左解散 = new AnimationMeta("向左解散", false, 0.0, "7083752251742753287", "1674332", "46b117e1d9fc552e574958fcde072a53");
        public static readonly AnimationMeta 圆形扫描 = new AnimationMeta("圆形扫描", false, 0.0, "6840698265277567496", "1644617", "84c8a6772ba3199c3fdba0c171f0f2fc");
        public static readonly AnimationMeta 居中打字 = new AnimationMeta("居中打字", false, 0.0, "7265222263174074937", "20304017", "39cf0ff875a8825a82377a11e8b89d6a");
        public static readonly AnimationMeta 展开 = new AnimationMeta("展开", false, 0.0, "6779879836916650509", "1644599", "cc9805cb2f96e99eec6c0f1978b03f70");
        public static readonly AnimationMeta 左上弹出 = new AnimationMeta("左上弹出", false, 0.0, "7078587337998864926", "1646758", "6cb5717740976cd9e65544d93bb8a8be");
        public static readonly AnimationMeta 左移弹动 = new AnimationMeta("左移弹动", false, 0.0, "7313890212529050138", "35176386", "26cd4509db97923ac2fb11eca5947750");
        public static readonly AnimationMeta 弹出 = new AnimationMeta("弹出", false, 0.0, "6887482090351235592", "1644648", "ee214499310cb2a55d2370534fd0c02b");
        public static readonly AnimationMeta 弹弓 = new AnimationMeta("弹弓", false, 0.0, "6862897350478664200", "1644618", "45f66e1fa1a3b79968b3749275bab10c");
        public static readonly AnimationMeta 弹性伸缩 = new AnimationMeta("弹性伸缩", false, 0.0, "6872642084977775118", "1644646", "f2882bcfc0abc3b0c53b39649a2c4224");
        public static readonly AnimationMeta 弹簧 = new AnimationMeta("弹簧", false, 0.0, "6884154487246688776", "1644647", "15c4e6b0a27360bab5d6f5d421bbbe1e");
        public static readonly AnimationMeta 打字机_I = new AnimationMeta("打字机 I", false, 0.0, "6763469696260903435", "1644611", "628234381485fb1dd576eeb48c85a091");
        public static readonly AnimationMeta 打字机_II = new AnimationMeta("打字机 II", false, 0.0, "6763469767555682823", "1644612", "83076ce7cda24efdaca9731b112fb097");
        public static readonly AnimationMeta 打字机_III = new AnimationMeta("打字机 III", false, 0.0, "6763469838368117256", "1644664", "3f77a87e46ee1b50cd0ac207809c4c24");
        public static readonly AnimationMeta 扭曲模糊 = new AnimationMeta("扭曲模糊", false, 0.0, "7090122015603954189", "1729226", "2e58579b330dbccc4491c5f0a8cf4a8a");
        public static readonly AnimationMeta 拖尾 = new AnimationMeta("拖尾", false, 0.0, "7244102819731477049", "15260277", "20d1992e9f7b67bedf1811c0811b1e5c");
        public static readonly AnimationMeta 放大 = new AnimationMeta("放大", false, 0.0, "6724919767200698884", "1644603", "e818fb0699073a734ecead7c2768d827");
        public static readonly AnimationMeta 放大_II = new AnimationMeta("放大 II", false, 0.0, "7042278078415901192", "1644666", "1d6882ba11b67fff13c98493bc644027");
        public static readonly AnimationMeta 故障打字机 = new AnimationMeta("故障打字机", false, 0.0, "6870061326698287624", "1644643", "71a23656184bc8438f4fa22425192185");
        public static readonly AnimationMeta 旋出 = new AnimationMeta("旋出", false, 0.0, "6763873732143354376", "1644604", "ffc35db86b29aee7a0a4342ea5ed059f");
        public static readonly AnimationMeta 日落 = new AnimationMeta("日落", false, 0.0, "6779084194392838670", "1644607", "662eea25ba7d450d9a91febf43f22f7f");
        public static readonly AnimationMeta 晕开 = new AnimationMeta("晕开", false, 0.0, "7090059095134179877", "1727994", "3f2770aa65e01746967c8289e193021b");
        public static readonly AnimationMeta 模糊 = new AnimationMeta("模糊", false, 0.0, "6923094772907250189", "1644652", "72f73d5e9fd970ccee4918008b5a9d9a");
        public static readonly AnimationMeta 水墨晕开 = new AnimationMeta("水墨晕开", false, 0.0, "7278296130432012857", "22734371", "2705529afbf57f101c042d3a96ca2795");
        public static readonly AnimationMeta 水平翻转 = new AnimationMeta("水平翻转", false, 0.0, "7052633346936934942", "1644667", "8719853b159397ea64fc2102c61e52e4");
        public static readonly AnimationMeta 波浪弹出 = new AnimationMeta("波浪弹出", false, 0.0, "6917178803521327630", "1644651", "c60021c62c10eab0aa4f408ed602405c");
        public static readonly AnimationMeta 渐隐 = new AnimationMeta("渐隐", false, 0.0, "6724919382104871427", "1644600", "11004616098603d847593ce9ede05a62");
        public static readonly AnimationMeta 溶解 = new AnimationMeta("溶解", false, 0.0, "6872642354898014728", "1644645", "46389f9f5f72e1b58020a0b8293a23b9");
        public static readonly AnimationMeta 滑动下落 = new AnimationMeta("滑动下落", false, 0.0, "7270726693277405733", "21330850", "fa4aaf84b182425eed4e330ac03ecdbd");
        public static readonly AnimationMeta 生长 = new AnimationMeta("生长", false, 0.0, "6869302139584254477", "1644642", "e6ae4e1fc5ade7bd8765ef6d918f5f6f");
        public static readonly AnimationMeta 缩小 = new AnimationMeta("缩小", false, 0.0, "6724921351385125387", "1644602", "6c679c75b88d8c69335c9faefbcd635a");
        public static readonly AnimationMeta 羽化向右擦除 = new AnimationMeta("羽化向右擦除", false, 0.0, "6897085341811872270", "1644649", "9d4c77cbae673b97c629890c6687bc71");
        public static readonly AnimationMeta 羽化向左擦除 = new AnimationMeta("羽化向左擦除", false, 0.0, "6897085246206906893", "1644650", "865d4874f9e21f104881bd3f1f1e02fa");
        public static readonly AnimationMeta 翻动 = new AnimationMeta("翻动", false, 0.0, "7308279288061497865", "32283993", "07d60e408004cba91944a6fbe3ec570d");
        public static readonly AnimationMeta 躺下 = new AnimationMeta("躺下", false, 0.0, "7265288999470633509", "20324365", "dc012ae6bfd6482bb0e52d02328016c8");
        public static readonly AnimationMeta 轻微放大 = new AnimationMeta("轻微放大", false, 0.0, "6763469915518145032", "1644601", "1e293df954586a261a11576481dd8454");
        public static readonly AnimationMeta 闪动 = new AnimationMeta("闪动", false, 0.0, "7039245189638001183", "1644658", "6b16591d61fa6ee68eef9148dbf0aa31");
        public static readonly AnimationMeta 闭幕 = new AnimationMeta("闭幕", false, 0.0, "6834511218552607239", "1644616", "02a28db581b74aac8547c2479cb219bc");
        public static readonly AnimationMeta 随机弹跳 = new AnimationMeta("随机弹跳", false, 0.0, "7026617357300666893", "1644665", "c260caa85b16e7d471ddeb2015cdf3f3");
        public static readonly AnimationMeta 随机飞出 = new AnimationMeta("随机飞出", false, 0.0, "6872642497013617159", "1644644", "d1292de2cfc57d0ca12fdbafb4e0bca2");

        // 付费
        public static readonly AnimationMeta 二段缩放 = new AnimationMeta("二段缩放", true, 0.0, "7238519014866031162", "14394793", "bc54fc23dff39b105104f5bb15043ff9");
        public static readonly AnimationMeta 发光闪出 = new AnimationMeta("发光闪出", true, 0.0, "7308275717505028617", "32281161", "980fe827d603f3785e69854b6e5967a4");
        public static readonly AnimationMeta 叠影并出 = new AnimationMeta("叠影并出", true, 0.0, "7259634082760364603", "19101496", "1cc4801fbe64f100872abd1d502ac121");
        public static readonly AnimationMeta 向上飞出 = new AnimationMeta("向上飞出", true, 0.0, "7090139631861109278", "1730928", "3513093fd914fcccfa87cb98a410062e");
        public static readonly AnimationMeta 向下弹出 = new AnimationMeta("向下弹出", true, 0.0, "7127158940151845390", "3859743", "751b7e005e3ec297f5d3d2c40664f585");
        public static readonly AnimationMeta 向下翻转 = new AnimationMeta("向下翻转", true, 0.0, "7198395913948107301", "9282213", "860c71ba47b9cf749ac977cb437ae1a8");
        public static readonly AnimationMeta 向左模糊 = new AnimationMeta("向左模糊", true, 0.0, "7112703727336690189", "3176752", "02ee1da62468714f7b17a671ee61acf0");
        public static readonly AnimationMeta 向左模糊_II = new AnimationMeta("向左模糊 II", true, 0.0, "7254503584732025381", "17830676", "0374eb3b551fbd0d36c78d3105e6f976");
        public static readonly AnimationMeta 吸出 = new AnimationMeta("吸出", true, 0.0, "7121986743141667358", "3647465", "27d43c1a8f3bb21f88f25fadfd74e113");
        public static readonly AnimationMeta 喷绘 = new AnimationMeta("喷绘", true, 0.0, "7120131305303446029", "3563649", "a2efafd9407094f2706c38b5ea2867c0");
        public static readonly AnimationMeta 复古打字机 = new AnimationMeta("复古打字机", true, 0.0, "7252619798108967484", "17250228", "7739c9b46eb8c9ed7105c7c5c859ea8d");
        public static readonly AnimationMeta 弹出跳动 = new AnimationMeta("弹出跳动", true, 0.0, "7184797189627974200", "8058215", "dffb8966b47b6eae5fb9ef0e0fe6e6b9");
        public static readonly AnimationMeta 弹性伸缩_II = new AnimationMeta("弹性伸缩 II", true, 0.0, "7308276711039177225", "32281815", "9b225f4fafa2341876eec98ba91c89ee");
        public static readonly AnimationMeta 打字光标 = new AnimationMeta("打字光标", true, 0.0, "7237411511755346491", "14235852", "1285f4e58d3989468cc7c7679145e155");
        public static readonly AnimationMeta 打字机IV = new AnimationMeta("打字机IV", true, 0.0, "7237411448303915557", "14235853", "3f2d4916f48390652f4abaff69742c0b");
        public static readonly AnimationMeta 折叠 = new AnimationMeta("折叠", true, 0.0, "7124961998919438884", "3769517", "ccce629bcf7f98a8de4d4e1a2228d11a");
        public static readonly AnimationMeta 描边填充 = new AnimationMeta("描边填充", true, 0.0, "7308273254127374874", "32279531", "9dc334dd67a2ace030c8d0f0d01ecede");
        public static readonly AnimationMeta 收缩震动 = new AnimationMeta("收缩震动", true, 0.0, "7268214314022998588", "20877442", "c95da61de0632a74d061f03806a8ea9b");
        public static readonly AnimationMeta 故障 = new AnimationMeta("故障", true, 0.0, "7091567288385540622", "1789138", "b106b2d684134a06b033aa2ba70baea2");
        public static readonly AnimationMeta 故障闪动 = new AnimationMeta("故障闪动", true, 0.0, "7244102414377161276", "15261509", "ba766fab0ea8b838f1c64973aee2b54b");
        public static readonly AnimationMeta 旋转缩放 = new AnimationMeta("旋转缩放", true, 0.0, "7243633648237285949", "15140857", "37af568e3f004232b19507b24d5438c1");
        public static readonly AnimationMeta 旋转飞出 = new AnimationMeta("旋转飞出", true, 0.0, "6775804032318444045", "1644639", "802b2078b18d70ecd073ffacff59c1d8");
        public static readonly AnimationMeta 模糊发光 = new AnimationMeta("模糊发光", true, 0.0, "7301536173959156274", "29690520", "a21891cf3eff128b2a5190cad5356d69");
        public static readonly AnimationMeta 模糊滚动 = new AnimationMeta("模糊滚动", true, 0.0, "7264501549240422949", "20154980", "9c07a1d5d75f675d32f8917dc76f7381");
        public static readonly AnimationMeta 波浪弹跳 = new AnimationMeta("波浪弹跳", true, 0.0, "7317637880799564297", "37396324", "17dc7c4e6498440fcafc56dfbe3fb4fe");
        public static readonly AnimationMeta 消散 = new AnimationMeta("消散", true, 0.0, "7155790075794559525", "5323563", "21888446c8d15d56c60864985328652b");
        public static readonly AnimationMeta 滚出 = new AnimationMeta("滚出", true, 0.0, "7023684709737566728", "1644656", "f25af0cdef9584d588584b3765350f64");
        public static readonly AnimationMeta 激光雕刻 = new AnimationMeta("激光雕刻", true, 0.0, "7244102529573720635", "15261103", "bb0ab89c7396d11d5663b0071296f27d");
        public static readonly AnimationMeta 炸开 = new AnimationMeta("炸开", true, 0.0, "7142816577971294734", "4577477", "15ced8e31e8d57f8932820fe99f96391");
        public static readonly AnimationMeta 炸开_II = new AnimationMeta("炸开 II", true, 0.0, "7148309755121898015", "4834739", "bff4571b77bca8598b6ce8ba65d93252");
        public static readonly AnimationMeta 炸开_Ⅲ = new AnimationMeta("炸开 Ⅲ", true, 0.0, "7308274161992864266", "32280237", "0060b15237436dc553a3a050825d18a6");
        public static readonly AnimationMeta 环绕滑出 = new AnimationMeta("环绕滑出", true, 0.0, "7261858590808347193", "19562193", "c88f30f314faade1a6e71884234a380b");
        public static readonly AnimationMeta 甩回 = new AnimationMeta("甩回", true, 0.0, "7244102747698500156", "15261069", "0203e194e3bcf10f7f96fde73dc350f3");
        public static readonly AnimationMeta 空翻 = new AnimationMeta("空翻", true, 0.0, "6865176065514410503", "1644641", "f578720479df7746fa067199a1e4ea8b");
        public static readonly AnimationMeta 螺旋下降 = new AnimationMeta("螺旋下降", true, 0.0, "6799874105710481927", "1644640", "e6e1a2239d894b408e41341a6ca578ca");
        public static readonly AnimationMeta 逐字旋出 = new AnimationMeta("逐字旋出", true, 0.0, "7229520513586958908", "13137113", "3df3f26182ac9c6359be95dfb443d5da");
        public static readonly AnimationMeta 逐字旋转 = new AnimationMeta("逐字旋转", true, 0.0, "7112021029085516319", "3129838", "ee29d8b9e06a471972f36734c53dbea8");
        public static readonly AnimationMeta 逐字翻转 = new AnimationMeta("逐字翻转", true, 0.0, "7112274846326723086", "3139394", "ffc81a4b0c44427fbfd60984f7ddcdc2");
        public static readonly AnimationMeta 逐字虚影 = new AnimationMeta("逐字虚影", true, 0.0, "7034717113130422791", "1644657", "fe2cfbc08c330517caa8b602187ced07");
        public static readonly AnimationMeta 镂空跳出 = new AnimationMeta("镂空跳出", true, 0.0, "7312331703903588902", "34383204", "f1bb60aeec2ee712e813b3cab75050bc");
        public static readonly AnimationMeta 闪烁散开 = new AnimationMeta("闪烁散开", true, 0.0, "7268169968204649020", "20860262", "b58f8939e94946a70c35188819a65a78");
        public static readonly AnimationMeta 随机弹跳_II = new AnimationMeta("随机弹跳 II", true, 0.0, "7114191629346411016", "3241116", "0f0b492622513301a7cd8f30b035a056");
        public static readonly AnimationMeta 随机打字机 = new AnimationMeta("随机打字机", true, 0.0, "6926719087158497806", "1644653", "9db48fc9916b5b8554ce7262bb90f18f");
        public static readonly AnimationMeta 顶出 = new AnimationMeta("顶出", true, 0.0, "7268231069768356408", "20882164", "98ad0ec3b5980352e4709158def77960");
        public static readonly AnimationMeta 预览打字 = new AnimationMeta("预览打字", true, 0.0, "7268216065337856572", "20878188", "360d883bb43dab551defd1e94b9730d6");
        public static readonly AnimationMeta 飞出 = new AnimationMeta("飞出", true, 0.0, "7029522072724312612", "1644654", "324c695abdd43e1ec3506364fce0a087");
    }

    //文字循环动画
    public static class Text_loop
    {
        
        // 免费
        public static readonly AnimationMeta VHS = new AnimationMeta("VHS", false, 0.0, "7399879467457319463", "77851352", "f82d0f25b2cc4f0696dce7d97c7b02be");
        public static readonly AnimationMeta 上弧 = new AnimationMeta("上弧", false, 0.0, "7075224569421763079", "1626238", "a0362ebaa2f5016487abfab05d47605b");
        public static readonly AnimationMeta 刷屏 = new AnimationMeta("刷屏", false, 0.0, "7308280358691148315", "32284703", "e92c576feca5efb75feda14004b269c5");
        public static readonly AnimationMeta 发光模糊多行 = new AnimationMeta("发光模糊多行", false, 0.0, "7397688001356108339", "77132594", "ee68176782c8b62a207c04f4a979957a");
        public static readonly AnimationMeta 吹泡泡 = new AnimationMeta("吹泡泡", false, 0.0, "7045155566003425823", "1644539", "6db3746838af18903d01968e6af07185");
        public static readonly AnimationMeta 吹泡泡_II = new AnimationMeta("吹泡泡 II", false, 0.0, "7052257626897256968", "1644528", "b378734fd7a0e8ec78e53987823fad79");
        public static readonly AnimationMeta 呐喊 = new AnimationMeta("呐喊", false, 0.0, "7119024816480326157", "4002167", "04933b5e575c54cbf09c57c5e933f0ec");
        public static readonly AnimationMeta 复古涂鸦 = new AnimationMeta("复古涂鸦", false, 0.0, "7400234025392017956", "77997810", "4bc57fba68e0cce14e2ea8ab652dabc2");
        public static readonly AnimationMeta 字体变换 = new AnimationMeta("字体变换", false, 0.0, "7402185694732358170", "78763194", "06c685c00a9c1a7a484c7841ac45742a");
        public static readonly AnimationMeta 弹幕滚动 = new AnimationMeta("弹幕滚动", false, 0.0, "6790247082155315719", "1644518", "4ca7b3a27da98849561b21c9c6d964fc");
        public static readonly AnimationMeta 彩虹 = new AnimationMeta("彩虹", false, 0.0, "6908592625406710280", "990096", "fac0ebef55c57c31b3142f5840299b03");
        public static readonly AnimationMeta 彩虹_情人节 = new AnimationMeta("彩虹-情人节", false, 0.0, "6916820108211917325", "1012617", "c45282c8e30b8639a71345769060f3d5");
        public static readonly AnimationMeta 彩虹_新年 = new AnimationMeta("彩虹-新年", false, 0.0, "6916820045519655432", "1012618", "dd9fcbbcfc17cad31ab42e886769c66e");
        public static readonly AnimationMeta 彩虹_马卡龙 = new AnimationMeta("彩虹-马卡龙", false, 0.0, "6921528300573561358", "1022790", "a614b3dd7d4b852f1a126afe4c5ee50f");
        public static readonly AnimationMeta 扫光 = new AnimationMeta("扫光", false, 0.0, "7051843475892867598", "1520868", "0495742cdb3a26ff28dfabf7f8ef236b");
        public static readonly AnimationMeta 投影颤抖_II = new AnimationMeta("投影颤抖 II", false, 0.0, "7070332370963927559", "1599696", "673aa54d5519360162ea8ec38986ea1c");
        public static readonly AnimationMeta 折叠 = new AnimationMeta("折叠", false, 0.0, "7064823078542381581", "1567212", "c9b3ef10e455a3916dbef47a7f711eaa");
        public static readonly AnimationMeta 拼贴纹理 = new AnimationMeta("拼贴纹理", false, 0.0, "7399983060806013479", "77918388", "922ca4e87c7eed7e60d062c18e928bc6");
        public static readonly AnimationMeta 描边粉笔 = new AnimationMeta("描边粉笔", false, 0.0, "7399879712140431883", "77851433", "05c3c10997b885c71ed0dd64aff14dd2");
        public static readonly AnimationMeta 摇摆 = new AnimationMeta("摇摆", false, 0.0, "6724920869363126795", "1644515", "8af4da60a802e3ca6c9fe2184fbe22d0");
        public static readonly AnimationMeta 摇荡 = new AnimationMeta("摇荡", false, 0.0, "6840710593289130503", "1644523", "61f24344eb8bf86582d6140ad985ef14");
        public static readonly AnimationMeta 故障闪动 = new AnimationMeta("故障闪动", false, 0.0, "6857714281136263687", "1644524", "51d9ee83fbaf2dfa049885676ec2d5d9");
        public static readonly AnimationMeta 旋转 = new AnimationMeta("旋转", false, 0.0, "6763900973946507784", "1644510", "151421d4de4d49e65b050cb413482cd5");
        public static readonly AnimationMeta 晃动 = new AnimationMeta("晃动", false, 0.0, "6790246693674684942", "1644520", "383dabd75d7fe7985d990ebb34d63732");
        public static readonly AnimationMeta 波纹 = new AnimationMeta("波纹", false, 0.0, "7275663372148806203", "22223033", "929efca6bd35df0718dadf77836cfba7");
        public static readonly AnimationMeta 爆闪 = new AnimationMeta("爆闪", false, 0.0, "7308279705252139530", "32284413", "61951bd303975761bc99f187bdb8fdab");
        public static readonly AnimationMeta 环绕 = new AnimationMeta("环绕", false, 0.0, "6980916124976157220", "1644542", "0d14427906b240809f0d9838f35cf95c");
        public static readonly AnimationMeta 翻转 = new AnimationMeta("翻转", false, 0.0, "6763897586328801805", "1644511", "e4983ce92d02628087780832ef631c7d");
        public static readonly AnimationMeta 色差故障 = new AnimationMeta("色差故障", false, 0.0, "6835878163575214605", "1644522", "e0295a9f4f19fe21692c405f7c00d1e5");
        public static readonly AnimationMeta 蓝黄滑动 = new AnimationMeta("蓝黄滑动", false, 0.0, "7398492769628459539", "77383265", "bb717e125d34532ec904d1bc01ec25da");
        public static readonly AnimationMeta 超强晃动 = new AnimationMeta("超强晃动", false, 0.0, "7065208406633615909", "1568854", "b129b0e6bed4f9835f871848db646763");
        public static readonly AnimationMeta 超强晃动_II = new AnimationMeta("超强晃动 II", false, 0.0, "7069965879437431303", "1597286", "2b8adf8a719de3e0bcfa10569d364a81");
        public static readonly AnimationMeta 超强波浪 = new AnimationMeta("超强波浪", false, 0.0, "6857036499389518349", "872098", "87f7332abda9ac46d5dc81f69c48daab");
        public static readonly AnimationMeta 超强波浪_II = new AnimationMeta("超强波浪 II", false, 0.0, "7065219379687854623", "1568964", "bdd007527d0eda9d64bfbf6aef103e97");
        public static readonly AnimationMeta 跳动 = new AnimationMeta("跳动", false, 0.0, "6724920002958332420", "1644512", "784250e657b472a46a3b3ce0a838e4f7");
        public static readonly AnimationMeta 轻微跳动 = new AnimationMeta("轻微跳动", false, 0.0, "6884155832838132231", "1644525", "ac5c4160fae860fd74e5b7ab6d053252");
        public static readonly AnimationMeta 钟摆 = new AnimationMeta("钟摆", false, 0.0, "6724921579517514248", "1644516", "320b71150105629f7ab1b318716181eb");
        public static readonly AnimationMeta 闪烁 = new AnimationMeta("闪烁", false, 0.0, "6724921437930394120", "1644514", "6fe3f0fcd14e11e70b7510f42444b86c");
        public static readonly AnimationMeta 雨刷 = new AnimationMeta("雨刷", false, 0.0, "6799874389669057037", "1644521", "6a4c40e24db5027cb42892d8ade9df38");
        public static readonly AnimationMeta 频闪边框 = new AnimationMeta("频闪边框", false, 0.0, "7308280718302384690", "32284883", "36184bd37eae10c2d8247fb5bd59c6f2");
        public static readonly AnimationMeta 颤抖 = new AnimationMeta("颤抖", false, 0.0, "6764189482871689742", "1644509", "82a2b88dc69ce9f9a36f975968649d5b");
        public static readonly AnimationMeta 颤抖_III = new AnimationMeta("颤抖 III", false, 0.0, "7070036604429013535", "1598082", "c6f744d4c3d208abf97a3af3afe9d356");

        // 付费
        public static readonly AnimationMeta 喷涌 = new AnimationMeta("喷涌", true, 0.0, "7134190113780666887", "4175399", "76cc53a7bb20385d208c858a13cf06fd");
        public static readonly AnimationMeta 喷绘 = new AnimationMeta("喷绘", true, 0.0, "7110160318529016350", "2999942", "fbd35399a1880d2637731d20eb619d29");
        public static readonly AnimationMeta 圆形涂鸦 = new AnimationMeta("圆形涂鸦", true, 0.0, "7276420462131810874", "22362181", "696d3b443b4c6ed8b9f0f28825c08a8c");
        public static readonly AnimationMeta 声波震动 = new AnimationMeta("声波震动", true, 0.0, "7239526343833031223", "14518651", "9098085cd316045cf912e54a73d845a4");
        public static readonly AnimationMeta 字幕滚动 = new AnimationMeta("字幕滚动", true, 0.0, "6790246884683289102", "1644519", "9aa4e0d045c61892c2b2e3fdfaf1b093");
        public static readonly AnimationMeta 尾巴摇摆 = new AnimationMeta("尾巴摇摆", true, 0.0, "7212897307782550053", "10967121", "c1585ff28130b111d0458c6490d20ef2");
        public static readonly AnimationMeta 弹幕 = new AnimationMeta("弹幕", true, 0.0, "7107592133472686606", "2795622", "8d0a44c1f51ea9cd7a8174f72751d2b7");
        public static readonly AnimationMeta 弹幕_II = new AnimationMeta("弹幕 II", true, 0.0, "7096375845773644318", "1826548", "11bcd8965488f2c70e27c8dc5112c6cb");
        public static readonly AnimationMeta 强调三遍 = new AnimationMeta("强调三遍", true, 0.0, "7129767866894651917", "3966601", "e008ee1c0ba1e9beb3fb5bb84b4c0643");
        public static readonly AnimationMeta 彩色切换 = new AnimationMeta("彩色切换", true, 0.0, "7303430211519910451", "30322872", "e2c7f4ec20555abe1e50c1920e81a0f9");
        public static readonly AnimationMeta 彩色火焰 = new AnimationMeta("彩色火焰", true, 0.0, "7308278472541999654", "32283417", "94dd9722a4b46d248c5e1d3d4b7c71fb");
        public static readonly AnimationMeta 影像叠加 = new AnimationMeta("影像叠加", true, 0.0, "7193989785319379515", "8882439", "018a39f66ba7ceb39f4d61e4446624f8");

        public static readonly AnimationMeta 心跳 = new AnimationMeta("心跳", true, 0.0, "7210283971316290085", "10650869", "3c2c6a7f6b8b102e9ae5f918600f83c0");
        public static readonly AnimationMeta 急了 = new AnimationMeta("急了", true, 0.0, "7134634461588623909", "4200435", "4f01b8c42b2d4a26a89aa528e6cc1544");
        public static readonly AnimationMeta 悸动 = new AnimationMeta("悸动", true, 0.0, "7229526981807706680", "13139395", "dc1aa28b54954465640c40928fae55f7");
        public static readonly AnimationMeta 情绪加载 = new AnimationMeta("情绪加载", true, 0.0, "7130142075995034119", "3983735", "6293429c9f4e12407d38089ee43b77cd");
        public static readonly AnimationMeta 扩音器 = new AnimationMeta("扩音器", true, 0.0, "7277870806552547895", "22619881", "ba24954b91039982fabf75ad533e7ff1");
        public static readonly AnimationMeta 扭动 = new AnimationMeta("扭动", true, 0.0, "7123093247672455711", "3733565", "5380b570671074788541d13e389daa4f");
        public static readonly AnimationMeta 投影颤抖 = new AnimationMeta("投影颤抖", true, 0.0, "7070332284934558245", "1599698", "4f4bebc9ab74f05801dca7b9b2ffa047");
        public static readonly AnimationMeta 抖动故障 = new AnimationMeta("抖动故障", true, 0.0, "7283103017526628921", "23998441", "55749de55fe55fc230a31952790142f3");
        public static readonly AnimationMeta 拉住 = new AnimationMeta("拉住", true, 0.0, "7221747595884892731", "12135594", "98db2339ea77225948ed8b7f8d72fc36");
        public static readonly AnimationMeta 拉开 = new AnimationMeta("拉开", true, 0.0, "7223675733606928957", "12390761", "41f672adaa1cdccdb81c8d0b2b1124a4");
        public static readonly AnimationMeta 排队入场 = new AnimationMeta("排队入场", true, 0.0, "7225496399817740855", "12628547", "0a7a9cb49305092f638d65888f149348");
        public static readonly AnimationMeta 摇摆_I = new AnimationMeta("摇摆 I", true, 0.0, "6908281696253121038", "1520478", "ea2f688a517d18a9de5912fa09f3bd56");
        public static readonly AnimationMeta 放大缩小 = new AnimationMeta("放大缩小", true, 0.0, "7224077152587616805", "12453543", "3e1538ad9a9f723238bb922423e20aed");
        public static readonly AnimationMeta 放大镜 = new AnimationMeta("放大镜", true, 0.0, "7272339163142165050", "21635790", "e9f8437306ec0f948c1eb485f09692a3");
        public static readonly AnimationMeta 文字泛光 = new AnimationMeta("文字泛光", true, 0.0, "7124226995231134239", "3740251", "879231435782ed4b72f278290070f20a");
        public static readonly AnimationMeta 波浪 = new AnimationMeta("波浪", true, 0.0, "6724927688047333891", "1644517", "176a075543ef82c04df1dd40d181ac5b");
        public static readonly AnimationMeta 波浪_II = new AnimationMeta("波浪 II", true, 0.0, "7067046171381862919", "1576246", "62245c9799544b75258689eb1ff222bb");
        public static readonly AnimationMeta 波浪_III = new AnimationMeta("波浪 III", true, 0.0, "7067812686557352456", "1583302", "8eecb90b305442a4568e2e9ff7151735");

        public static readonly AnimationMeta 流光 = new AnimationMeta("流光", true, 0.0, "7181754919827804728", "7776353", "16711992a6719a5c798f8fb138550229");
        public static readonly AnimationMeta 涂鸦手绘 = new AnimationMeta("涂鸦手绘", true, 0.0, "7276407256965452346", "22361305", "1ae8ceff3f65dd62f36b3eb43baff6b4");
        public static readonly AnimationMeta 涂鸦手绘_II = new AnimationMeta("涂鸦手绘 II", true, 0.0, "7276407576625943100", "22361304", "f72282b1f43b0d5e59144bbca7fbeda8");
        public static readonly AnimationMeta 渐变拖尾 = new AnimationMeta("渐变拖尾", true, 0.0, "7308277117622424090", "32282151", "950687cffad02a7b17bc9b672c9585f2");
        public static readonly AnimationMeta 漂浮 = new AnimationMeta("漂浮", true, 0.0, "7213291988500615738", "11017729", "451fbb332b33ec6ba683dc9d22055810");
        public static readonly AnimationMeta 漩涡 = new AnimationMeta("漩涡", true, 0.0, "7099419657290912286", "1936778", "416be3d42ae0d037597209d2a2f843c4");
        public static readonly AnimationMeta 环形滚动 = new AnimationMeta("环形滚动", true, 0.0, "7179135028343870012", "7564487", "e167e03db93ab98c4917ff53f59162c1");
        public static readonly AnimationMeta 环绕_II = new AnimationMeta("环绕 II", true, 0.0, "7114181846086193701", "3240866", "6df622ca3b91909a8d23ae24f1c2a675");
        public static readonly AnimationMeta 甜甜圈 = new AnimationMeta("甜甜圈", true, 0.0, "7070415354656199181", "1600378", "23a8cee8851ad7e169a094cee8ca9513");
        public static readonly AnimationMeta 福袋炸开 = new AnimationMeta("福袋炸开", true, 0.0, "7047088638932292127", "1531460", "2646a21f26faeb4103acacaa74c171f6");
        public static readonly AnimationMeta 空间翻转_I = new AnimationMeta("空间翻转 I", true, 0.0, "7163896186972148261", "5965291", "24cd6c57edb2d457135c7c24a2b79a02");
        public static readonly AnimationMeta 空间翻转_II = new AnimationMeta("空间翻转 II", true, 0.0, "7163901901589713444", "5966503", "ce769779dfa1d9c69eb593318bf1bc28");
        public static readonly AnimationMeta 空间翻转_III = new AnimationMeta("空间翻转 III", true, 0.0, "7163892769176424991", "5964737", "f9c82b94ebd990e6734ddef5ebba68cb");
        public static readonly AnimationMeta 翻页I = new AnimationMeta("翻页I", true, 0.0, "7168819879183651359", "6443365", "8e4559d96b415b5c1ec0748b8a138f4e");
        public static readonly AnimationMeta 调皮 = new AnimationMeta("调皮", true, 0.0, "6917143282690560526", "1644527", "b832fcbb8ea3bcc64ddbd70c56166956");
        public static readonly AnimationMeta 逐字放大 = new AnimationMeta("逐字放大", true, 0.0, "6908592686781960717", "1644526", "4cd5a5c4144a3a713469043722579306");
        public static readonly AnimationMeta 错位 = new AnimationMeta("错位", true, 0.0, "7243633488249754173", "15140783", "cc869e81ac3b5d769afa6836bab5937b");
        public static readonly AnimationMeta 随机弹跳 = new AnimationMeta("随机弹跳", true, 0.0, "7045150354672980516", "1644538", "8656e9848f862adf1adfa30c26113a80");
        public static readonly AnimationMeta 颤抖_II = new AnimationMeta("颤抖 II", true, 0.0, "6986920909927879199", "1446098", "8d180f0ad5ff173a44f9142baeee536c");
        public static readonly AnimationMeta 飘起 = new AnimationMeta("飘起", true, 0.0, "7211060597352305189", "10749797", "1ab6d9a8761c108da6989633b933647e");
    }

    public enum AnimationCategory
    {
        Intro,
        Outro,
        Group,
        Unknown
    }

    public static class AnimationCategoryResolver
    {
        public static AnimationCategory GetCategory(AnimationMeta meta)
        {
            if (BelongsTo(meta, typeof(IntroType))) return AnimationCategory.Intro;
            if (BelongsTo(meta, typeof(OutroType))) return AnimationCategory.Outro;
            if (BelongsTo(meta, typeof(GroupType))) return AnimationCategory.Group;
            return AnimationCategory.Unknown;
        }

        private static bool BelongsTo(AnimationMeta meta, Type type)
        {
            var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            return fields.Any(f => f.GetValue(null) == meta);
        }
    }
}
