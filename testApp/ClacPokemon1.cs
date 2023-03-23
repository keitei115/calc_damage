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
        float compatibility; //タイプ相性による倍率
        float weather; //天候補正
        float metronome; //メトロノーム補正
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

        public CalcPokemon(
            int level = 50,
            int power = 10,
            int attack = 10,
            int defense = 10,
            int attackRank = 0,
            int defenseRank = 0,
            float compatibility = 1.0F,
            float weather = 1.0F,
            float metronome = 1.0F,
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
            bool mtwice = false
            )
        {
            this.level = level;
            this.power = power;
            this.attack = attack;
            this.defense = defense;
            this.attackRank = attackRank;
            this.defenseRank = defenseRank;
            this.compatibility = compatibility;
            this.weather = weather;
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

            if (attackRank < 0)
            {
                this.attack = attack * 2 / (2 - attackRank);
            }
            else
            {
                this.attack = attack * (2 + attackRank) / 2;
            }

            if (defenseRank < 0)
            {
                this.defense = defense * 2 / (2 - defenseRank);
            }
            else
            {
                this.defense = defense * (2 + defenseRank) / 2;
            }

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
    }

}
