using System;
using System.Diagnostics;
using System.Linq;

namespace testApp
{
    public class CalcPokemon
    {

        public enum AllyItem //味方の持ち物
        {
            none, //持ち物なし
            expertBelt, //たつじんのおび
            lifeOrb, //いのちのたま
            choice, //こだわりハチマキ・こだわりメガネ
            metronomeTwo, //メトロノーム2回目
            metronomeThree, //メトロノーム3回目
            metronomeFour, //メトロノーム4回目
            metronomeFive, //メトロノーム5回目
            metronomeSix, //メトロノーム6回目
            specialItemAttack, //でんきだま・ふといホネ・しんかいのキバ
            bandGlasses, //ちからのハチマキ・ものしりメガネ
            plate, //タイプ強化アイテム
            jewel //ジュエル
        }

        public enum FoeItem //相手の持ち物
        {
            none, //持ち物なし
            berry, //弱点半減きのみ
            evioliteVest, //しんかのきせき・とつげきチョッキ
            specialItemDefence, //メタルパウダー・しんかいのウロコ
        }

        public enum AllyAbility //味方の特性
        {
            none, //特性なし
            statusAttackHalf, //スロースタート・よわき
            statusAttackOnePointFive, //しんりょく・もうか・げきりゅう・むしのしらせ・はりきり・もらいび・サンパワー
            guts, //こんじょう(やけどを無視する)
            statusTwice, //ちからもち・ヨガパワー
            hustle, //はりきり
            attackZeroPointSevenFive, //とうそうしん(異性)
            attackOnePointTwo, //すてみ・てつのこぶし
            attackOnePointTwoFive, //とうそうしん(同性)
            attackOnePointThree, //アナライズ・かたいツメ・スキン・すなのちから・ちからずく
            attackOnePointFive, //がんじょうあご・テクニシャン・どくぼうそう・ねつぼうそう・メガランチャー
            sniper, //スナイパー
            tintedLens, //いろめがね
            parentalBond //おやこあい
        }

        public enum FoeAbility //相手の特性
        {
            none, //特性なし
            statusDefenceOnePointFive, //くさのけがわ・ふしぎなうろこ
            thickFat, //あついしぼう
            defenseHalf, //たいねつ
            defenseOnePointTwoFive, //かんそうはだ
            mhalf, //マルチスケイル(特性による半減)
            mfilter //ハードロック・フィルター
        }

        public enum Weather //天候
        {
            none, //通常時
            weatherReinforce, //天候補正(強化)
            weatherWeak //天候補正(弱体化)
        }

        public enum HelpingHand //てだすけ
        {
            none, //てだすけなし
            one, //てだすけ1つ目
            two //てだすけ2つ目
        }
        public enum Compatibility //タイプ相性による倍率
        {
            none = 4,
            effective = 8,
            superEffective = 16,
            notEffective = 2,
            notVeryEffective = 1,
            noEffect = 0
        }

        AllyItem allyItem; //味方の持ち物
        FoeItem foeItem; //相手の持ち物
        AllyAbility allyAbility; //味方の特性
        FoeAbility foeAbility; //相手の特性
        Weather weather; //天候
        HelpingHand helpingHand; //てだすけ
        Compatibility compatibility; //タイプ相性による倍率

        int level; //攻撃側のレベル
        int power; //わざの威力
        int attack; //こうげき・とくこう
        int defense; //ぼうぎょ・とくぼう
        int attackRank; //攻撃側の能力ランク
        int defenseRank; //防御側の能力ランク

        //ダメージにかかわる補正
        bool typeMatch; //タイプ一致
        bool adaptability; //てきおうりょく
        bool critical; //急所
        bool ranged; //範囲・全体技
        bool burn; //やけど
        bool reflect; //リフレクター・ひかりのかべ
        bool friendGuard; //フレンドガード
        bool mtwice; //穴を掘る→地震、ダイビング→波乗り、小さくなる→踏みつけの2倍

        //ステータスを上下させるシステム
        bool sandstorm; //いわタイプ+すなあらし
        bool flowerGiftAttack; //フラワーギフト(攻撃側)
        bool flowerGiftDefence; //フラワーギフト(防御側)

        //技の威力を上下させるシステム
        bool auraBreaker; //オーラブレイク
        bool aura; //フェアリーオーラ・ダークオーラ
        bool powerHalf; //雨下ソーラービーム
        bool powerOnePointFive; //持ち物を持ってるポケモンにはたきおとす
        bool meFirst; //さきどり
        bool charge; //じゅうでん
        bool powerTwice; //かたきうち・からげんき・クロスサンダー・クロスフレイム・しおみず・ベノムショック
        bool descentField; //グラスフィールド下でのじしん・じならし・マグニチュード、ミストフィールド下でのドラゴン技
        bool riseField; //エレキフィールド・グラスフィールド
        bool sport; //みずあそび、どろあそび

