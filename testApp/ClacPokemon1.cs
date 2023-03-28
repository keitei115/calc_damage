using System;
using System.Diagnostics;

namespace testApp
{
    public class CalcPokemon
    {
        int level; //攻撃側のレベル
        int power; //わざの威力
        int attack; //こうげき・とくこう
        int defense; //ぼうぎょ・とくぼう
        int attackRank; //攻撃側の能力ランク
        int defenseRank; //防御側の能力ランク

        //ダメージにかかわる補正
        double compatibility; //タイプ相性による倍率
        bool weatherReinforce; //天候補正(弱体化)
        bool weatherWeak; //天候補正(弱体化)
        int metronome; //メトロノーム補正
        bool typeMatch; //タイプ一致
        bool critical; //急所
        bool ranged; //範囲・全体技
        bool burn; //やけど
        bool reflect; //リフレクター・ひかりのかべ
        bool sniper; //スナイパー
        bool tintedLens; //いろめがね
        bool mhalf; //マルチスケイル(特性による半減)
        bool mfilter; //ハードロック・フィルター
        bool friendGuard; //フレンドガード
        bool expertBelt; //たつじんのおび
        bool lifeOrb; //いのちのたま
        bool berry; //半減実
        bool mtwice; //穴を掘る→地震、ダイビング→波乗り、小さくなる→踏みつけの2倍

        //ステータスを上下させるアイテム
        bool choice; //こだわりハチマキ・こだわりメガネ
        bool specialItemAttack; //でんきだま・ふといホネ・しんかいのキバ
        bool eviolite; //しんかのきせき・とつげきチョッキ
        bool specialItemDefence; //メタルパウダー・しんかいのウロコ

        //ステータスを上下させるシステム
        bool sandstorm; //いわタイプ+すなあらし

        //ステータスを上下させる特性
        bool statusAttackHalf; //スロースタート・よわき
        bool statusAttackOnePointFive; //しんりょく・もうか・げきりゅう・むしのしらせ・はりきり・もらいび・サンパワー
        bool flowerGiftAttack; //フラワーギフト(攻撃側)
        bool flowerGiftDefence; //フラワーギフト(防御側)
        bool guts; //こんじょう(やけどを無視する)
        bool statusTwice; //ちからもち・ヨガパワー
        bool hustle; //はりきり
        bool statusDefenceOnePointFive; //くさのけがわ・ふしぎなうろこ
        bool thickFat; //あついしぼう

        //技の威力を上下させる特性
        bool attackZeroPointSevenFive; //とうそうしん(異性)
        bool auraBreaker; //オーラブレイク
        bool attackOnePointTwo; //すてみ・てつのこぶし
        bool attackOnePointTwoFive; //とうそうしん(同性)
        bool attackOnePointThree; //アナライズ・かたいツメ・スキン・すなのちから・ちからずく
        bool aura; //フェアリーオーラ・ダークオーラ
        bool attackOnePointFive; //がんじょうあご・テクニシャン・どくぼうそう・ねつぼうそう・メガランチャー
        bool defenseHalf; //たいねつ
        bool defenseOnePointTwoFive; //かんそうはだ

        //技の威力を上げるアイテム
        bool bandGlasses; //ちからのハチマキ・ものしりメガネ
        bool plate; //タイプ強化アイテム
        bool jewel; //ジュエル

        //その他威力を上げるシステム
        bool powerHalf; //雨下ソーラービーム
        bool powerOnePointFive; //持ち物を持ってるポケモンにはたきおとす
        bool helpingHandFirst; //てだすけ1匹目
        bool helpingHandSecond; //てだすけ2匹目
        bool meFirst; //さきどり
        bool charge; //じゅうでん
        bool powerTwice; //かたきうち・からげんき・クロスサンダー・クロスフレイム・しおみず・ベノムショック
        bool descentField; //グラスフィールド下でのじしん・じならし・マグニチュード、ミストフィールド下でのドラゴン技
        bool riseField; //エレキフィールド・グラスフィールド
        bool sport; //みずあそび、どろあそび

