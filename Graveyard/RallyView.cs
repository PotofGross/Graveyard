﻿using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace HDT.Plugins.Graveyard
{
	public class RallyView : NormalView
	{
		private ChancesTracker _chances = new ChancesTracker();

		public static bool isValid()
		{
			return Core.Game.Player.PlayerCardList.FindIndex(card =>
				card.Id == HearthDb.CardIds.Collectible.Neutral.Rally) > -1;
		}

		public static bool IsAlwaysSeparate => Settings.Default.RallyEnabled && Settings.Default.AlwaysRallySeparately;

		public RallyView()
		{
			// Section Label
			Label.Text = Strings.GetLocalized("Rally");
		}

		public bool Update(Card card)
		{
			var update = card.Type == "Minion" && card.Cost >= 1 && card.Cost <= 3  && base.Update(card);

			if (update)
				_chances.Update(card, Cards, View);

			return update;
		}
	}
}
