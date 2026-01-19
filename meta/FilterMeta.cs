using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    //剪映自带的滤镜效果类型
    public static class FilterType
    {
        public static readonly EffectMeta _1980 = new EffectMeta("1980", false, "7127828208690433311", "7127828208690433311", "d3595847ee8348c69c6037b8003a76e9", null);
        public static readonly EffectMeta ABG = new EffectMeta("ABG", false, "7127679308897832206", "7127679308897832206", "d07b36b0b8e1893ce49df327ba926804", null);
        public static readonly EffectMeta Ditto = new EffectMeta("Ditto", false, "7195816046077496635", "7195816046077496635", "09d18408ca0dee53716c3a4f41dd35e1", null);
        public static readonly EffectMeta KE1 = new EffectMeta("KE1", false, "7127819154018536741", "7127819154018536741", "5ece7eff894e25a356b9111e78478c56", null);
        public static readonly EffectMeta KV5D = new EffectMeta("KV5D", false, "7127578859217620254", "7127578859217620254", "57940599e2c8d85a7f73824c7360bfca", null);
        public static readonly EffectMeta VHS_III = new EffectMeta("VHS III", false, "7127669764905782542", "7127669764905782542", "c8d7adad4773fccc2128d8eafa569572", null);
        public static readonly EffectMeta 三洋VPC = new EffectMeta("三洋VPC", false, "7127669338089311495", "7127669338089311495", "73c77a4b9c5085af6175a523d24bc7c6", null);
        public static readonly EffectMeta 书意 = new EffectMeta("书意", false, "7368493100127292723", "7368493100127292723", "3e20d8ccc31ca6a495b3f8e2ff116744", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 亮肤 = new EffectMeta("亮肤", false, "7127655008715230495", "7127655008715230495", "2aaa463c5deee34e73384d549edc7c15", null);
        public static readonly EffectMeta 仲夏绿光 = new EffectMeta("仲夏绿光", false, "7127675970252754189", "7127675970252754189", "970f4b2c797e2890787f7420d8c0613b", null);
        public static readonly EffectMeta 似锦 = new EffectMeta("似锦", false, "7188014191834418493", "7188014191834418493", "869cb94d6bbec5c6b771092ec1ef8cfe", null);
        public static readonly EffectMeta 低保真 = new EffectMeta("低保真", false, "7304170509661506843", "7304170509661506843", "db39172ffff69e973886c2e8598dbc75", null);
        public static readonly EffectMeta 侘寂灰 = new EffectMeta("侘寂灰", false, "7127609569416711455", "7127609569416711455", "17547e013b45f87dc7e4e1f7059d7e62", null);
        public static readonly EffectMeta 冬恋 = new EffectMeta("冬恋", false, "7304573577255324967", "7304573577255324967", "995b1153346f3f3237099b4357b78374", null);
        public static readonly EffectMeta 冰火 = new EffectMeta("冰火", false, "7303812389177265447", "7303812389177265447", "61065880d8580b8b1a206de0b0773571", null);
        public static readonly EffectMeta 冰肌 = new EffectMeta("冰肌", false, "7199089344756370743", "7199089344756370743", "18c6b91685b82ef1cd3d7b7261f997ea", null);
        public static readonly EffectMeta 冷气机 = new EffectMeta("冷气机", false, "7263359186883366155", "7263359186883366155", "740c1bfa9cb365344bd8a51bf7ef037b", null);
        public static readonly EffectMeta 冷白 = new EffectMeta("冷白", false, "7127614731187178783", "7127614731187178783", "a47ab1d817480c87ff6de4c9ba10b204", null);
        public static readonly EffectMeta 冷蓝 = new EffectMeta("冷蓝", false, "7127618237117877518", "7127618237117877518", "accf4492064dabe05dce1c28457b6f89", null);
        public static readonly EffectMeta 凝黛 = new EffectMeta("凝黛", false, "7298279202350976282", "7298279202350976282", "7bad3476dce5691d9e8f90f50122ed33", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 初冷 = new EffectMeta("初冷", false, "7297566793881734438", "7297566793881734438", "5a97174119b20bbbc86a6cfd62e148d5", null);
        public static readonly EffectMeta 初恋 = new EffectMeta("初恋", false, "7195812984306814267", "7195812984306814267", "9fdc53e8dab072725d9bb088b8930869", null);
        public static readonly EffectMeta 千玺IXU = new EffectMeta("千玺IXU", false, "7127824119294364959", "7127824119294364959", "12af151fa57d3226ee3781a070ae54a6", null);
        public static readonly EffectMeta 千金妝 = new EffectMeta("千金妝", false, "7370585884078443802", "7370585884078443802", "e814069ba1dea090eeb44b397eeac252", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 即刻春光 = new EffectMeta("即刻春光", false, "7127675868641594654", "7127675868641594654", "ba343f6bb3720ba81a8662d669b6b743", null);
        public static readonly EffectMeta 原木 = new EffectMeta("原木", false, "7127675195812351239", "7127675195812351239", "a2cb1c6dd47c2ce4aeb0dd7303353438", null);
        public static readonly EffectMeta 古罗马 = new EffectMeta("古罗马", false, "7242212640498568503", "7242212640498568503", "3d438e293e65d63e71af3db73b03bc4e", null);
        public static readonly EffectMeta 喜市 = new EffectMeta("喜市", false, "7185440129442417931", "7185440129442417931", "5210a45933f4265e5f262d3018a78d64", null);
        public static readonly EffectMeta 复古工业 = new EffectMeta("复古工业", false, "7127608212483820837", "7127608212483820837", "cf8d236e185f6b174544151be3baba93", null);
        public static readonly EffectMeta 夏日风吟 = new EffectMeta("夏日风吟", false, "7127684611802418445", "7127684611802418445", "3120cfc3dd0f1fe2090749012d60a20b", null);
        public static readonly EffectMeta 奈良 = new EffectMeta("奈良", false, "7351684015906147621", "7351684015906147621", "2a7ada2a5ac7a8742b37c3bc794b07b0", null);
        public static readonly EffectMeta 奥本海默 = new EffectMeta("奥本海默", false, "7271142654505766183", "7271142654505766183", "2a1f03001d0db5f28f73bee7bc00ccf7", null);
        // public static readonly EffectMeta 奶杏 = new EffectMeta("奶杏", false, "7297134192100379938", "7297134192100379938", "89ae84878534d61d0b7d62ba395fc8b7", null);
        public static readonly EffectMeta 奶油 = new EffectMeta("奶油", false, "7127618513048571173", "7127618513048571173", "dd39d5622353128e5f7c1de20020359a", null);
        public static readonly EffectMeta 奶绿 = new EffectMeta("奶绿", false, "7127684319300029733", "7127684319300029733", "8924565ec41520d2a8a88d846069768f", null);
        public static readonly EffectMeta 姜饼红 = new EffectMeta("姜饼红", false, "7127624030135389471", "7127624030135389471", "22925be3f36caa278eb5df6a0278c636", null);
        public static readonly EffectMeta 安愉 = new EffectMeta("安愉", false, "7190242827543022880", "7190242827543022880", "ed7e951505cbf70dee0f4d144d239828", null);
        public static readonly EffectMeta 富士CC_II = new EffectMeta("富士CC II", false, "7268561903721401641", "7268561903721401641", "cb92e0b13cd9b9a3aca8bb00b1a9c328", null);
        public static readonly EffectMeta 寻荷 = new EffectMeta("寻荷", false, "7295362817874480425", "7295362817874480425", "0230f2fb3e9ea72df20f8819542b4410", null);
        public static readonly EffectMeta 小镇 = new EffectMeta("小镇", false, "7127654151688965384", "7127654151688965384", "fc386676ee752b20918fb61c42c28a7b", null);
        public static readonly EffectMeta 山系 = new EffectMeta("山系", false, "7127662738884545806", "7127662738884545806", "d9d5332152b0f951229402d7d840263e", null);
        public static readonly EffectMeta 巧克力 = new EffectMeta("巧克力", false, "7363220647767592243", "7363220647767592243", "6e513d9dcb9357219e35097b945a3881", null);
        public static readonly EffectMeta 布兰卡 = new EffectMeta("布兰卡", false, "7242208887883992381", "7242208887883992381", "1774e2dd335a10a5f3174062c08403a2", null);
        public static readonly EffectMeta 布朗 = new EffectMeta("布朗", false, "7273777590102527290", "7273777590102527290", "b6bee72111d56fd16679adcf9543a05a", null);
        // public static readonly EffectMeta 布朗 = new EffectMeta("布朗", false, "7127576913375153415", "7127576913375153415", "1f969e8f3e5e8545f41715cde1baf946", null);
        public static readonly EffectMeta 希望 = new EffectMeta("希望", false, "7271141541521968396", "7271141541521968396", "fdb975090cbdc5a5fb2e56ae982514a2", null);
        public static readonly EffectMeta 幽蓝 = new EffectMeta("幽蓝", false, "7330441280016715062", "7330441280016715062", "9db4cff7dd63bf1a17ced3728ca02e5e", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 彩果 = new EffectMeta("彩果", false, "7175101541198679353", "7175101541198679353", "a86fb22ed3009ad44f9457f6eefdb9a7", null);
        public static readonly EffectMeta 影叙 = new EffectMeta("影叙", false, "7349953761059638555", "7349953761059638555", "72e02210098c120bbcddca245656aaca", null);
        public static readonly EffectMeta 德古拉 = new EffectMeta("德古拉", false, "7127678346472819982", "7127678346472819982", "f8bfba1ebdb6c5054eec4eb1e9433e72", null);
        public static readonly EffectMeta 快照I = new EffectMeta("快照I", false, "7143537677655100709", "7143537677655100709", "526ce6c2fd2228cda17fc5f64a7267cf", null);
        public static readonly EffectMeta 忽风 = new EffectMeta("忽风", false, "7330123964305378586", "7330123964305378586", "c455bc6760bd9829f2d467866527a1b1", null);
        public static readonly EffectMeta 恋颂 = new EffectMeta("恋颂", false, "7307103748076113188", "7307103748076113188", "2919ab042e2f8b431826f90ba9bb3e89", null);
        public static readonly EffectMeta 敦刻尔克 = new EffectMeta("敦刻尔克", false, "7127568601921408293", "7127568601921408293", "6b4a7017eecf10aa48e3f93586e04a6a", null);
        public static readonly EffectMeta 料理 = new EffectMeta("料理", false, "7127656350833806622", "7127656350833806622", "31ebabffaf3ed8653e0db318dfbeaa9d", null);
        public static readonly EffectMeta 新闪 = new EffectMeta("新闪", false, "7342395072199019803", "7342395072199019803", "9c3858dfbdd548bef8a012d55f795b47", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 日出 = new EffectMeta("日出", false, "7325383700240256296", "7325383700240256296", "628b7f7c8a7fea3f89edaff21f4c9d25", null);
        public static readonly EffectMeta 日系奶油 = new EffectMeta("日系奶油", false, "7127664177870671135", "7127664177870671135", "8e779b2183d399fb192decf3616f8c27", null);
        public static readonly EffectMeta 日落橘 = new EffectMeta("日落橘", false, "7127669630667066655", "7127669630667066655", "1ff996d1537f8a485f193314861c6b5b", null);
        public static readonly EffectMeta 旧乐园 = new EffectMeta("旧乐园", false, "7239977329668263227", "7239977329668263227", "604ff64bec0ae328aa1d1c19fb89bfa2", null);
        public static readonly EffectMeta 旧时代I = new EffectMeta("旧时代I", false, "7232218563270954300", "7232218563270954300", "9532fcb213a6eb45c2441d8d0466f9ef", null);
        public static readonly EffectMeta 明晰 = new EffectMeta("明晰", false, "7367715162964446516", "7367715162964446516", "c622c908228fb2796e141f973b9746e9", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 星云 = new EffectMeta("星云", false, "7127672042069036319", "7127672042069036319", "b73b7e9c33f8e387cbb579a5c11f01b9", null);
        public static readonly EffectMeta 晴颜 = new EffectMeta("晴颜", false, "7297968738131873035", "7297968738131873035", "97b54d7d49c75162656379068221e3a1", null);
        public static readonly EffectMeta 暖食 = new EffectMeta("暖食", false, "7127653100269210916", "7127653100269210916", "47b7c1b9f560b85b528c24f7cbbb6cd4", null);
        public static readonly EffectMeta 暗夜 = new EffectMeta("暗夜", false, "7127823728070659358", "7127823728070659358", "788c476ccf299db46035bd930d90c342", null);
        public static readonly EffectMeta 暗雅 = new EffectMeta("暗雅", false, "7127656352410848548", "7127656352410848548", "c5207d449099512b7efd9419c75378f7", null);
        public static readonly EffectMeta 暮光 = new EffectMeta("暮光", false, "7242211155131862332", "7242211155131862332", "b5e36cb0438d74eac97fb6c7ec66260f", null);
        public static readonly EffectMeta 暮色 = new EffectMeta("暮色", false, "7127594686541237535", "7127594686541237535", "adbf6d3bbbd6a6d4525300d78323a7d2", null);
        public static readonly EffectMeta 月升之国 = new EffectMeta("月升之国", false, "7127819487419567373", "7127819487419567373", "46638e887295beddd23c84206af26a1b", null);
        public static readonly EffectMeta 月夜 = new EffectMeta("月夜", false, "7143532202112912670", "7143532202112912670", "67cfe630584f194d007e3001052f5094", null);
        public static readonly EffectMeta 月辉 = new EffectMeta("月辉", false, "7213576268346838333", "7213576268346838333", "606cb40e4b0b4706855126dc82ed3e01", null);
        public static readonly EffectMeta 未央 = new EffectMeta("未央", false, "7340282260312182050", "7340282260312182050", "901d60cca1c56063279941926ed877be", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 松果棕 = new EffectMeta("松果棕", false, "7127669342325443854", "7127669342325443854", "d68bcfc1e312f0e3e52f164a59cff686", null);
        public static readonly EffectMeta 林间 = new EffectMeta("林间", false, "7127663793827564808", "7127663793827564808", "c1ff0cd2a3eea239334b9604d31b4947", null);
        public static readonly EffectMeta 枫糖咖 = new EffectMeta("枫糖咖", false, "7305333618891574567", "7305333618891574567", "9ec78b71c47895ec6ff375a62b5b77d0", null);
        public static readonly EffectMeta 柠檬青 = new EffectMeta("柠檬青", false, "7127676358766923016", "7127676358766923016", "0437481ce079dd3f1160351c1038d628", null);
        public static readonly EffectMeta 梦海 = new EffectMeta("梦海", false, "7307544983454682431", "7307544983454682431", "09ce81fe256e044893d494f48532f66a", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 梨花白 = new EffectMeta("梨花白", false, "7345493751416016166", "7345493751416016166", "fa20a675c5b9caa46f42809746ed3ff5", null);
        public static readonly EffectMeta 梵时 = new EffectMeta("梵时", false, "7341767383259942155", "7341767383259942155", "a8908ae23533d029ea98fd6c5d052143", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 棕咖 = new EffectMeta("棕咖", false, "7273779209934245179", "7273779209934245179", "d661b0ee2e5417c12e824af664490161", null);
        public static readonly EffectMeta 棕宥 = new EffectMeta("棕宥", false, "7332348414933421366", "7332348414933421366", "d3dfad8c9cbc044369c528461bd79f57", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 棠梨 = new EffectMeta("棠梨", false, "7329819965920398604", "7329819965920398604", "09c9a4e110dd011c2155a544ecfe4b89", null);
        public static readonly EffectMeta 椰林 = new EffectMeta("椰林", false, "7252674515287788856", "7252674515287788856", "d0e4bf788a131db36ccf98e09f6cf056", null);
        public static readonly EffectMeta 椿和 = new EffectMeta("椿和", false, "7341032461234654475", "7341032461234654475", "46b1e432d7075fe6dc2b31d98809dac5", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 椿来 = new EffectMeta("椿来", false, "7347729407181704498", "7347729407181704498", "13780c3447b3326ab87365015d0d0cb9", null);
        public static readonly EffectMeta 樱粉 = new EffectMeta("樱粉", false, "7127632545272925470", "7127632545272925470", "a5411e69fdf93e03f1d0c29ee6822173", null);
        public static readonly EffectMeta 比佛利 = new EffectMeta("比佛利", false, "7127657040348040479", "7127657040348040479", "0b705ff4b8eb7fe5090848b588139e75", null);
        public static readonly EffectMeta 气泡水 = new EffectMeta("气泡水", false, "7127619120761212168", "7127619120761212168", "4a0b28181b76b9ba2dd4ccdf66aa905a", null);
        public static readonly EffectMeta 气色 = new EffectMeta("气色", false, "7127681015732014350", "7127681015732014350", "b0d684a9b8ac503bcc80efd5213c0e9e", null);
        public static readonly EffectMeta 江浙沪 = new EffectMeta("江浙沪", false, "7127838224344435981", "7127838224344435981", "9287d59bc7ff0bce6f4893b0383c4bfe", null);
        public static readonly EffectMeta 浅岛 = new EffectMeta("浅岛", false, "7281163331245821239", "7281163331245821239", "dc6d03248744c082a2929bb29184f820", null);
        public static readonly EffectMeta 浮生 = new EffectMeta("浮生", false, "7340687187194678569", "7340687187194678569", "f438386d5155971f6ecd2600126fcbb4", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 海街日记 = new EffectMeta("海街日记", false, "7127615915004366116", "7127615915004366116", "8ac09d35b39a8b6f289ef5f4330a3d62", null);
        public static readonly EffectMeta 海雾 = new EffectMeta("海雾", false, "7189595107610447163", "7189595107610447163", "3099b6872219761db76f4c7cc86ea0e5", null);
        public static readonly EffectMeta 海鸥DC = new EffectMeta("海鸥DC", false, "7127830050786823437", "7127830050786823437", "8cd726548b6275553ce2668cca28f32e", null);
        public static readonly EffectMeta 深褐 = new EffectMeta("深褐", false, "7127615347703811336", "7127615347703811336", "e7e999ed75f9f3a0626cf946b08c4f35", null);
        public static readonly EffectMeta 清明上河 = new EffectMeta("清明上河", false, "7208495962887621899", "7208495962887621899", "9fa5e1e67f3217c48cb8e64c26469fc1", null);
        public static readonly EffectMeta 清晰 = new EffectMeta("清晰", false, "7127621434230213924", "7127621434230213924", "783e545788c2a60d5d85a160ee5371ae", null);
        public static readonly EffectMeta 清澈 = new EffectMeta("清澈", false, "7359419156619332902", "7359419156619332902", "a40f003f9ea1ff5570314e7fa1e0a289", null);
        public static readonly EffectMeta 温述 = new EffectMeta("温述", false, "7351580023742090535", "7351580023742090535", "207610064067f787d8339e8661a19d72", null);
        public static readonly EffectMeta 港历 = new EffectMeta("港历", false, "7346017304909581587", "7346017304909581587", "a60377ccb7d2eba39c9c9a54178f2869", null);
        public static readonly EffectMeta 港风 = new EffectMeta("港风", false, "7127830945243090184", "7127830945243090184", "44c277e7933012ecceaa669d4bc64452", null);
        public static readonly EffectMeta 漫夏 = new EffectMeta("漫夏", false, "7366616947703991571", "7366616947703991571", "3b090944724c8cc1a8d7a5d73be3358f", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 漫彩 = new EffectMeta("漫彩", false, "7177269429972045089", "7177269429972045089", "71885c8e558e4b6fece843e3d4464e62", null);
        public static readonly EffectMeta 漫步 = new EffectMeta("漫步", false, "7263357613050563852", "7263357613050563852", "de874f8a3993f93bb067593f0dfcfa5a", null);
        public static readonly EffectMeta 烘培 = new EffectMeta("烘培", false, "7127675183246200072", "7127675183246200072", "55cb15f600fff6aa4bda19f490aa7548", null);
        public static readonly EffectMeta 烟岚 = new EffectMeta("烟岚", false, "7341204799590763788", "7341204799590763788", "33937d0f480f994e09bc32adfe352cbd", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 烟霞 = new EffectMeta("烟霞", false, "7143533042978524424", "7143533042978524424", "e33d66d89891ebab00dabb91a4b4caee", null);
        public static readonly EffectMeta 煦日 = new EffectMeta("煦日", false, "7297144048903556388", "7297144048903556388", "0ccb49dc9361df2d3262786b6c43d8ee", null);
        public static readonly EffectMeta 燃力 = new EffectMeta("燃力", false, "7248571956860079395", "7248571956860079395", "f8deda9b7cb4ff2f4e6382795c7265a7", null);
        public static readonly EffectMeta 牛皮纸 = new EffectMeta("牛皮纸", false, "7127822013074263310", "7127822013074263310", "351a03b45cb0cd2e13911113e7b06ca5", null);
        public static readonly EffectMeta 珠光蓝 = new EffectMeta("珠光蓝", false, "7127657509501914399", "7127657509501914399", "2b91f0f9a4a9cac90b3cd1be50637f58", null);
        public static readonly EffectMeta 珠落 = new EffectMeta("珠落", false, "7213575938615872823", "7213575938615872823", "9ced1b064be8feb4c3c3b2989b61e286", null);
        // public static readonly EffectMeta 琥珀 = new EffectMeta("琥珀", false, "7127620849372302629", "7127620849372302629", "3cda15f337b1fc8ce63bcc055926779c", null);
        public static readonly EffectMeta 病娇 = new EffectMeta("病娇", false, "7291179909718740259", "7291179909718740259", "5e1e1d48442e9e2fa3bab8e724bce4ad", null);
        public static readonly EffectMeta 白皙 = new EffectMeta("白皙", false, "7127668617147141413", "7127668617147141413", "d029402b10782b63f67967b4d1bc1c03", null);
        public static readonly EffectMeta 盐岚 = new EffectMeta("盐岚", false, "7359223280714239268", "7359223280714239268", "e517e2dd0dc2601874ce0ca63c9cc75d", null);
        public static readonly EffectMeta 矿野 = new EffectMeta("矿野", false, "7281162649314889015", "7281162649314889015", "7e645e33c8e3d019669e9cb5d03d6886", null);
        public static readonly EffectMeta 砂红 = new EffectMeta("砂红", false, "7300758676732677427", "7300758676732677427", "2f33ad8925eb2079b23900241fcf83a4", null);
        public static readonly EffectMeta 砾绀 = new EffectMeta("砾绀", false, "7340915058542759219", "7340915058542759219", "d0f6bbafe6d5b1d6d5100e99c79b9e9e", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 祈安 = new EffectMeta("祈安", false, "7314682996131433766", "7314682996131433766", "2a9a992fc75889486745e8213a7047f8", null);
        public static readonly EffectMeta 空灵 = new EffectMeta("空灵", false, "7353555308448419098", "7353555308448419098", "341afbfb8058ac32a1994b2dc39be59c", null);
        public static readonly EffectMeta 米棕 = new EffectMeta("米棕", false, "7221477781043973413", "7221477781043973413", "e687f0134f6ee01f8f50198bd52ebd00", null);
        public static readonly EffectMeta 粉瓷 = new EffectMeta("粉瓷", false, "7127667757998411044", "7127667757998411044", "76eac8836f1ddd762af8c6317b1c8c73", null);
        public static readonly EffectMeta 粉肤 = new EffectMeta("粉肤", false, "7296493947625557286", "7296493947625557286", "1b4893feb8dac4eb014b6e3f52449786", null);
        public static readonly EffectMeta 粹光 = new EffectMeta("粹光", false, "7373693828328475941", "7373693828328475941", "a3b69c7718dab46fedcd6ceabcb7425b", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 素肌 = new EffectMeta("素肌", false, "7127671162758270245", "7127671162758270245", "cfb819eefe90e08965021dfea52d402b", null);
        public static readonly EffectMeta 红绿 = new EffectMeta("红绿", false, "7127622617699290399", "7127622617699290399", "e20b3185492170b68d6c7944270e3f76", null);
        public static readonly EffectMeta 绝对红 = new EffectMeta("绝对红", false, "7127667361456426248", "7127667361456426248", "cc6084f69428c5a741ea4280ddbfe3c8", null);
        public static readonly EffectMeta 绿妍 = new EffectMeta("绿妍", false, "7127675252410223909", "7127675252410223909", "46a6f490249d7eabe3a9e8cd8e92cf2d", null);
        public static readonly EffectMeta 老友记 = new EffectMeta("老友记", false, "7127669912050420999", "7127669912050420999", "e45f9a4c50717a3585006591b41e3440", null);
        public static readonly EffectMeta 胡桃木 = new EffectMeta("胡桃木", false, "7127830961621847310", "7127830961621847310", "5eb7457d0d18cfdf0dcd99725acf2dd9", null);
        public static readonly EffectMeta 自然 = new EffectMeta("自然", false, "7127821314198342943", "7127821314198342943", "f4a371ed60b7448b146cd1b1c697a9e8", null);
        public static readonly EffectMeta 自由 = new EffectMeta("自由", false, "7271143155544739108", "7271143155544739108", "a202f96129bf04064a37cd92f5fda5b9", null);
        public static readonly EffectMeta 臻金 = new EffectMeta("臻金", false, "7306726303594564904", "7306726303594564904", "6cae1766e18f62be45ddcf4d169da037", null);
        public static readonly EffectMeta 花园 = new EffectMeta("花园", false, "7226990672190950713", "7226990672190950713", "b235531243327c4b03bdd5495f95d9c6", null);
        public static readonly EffectMeta 花椿 = new EffectMeta("花椿", false, "7127539889553427719", "7127539889553427719", "6502db5f541da3fdfbedf9161a79e53c", null);
        public static readonly EffectMeta 苍岭 = new EffectMeta("苍岭", false, "7310976403078434102", "7310976403078434102", "df38cb08feab82523e96b89856e4030d", null);
        public static readonly EffectMeta 落日 = new EffectMeta("落日", false, "7166494058305670432", "7166494058305670432", "a3909c6739bcfffce11c1ed328afdb39", null);
        public static readonly EffectMeta 落日海岛 = new EffectMeta("落日海岛", false, "7369501986401570099", "7369501986401570099", "0cefc26f8aa950c8934766ad229255bc", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 落日飞车 = new EffectMeta("落日飞车", false, "7350133636890463498", "7350133636890463498", "c92ce87d49816b7c930d5c1a5f537536", null);
        public static readonly EffectMeta 薄荷 = new EffectMeta("薄荷", false, "7343782317820857641", "7343782317820857641", "eed11d695897d0068dc658d09a18f444", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 褪色 = new EffectMeta("褪色", false, "7127668404764380447", "7127668404764380447", "13ed65a66841ee746146665f0aa18c6d", null);
        public static readonly EffectMeta 西野 = new EffectMeta("西野", false, "7331590962696834313", "7331590962696834313", "c5368d1617ac7b8af8b616782b388557", null);
        public static readonly EffectMeta 西餐 = new EffectMeta("西餐", false, "7127668806398315806", "7127668806398315806", "c447f798e1aaf5a776b40432571e9ee8", null);
        public static readonly EffectMeta 谧歌 = new EffectMeta("谧歌", false, "7301212776532380966", "7301212776532380966", "229eed4ae519e0c29efe23a2f07ba644", null);
        public static readonly EffectMeta 贝松绿 = new EffectMeta("贝松绿", false, "7127668616991952158", "7127668616991952158", "5820a95014d61c7b5a45d23ba045d0e1", null);
        public static readonly EffectMeta 质感暗调 = new EffectMeta("质感暗调", false, "7127653798155209997", "7127653798155209997", "80cc0198c081d823bfbfa08fd5e0c3c6", null);
        public static readonly EffectMeta 赛博朋克 = new EffectMeta("赛博朋克", false, "7127657979838516494", "7127657979838516494", "fe6d8ddb41fd8ea4f184ff5d9ca0b77e", null);
        public static readonly EffectMeta 赤陀 = new EffectMeta("赤陀", false, "7226251886360300837", "7226251886360300837", "f44a2fd63bcdb30bd1cdfd1120ced1e1", null);
        public static readonly EffectMeta 赫本 = new EffectMeta("赫本", false, "7127663117508660517", "7127663117508660517", "589b59735865a200db3ac561640ed299", null);
        public static readonly EffectMeta 赫石 = new EffectMeta("赫石", false, "7302823953406446899", "7302823953406446899", "4be5b26f8b932f7fe7a3f8033d5549b2", null);
        public static readonly EffectMeta 轻食 = new EffectMeta("轻食", false, "7127621137705618724", "7127621137705618724", "27fbb36cf04af9886d4d9e6abcd3691b", null);
        public static readonly EffectMeta 达芬妮 = new EffectMeta("达芬妮", false, "7300602459356040484", "7300602459356040484", "e9556101678a74dc573133da00401854", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 迈阿密 = new EffectMeta("迈阿密", false, "7127684611450178823", "7127684611450178823", "f9f32708f0029a5b043736e64133324f", null);
        public static readonly EffectMeta 酷白 = new EffectMeta("酷白", false, "7127676762514885919", "7127676762514885919", "e62e07d9ed430226e6afaa96dba3844a", null);
        public static readonly EffectMeta 金属 = new EffectMeta("金属", false, "7127654151688949000", "7127654151688949000", "7aaae4aad5195f4df6929d9cb2f77fc9", null);
        public static readonly EffectMeta 闪光灯 = new EffectMeta("闪光灯", false, "7364705637931994405", "7364705637931994405", "5b6fd1621826d837d88c71de0ced5f76", null);
        public static readonly EffectMeta 闻香识人 = new EffectMeta("闻香识人", false, "7127823728267775263", "7127823728267775263", "56693fef51ca05d7631f1bf3ae47c3cc", null);
        public static readonly EffectMeta 阿尔菲 = new EffectMeta("阿尔菲", false, "7299130097632627979", "7299130097632627979", "5225172497e1cd5bd3a8e1162a9c25d0", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 雪鹿 = new EffectMeta("雪鹿", false, "7302796570947243264", "7302796570947243264", "10ff7e7bc0accc06c5ce3b9c09114b18", null);
        public static readonly EffectMeta 雾瓷 = new EffectMeta("雾瓷", false, "7169239634076060960", "7169239634076060960", "03e7a58f2d18954a4ced7fec8371cd5e", null);
        public static readonly EffectMeta 青橙 = new EffectMeta("青橙", false, "7127615575865478430", "7127615575865478430", "58b4c939e727d94fb074ca0a1c0400ad", null);
        public static readonly EffectMeta 青红夜 = new EffectMeta("青红夜", false, "7281575818621455628", "7281575818621455628", "7b439160a4134076dc70571813ec9cbb", null);
        public static readonly EffectMeta 风铃 = new EffectMeta("风铃", false, "7211001257996127547", "7211001257996127547", "48d79f8501ade6fd7a33055b83947eb8", null);
        public static readonly EffectMeta 高饱和 = new EffectMeta("高饱和", false, "7127653121966230814", "7127653121966230814", "a0533d46f3bc544f36e00965b2644067", null);
        public static readonly EffectMeta 鬼魅 = new EffectMeta("鬼魅", false, "7291201164027252024", "7291201164027252024", "20fd9ce9674e1e0137955e2d74ce252a", null);
        public static readonly EffectMeta 黑胶唱片 = new EffectMeta("黑胶唱片", false, "7221805176410180921", "7221805176410180921", "97fc59d95cbb611d888bf10da5a1c015", null);
        public static readonly EffectMeta 黑豹 = new EffectMeta("黑豹", false, "7202475126485503236", "7202475126485503236", "9f33e8c52e07d1af8ff00781f7645124", null);
        public static readonly EffectMeta 默片 = new EffectMeta("默片", false, "7127655037026848031", "7127655037026848031", "81be2b9491c4c805cb4f70a595ab46a6", null);
        public static readonly EffectMeta _160C = new EffectMeta("160C", true, "7190249807682800954", "7190249807682800954", "7505f10b71bc6e346a1696544121ac9e", null);
        public static readonly EffectMeta _2077 = new EffectMeta("2077", true, "7131347316111314189", "7131347316111314189", "a85f790077f307193b1c70ed94e4aa41", null);
        public static readonly EffectMeta _400H = new EffectMeta("400H", true, "7190236487152127269", "7190236487152127269", "20817f9b1ed37a720c02abea87714655", null);
        public static readonly EffectMeta _800Z = new EffectMeta("800Z", true, "7190237757552348471", "7190237757552348471", "53acbe492462a72db57c3f5ed7de9345", null);
        public static readonly EffectMeta _90s = new EffectMeta("90s", true, "7131366613823114503", "7131366613823114503", "67f1677d3b2033d0ab1101789fd833cb", null);
        public static readonly EffectMeta City_Walk = new EffectMeta("City Walk", true, "7263360572404550931", "7263360572404550931", "9a183540a03b391b3a17b67970ddc93a", null);
        public static readonly EffectMeta FXN = new EffectMeta("FXN", true, "7332480052392774975", "7332480052392774975", "01cd75f7c9b5fb3b05bbcb54e53400d4", null);
        public static readonly EffectMeta GR正片 = new EffectMeta("GR正片", true, "7168098796860148995", "7168098796860148995", "1f28a387f3f22baff4b1410530d2750f", null);
        public static readonly EffectMeta GR绿 = new EffectMeta("GR绿", true, "7168121440141708576", "7168121440141708576", "5ad1db915106f04413a025928b28cdf5", null);
        public static readonly EffectMeta GR蓝 = new EffectMeta("GR蓝", true, "7168097661160131879", "7168097661160131879", "c191e003d6d9f39dd5e9b770fb21ac29", null);
        public static readonly EffectMeta IG白 = new EffectMeta("IG白", true, "7221479156318489893", "7221479156318489893", "02a7a3a08ed9756bb1ae7b924213c33d", null);
        public static readonly EffectMeta INS暗 = new EffectMeta("INS暗", true, "7223645151820877093", "7223645151820877093", "29c393013eddca0fdd0ee0087100915e", null);
        public static readonly EffectMeta 中性 = new EffectMeta("中性", true, "7127621445806525704", "7127621445806525704", "8168144d29c35cf186eccb03ec9f3d93", null);
        public static readonly EffectMeta 中性II = new EffectMeta("中性II", true, "7312646907908607244", "7312646907908607244", "ad71ff12ac0afd02cb6c583d0ee69d8a", null);
        public static readonly EffectMeta 丹枫 = new EffectMeta("丹枫", true, "7297138825359281423", "7297138825359281423", "a97673c2524eba984b75396530501fa8", null);
        public static readonly EffectMeta 乐游 = new EffectMeta("乐游", true, "7193982146363673856", "7193982146363673856", "2a215f5fe9ff6c1a8effea9135bbe3bb", null);
        public static readonly EffectMeta 云暖 = new EffectMeta("云暖", true, "7314883649999015231", "7314883649999015231", "7819364ae09bf6c6771fce646cde6ec9", null);
        public static readonly EffectMeta 人生之事 = new EffectMeta("人生之事", true, "7148844086869396743", "7148844086869396743", "3dfc5764bccb9e7ec2e3f15e59edd563", null);
        public static readonly EffectMeta 仲夏夜 = new EffectMeta("仲夏夜", true, "7281166048273943867", "7281166048273943867", "0773453b9c513222ed0b2a629b141b38", null);
        public static readonly EffectMeta 余晖 = new EffectMeta("余晖", true, "7278616064018107707", "7278616064018107707", "19e8ac930af976579c60df1ad6f4c4fe", null);
        public static readonly EffectMeta 佳能G7X_II = new EffectMeta("佳能G7X II", true, "7291597100389862707", "7291597100389862707", "e9aef9a32a0ed9ebf39c9f23340fd408", null);
        public static readonly EffectMeta 佳能G7X_III = new EffectMeta("佳能G7X III", true, "7291595038688136474", "7291595038688136474", "3c89208f4754d78ad97df171a1cc1ffc", null);
        public static readonly EffectMeta 俱乐部 = new EffectMeta("俱乐部", true, "7239235794744003851", "7239235794744003851", "1f6a4516fb91c8e68217123191dc38ea", null);
        public static readonly EffectMeta 倾森 = new EffectMeta("倾森", true, "7332714336315526409", "7332714336315526409", "2b0731e9eacb5098ad43bd99ae6f23d7", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 光流 = new EffectMeta("光流", true, "7233732009070300473", "7233732009070300473", "351346b807ca9bfa063e517f10d96f95", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 冬禧 = new EffectMeta("冬禧", true, "7190250133672578316", "7190250133672578316", "6423fd745c7ba83613feea71977763fb", null);
        public static readonly EffectMeta 冰原 = new EffectMeta("冰原", true, "7171615136271060236", "7171615136271060236", "4664881945ad10f8e3de28f2ccd47e56", null);
        public static readonly EffectMeta 冰瀑 = new EffectMeta("冰瀑", true, "7196927862056701240", "7196927862056701240", "9691bde0838975e3573faad0791d3cdf", null);
        public static readonly EffectMeta 冰茶 = new EffectMeta("冰茶", true, "7131399016771800357", "7131399016771800357", "ab44066c23ab6639ca6ff5eb2b850582", null);
        public static readonly EffectMeta 冰雪世界 = new EffectMeta("冰雪世界", true, "7328364342146059531", "7328364342146059531", "6df501f5b6c1cdba49ded903a5d6a28c", null);
        public static readonly EffectMeta 冷叙 = new EffectMeta("冷叙", true, "7159132840179895590", "7159132840179895590", "c60635dea7f7a6df2ba9b1e08fee006e", null);
        public static readonly EffectMeta 冷墨 = new EffectMeta("冷墨", true, "7300751893813366053", "7300751893813366053", "e6d9891ef7f02898055a16f11a8750bc", null);
        public static readonly EffectMeta 冷寂 = new EffectMeta("冷寂", true, "7171628827477642535", "7171628827477642535", "9a932b548dfab1964a2d70ef27717d43", null);
        public static readonly EffectMeta 冷月夜 = new EffectMeta("冷月夜", true, "7281165355353951543", "7281165355353951543", "0a9aaba6174a6b1a46d78365bd7fa0c4", null);
        public static readonly EffectMeta 冷透 = new EffectMeta("冷透", true, "7127824802819116302", "7127824802819116302", "06655076bb1cf6ce7c6e3b23d027496f", null);
        public static readonly EffectMeta 净白 = new EffectMeta("净白", true, "7127667352782572807", "7127667352782572807", "c13995808d8fbfdf9ed2b9f2873dfea7", null);
        public static readonly EffectMeta 净透 = new EffectMeta("净透", true, "7127666004477414687", "7127666004477414687", "bc8357fb00d1824e2ceaed463bc611b6", null);
        public static readonly EffectMeta 凛风 = new EffectMeta("凛风", true, "7189593678816513340", "7189593678816513340", "c270ecab8fc6c7db7bbf30da6ea69ecd", null);
        public static readonly EffectMeta 初雪 = new EffectMeta("初雪", true, "7166473491737283873", "7166473491737283873", "50cf99c6a27c0a6e284fcc34afbe5e13", null);
        public static readonly EffectMeta 初雪II = new EffectMeta("初雪II", true, "7307159461724966185", "7307159461724966185", "348ff04e81ba87ea2638a5aa8282ff05", null);
        public static readonly EffectMeta 劲闯 = new EffectMeta("劲闯", true, "7248568097660013864", "7248568097660013864", "9822ae48045e256dfb2ca2369c368d47", null);
        public static readonly EffectMeta 原生肤 = new EffectMeta("原生肤", true, "7366582938638503187", "7366582938638503187", "8dc66d930e2420c9c035182ddbd3d627", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 去灰 = new EffectMeta("去灰", true, "7127559231062002951", "7127559231062002951", "21c377ab968576732daa1643051b735c", null);
        public static readonly EffectMeta 去灰II = new EffectMeta("去灰II", true, "7226991425160858937", "7226991425160858937", "e58c1b8d3539cb1e89c37dc56b934369", null);
        public static readonly EffectMeta 去黄 = new EffectMeta("去黄", true, "7302338306849656127", "7302338306849656127", "f4fcb8afc69acb229dec8764320e42a3", null);
        public static readonly EffectMeta 古早记忆 = new EffectMeta("古早记忆", true, "7366562482812456255", "7366562482812456255", "3a6086410283e0166d65d7935faa3809", null);
        public static readonly EffectMeta 古筑 = new EffectMeta("古筑", true, "7226238008201104698", "7226238008201104698", "77e37950cce407b97cc09888476d64cc", null);
        public static readonly EffectMeta 古都 = new EffectMeta("古都", true, "7127615616525126949", "7127615616525126949", "ce6f674fe7eebb2be94a3784496d2d4f", null);
        public static readonly EffectMeta 吉宵 = new EffectMeta("吉宵", true, "7190241639070174503", "7190241639070174503", "14910132a5caef71f9fa0a1076098026", null);
        public static readonly EffectMeta 向晚 = new EffectMeta("向晚", true, "7226254370084490554", "7226254370084490554", "f16c7f86eb94ede08374f3485d9de7f6", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 味蕾 = new EffectMeta("味蕾", true, "7281166220794055997", "7281166220794055997", "04205b3010d2adedb961380ceb679a6b", null);
        public static readonly EffectMeta 哈苏I = new EffectMeta("哈苏I", true, "7291596720956329266", "7291596720956329266", "df3882769e455938b11f5596ac569e49", null);
        public static readonly EffectMeta 哈苏II = new EffectMeta("哈苏II", true, "7291560741885480250", "7291560741885480250", "498b45335903ffa59cef94ac0376fd38", null);
        public static readonly EffectMeta 哈苏蓝 = new EffectMeta("哈苏蓝", true, "7361792059109313811", "7361792059109313811", "45392b51287027d5fa5249495c6a9007", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 哥谭 = new EffectMeta("哥谭", true, "7337928347118275890", "7337928347118275890", "25575caefd72dfcac744d7aa717d4c1f", null);
        public static readonly EffectMeta 增色 = new EffectMeta("增色", true, "7283013745788357925", "7283013745788357925", "c1dffcebde80cca62c000f8f023065c8", null);
        public static readonly EffectMeta 墨林 = new EffectMeta("墨林", true, "7271284653816843554", "7271284653816843554", "a311fa20eacf38b912c183627e008ff5", null);
        public static readonly EffectMeta 夏日粉 = new EffectMeta("夏日粉", true, "7261469707138518283", "7261469707138518283", "b667443ab8554ad725bd72bb9cabab2b", null);
        public static readonly EffectMeta 多巴胺 = new EffectMeta("多巴胺", true, "7237441824611224889", "7237441824611224889", "83ec0f2e61d762e17830bd55ca08e8d3", null);
        public static readonly EffectMeta 夜景增色 = new EffectMeta("夜景增色", true, "7341302999068757259", "7341302999068757259", "f144c6f9e9accae6cb76c2b11b9549b2", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 夜雾 = new EffectMeta("夜雾", true, "7168110568673479948", "7168110568673479948", "e6b2ff75ac938639d840ec586264c2f5", null);
        // public static readonly EffectMeta 夜雾 = new EffectMeta("夜雾", true, "7132866902367423748", "7132866902367423748", "e6b2ff75ac938639d840ec586264c2f5", null);
        public static readonly EffectMeta 奥林巴斯 = new EffectMeta("奥林巴斯", true, "7361792068475325735", "7361792068475325735", "a523adb5976eb5a39d963683f520551f", null);
        public static readonly EffectMeta 奶昔 = new EffectMeta("奶昔", true, "7172169921726565670", "7172169921726565670", "ca0cc9a987f8eca36ac97a5b5d6a5327", null);
        public static readonly EffectMeta 奶杏 = new EffectMeta("奶杏", true, "7127670311775898917", "7127670311775898917", "bc9612d23f668596ecc50c1e636ed7e8", null);
        public static readonly EffectMeta 好莱坞I = new EffectMeta("好莱坞I", true, "7226994281414692155", "7226994281414692155", "b255b7959f2c621cdbc5aa7cda9e7583", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 好莱坞II = new EffectMeta("好莱坞II", true, "7226995248814165308", "7226995248814165308", "41348d00e1ab4f1dbe6832f8b6224c13", null);
        public static readonly EffectMeta 好莱坞III = new EffectMeta("好莱坞III", true, "7312617341710372107", "7312617341710372107", "59b8ade3560f637686d6e4b0f56f97fe", null);
        public static readonly EffectMeta 好莱坞IV = new EffectMeta("好莱坞IV", true, "7312647197462367524", "7312647197462367524", "12657ebf4545c621bc0ca38944b9712c", null);
        public static readonly EffectMeta 嫩肤 = new EffectMeta("嫩肤", true, "7300523145818148096", "7300523145818148096", "f79fa85e5e9238570b84b95505406213", null);
        public static readonly EffectMeta 子弹列车 = new EffectMeta("子弹列车", true, "7202480777387445507", "7202480777387445507", "ee8aa0105ea992ace4fc114c34b08adc", null);
        public static readonly EffectMeta 家宴 = new EffectMeta("家宴", true, "7330584144524643595", "7330584144524643595", "1cb453a49c768a3f9c086b047321c233", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 宿营 = new EffectMeta("宿营", true, "7127822311708691726", "7127822311708691726", "e8ad70a709e7a37282ee64779c874732", null);
        public static readonly EffectMeta 富士CC_I = new EffectMeta("富士CC I", true, "7268561936344780086", "7268561936344780086", "069ae1d53dc300c85b017cdf6df18550", null);
        public static readonly EffectMeta 富士NC_I = new EffectMeta("富士NC I", true, "7159156535640296737", "7159156535640296737", "bdce583bf77430b24e9f7d78d40a69eb", null);
        public static readonly EffectMeta 富士NC_II = new EffectMeta("富士NC II", true, "7159408376378559747", "7159408376378559747", "0fce68168c67f99c11bf1e05e933eb79", null);
        public static readonly EffectMeta 富士NC_III = new EffectMeta("富士NC III", true, "7159134459088899339", "7159134459088899339", "25f1e0d1d5997b56577a96de8de2005d", null);
        public static readonly EffectMeta 富士蓝 = new EffectMeta("富士蓝", true, "7246720031118101816", "7246720031118101816", "ca146f44fb50a5c1335149b2c1bd0079", null);
        public static readonly EffectMeta 富士蓝II = new EffectMeta("富士蓝II", true, "7226994246471945530", "7226994246471945530", "43bee1438c8372b1f4a8857650fab808", null);
        public static readonly EffectMeta 富士青 = new EffectMeta("富士青", true, "7226994214029184313", "7226994214029184313", "77bfdff2d848539626acd538429cc660", null);
        public static readonly EffectMeta 小麦肌 = new EffectMeta("小麦肌", true, "7131507906737917220", "7131507906737917220", "0498d2f3ee88c8073f774e908ade3400", null);
        public static readonly EffectMeta 小麦色 = new EffectMeta("小麦色", true, "7362076973981584691", "7362076973981584691", "ea639b8e75457d08c026eb753f8704e5", null);
        public static readonly EffectMeta 尘烟 = new EffectMeta("尘烟", true, "7148958479326153991", "7148958479326153991", "d649f05e5cc2f0f7a93d703418a4d7ee", null);
        public static readonly EffectMeta 山晴 = new EffectMeta("山晴", true, "7246723856222719269", "7246723856222719269", "acbd5fdb5b04114a6eedffdf716ed6b3", null);
        public static readonly EffectMeta 山本 = new EffectMeta("山本", true, "7156638423191784735", "7156638423191784735", "9bf35c896fe6637a3cd8017f5fc8eaed", null);
        public static readonly EffectMeta 岚夏 = new EffectMeta("岚夏", true, "7260771472107441471", "7260771472107441471", "5d9760bfa20e1745f2da9d0dddc1f8f3", null);
        public static readonly EffectMeta 岩灰 = new EffectMeta("岩灰", true, "7221472488079904060", "7221472488079904060", "fdd078505b4a102962d962cf461e9544", null);
        public static readonly EffectMeta 底特律 = new EffectMeta("底特律", true, "7336763348492553499", "7336763348492553499", "d1bcdfe293f329d701a0df1ef4ab5e16", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 彩光 = new EffectMeta("彩光", true, "7127824109093866760", "7127824109093866760", "0aeae3c00b2ff3d26f0bba78a0f0cda5", null);
        public static readonly EffectMeta 影部 = new EffectMeta("影部", true, "7168136171673963787", "7168136171673963787", "57ebfdd7bdad96f19879e1635d823fb8", null);
        public static readonly EffectMeta 徕卡I = new EffectMeta("徕卡I", true, "7268562944093408523", "7268562944093408523", "91730e54e94b7eeb40bcfbd8f7c9a3cf", null);
        public static readonly EffectMeta 徕卡II = new EffectMeta("徕卡II", true, "7268563047776587020", "7268563047776587020", "a75e26160d19e9db7d9be10f6e8056b7", null);
        public static readonly EffectMeta 心动夏 = new EffectMeta("心动夏", true, "7261461692096220428", "7261461692096220428", "daffbda5fec8238d91024cb36610023d", null);
        public static readonly EffectMeta 忆山 = new EffectMeta("忆山", true, "7271278427309755688", "7271278427309755688", "919dd48c0590b884f6aabc4f46f63b3f", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 快照II = new EffectMeta("快照II", true, "7143760738765655310", "7143760738765655310", "94a1e1cdca9b003126ac25d1df655263", null);
        public static readonly EffectMeta 怦然心动 = new EffectMeta("怦然心动", true, "7195889899738909990", "7195889899738909990", "48ce7e2b8db89c5f411f53d6d7750cb7", null);
        public static readonly EffectMeta 恍光 = new EffectMeta("恍光", true, "7237446176629345593", "7237446176629345593", "9c7e3ff19468cb967d0ff9b0d79ea23d", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 慕斯 = new EffectMeta("慕斯", true, "7261185427703418169", "7261185427703418169", "038504b6474c25b4ce735d1d165c4198", null);
        public static readonly EffectMeta 捕风 = new EffectMeta("捕风", true, "7248566556593098024", "7248566556593098024", "2ebec31165718f44bbd2ecbc338c175a", null);
        public static readonly EffectMeta 摩登 = new EffectMeta("摩登", true, "7131219052021779719", "7131219052021779719", "178dab15fb53b396f20c89ccaec799a2", null);
        public static readonly EffectMeta 攀岩 = new EffectMeta("攀岩", true, "7195930274918567180", "7195930274918567180", "928cb605e08b3e72110837d55afaa9d9", null);
        public static readonly EffectMeta 日和 = new EffectMeta("日和", true, "7338311462277991718", "7338311462277991718", "70b43e53688e11ab0f849a5768cf6f6f", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 旧时代II = new EffectMeta("旧时代II", true, "7232217903536409893", "7232217903536409893", "779a72d4b71cd42f470008749a165d93", null);
        public static readonly EffectMeta 旧时来信 = new EffectMeta("旧时来信", true, "7366562830486621459", "7366562830486621459", "1680dbb9fafa20e0a3c81e56b038508f", null);
        public static readonly EffectMeta 旧金山 = new EffectMeta("旧金山", true, "7159161900389977382", "7159161900389977382", "22f238fa32975ad165c124316008ab31", null);
        public static readonly EffectMeta 旷野 = new EffectMeta("旷野", true, "7275698024892943655", "7275698024892943655", "5d52166c545e774971e36e50cb218f04", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 旷野蓝 = new EffectMeta("旷野蓝", true, "7131513310733765918", "7131513310733765918", "80b306543cb7373bc89f06ae76629ebe", null);
        public static readonly EffectMeta 明肤 = new EffectMeta("明肤", true, "7302334059890478347", "7302334059890478347", "db19d8273ad16417298afc8b9038778a", null);
        public static readonly EffectMeta 春风 = new EffectMeta("春风", true, "7148963827239963918", "7148963827239963918", "ae9468b81643a706f5cae5761eff19b8", null);
        public static readonly EffectMeta 昭和 = new EffectMeta("昭和", true, "7195780237790154042", "7195780237790154042", "211b05e6793f255052a1cc463864ed3d", null);
        public static readonly EffectMeta 晚宴 = new EffectMeta("晚宴", true, "7302041028205333786", "7302041028205333786", "af499ef2d522dda0857f2be9c7db00d0", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 晚晴 = new EffectMeta("晚晴", true, "7297143895408839947", "7297143895408839947", "987e48eb485c58a239d5d67d01b9c76a", null);
        public static readonly EffectMeta 晚樱 = new EffectMeta("晚樱", true, "7127609541839129886", "7127609541839129886", "c30e126bfe5accdb5902c5ba63c8579e", null);
        public static readonly EffectMeta 晚霞 = new EffectMeta("晚霞", true, "7278616055470165285", "7278616055470165285", "4964c30b3df8eb4cca5831bffa864ecb", null);
        public static readonly EffectMeta 晚霞增色 = new EffectMeta("晚霞增色", true, "7392898170524618023", "7392898170524618023", "ed6efd67ec78c21a530046b4a6cfbb66", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 普林斯顿 = new EffectMeta("普林斯顿", true, "7127615578705104135", "7127615578705104135", "ab9e14d92af596b94e91fd6253b510cd", null);
        public static readonly EffectMeta 晴冬 = new EffectMeta("晴冬", true, "7307159401838726441", "7307159401838726441", "d8264137bd37822e87e482593926f0a6", null);
        public static readonly EffectMeta 晴好 = new EffectMeta("晴好", true, "7281163707227344189", "7281163707227344189", "8ab42295fd5c3f9671dc860cab4cf822", null);
        public static readonly EffectMeta 晴好假日 = new EffectMeta("晴好假日", true, "7374709776623635724", "7374709776623635724", "9747e32d2ec1f251aee54d080ec5fc84", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 晴春 = new EffectMeta("晴春", true, "7346542846863887635", "7346542846863887635", "ed510f73b526d21d1fcabfc410f664b8", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 晴空 = new EffectMeta("晴空", true, "7127558139058179342", "7127558139058179342", "5b5899ce01e0aac5b8f15a2f77c4ee62", null);
        public static readonly EffectMeta 晴肤 = new EffectMeta("晴肤", true, "7365842976691604763", "7365842976691604763", "c3d640b01c7bb7f6ab7ebd598bf92811", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 晶透 = new EffectMeta("晶透", true, "7199095242476293435", "7199095242476293435", "17e30bbde014d6688a3b00203a7a8ea8", null);
        public static readonly EffectMeta 暖冬 = new EffectMeta("暖冬", true, "7171607744900877600", "7171607744900877600", "ebfd26418a2c446b0d9a03d43b6c1f09", null);
        public static readonly EffectMeta 暖晨 = new EffectMeta("暖晨", true, "7312646382395936010", "7312646382395936010", "03737fce45a4ba22d225edbe7e36a04c", null);
        public static readonly EffectMeta 暖黄 = new EffectMeta("暖黄", true, "7127830631601458440", "7127830631601458440", "7c7c4a40d7c44698a9db145eb8260156", null);
        public static readonly EffectMeta 暗匣 = new EffectMeta("暗匣", true, "7159163878822153483", "7159163878822153483", "00729c25c8b262db946bb5ac80b8d1dc", null);
        public static readonly EffectMeta 暗夜明肤 = new EffectMeta("暗夜明肤", true, "7328364126449765671", "7328364126449765671", "9fe0da0817604428adb38249ecae911c", null);
        public static readonly EffectMeta 暗影 = new EffectMeta("暗影", true, "7291203298630159676", "7291203298630159676", "21f3af497daf847e50efadc241f88a1a", null);
        public static readonly EffectMeta 暗曛 = new EffectMeta("暗曛", true, "7281163501047991608", "7281163501047991608", "893d483cd405343c9420015066e56096", null);
        public static readonly EffectMeta 暗银 = new EffectMeta("暗银", true, "7177725752513793284", "7177725752513793284", "ad378d530ac056cb2b2e0b0ab171ede8", null);
        public static readonly EffectMeta 暗银II = new EffectMeta("暗银II", true, "7223630575888780602", "7223630575888780602", "33f209efb496924d6da0c7ad89bea81f", null);
        public static readonly EffectMeta 暮川 = new EffectMeta("暮川", true, "7262351934785408267", "7262351934785408267", "187450ba96a5e11233e9d38396274d87", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 暮色约会 = new EffectMeta("暮色约会", true, "7332396398157090089", "7332396398157090089", "920f4d54eb383be7327d76689d96f1a5", null);
        public static readonly EffectMeta 月吟 = new EffectMeta("月吟", true, "7168108694285159719", "7168108694285159719", "98ee4013998d056bf434a4d2c62cf548", null);
        // public static readonly EffectMeta 月吟 = new EffectMeta("月吟", true, "7132787977171766539", "7132787977171766539", "465157acdab059cfa20046ba607ae618", null);
        public static readonly EffectMeta 松绿 = new EffectMeta("松绿", true, "7246723559047941433", "7246723559047941433", "1aca4ded18b11bff899309955ed07c5c", null);
        public static readonly EffectMeta 果酥 = new EffectMeta("果酥", true, "7160594387594972446", "7160594387594972446", "f68ff633bab02132880a03034894d378", null);
        public static readonly EffectMeta 柔焦 = new EffectMeta("柔焦", true, "7345412316621442354", "7345412316621442354", "e9449745f95a354e4d835961cbb0e674", null);
        public static readonly EffectMeta 柔绀 = new EffectMeta("柔绀", true, "7189592131118320954", "7189592131118320954", "ab2c4bebda2329ec36efd65b725a37cb", null);
        public static readonly EffectMeta 栩栩 = new EffectMeta("栩栩", true, "7177259623819316519", "7177259623819316519", "09c34a30d79f4c7332267b16eaca664e", null);
        public static readonly EffectMeta 格金 = new EffectMeta("格金", true, "7348301778909252879", "7348301778909252879", "256144ddabaf723badea240301660868", null);
        public static readonly EffectMeta 桃木 = new EffectMeta("桃木", true, "7252673818035064124", "7252673818035064124", "7e5d4fb53f764eaa07d6e465fd60588e", null);
        public static readonly EffectMeta 桃粉 = new EffectMeta("桃粉", true, "7297131749346135331", "7297131749346135331", "80b55b69c2b4662c65835f49ee46ad97", null);
        public static readonly EffectMeta 桐影 = new EffectMeta("桐影", true, "7275699191253339455", "7275699191253339455", "b77671ede2639384b704eb73722e928a", null);
        public static readonly EffectMeta 梦境 = new EffectMeta("梦境", true, "7127675251604917517", "7127675251604917517", "12627ad5e79adab77540c65ea8ee7cc2", null);
        public static readonly EffectMeta 梦幻雪乡 = new EffectMeta("梦幻雪乡", true, "7328364320276876598", "7328364320276876598", "e39ddb22d6d8da4f2dea3f9025c0f92f", null);
        public static readonly EffectMeta 梦核紫 = new EffectMeta("梦核紫", true, "7261463763344248103", "7261463763344248103", "41ed7e729f06a288363ca93a928f8a90", null);
        public static readonly EffectMeta 棕榈 = new EffectMeta("棕榈", true, "7252676190073392444", "7252676190073392444", "113b463fa3945ef37700c7c52dfc6bb9", null);
        public static readonly EffectMeta 森山 = new EffectMeta("森山", true, "7242215081663008056", "7242215081663008056", "0dc17be521cf783590bebcf2a5c888df", null);
        public static readonly EffectMeta 森秋 = new EffectMeta("森秋", true, "7274575376095923497", "7274575376095923497", "b055e64a58bd8d9b882477c9be6ef3a6", null);
        public static readonly EffectMeta 榄白 = new EffectMeta("榄白", true, "7169350167903112451", "7169350167903112451", "6068c4a2ea7f0854027347a938115dae", null);
        public static readonly EffectMeta 橙蓝 = new EffectMeta("橙蓝", true, "7127561047048850718", "7127561047048850718", "4dd590015f2e14265dd5456a91ec86a6", null);
        public static readonly EffectMeta 殷粉 = new EffectMeta("殷粉", true, "7169357894868061478", "7169357894868061478", "91d27d5647faec40a747359ec6dd6eb4", null);
        public static readonly EffectMeta 沙砾 = new EffectMeta("沙砾", true, "7160580722774920461", "7160580722774920461", "a796471629be7b3bfbd649deafca3ddb", null);
        public static readonly EffectMeta 法餐 = new EffectMeta("法餐", true, "7127655700532186398", "7127655700532186398", "b8b6d5ae88e12e25be14a2dd85b7cbc6", null);
        public static readonly EffectMeta 浅茶 = new EffectMeta("浅茶", true, "7221481120083283257", "7221481120083283257", "6acf81ddf75fc8c5ddb20f3a927dcaa3", null);
        public static readonly EffectMeta 浅草 = new EffectMeta("浅草", true, "7195783041376111932", "7195783041376111932", "8c4eb75992a7f07bd07e56c16b388d87", null);
        public static readonly EffectMeta 润光 = new EffectMeta("润光", true, "7199093300526173501", "7199093300526173501", "3916e1d5dc3a3522f4b883c3b1f2b43a", null);
        public static readonly EffectMeta 润白 = new EffectMeta("润白", true, "7366518614729493799", "7366518614729493799", "1686ce704f4899b9e9a1e42693f24037", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 淡奶油 = new EffectMeta("淡奶油", true, "7127668617101020423", "7127668617101020423", "e53103dabd1bbb6ab4481b18a4c42b2c", null);
        public static readonly EffectMeta 清新润颜 = new EffectMeta("清新润颜", true, "7383551596023663882", "7383551596023663882", "738937971c198e9952e91f08adaa8227", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 清晰ll = new EffectMeta("清晰ll", true, "7127669764792634637", "7127669764792634637", "7b2ad7edaed946467ab161d016cfca93", null);
        public static readonly EffectMeta 清爽 = new EffectMeta("清爽", true, "7392897785755897100", "7392897785755897100", "c012321a086ec42b7570338f557a713e", null);
        public static readonly EffectMeta 漠土 = new EffectMeta("漠土", true, "7347670931646549282", "7347670931646549282", "9dfde36f1fab0e85773d04fadeb30650", null);
        // public static readonly EffectMeta 漫夏 = new EffectMeta("漫夏", true, "7210756366317686054", "7210756366317686054", "9517c7a5e9f82a3964dd3967a2b6273f", null);
        public static readonly EffectMeta 漫樱 = new EffectMeta("漫樱", true, "7356883843376221475", "7356883843376221475", "1799ab3b4a9bf0957995b69d27195229", null);
        public static readonly EffectMeta 漫空 = new EffectMeta("漫空", true, "7210749292888280359", "7210749292888280359", "cd88f8152fffe8033bb5057fc2539319", null);
        public static readonly EffectMeta 漫荫 = new EffectMeta("漫荫", true, "7210758351595048195", "7210758351595048195", "fc46efdc25a15ca3958126a8c72c1cd8", null);
        public static readonly EffectMeta 漱石 = new EffectMeta("漱石", true, "7145394477249678606", "7145394477249678606", "ac50156682af7d7ce4e76eb731a5a832", null);
        public static readonly EffectMeta 潘多拉 = new EffectMeta("潘多拉", true, "7127620215290039566", "7127620215290039566", "36e7d537966ee59eb61c326598546cb0", null);
        public static readonly EffectMeta 灯会 = new EffectMeta("灯会", true, "7145394908608662814", "7145394908608662814", "21472133401674a3e5645f79e9d30ae9", null);
        public static readonly EffectMeta 灰麻 = new EffectMeta("灰麻", true, "7312645421271158070", "7312645421271158070", "38ff7fc68c3ad9d76d9527a6d0b560cb", null);
        public static readonly EffectMeta 炊烟 = new EffectMeta("炊烟", true, "7194083900333755704", "7194083900333755704", "924d2235bf0485217a6897fb9504b456", null);
        public static readonly EffectMeta 烈空 = new EffectMeta("烈空", true, "7246722333010824508", "7246722333010824508", "849e979a487594a0da039ddd33e43c6b", null);
        public static readonly EffectMeta 烘挞 = new EffectMeta("烘挞", true, "7160598329817091364", "7160598329817091364", "8df6f056381a16178b36fa8ad6e559bf", null);
        public static readonly EffectMeta 烟橙 = new EffectMeta("烟橙", true, "7131582482608164132", "7131582482608164132", "e958619538087c86308f718045b292f2", null);
        public static readonly EffectMeta 烟花璀璨 = new EffectMeta("烟花璀璨", true, "7328363415313993001", "7328363415313993001", "0d2282c9172ed09758f861849916ab4b", null);
        public static readonly EffectMeta 热带季风 = new EffectMeta("热带季风", true, "7377368986276646171", "7377368986276646171", "2879146129f3375e8fefc940fe970397", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 焕肤 = new EffectMeta("焕肤", true, "7127674287238008078", "7127674287238008078", "073940956259c1077acaec764f52f31c", null);
        public static readonly EffectMeta 焰色 = new EffectMeta("焰色", true, "7131539023817936158", "7131539023817936158", "a5496033c5eac6ada1c761f1f5e6fcd0", null);
        public static readonly EffectMeta 爱之城 = new EffectMeta("爱之城", true, "7131656881805741325", "7131656881805741325", "3531cd81550d23dd7d10b4b8ec90ba9f", null);
        public static readonly EffectMeta 爱之城II = new EffectMeta("爱之城II", true, "7337929076042222899", "7337929076042222899", "1635b6718619a9832177e25c33f1968b", null);
        public static readonly EffectMeta 牙白 = new EffectMeta("牙白", true, "7172285234296278309", "7172285234296278309", "1c6bd0a57d892c86c845666b44a8f547", null);
        public static readonly EffectMeta 牧野 = new EffectMeta("牧野", true, "7194090104317594938", "7194090104317594938", "aa1bf1455ec02e406df6821e6bb3c4f8", null);
        public static readonly EffectMeta 独行侠 = new EffectMeta("独行侠", true, "7202485617026977056", "7202485617026977056", "50fc4f48bab6acc0b86f42c68a44e3dc", null);
        public static readonly EffectMeta 玩趣 = new EffectMeta("玩趣", true, "7177267248753610023", "7177267248753610023", "3dd9c3beaf276b96f226c49ac2bcbdd0", null);
        public static readonly EffectMeta 琥珀 = new EffectMeta("琥珀", true, "7295599414180138250", "7295599414180138250", "4a9ef682fbe7b4214e681796d4b4c77d", null);
        public static readonly EffectMeta 画报 = new EffectMeta("画报", true, "7239979137404833083", "7239979137404833083", "267ef83e978e1b8282afa81c88e8dfd4", null);
        public static readonly EffectMeta 登高 = new EffectMeta("登高", true, "7195925533031435558", "7195925533031435558", "688df92b416581b9cf33e543ae7ae03b", null);
        public static readonly EffectMeta 白富美 = new EffectMeta("白富美", true, "7302336985513970963", "7302336985513970963", "9fb4286e708d3bbf2b6bc6af85120be2", null);
        public static readonly EffectMeta 白桃 = new EffectMeta("白桃", true, "7300522962937990415", "7300522962937990415", "2c277b4b642fa2a5d7ddd7bff681ff91", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 白色恋人 = new EffectMeta("白色恋人", true, "7307158934735883583", "7307158934735883583", "6f7d0dd5f3463b557ed59b993303603d", null);
        public static readonly EffectMeta 百川 = new EffectMeta("百川", true, "7210616269597314362", "7210616269597314362", "cd1f1360bd1891f9b31c63542689d8ea", null);
        public static readonly EffectMeta 皓影 = new EffectMeta("皓影", true, "7303917567058414911", "7303917567058414911", "13892bfe5e6f6b0c0283a4d3e9034778", null);
        public static readonly EffectMeta 盐系 = new EffectMeta("盐系", true, "7127823742830398757", "7127823742830398757", "9d48681f2c1f584e9b93fa37485693d1", null);
        public static readonly EffectMeta 石山 = new EffectMeta("石山", true, "7194091413728922941", "7194091413728922941", "a9faf4808c5ec06b8d2ecc944a3682c6", null);
        public static readonly EffectMeta 砂金 = new EffectMeta("砂金", true, "7131655685321821477", "7131655685321821477", "28c53cc31c04a9a1e714c3c18038af09", null);
        public static readonly EffectMeta 破晓 = new EffectMeta("破晓", true, "7348707347419712794", "7348707347419712794", "0f73c6cf0189f4c0e462e76102e46084", null);
        public static readonly EffectMeta 硬朗 = new EffectMeta("硬朗", true, "7127663097162075399", "7127663097162075399", "7f33d22c16b09c852f48314404c2b532", null);
        public static readonly EffectMeta 碳烤 = new EffectMeta("碳烤", true, "7363537225620983067", "7363537225620983067", "596d7d07b942eff22e9f8aaa47918711", null);
        public static readonly EffectMeta 私语 = new EffectMeta("私语", true, "7127674303306419464", "7127674303306419464", "7f8596dc2626cd91e642c6a17c953390", null);
        public static readonly EffectMeta 秋池 = new EffectMeta("秋池", true, "7145391965717253406", "7145391965717253406", "3a908de0c7ba051b7838f5515d523a2c", null);
        public static readonly EffectMeta 秋波 = new EffectMeta("秋波", true, "7196920471043050812", "7196920471043050812", "0ce8c8224ab832699cae7ebdbd7034e9", null);
        public static readonly EffectMeta 简餐 = new EffectMeta("简餐", true, "7127561998556073247", "7127561998556073247", "0c4b5c50cb8bd668c241a262984f940b", null);
        public static readonly EffectMeta 粉橘 = new EffectMeta("粉橘", true, "7131467442789846285", "7131467442789846285", "30b24cc05d8768de3943d9323af8dc2e", null);
        public static readonly EffectMeta 粉白 = new EffectMeta("粉白", true, "7156647258342034702", "7156647258342034702", "e852a972957c3dadc478d3215639e0e1", null);
        public static readonly EffectMeta 素净 = new EffectMeta("素净", true, "7351018816215764233", "7351018816215764233", "3c792ad3327a3b6774aa89990dacf093", null);
        public static readonly EffectMeta 素简 = new EffectMeta("素简", true, "7300968790391606567", "7300968790391606567", "091f103fae7c3a0480f05be172a0c904", null);
        public static readonly EffectMeta 素银 = new EffectMeta("素银", true, "7307158197675117863", "7307158197675117863", "fca7c6917f26482a6453ffba5fd167c2", null);
        public static readonly EffectMeta 繁花似锦 = new EffectMeta("繁花似锦", true, "7322666518536359204", "7322666518536359204", "f5d1f324f0f06bf4fc783095efd7dc1e", null);
        public static readonly EffectMeta 繁花如梦 = new EffectMeta("繁花如梦", true, "7322665314980859177", "7322665314980859177", "d8bcaf063ca3ef2cd8d5f1642204a35f", null);
        public static readonly EffectMeta 繁花璀璨 = new EffectMeta("繁花璀璨", true, "7322665617373351231", "7322665617373351231", "98b0d8c15909c10ef71f187df3e36c9f", null);
        public static readonly EffectMeta 红运 = new EffectMeta("红运", true, "7325421708809096467", "7325421708809096467", "31a7c3905e75dda75c86e104dcb5d222", null);
        public static readonly EffectMeta 纱雾 = new EffectMeta("纱雾", true, "7260772961462799627", "7260772961462799627", "acde0ae9bd3ee0a6684457d562f35e25", null);
        public static readonly EffectMeta 美拉德 = new EffectMeta("美拉德", true, "7273782607257685309", "7273782607257685309", "f22f3b6e1ef2d6f6e5b7a9e3b753fe18", null);
        public static readonly EffectMeta 美高 = new EffectMeta("美高", true, "7239236880858877217", "7239236880858877217", "29446ccd642910767b50978b2fe45f4b", null);
        public static readonly EffectMeta 羽梦 = new EffectMeta("羽梦", true, "7213573482850880827", "7213573482850880827", "ee8c5d6e7808f4e6662d42298104b87b", null);
        public static readonly EffectMeta 聚焦 = new EffectMeta("聚焦", true, "7320428711487098153", "7320428711487098153", "54fcd82f212e40df18ac882bd748f59c", null);
        public static readonly EffectMeta 艾丽莎 = new EffectMeta("艾丽莎", true, "7269240546810400011", "7269240546810400011", "720b5b57295f927d983152d9bffcf33c", null);
        public static readonly EffectMeta 花间 = new EffectMeta("花间", true, "7211008985187487036", "7211008985187487036", "6acce0fe02d2e0328e597abcb1043de3", null);
        public static readonly EffectMeta 花间II = new EffectMeta("花间II", true, "7356877435184450851", "7356877435184450851", "78e26d36522db19bd16b83f52ae81593", null);
        public static readonly EffectMeta 花食 = new EffectMeta("花食", true, "7261180740283403578", "7261180740283403578", "37b2683488f5e586c98256dab864ab84", null);
        public static readonly EffectMeta 苍橘 = new EffectMeta("苍橘", true, "7131605817958075685", "7131605817958075685", "43666fcf1f38cb2036f87b7e496ccec4", null);
        public static readonly EffectMeta 茶酪 = new EffectMeta("茶酪", true, "7160603159486827783", "7160603159486827783", "3115e57bcd131acf89d8bdef6cd11cbd", null);
        public static readonly EffectMeta 莫吉托 = new EffectMeta("莫吉托", true, "7131419324622982408", "7131419324622982408", "c1a69c9148f223e97a862268a91c3e95", null);
        public static readonly EffectMeta 落日派对 = new EffectMeta("落日派对", true, "7374708995501739305", "7374708995501739305", "e00847299fab64d98f8ae309c62b98aa", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 落日粉 = new EffectMeta("落日粉", true, "7368141858603666698", "7368141858603666698", "66dd18db6e7d8f042e7cf8cd02e64af4", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 落日鎏金 = new EffectMeta("落日鎏金", true, "7374251948058447158", "7374251948058447158", "f5154a29054db9946d66ed823cb58006", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 蓝梦核 = new EffectMeta("蓝梦核", true, "7237440664139484473", "7237440664139484473", "0d12a669f41b3b92d1a892f42b9e0d9b", null);
        public static readonly EffectMeta 蓝橙II = new EffectMeta("蓝橙II", true, "7337929426493132058", "7337929426493132058", "40056bb94f392bdc1ab305683e265b2b", null);
        public static readonly EffectMeta 蓝灰 = new EffectMeta("蓝灰", true, "7127667757839076645", "7127667757839076645", "aa8ef49b3edba824d41f097effe534c0", null);
        public static readonly EffectMeta 蓝调 = new EffectMeta("蓝调", true, "7127664822921022734", "7127664822921022734", "3f0f50b54a2486b3fe5cfbb68dfaeaae", null);
        public static readonly EffectMeta 蓝调时刻 = new EffectMeta("蓝调时刻", true, "7392898023505792319", "7392898023505792319", "1bcdd5c706e257d4935503a026ee6b20", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 蓝调烟火 = new EffectMeta("蓝调烟火", true, "7328363887542209828", "7328363887542209828", "fe2367155cae2d1d5c07c10a64e3b6ef", null);
        public static readonly EffectMeta 蓝调舞曲 = new EffectMeta("蓝调舞曲", true, "7366562845120646463", "7366562845120646463", "95d43f9239219401b66eae286f0ccc1c", null);
        public static readonly EffectMeta 蓝都 = new EffectMeta("蓝都", true, "7166470141494955297", "7166470141494955297", "1bd22b8a07bc26b8bbd598414f67a13b", null);
        public static readonly EffectMeta 蓝金 = new EffectMeta("蓝金", true, "7341300292148907327", "7341300292148907327", "4107fa238d7b56801c9cc3a4a3a15c32", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 裸粉 = new EffectMeta("裸粉", true, "7127671519450303775", "7127671519450303775", "cea47ac2c5469b0c7630c2bcd83e3e87", null);
        public static readonly EffectMeta 西冷 = new EffectMeta("西冷", true, "7131899038625975559", "7131899038625975559", "582a118ed87f8ddfbf2bab6ce6ccbba2", null);
        public static readonly EffectMeta 西西里 = new EffectMeta("西西里", true, "7131488780451663140", "7131488780451663140", "36c35e9b449bd69a2d186c044c8032c8", null);
        public static readonly EffectMeta 西雅图 = new EffectMeta("西雅图", true, "7159175960414194982", "7159175960414194982", "d89963be26099b79db297b25e18011a6", null);
        public static readonly EffectMeta 诗诺 = new EffectMeta("诗诺", true, "7330543523042708790", "7330543523042708790", "ddc9145845f6f5548aba0c4f5ceb76ed", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 象牙白 = new EffectMeta("象牙白", true, "7234799040184012092", "7234799040184012092", "f73f4e38a3028c844f4a3d87cfe5d30b", null);
        public static readonly EffectMeta 贝果 = new EffectMeta("贝果", true, "7131656881805856013", "7131656881805856013", "21f8c68e7dd3fe22071ed06d21cc328a", null);
        public static readonly EffectMeta 赏味 = new EffectMeta("赏味", true, "7127608379056459015", "7127608379056459015", "d29bc8b2ddd9d018da1309ba9a467517", null);
        public static readonly EffectMeta 赤墙 = new EffectMeta("赤墙", true, "7226238039155150139", "7226238039155150139", "13130d2c72bde7a34001d2ff74ea9ac1", null);
        public static readonly EffectMeta 超白 = new EffectMeta("超白", true, "7302338645938261287", "7302338645938261287", "08f7a0eb8cd3535a23b4360acc4cc2f0", null);
        public static readonly EffectMeta 越岭 = new EffectMeta("越岭", true, "7193989203930123554", "7193989203930123554", "80634d76c41bb167ee4c2bec4172235b", null);
        public static readonly EffectMeta 越野 = new EffectMeta("越野", true, "7195931118166609190", "7195931118166609190", "f8f340ecb359e2dd7f155da84b06f013", null);
        public static readonly EffectMeta 过期电影卷 = new EffectMeta("过期电影卷", true, "7361791960652238143", "7361791960652238143", "7b98e4262666c36aeb965842cd14d10a", null);
        public static readonly EffectMeta 迷幻 = new EffectMeta("迷幻", true, "7233731748545203493", "7233731748545203493", "6eb7969f4e1becb256c90950b3cb8eb3", null);
        public static readonly EffectMeta 迷雾 = new EffectMeta("迷雾", true, "7160594413847203085", "7160594413847203085", "5143fc0b35bca33c7b010458ffe8f1d7", null);
        public static readonly EffectMeta 逆光提亮 = new EffectMeta("逆光提亮", true, "7366260047401323811", "7366260047401323811", "8990c9bac399f2eaedfd706d99dbdd4e", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 透亮 = new EffectMeta("透亮", true, "7127620232104955150", "7127620232104955150", "62319c31caf875d0041e0bfa50d1b9d7", null);
        public static readonly EffectMeta 邂逅 = new EffectMeta("邂逅", true, "7271145889119440147", "7271145889119440147", "6b6957bc110b65e03bc5d9ae65de6d66", null);
        public static readonly EffectMeta 郁金香 = new EffectMeta("郁金香", true, "7343831195924303123", "7343831195924303123", "15e11e4352b9891fd1a1969ff7841b6b", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 都卡 = new EffectMeta("都卡", true, "7341296364598480178", "7341296364598480178", "fac476280a61adbc7a731a9ee538b0b1", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 都市 = new EffectMeta("都市", true, "7312646683672825100", "7312646683672825100", "486a70b4dc6b3cbedf1ad34461022d78", null);
        public static readonly EffectMeta 酚蓝 = new EffectMeta("酚蓝", true, "7131322091839753502", "7131322091839753502", "483ca6c547361c0868c8922cebebd893", null);
        public static readonly EffectMeta 醒春 = new EffectMeta("醒春", true, "7211006465358843196", "7211006465358843196", "3544111511d3c365e3068023059ed83e", null);
        public static readonly EffectMeta 里昂 = new EffectMeta("里昂", true, "7131643870714006821", "7131643870714006821", "634a11a0d1a1b69aa4ac2770aa47c7dc", null);
        public static readonly EffectMeta 野趣 = new EffectMeta("野趣", true, "7193983160231742772", "7193983160231742772", "dc9a0e3b25c1b462e5c684ac64bbb1b7", null);
        public static readonly EffectMeta 金喜 = new EffectMeta("金喜", true, "7323022101735083315", "7323022101735083315", "184ae43f227bd4d20edab495a6574610", null);
        public static readonly EffectMeta 金姜 = new EffectMeta("金姜", true, "7233733326517832995", "7233733326517832995", "5116f63c46a435d34ccb83fd58b3d009", null);
        public static readonly EffectMeta 金色韶华 = new EffectMeta("金色韶华", true, "7376141023656873254", "7376141023656873254", "6fe8d7f355b0895a9b4bd4110d7f58d4", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 银蓝 = new EffectMeta("银蓝", true, "7145394266209127694", "7145394266209127694", "e1f2f32043ab9fd801bfdbc9a9f708d3", null);
        public static readonly EffectMeta 镜粉 = new EffectMeta("镜粉", true, "7145390299370638600", "7145390299370638600", "26b6e129d49359d3112438c001f22926", null);
        public static readonly EffectMeta 闪星 = new EffectMeta("闪星", true, "7346450662185569555", "7346450662185569555", "f9bdd96e9282b3783dcc174484aa5fc6", null);
        public static readonly EffectMeta 阳光肤 = new EffectMeta("阳光肤", true, "7234795543178775868", "7234795543178775868", "116a1adcf464b736d76bf31d679b3d72", null);
        public static readonly EffectMeta 陶瓷肌 = new EffectMeta("陶瓷肌", true, "7234793127867878712", "7234793127867878712", "e7b66853ca5dbdb1c049d45225b355cb", null);
        public static readonly EffectMeta 随性 = new EffectMeta("随性", true, "7271140658071588132", "7271140658071588132", "6619560c233df84381e8c371b7387faa", null);
        public static readonly EffectMeta 雨空 = new EffectMeta("雨空", true, "7196917591909109052", "7196917591909109052", "ffe686005136a692517b6e19e4e490e7", null);
        public static readonly EffectMeta 雪挞 = new EffectMeta("雪挞", true, "7262376135202327871", "7262376135202327871", "319cab31ed6a056c3f5256a357eb9b96", null);
        public static readonly EffectMeta 雪肤 = new EffectMeta("雪肤", true, "7307211406590364955", "7307211406590364955", "03a6b1da7a8fac8dbab32754d9d6655d", null);
        public static readonly EffectMeta 雾都 = new EffectMeta("雾都", true, "7312646650202262820", "7312646650202262820", "00b8522f76bf9a991e0a6090f63747ee", null);
        public static readonly EffectMeta 雾野 = new EffectMeta("雾野", true, "7127823362356727077", "7127823362356727077", "6fbd00682d2a15e079bc242301e9b757", null);
        public static readonly EffectMeta 青提 = new EffectMeta("青提", true, "7131290518838938887", "7131290518838938887", "8ddee3f2a95239705898ac4892cdc803", null);
        public static readonly EffectMeta 青灰 = new EffectMeta("青灰", true, "7127671508264078599", "7127671508264078599", "a9b480c9b5bf91d2aa0b5e8388f53746", null);
        public static readonly EffectMeta 青蒲 = new EffectMeta("青蒲", true, "7145393992673414407", "7145393992673414407", "7cd919e92b66b19e00c95b9f3db9def8", null);
        public static readonly EffectMeta 青黄 = new EffectMeta("青黄", true, "7127541821332409630", "7127541821332409630", "e777bf266933df88bfc019a84e6dd792", null);
        public static readonly EffectMeta 青黄II = new EffectMeta("青黄II", true, "7337932621046910262", "7337932621046910262", "059b7e40c1fe52a2451c35bd82e329e5", null);
        public static readonly EffectMeta 风味 = new EffectMeta("风味", true, "7330579916272012580", "7330579916272012580", "7abbb099b234e92b6a7169f2ae6232b6", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 风铃II = new EffectMeta("风铃II", true, "7356885346841349410", "7356885346841349410", "7e36a3f345976371e7a668d1e96c7905", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 风铃蓝 = new EffectMeta("风铃蓝", true, "7261466919688015140", "7261466919688015140", "5bf0d1478c19629df96ad85b3301ec35", null);
        public static readonly EffectMeta 飒意 = new EffectMeta("飒意", true, "7248568718265978112", "7248568718265978112", "25a705fe908fad028d75a5b9bf30e4b7", null);
        public static readonly EffectMeta 食色 = new EffectMeta("食色", true, "7131644140340776205", "7131644140340776205", "8540ba0ddb988c6f5f4b69742ca94136", null);
        public static readonly EffectMeta 香浓 = new EffectMeta("香浓", true, "7330588808666156307", "7330588808666156307", "480c2599aaaf7be5a800c269dada7cdd", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 驮月 = new EffectMeta("驮月", true, "7145394213339860261", "7145394213339860261", "ba8a3a6272282d63ee8b46c2e228e09b", null);
        public static readonly EffectMeta 高清 = new EffectMeta("高清", true, "7320436048134147340", "7320436048134147340", "a33cc5e4879a6f4d03e2f4f7535c96b2", null);
        public static readonly EffectMeta 高清II = new EffectMeta("高清II", true, "7325426821267295551", "7325426821267295551", "17a86357c081e0d080c9d501a66382d0", null);
        public static readonly EffectMeta 魅影 = new EffectMeta("魅影", true, "7175076304058895619", "7175076304058895619", "361328c4bc995c85053ea003268aefbf", null);
        public static readonly EffectMeta 魔都 = new EffectMeta("魔都", true, "7166480345666260263", "7166480345666260263", "cf4adfafcc5e59b9bddd8eeb4d20f44e", null);
        public static readonly EffectMeta 鲜亮 = new EffectMeta("鲜亮", true, "7127615338035858702", "7127615338035858702", "329252a715f5e0f9727810511e0e9832", null);
        public static readonly EffectMeta 鲜明 = new EffectMeta("鲜明", true, "7320434750018047251", "7320434750018047251", "ba8b7cbf504c97a30c923d0d6a6c2b44", null);
        public static readonly EffectMeta 鲜明II = new EffectMeta("鲜明II", true, "7361400073533820196", "7361400073533820196", "350ff543fdd150a6f7e571aa3f467640", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 鲜美 = new EffectMeta("鲜美", true, "7330581892510649636", "7330581892510649636", "0f2146e69f0cf22a0e0aa733be623bd4", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 黄昏 = new EffectMeta("黄昏", true, "7272330168717430075", "7272330168717430075", "eebcc8f84ff895bd0d66535d9ad44275", null);
        public static readonly EffectMeta 黑冰 = new EffectMeta("黑冰", true, "7131522303082466597", "7131522303082466597", "d03c03e8f1e67f5cff0a5671fe96dfb9", null);
        public static readonly EffectMeta 黑曜 = new EffectMeta("黑曜", true, "7223712396769119545", "7223712396769119545", "3b81efb578ddec8efa40dd0c5b754056", null);
        public static readonly EffectMeta 黑金 = new EffectMeta("黑金", true, "7127670164996295972", "7127670164996295972", "bfd8bd193bf24f5de2bd719516ef230d", null);
        public static readonly EffectMeta 黑金红 = new EffectMeta("黑金红", true, "7341266486536768831", "7341266486536768831", "66796ec5de5e85b2cf461fa49b4c0225", [
                                  new EffectParam("effects_adjust_filter", 1.000, 0.000, 1.000)]);
        //滤镜强度可调//
        public static readonly EffectMeta 龙舌兰 = new EffectMeta("龙舌兰", true, "7252674245396942139", "7252674245396942139", "254083154fd15d41d41cc3763eda9f40", null);
    }
}