        //その他
        bool doubleBattle; //ダブルバトルの場合

        public CalcPokemon(
            int level = 50,
            int power = 10,
            int attack = 10,
            int defense = 10,
            int attackRank = 0,
            int defenseRank = 0,
            double compatibility = 1.0,
            bool weatherReinforce = false,
            bool weatherWeak = false,
            int metronome = 1,
            bool typeMatch = false,
            bool critical = false,
            bool ranged = false,
            bool burn = false,
            bool reflect = false,
            bool sniper = false,
            bool tintedLens = false,
            bool mhalf = false,
            bool mfilter = false,
            bool friendGuard = false,
            bool expertBelt = false,
            bool lifeOrb = false,
            bool berry = false,
            bool mtwice = false,
            bool choice = false,
            bool specialItemAttack = false,
            bool eviolite = false,
            bool specialItemDefence = false,
            bool sandstorm = false,
            bool statusAttackHalf = false,
            bool statusAttackOnePointFive = false,
            bool flowerGiftAttack = false,
            bool flowerGiftDefence = false,
            bool guts = false,
            bool statusTwice = false,
            bool hustle = false,
            bool statusDefenceOnePointFive = false,
            bool thickFat = false,
            bool attackZeroPointSevenFive = false,
            bool auraBreaker = false,
            bool attackOnePointTwo = false,
            bool attackOnePointTwoFive = false,
            bool attackOnePointThree = false,
            bool aura = false,
            bool attackOnePointFive = false,
            bool defenseHalf = false,
            bool defenseOnePointTwoFive = false,
            bool bandGlasses = false,
            bool plate = false,
            bool jewel = false,
            bool powerHalf = false,
            bool powerOnePointFive = false,
            bool helpingHandFirst = false,
            bool helpingHandSecond = false,
            bool meFirst = false,
            bool charge = false,
            bool powerTwice = false,
            bool descentField = false,
            bool riseField = false,
            bool sport = false,
            bool doubleBattle = false
            )
        {
            this.level = level;
            this.power = power;
            this.attack = attack;
            this.defense = defense;
            this.attackRank = attackRank;
            this.defenseRank = defenseRank;
            this.compatibility = compatibility;
            this.weatherReinforce = weatherReinforce;
            this.weatherWeak = weatherWeak;
            this.metronome = metronome;
            this.typeMatch = typeMatch;
            this.critical = critical;
            this.ranged = ranged;
            this.burn = burn;
            this.reflect = reflect;
            this.sniper = sniper;
            this.tintedLens = tintedLens;
            this.mhalf = mhalf;
            this.mfilter = mfilter;
            this.friendGuard = friendGuard;
            this.expertBelt = expertBelt;
            this.lifeOrb = lifeOrb;
            this.berry = berry;
            this.mtwice = mtwice;
            this.choice = choice;
            this.specialItemAttack = specialItemAttack;
            this.eviolite = eviolite;
            this.specialItemDefence = specialItemDefence;
            this.sandstorm = sandstorm;
            this.statusAttackHalf = statusAttackHalf;
            this.statusAttackOnePointFive = statusAttackOnePointFive;
            this.flowerGiftAttack = flowerGiftAttack;
            this.flowerGiftDefence = flowerGiftDefence;
            this.guts = guts;
            this.statusTwice = statusTwice;
            this.hustle = hustle;
            this.statusDefenceOnePointFive = statusDefenceOnePointFive;
            this.thickFat = thickFat;
            this.attackZeroPointSevenFive = attackZeroPointSevenFive;
            this.auraBreaker = auraBreaker;
            this.attackOnePointTwo = attackOnePointTwo;
            this.attackOnePointTwoFive = attackOnePointTwoFive;
            this.attackOnePointThree = attackOnePointThree;
            this.aura = aura;
            this.attackOnePointFive = attackOnePointFive;
            this.defenseHalf = defenseHalf;
            this.defenseOnePointTwoFive = defenseOnePointTwoFive;
            this.bandGlasses = bandGlasses;
            this.plate = plate;
            this.jewel = jewel;
            this.powerHalf = powerHalf;
            this.powerOnePointFive = powerOnePointFive;
            this.helpingHandFirst = helpingHandFirst;
            this.helpingHandSecond = helpingHandSecond;
            this.meFirst = meFirst;
            this.charge = charge;
            this.powerTwice = powerTwice;
            this.descentField = descentField;
            this.riseField = riseField;
            this.sport = sport;
            this.doubleBattle = doubleBattle;
        }

