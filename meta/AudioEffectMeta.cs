using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    //剪映自带的音频“音色”效果类型
    public static class ToneEffectType
    {
        // 免费
        public static readonly EffectMeta 台湾小哥 = new EffectMeta("台湾小哥", false, "7255565276819755576", "18149602", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 圣诞精灵 = new EffectMeta("圣诞精灵", false, "7310059412062736946", "33214695", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 圣诞老人 = new EffectMeta("圣诞老人", false, "7310059178133819930", "33214489", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 广告男声 = new EffectMeta("广告男声", false, "7328088579811316263", "42060748", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 港普男声 = new EffectMeta("港普男声", false, "7328087687548637732", "42060743", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 老婆婆 = new EffectMeta("老婆婆", false, "7328089253114548799", "42060746", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 解说小帅 = new EffectMeta("解说小帅", false, "7332473259369173540", "44254166", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 大叔 = new EffectMeta("大叔", false, "7020344898033291790", "2672760", "2509bbd71e127b04a29f52a54e82c53c", [
                                        new EffectParam("音调", 0.834, 0.000, 1.000),
                                   new EffectParam("音色", 1.000, 0.000, 1.000)]);

        //参数:
        //// 音调: 默认0.83, 0.00 ~ 1.00
        //// 音色: 默认1.00, 0.00 ~ 1.00
        public static readonly EffectMeta 女生 = new EffectMeta("女生", false, "7020345715901600270", "2672757", "0ce1aade5958506c97bffea150772b6e", [
                                    new EffectParam("音调", 0.834, 0.000, 1.000),
                                    new EffectParam("音色", 0.334, 0.000, 1.000)]);
        //参数:
        //// 音调: 默认0.83, 0.00 ~ 1.00
        //// 音色: 默认0.33, 0.00 ~ 1.00
        public static readonly EffectMeta 怪物 = new EffectMeta("怪物", false, "7020344978794615327", "2672759", "2130ffa21e5980196e014ec0baade179", [
                                    new EffectParam("音调", 0.650, 0.000, 1.000),
                                    new EffectParam("音色", 0.780, 0.000, 1.000)]);
        //参数:
        // 音调: 默认0.65, 0.00 ~ 1.00
        // 音色: 默认0.78, 0.00 ~ 1.00
        //
        public static readonly EffectMeta 机器人 = new EffectMeta("机器人", false, "7018011705414259213", "2672750", "4b87db25aecd2f6f71927930110c4a1e", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00
        //
        public static readonly EffectMeta 男生 = new EffectMeta("男生", false, "7020345085233467917", "2672758", "ffd7a609207fd849efc9f63bf31697b1", [
                                        new EffectParam("音调", 0.375, 0.000, 1.000),
                                    new EffectParam("音色", 0.250, 0.000, 1.000)]);
        //参数:
        // 音调: 默认0.38, 0.00 ~ 1.00
        // 音色: 默认0.25, 0.00 ~ 1.00
        //
        public static readonly EffectMeta 花栗鼠 = new EffectMeta("花栗鼠", false, "7018011553081332231", "2672752", "e30b1922b8300423f21f9f84eff41ced", [
                                        new EffectParam("音调", 0.500, 0.000, 1.000),
                                    new EffectParam("音色", 0.500, 0.000, 1.000)]);
        //参数:
        // 音调: 默认0.50, 0.00 ~ 1.00
        // 音色: 默认0.50, 0.00 ~ 1.00
        //
        public static readonly EffectMeta 萝莉 = new EffectMeta("萝莉", false, "7020345789599715848", "2672756", "00b7ed2ccfe4d6076f78c8d751347a53", [
                                        new EffectParam("音调", 0.750, 0.000, 1.000),
                                    new EffectParam("音色", 0.600, 0.000, 1.000)]);
        //参数:
        // 音调: 默认0.75, 0.00 ~ 1.00
        // 音色: 默认0.60, 0.00 ~ 1.00
        //


        //付费
        public static readonly EffectMeta TVB女声 = new EffectMeta("TVB女声", true, "7260024060417937978", "19186454", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 东厂公公 = new EffectMeta("东厂公公", true, "7328092524612948491", "42060742", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 云龙哥 = new EffectMeta("云龙哥", true, "7376558114830553612", "68856989", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 侠客 = new EffectMeta("侠客", true, "7328089134331859468", "42060738", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 做作夹子音 = new EffectMeta("做作夹子音", true, "7367676929496846911", "63231108", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 八戒 = new EffectMeta("八戒", true, "7265891792766112314", "20427371", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 军事解说 = new EffectMeta("军事解说", true, "7328092289480266252", "42060734", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 动漫小新 = new EffectMeta("动漫小新", true, "7360901047662940708", "58979441", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 动漫海绵 = new EffectMeta("动漫海绵", true, "7367676859883983379", "63231109", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 咆哮哥 = new EffectMeta("咆哮哥", true, "7332473122605503039", "44254278", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 商务殷语 = new EffectMeta("商务殷语", true, "7328085477267870249", "42060747", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 四郎 = new EffectMeta("四郎", true, "7250403044414722621", "16627073", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 太白 = new EffectMeta("太白", true, "7328091247308968484", "42060736", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 如来佛祖 = new EffectMeta("如来佛祖", true, "7376558174049931830", "68856990", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 姜饼人 = new EffectMeta("姜饼人", true, "7310059267384414747", "33214539", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 容嬷嬷 = new EffectMeta("容嬷嬷", true, "7332472945366798860", "44254320", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 小孩 = new EffectMeta("小孩", true, "7262648951948448315", "19716244", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 强势妹 = new EffectMeta("强势妹", true, "7328091624427229759", "42060740", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 快板 = new EffectMeta("快板", true, "7328088454183522827", "42060741", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 恐怖电影 = new EffectMeta("恐怖电影", true, "7325710953247412787", "40932465", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 悬疑解说 = new EffectMeta("悬疑解说", true, "7325711304390349362", "40932811", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 懒小羊 = new EffectMeta("懒小羊", true, "7332473035116515859", "44254304", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 搞笑解说 = new EffectMeta("搞笑解说", true, "7262648842238038584", "19716150", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 文艺女声 = new EffectMeta("文艺女声", true, "7379565719991620132", "70562787", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 樱桃丸子 = new EffectMeta("樱桃丸子", true, "7325709643332719113", "40931609", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 樱花小哥 = new EffectMeta("樱花小哥", true, "7328091741678998055", "42060735", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 武则天 = new EffectMeta("武则天", true, "7328088300474864167", "42060744", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 沉稳解说 = new EffectMeta("沉稳解说", true, "7367676791164506636", "63231110", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 温柔姐姐 = new EffectMeta("温柔姐姐", true, "7379565769190806079", "70562785", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 熊二 = new EffectMeta("熊二", true, "7250403222798471740", "16627311", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 猴哥 = new EffectMeta("猴哥", true, "7236944659547689531", "14477015", "4f6a1fbc0000e178c724d355efea1d9f", null);
        public static readonly EffectMeta 甜美悦悦 = new EffectMeta("甜美悦悦", true, "7325710673978069530", "40932253", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 生活小妙招 = new EffectMeta("生活小妙招", true, "7328092409525441065", "42060737", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 电竞解说 = new EffectMeta("电竞解说", true, "7325711893551649330", "40933559", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 电视广告 = new EffectMeta("电视广告", true, "7360901109667336743", "58979440", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 紫薇 = new EffectMeta("紫薇", true, "7281175506391667257", "23475307", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 舌尖解说 = new EffectMeta("舌尖解说", true, "7328091500753982015", "42060739", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 蜡笔小妮 = new EffectMeta("蜡笔小妮", true, "7379565670398169619", "70562786", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 语音助手 = new EffectMeta("语音助手", true, "7325710335455793714", "40931973", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 那姐 = new EffectMeta("那姐", true, "7369177370873303587", "64206631", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 锤子哥 = new EffectMeta("锤子哥", true, "7328091348098093580", "42060745", "f554735f65a98cc4da17a1c53ef6a886", null);
        public static readonly EffectMeta 顾姐 = new EffectMeta("顾姐", true, "7250403134923608631", "16627197", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 黛玉 = new EffectMeta("黛玉", true, "7255565592093004343", "18149634", "8dd8889045e6c065177df791ddb3dfb8", null);


    }

    //剪映自带的音频“场景音”效果类型
    public static class AudioSceneEffectType
    {
        //免费
        public static readonly EffectMeta _8bit = new EffectMeta("8bit", false, "7161319747584266766", "5723961", "8d24238329ea5c250e33ae241d5adae2", [
                                        new EffectParam("change_voice_param_pitch_shift", 0.500, 0.000, 1.000),
                                    new EffectParam("change_voice_param_timbre", 1.000, 0.000, 1.000),
                                    new EffectParam("change_voice_param_strength", 1.000, 0.000, 1.000)]);
        //参数:
        // change_voice_param_pitch_shift: 默认0.50, 0.00 ~ 1.00
        // change_voice_param_timbre: 默认1.00, 0.00 ~ 1.00
        // change_voice_param_strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 低保真 = new EffectMeta("低保真", false, "7024390914537689614", "2672762", "7ddbd39a691a66a021f684cab756a89a", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 合成器 = new EffectMeta("合成器", false, "7018011500577034759", "2672753", "394efea5922637bcd8288e0fb3c2372e", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 回音 = new EffectMeta("回音", false, "7018011608408396325", "5723901", "5377f66109693f2d473df5ea6ec8f791", [
                                        new EffectParam("change_voice_param_quantity", 0.800, 0.000, 1.000),
                                    new EffectParam("change_voice_param_strength", 0.762, 0.000, 1.000)]);
        //参数:
        // change_voice_param_quantity: 默认0.80, 0.00 ~ 1.00
        // change_voice_param_strength: 默认0.76, 0.00 ~ 1.00

        public static readonly EffectMeta 扩音器 = new EffectMeta("扩音器", false, "7018011975514853924", "2672749", "13169f6ab9957ff005d316239bef0045", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 水下 = new EffectMeta("水下", false, "7106404450444513806", "2673077", "53956694a8b68b2855faa2adc043b5b1", [
                                        new EffectParam("深度", 0.500, 0.000, 1.000)]);
        //参数:
        // 深度: 默认0.50, 0.00 ~ 1.00

        public static readonly EffectMeta 没电了 = new EffectMeta("没电了", false, "7018012193769656845", "2672747", "87f91614bac060840ad5a57ef2b0c9ca", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 环绕音 = new EffectMeta("环绕音", false, "7161319847819743780", "5723960", "fa9a4cb20d3488bf79e176571d5841f5", [
                                        new EffectParam("change_voice_param_center_position", 0.500, 0.000, 1.000),
                                    new EffectParam("change_voice_param_surrounding_frequency", 0.500, 0.000, 1.000)]);
        //参数:
        // change_voice_param_center_position: 默认0.50, 0.00 ~ 1.00
        // change_voice_param_surrounding_frequency: 默认0.50, 0.00 ~ 1.00

        public static readonly EffectMeta 电音 = new EffectMeta("电音", false, "7018011438379700773", "2672754", "d893a319d5175d9f09f70ddef1f79980", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 颤音 = new EffectMeta("颤音", false, "7018011370289369637", "2672755", "c5e4874f83337e1cb9f8322fb843c901", [
                                        new EffectParam("频率", 0.714, 0.000, 1.000),
                                    new EffectParam("幅度", 0.905, 0.000, 1.000)]);
        //参数:
        // 频率: 默认0.71, 0.00 ~ 1.00
        // 幅度: 默认0.91, 0.00 ~ 1.00

        public static readonly EffectMeta 麦霸 = new EffectMeta("麦霸", false, "7018012141332468260", "2672748", "3eedef5ef82b32912203a1f4fb901182", [
                                        new EffectParam("空间大小", 0.052, 0.000, 1.000),
                                    new EffectParam("强弱", 0.450, 0.000, 1.000)]);
        //参数:
        // 空间大小: 默认0.05, 0.00 ~ 1.00
        // 强弱: 默认0.45, 0.00 ~ 1.00

        public static readonly EffectMeta 黑胶 = new EffectMeta("黑胶", false, "7024391411764040205", "2672761", "59e61d687a0f612bfae43bccf770f090", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000),
                                    new EffectParam("噪点", 0.743, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00
        // 噪点: 默认0.74, 0.00 ~ 1.00


        //付费
        public static readonly EffectMeta _3d环绕音 = new EffectMeta("3d环绕音", true, "7350214888242811455", "53187169", "577c3d8e5312012b1d98ba5fc0b206d0", [
                                        new EffectParam("强度", 0.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认0.00, 0.00 ~ 1.00

        public static readonly EffectMeta Autotune = new EffectMeta("Autotune", true, "7360900806851170828", "58979352", "1477f4ca8307e2fa4ee2243d98d8b837", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 下雨 = new EffectMeta("下雨", true, "7375069649446113804", "68076030", "83bb223637d5368384c47e3d2b061b62", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 乡村大喇叭 = new EffectMeta("乡村大喇叭", true, "7282691036197950009", "23897651", "c996243ac50d235f00e5931e5ecadc52", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 人声增强 = new EffectMeta("人声增强", true, "7106404399756349983", "2673078", "626f988dbd2cbd17acaa24d08451e314", [
                                        new EffectParam("强弱", 1.000, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 低音增强 = new EffectMeta("低音增强", true, "7106404304247853604", "2673080", "e7c09c96d10c163269fc4e35c1f4b1ee", [
                                        new EffectParam("change_voice_param_strength", 1.000, 0.000, 1.000)]);
        //参数:
        // change_voice_param_strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 停车场 = new EffectMeta("停车场", true, "7372150242524795446", "66413024", "d2dd515293081a8573485159db5a71e0", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 冰川之下 = new EffectMeta("冰川之下", true, "7375068986829967883", "68076029", "6b9cda93f6d75b9a3b19b2e8eb6ad40f", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 刮风 = new EffectMeta("刮风", true, "7375069247275274771", "68076028", "8600891882159f364d8c53e4f703cff4", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 噪音混响 = new EffectMeta("噪音混响", true, "7382844688987853349", "72110975", "3b3b09b530b0a64666f1c5b6d20d4018", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 地狱 = new EffectMeta("地狱", true, "7375069113988682281", "68076027", "5ec03c41ada16530949daa4106c85a90", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 复古收音机 = new EffectMeta("复古收音机", true, "7350215379714576907", "53187166", "301d642d131aabff7ea8c3b717b36a79", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 失真电子 = new EffectMeta("失真电子", true, "7350215296801575443", "53187167", "a1c00df42076ed1bd6a81f2d30b94566", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 对讲机 = new EffectMeta("对讲机", true, "7350214704284832275", "53187168", "016dbdb3c786896c92bb936ece11acf6", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 房间 = new EffectMeta("房间", true, "7282691385872880165", "23880629", "639f5c0c6b20418aaeb0e144da21151c", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 捂嘴 = new EffectMeta("捂嘴", true, "7372405649684042292", "66552320", "9f9a8270c0005a480547d6ddf2a9293a", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 教堂 = new EffectMeta("教堂", true, "7282691146759803429", "23882063", "96dc71756d0025e96a504b42d988b2ac", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 教室 = new EffectMeta("教室", true, "7282687783833965113", "23897703", "678c14a6f63f75e03daa062a254081f7", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 机器人2 = new EffectMeta("机器人2", true, "7372150541738054156", "66413023", "952f3feddf3555939adbbfd1c1869474", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 沙漠 = new EffectMeta("沙漠", true, "7375069515530375691", "68076025", "099c935428943c9c3662b15b35b1ee36", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 派对 = new EffectMeta("派对", true, "7381685442795541042", "71718513", "723386ab87f938779a3369436234d903", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

        public static readonly EffectMeta 深海回声 = new EffectMeta("深海回声", true, "7350215168413929995", "53187172", "37a16a2dc77540b7d70fe301e482d4f2", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 电话 = new EffectMeta("电话", true, "7264894634285863483", "20255003", "5da5a98b8c926c0dcc1c3c8bc3f3012f", [
                                        new EffectParam("强弱", 0.700, 0.000, 1.000)]);
        //参数:
        // 强弱: 默认0.70, 0.00 ~ 1.00

        public static readonly EffectMeta 留声机 = new EffectMeta("留声机", true, "7282687663872676408", "23897797", "e692fae669650c948451b5811a04e7e6", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 百老汇 = new EffectMeta("百老汇", true, "7372150379150053907", "66413025", "73e3a35496b9766d0400165844be72f1", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 空灵感 = new EffectMeta("空灵感", true, "7350215092975178252", "53187171", "aa1887a8b3375d20df6bf9438d62083a", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 空谷回声 = new EffectMeta("空谷回声", true, "7350214991628210727", "53187170", "9913daa32167a17c1f41ad2f5596c411", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 老式电话 = new EffectMeta("老式电话", true, "7282691476843139621", "23880011", "2eb835175e1e72e9d86b09bf513077cf", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 言灵术 = new EffectMeta("言灵术", true, "7382844601435951653", "72110974", "7184386e75226a36942c60a5d5bb5618", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 豪宅回声 = new EffectMeta("豪宅回声", true, "7360900963294515775", "58979353", "7c20b5fba991f3188f14d7cdb0de1fa1", [
                                        new EffectParam("强度", 1.000, 0.000, 1.000)]);
        //参数:
        // 强度: 默认1.00, 0.00 ~ 1.00

        public static readonly EffectMeta 迷幻电子 = new EffectMeta("迷幻电子", true, "7375069381769826879", "68076026", "ce220d25a6f95bd31a81f6421bbf2525", [
                                        new EffectParam("strength", 1.000, 0.000, 1.000),
                                    new EffectParam("noise", 0.743, 0.000, 1.000)]);
        //参数:
        // strength: 默认1.00, 0.00 ~ 1.00
        // noise: 默认0.74, 0.00 ~ 1.00

    }

    // 声音成曲
    public static class SpeechToSongType
    {
        public static readonly EffectMeta Lofi = new EffectMeta("Lofi", false, "7252917861948068410", "17345060", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 民谣 = new EffectMeta("民谣", false, "7251868698170888759", "17046923", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 嘻哈 = new EffectMeta("嘻哈", true, "7252918249036190245", "17344948", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 爵士 = new EffectMeta("爵士", true, "7264413578860433978", "20120940", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 节奏蓝调 = new EffectMeta("节奏蓝调", true, "7252918101958726200", "17345046", "8dd8889045e6c065177df791ddb3dfb8", null);
        public static readonly EffectMeta 雷鬼 = new EffectMeta("雷鬼", true, "7264413386962637368", "20120864", "8dd8889045e6c065177df791ddb3dfb8", null);
    }

    public enum AudioEffectCategory
    {
        Tone,
        Audio,
        Song,
        Unknown
    }

    public static class AudioEffectCategoryResolver
    {
        public static AudioEffectCategory GetCategory(EffectMeta meta)
        {
            if (BelongsTo(meta, typeof(ToneEffectType))) return AudioEffectCategory.Tone;
            if (BelongsTo(meta, typeof(AudioSceneEffectType))) return AudioEffectCategory.Audio;
            if (BelongsTo(meta, typeof(SpeechToSongType))) return AudioEffectCategory.Song;
            return AudioEffectCategory.Unknown;
        }

        private static bool BelongsTo(EffectMeta meta, Type type)
        {
            var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            return fields.Any(f => f.GetValue(null) == meta);
        }
    }
}
