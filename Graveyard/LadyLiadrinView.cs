﻿using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.Generic;
using static HearthDb.CardIds.Collectible;

namespace HDT.Plugins.Graveyard
{
    public class LadyLiadrinView : NormalView
    {
        public static readonly List<string> SpellList = new List<string>
        {
            // 0
            Paladin.ForbiddenHealing,
            // 1
            Paladin.Adaptation,
            Paladin.BlessingOfMight,
            Paladin.BlessingOfWisdom,
            Paladin.DivineStrength,
            Paladin.HandOfProtection,
            //Paladin.Humility
            Paladin.SandBreath,
            // 2
            Paladin.DarkConviction,
            Paladin.FlashOfLight,
            Paladin.HandOfAdal,
            Paladin.HolyLight,
            Paladin.LibramOfWisdom,
            Paladin.LightforgedBlessing,
            Paladin.PotionOfHeroism,
            Paladin.SealOfLight,
            Paladin.SoundTheBells,
            //Paladin.Subdue
            // 3
            Paladin.SealOfChampions,
            // 4
            Paladin.BlessingOfKings,
            //Paladin.HammerOfWrath,
            Paladin.SilvermoonPortal,
            // 5
            Paladin.BlessedChampion,
            //Paladin.HolyWrath,
            // 6
            //?Paladin.Righteousness, all minions
            //?Paladin.ShrinkRay, all minions
            //?Paladin.LevelUp, all minions
            Paladin.PharaohsBlessing,
            Paladin.SpikeridgedSteed,
            // 8
            Paladin.Dinosize,
            Paladin.LayOnHands,
            // 9
            Paladin.LibramOfHope,
        };

        public static bool isValid()
        {
            return Core.Game.Player.PlayerCardList.FindIndex(card => card.Id == HearthDb.CardIds.Collectible.Paladin.LadyLiadrin) > -1;
        }

        public LadyLiadrinView()
        {
            // Section Label
            Label.Text = Strings.GetLocalized("LadyLiadrin");
        }

        public bool Update(Card card)
        {
            return card.Type == "Spell" && SpellList.Contains(card.Id) && base.Update(card, true);
        }
    }
}