        private int[] calcStatus()
        {
            int baseAttack = attack;
            int baseDefense = defense;
            //ランク補正
            if (attackRank >= 0) baseAttack = baseAttack * (2 + attackRank) / 2;
            else baseAttack = baseAttack * 2 / (2 - attackRank);

            if (defenseRank >= 0) baseDefense = baseDefense * (2 + defenseRank) / 2;
            else baseDefense = baseDefense * 2 / (2 - defenseRank);

            //はりきり
            if (hustle) baseAttack = baseAttack * 6144 / 4096;

            //攻撃ステータスの補正
            int statusAttackCorrectionValue = 4096;

            if (statusAttackHalf) statusAttackCorrectionValue = CorrectionValueCalculation(2048, statusAttackCorrectionValue);
            if (statusAttackOnePointFive) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (flowerGiftAttack) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (guts) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (statusTwice) statusAttackCorrectionValue = CorrectionValueCalculation(8192, statusAttackCorrectionValue);
            if (thickFat) statusAttackCorrectionValue = CorrectionValueCalculation(2048, statusAttackCorrectionValue);
            if (choice) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (specialItemAttack) statusAttackCorrectionValue = CorrectionValueCalculation(8192, statusAttackCorrectionValue);

            baseAttack = OverHalf(baseAttack * statusAttackCorrectionValue / 4096.0);


            //すなあらし+いわタイプによる特防上昇
            if (hustle) baseDefense = baseDefense * 6144 / 4096;

            //防御ステータスの補正
            int statusDefenseCorrectionValue = 4096;

            if (statusDefenceOnePointFive) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (flowerGiftDefence) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (eviolite) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (specialItemDefence) statusDefenseCorrectionValue = CorrectionValueCalculation(8192, statusDefenseCorrectionValue);

            baseDefense = OverHalf(baseDefense * statusDefenseCorrectionValue / 4096.0);

            //1未満のとき1にする
            if (baseAttack < 1) baseAttack = 1;
            if (baseDefense < 1) baseDefense = 1;

            int[] result = { baseAttack, baseDefense };
            return result;
        }

        private int calcPower()
        {
            int basePower = power;

            return basePower;
        }

        public int calcDamage()
        {

            int baseLevel, status, baseDamage, damage;
            baseLevel = level * 2 / 5 + 2;
            status = baseLevel * power * attack / defense;
            baseDamage = status / 50 + 2;
            damage = baseDamage;

            Debug.WriteLine("level: " + level);
            Debug.WriteLine("power: " + power);
            Debug.WriteLine("attack: " + attack);
            Debug.WriteLine("defense: " + defense);
            Debug.WriteLine("baseLevel: " + baseLevel);
            Debug.WriteLine("status: " + status);
            Debug.WriteLine("baseDamage: " + baseDamage);
            Debug.WriteLine("damage: " + damage);
            return damage;
        }

        //五捨五超入
        private int OverHalf(double x)
        {
            if ((x % 1) > 0.5) return (int)(Math.Floor(x) + 1);
            else return (int)(Math.Floor(x));
        }

        //n/4096をかけた後、四捨五入
        private int CorrectionValueCalculation(int correction, int baseValue)
        {
            double x = (double)baseValue * (double)correction / 4096.0;
            int y = (int)Math.Round(x, MidpointRounding.AwayFromZero);
            return y;
        }

    }

}
