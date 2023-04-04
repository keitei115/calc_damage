﻿using System;
using System.Diagnostics;
using System.Linq;

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
        int compatibility; //タイプ相性による倍率
        bool weatherReinforce; //天候補正(強化)
        bool weatherWeak; //天候補正(弱体化)
        int metronome; //メトロノーム補正
        bool typeMatch; //タイプ一致
        bool adaptability; //てきおうりょく
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

        //その他威力を上下させるシステム
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
            int compatibility = 4, //通常時に4とする
            bool weatherReinforce = false,
            bool weatherWeak = false,
            int metronome = 1,
            bool typeMatch = false,
            bool adaptability = false,
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
            this.adaptability = adaptability;
            ;
        }

        private (int baseAttack, int baseDefense) calcStatus()
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
            if (sandstorm) baseDefense = baseDefense * 6144 / 4096;

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

            return (baseAttack, baseDefense);
        }

        private int calcPower()
        {
            int basePower = power;

            int powerCorrectionValue = 4096;

            if (attackZeroPointSevenFive) powerCorrectionValue = CorrectionValueCalculation(3072, powerCorrectionValue);
            if (auraBreaker) powerCorrectionValue = CorrectionValueCalculation(3072, powerCorrectionValue);
            if (attackOnePointTwo) powerCorrectionValue = CorrectionValueCalculation(4915, powerCorrectionValue);
            if (attackOnePointTwoFive) powerCorrectionValue = CorrectionValueCalculation(5120, powerCorrectionValue);
            if (attackOnePointThree) powerCorrectionValue = CorrectionValueCalculation(5325, powerCorrectionValue);
            if (aura) powerCorrectionValue = CorrectionValueCalculation(5448, powerCorrectionValue);
            if (attackOnePointFive) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (defenseHalf) powerCorrectionValue = CorrectionValueCalculation(2048, powerCorrectionValue);
            if (defenseOnePointTwoFive) powerCorrectionValue = CorrectionValueCalculation(5120, powerCorrectionValue);
            if (bandGlasses) powerCorrectionValue = CorrectionValueCalculation(4505, powerCorrectionValue);
            if (plate) powerCorrectionValue = CorrectionValueCalculation(4915, powerCorrectionValue);
            if (jewel) powerCorrectionValue = CorrectionValueCalculation(5325, powerCorrectionValue);
            if (powerHalf) powerCorrectionValue = CorrectionValueCalculation(2048, powerCorrectionValue);
            if (powerOnePointFive) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (helpingHandFirst) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (helpingHandSecond) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (meFirst) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (charge) powerCorrectionValue = CorrectionValueCalculation(8192, powerCorrectionValue);
            if (powerTwice) powerCorrectionValue = CorrectionValueCalculation(8192, powerCorrectionValue);
            if (descentField) powerCorrectionValue = CorrectionValueCalculation(2048, powerCorrectionValue);
            if (riseField) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (sport) powerCorrectionValue = CorrectionValueCalculation(1352, powerCorrectionValue);

            basePower = OverHalf(basePower * powerCorrectionValue / 4096.0);

            if (basePower < 1) basePower = 1;

            return basePower;
        }

        private int calcDamageCorrectionValue()
        {
            int damageCorrectionValuer = 4096;
            if (reflect && doubleBattle) damageCorrectionValuer = CorrectionValueCalculation(2732, damageCorrectionValuer);
            else if (reflect && !doubleBattle) damageCorrectionValuer = CorrectionValueCalculation(2048, damageCorrectionValuer);
            if (sniper && critical) damageCorrectionValuer = CorrectionValueCalculation(6144, damageCorrectionValuer);
            if (tintedLens) damageCorrectionValuer = CorrectionValueCalculation(8192, damageCorrectionValuer);
            if (mhalf) damageCorrectionValuer = CorrectionValueCalculation(2048, damageCorrectionValuer);
            if (friendGuard) damageCorrectionValuer = CorrectionValueCalculation(3072, damageCorrectionValuer);
            if (mfilter) damageCorrectionValuer = CorrectionValueCalculation(3072, damageCorrectionValuer);
            if (metronome == 2) damageCorrectionValuer = CorrectionValueCalculation(4915, damageCorrectionValuer);
            else if (metronome == 3) damageCorrectionValuer = CorrectionValueCalculation(5734, damageCorrectionValuer);
            else if (metronome == 4) damageCorrectionValuer = CorrectionValueCalculation(6553, damageCorrectionValuer);
            else if (metronome == 5) damageCorrectionValuer = CorrectionValueCalculation(7372, damageCorrectionValuer);
            else if (metronome == 6) damageCorrectionValuer = CorrectionValueCalculation(8192, damageCorrectionValuer);
            if (expertBelt) damageCorrectionValuer = CorrectionValueCalculation(4915, damageCorrectionValuer);
            if (lifeOrb) damageCorrectionValuer = CorrectionValueCalculation(5324, damageCorrectionValuer);
            if (berry) damageCorrectionValuer = CorrectionValueCalculation(2048, damageCorrectionValuer);
            if (mtwice) damageCorrectionValuer = CorrectionValueCalculation(8192, damageCorrectionValuer);
            return damageCorrectionValuer;
        }

        public int[] calcDamage()
        {
            (int calculatedAttack, int calculatedDefense) = calcStatus();
            int calculatedPower = calcPower();
            int calculatedDamageCorrectionValue = calcDamageCorrectionValue();
            int[] RandomCorrection = { 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
            int baseLevel, status, baseDamage, damage;
            int[] randamDamage = new int[16];
            baseLevel = level * 2 / 5 + 2;
            status = baseLevel * calculatedPower * calculatedAttack / calculatedDefense;
            baseDamage = status / 50 + 2;
            damage = baseDamage;
            if (ranged && doubleBattle) damage = OverHalf(damage * 3072 / 4096);
            if (weatherWeak) damage = OverHalf(damage * 2048 / 4096);
            if (weatherReinforce) damage = OverHalf(damage * 6144 / 4096);
            if (critical) damage = OverHalf(damage * 6144 / 4096);
            randamDamage = RandomCorrection.Select(e => (e * damage / 100)).ToArray();
            if (typeMatch && adaptability) randamDamage = randamDamage.Select(e => OverHalf(e * 8192 / 4096)).ToArray();
            else if (typeMatch && !adaptability) randamDamage = randamDamage.Select(e => OverHalf(e * 6144 / 4096)).ToArray();
            randamDamage = randamDamage.Select(e => (int)(e * ((double)compatibility / 4.0))).ToArray();

            Debug.WriteLine((double)compatibility / 4.0);
            Debug.WriteLine(randamDamage[15]);
            if (burn) randamDamage = randamDamage.Select(e => OverHalf(e * 2048 / 4096)).ToArray();
            randamDamage = randamDamage.Select(e => OverHalf(e * calculatedDamageCorrectionValue / 4096)).ToArray();

            Debug.WriteLine("level: " + level);
            Debug.WriteLine("power: " + power);
            Debug.WriteLine("attack: " + attack);
            Debug.WriteLine("defense: " + defense);
            Debug.WriteLine("baseLevel: " + baseLevel);
            Debug.WriteLine("status: " + status);
            Debug.WriteLine("baseDamage: " + baseDamage);
            Debug.WriteLine("damage: " + randamDamage[15]);
            return randamDamage;
        }

        public void testCalc()
        {
            (int baseAttack, int baseDefense) = calcStatus();
            Debug.WriteLine("attack: " + baseAttack);
            Debug.WriteLine("defence: " + baseDefense);
        }

        public void testPow()
        {
            int BasePower = calcPower();
            Debug.WriteLine("power: " + BasePower);
        }
        public void testDamage()
        {
            int BaseDamage = calcDamageCorrectionValue();
            Debug.WriteLine("power: " + BaseDamage);
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
