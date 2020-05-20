using Hearthstone_Deck_Tracker;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WPFLocalizeExtension.Engine;

namespace HDT.Plugins.Graveyard
{
	public partial class SettingsView : ScrollViewer
	{
		private static Flyout _flyout;

		public static Flyout Flyout
		{
			get
			{
				if (_flyout == null)
				{
					_flyout = CreateSettingsFlyout();
				}
				return _flyout;
			}
		}

		private static Flyout CreateSettingsFlyout()
		{
			var settings = new Flyout();
			settings.Position = Position.Left;
			Panel.SetZIndex(settings, 100);
			settings.Header = Strings.GetLocalized("SettingsTitle");
			settings.Content = new SettingsView();
			Core.MainWindow.Flyouts.Items.Add(settings);
			return settings;
		}

		public SettingsView()
		{
			InitializeComponent();
			Settings.Default.PropertyChanged += (sender, e) => Settings.Default.Save();
			Debug.WriteLine(LocalizeDictionary.Instance.Culture.Name);
		}

		private void BtnUnlock_Click (object sender, RoutedEventArgs e) {
			BtnUnlock.Content = Graveyard.Input.Toggle() ? Strings.GetLocalized("Lock") : Strings.GetLocalized("Unlock");
		}
	}
}