        //その他
        bool doubleBattle; //ダブルバトルの場合

        public CalcPokemon(
            AllyItem allyItem = AllyItem.none,
            FoeItem foeItem = FoeItem.none,
            AllyAbility allyAbility = AllyAbility.none,
            FoeAbility foeAbility = FoeAbility.none,
            Weather weather = Weather.none,
            HelpingHand helpingHand = HelpingHand.none,
            Compatibility compatibility = Compatibility.none,

            int level = 50,
            int power = 10,
            int attack = 10,
            int defense = 10,
            int attackRank = 0,
            int defenseRank = 0,
            bool typeMatch = false,
            bool adaptability = false,
            bool critical = false,
            bool ranged = false,
            bool burn = false,
            bool reflect = false,
            bool friendGuard = false,
            bool mtwice = false,
            bool sandstorm = false,
            bool flowerGiftAttack = false,
            bool flowerGiftDefence = false,
            bool auraBreaker = false,
            bool aura = false,
            bool powerHalf = false,
            bool powerOnePointFive = false,
            bool meFirst = false,
            bool charge = false,
            bool powerTwice = false,
            bool descentField = false,
            bool riseField = false,
            bool sport = false,
            bool doubleBattle = false
            )
        {
            this.allyItem = allyItem;
            this.foeItem = foeItem;
            this.allyAbility = allyAbility;
            this.foeAbility = foeAbility;
            this.weather = weather;
            this.helpingHand = helpingHand;

            this.level = level;
            this.power = power;
            this.attack = attack;
            this.defense = defense;
            this.attackRank = attackRank;
            this.defenseRank = defenseRank;
            this.compatibility = compatibility;
            this.typeMatch = typeMatch;
            this.critical = critical;
            this.ranged = ranged;
            this.burn = burn;
            this.reflect = reflect;
            this.friendGuard = friendGuard;
            this.mtwice = mtwice;
            this.sandstorm = sandstorm;
            this.flowerGiftAttack = flowerGiftAttack;
            this.flowerGiftDefence = flowerGiftDefence;
            this.auraBreaker = auraBreaker;
            this.aura = aura;
            this.powerHalf = powerHalf;
            this.powerOnePointFive = powerOnePointFive;
            this.meFirst = meFirst;
            this.charge = charge;
            this.powerTwice = powerTwice;
            this.descentField = descentField;
            this.riseField = riseField;
            this.sport = sport;
            this.doubleBattle = doubleBattle;
            this.adaptability = adaptability;
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
            if (allyAbility == AllyAbility.hustle) baseAttack = baseAttack * 6144 / 4096;

            //攻撃ステータスの補正
            int statusAttackCorrectionValue = 4096;

            if (allyAbility == AllyAbility.statusAttackHalf) statusAttackCorrectionValue = CorrectionValueCalculation(2048, statusAttackCorrectionValue);
            if (allyAbility == AllyAbility.statusAttackOnePointFive) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (flowerGiftAttack) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (allyAbility == AllyAbility.guts) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (allyAbility == AllyAbility.statusTwice) statusAttackCorrectionValue = CorrectionValueCalculation(8192, statusAttackCorrectionValue);
            if (foeAbility == FoeAbility.thickFat) statusAttackCorrectionValue = CorrectionValueCalculation(2048, statusAttackCorrectionValue);
            if (allyItem == AllyItem.choice) statusAttackCorrectionValue = CorrectionValueCalculation(6144, statusAttackCorrectionValue);
            if (allyItem == AllyItem.specialItemAttack) statusAttackCorrectionValue = CorrectionValueCalculation(8192, statusAttackCorrectionValue);

            baseAttack = OverHalf(baseAttack * statusAttackCorrectionValue / 4096.0);

            //すなあらし+いわタイプによる特防上昇
            if (sandstorm) baseDefense = baseDefense * 6144 / 4096;

            //防御ステータスの補正
            int statusDefenseCorrectionValue = 4096;

            if (foeAbility == FoeAbility.statusDefenceOnePointFive) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (flowerGiftDefence) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (foeItem == FoeItem.evioliteVest) statusDefenseCorrectionValue = CorrectionValueCalculation(6144, statusDefenseCorrectionValue);
            if (foeItem == FoeItem.specialItemDefence) statusDefenseCorrectionValue = CorrectionValueCalculation(8192, statusDefenseCorrectionValue);

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

            if (allyAbility == AllyAbility.attackZeroPointSevenFive) powerCorrectionValue = CorrectionValueCalculation(3072, powerCorrectionValue);
            if (auraBreaker) powerCorrectionValue = CorrectionValueCalculation(3072, powerCorrectionValue);
            if (allyAbility == AllyAbility.attackOnePointTwo) powerCorrectionValue = CorrectionValueCalculation(4915, powerCorrectionValue);
            if (allyAbility == AllyAbility.attackOnePointTwoFive) powerCorrectionValue = CorrectionValueCalculation(5120, powerCorrectionValue);
            if (allyAbility == AllyAbility.attackOnePointThree) powerCorrectionValue = CorrectionValueCalculation(5325, powerCorrectionValue);
            if (aura) powerCorrectionValue = CorrectionValueCalculation(5448, powerCorrectionValue);
            if (allyAbility == AllyAbility.attackOnePointFive) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (foeAbility == FoeAbility.defenseHalf) powerCorrectionValue = CorrectionValueCalculation(2048, powerCorrectionValue);
            if (foeAbility == FoeAbility.defenseOnePointTwoFive) powerCorrectionValue = CorrectionValueCalculation(5120, powerCorrectionValue);
            if (allyItem == AllyItem.bandGlasses) powerCorrectionValue = CorrectionValueCalculation(4505, powerCorrectionValue);
            if (allyItem == AllyItem.plate) powerCorrectionValue = CorrectionValueCalculation(4915, powerCorrectionValue);
            if (allyItem == AllyItem.jewel) powerCorrectionValue = CorrectionValueCalculation(5325, powerCorrectionValue);
            if (powerHalf) powerCorrectionValue = CorrectionValueCalculation(2048, powerCorrectionValue);
            if (powerOnePointFive) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            if (helpingHand == HelpingHand.one) powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            else if (helpingHand == HelpingHand.two)
            {
                powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
                powerCorrectionValue = CorrectionValueCalculation(6144, powerCorrectionValue);
            }
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
            if (allyAbility == AllyAbility.sniper && critical) damageCorrectionValuer = CorrectionValueCalculation(6144, damageCorrectionValuer);
            if (allyAbility == AllyAbility.tintedLens) damageCorrectionValuer = CorrectionValueCalculation(8192, damageCorrectionValuer);
            if (foeAbility == FoeAbility.mhalf) damageCorrectionValuer = CorrectionValueCalculation(2048, damageCorrectionValuer);
            if (friendGuard) damageCorrectionValuer = CorrectionValueCalculation(3072, damageCorrectionValuer);
            if (foeAbility == FoeAbility.mfilter) damageCorrectionValuer = CorrectionValueCalculation(3072, damageCorrectionValuer);
            if (allyItem == AllyItem.metronomeTwo) damageCorrectionValuer = CorrectionValueCalculation(4915, damageCorrectionValuer);
            else if (allyItem == AllyItem.metronomeThree) damageCorrectionValuer = CorrectionValueCalculation(5734, damageCorrectionValuer);
            else if (allyItem == AllyItem.metronomeFour) damageCorrectionValuer = CorrectionValueCalculation(6553, damageCorrectionValuer);
            else if (allyItem == AllyItem.metronomeFive) damageCorrectionValuer = CorrectionValueCalculation(7372, damageCorrectionValuer);
            else if (allyItem == AllyItem.metronomeSix) damageCorrectionValuer = CorrectionValueCalculation(8192, damageCorrectionValuer);
            if (allyItem == AllyItem.expertBelt) damageCorrectionValuer = CorrectionValueCalculation(4915, damageCorrectionValuer);
            if (allyItem == AllyItem.lifeOrb) damageCorrectionValuer = CorrectionValueCalculation(5324, damageCorrectionValuer);
            if (foeItem == FoeItem.berry) damageCorrectionValuer = CorrectionValueCalculation(2048, damageCorrectionValuer);
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
            if (weather == Weather.weatherWeak) damage = OverHalf(damage * 2048 / 4096);
            else if (weather == Weather.weatherReinforce) damage = OverHalf(damage * 6144 / 4096);
            if (critical) damage = OverHalf(damage * 6144 / 4096);
            randamDamage = RandomCorrection.Select(e => (e * damage / 100)).ToArray();
            if (typeMatch && adaptability) randamDamage = randamDamage.Select(e => OverHalf(e * 8192 / 4096)).ToArray();
            else if (typeMatch && !adaptability) randamDamage = randamDamage.Select(e => OverHalf(e * 6144 / 4096)).ToArray();
            randamDamage = randamDamage.Select(e => (int)(e * ((int)compatibility / 4.0))).ToArray();

            Debug.WriteLine((double)compatibility / 4.0);
            Debug.WriteLine(randamDamage[15]);
            if (burn) randamDamage = randamDamage.Select(e => OverHalf(e * 2048 / 4096)).ToArray();
            randamDamage = randamDamage.Select(e => OverHalf(e * calculatedDamageCorrectionValue / 4096)).ToArray();
            if (compatibility != Compatibility.noEffect) randamDamage = randamDamage.Select(e => e > 0 ? e : 1).ToArray();

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
