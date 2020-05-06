﻿using HDT.Plugins.Graveyard.Resources;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDT.Plugins.Graveyard
{
    public class SoulwardenView : NormalView
    {
        private ChancesTracker _chances = new ChancesTracker();

        public string Literal { get; }

        public static bool isValid()
        {
            return Core.Game.Player.PlayerCardList.FindIndex(card => card.Id == HearthDb.CardIds.Collectible.Warlock.Soulwarden) > -1;
        }

        public SoulwardenView()
        {
            // Section Label
            Label.Text = Strings.Soulwarden;
        }

        public bool Update(Card card)
        {
            if (!base.Update(card, card.Type == "Spell"))
            {
                return false;
            }

            // Silverware Golem and Clutchmother Zaras are still counted as discarded, even when their effects trigger
            _chances.Update(card, Cards, View);

            return true;
        }
    }
}
