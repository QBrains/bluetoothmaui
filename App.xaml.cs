using BluetoothMaui.Core;
using Shiny.BluetoothLE.Hosting;

namespace BluetoothMaui;

public partial class App : Application
{
	private readonly IBleHostingManager _bleHostingManager;
	public App(IBleHostingManager bleHostingManager)
	{
		_bleHostingManager = bleHostingManager;
		InitializeComponent();

		// load all the dependencies
		Resolver.AddOnStartup<IBleHostingManager>(BluetoothLEHosting);
		Resolver.Build();

		MainPage = new AppShell();
	}

	public IBleHostingManager BluetoothLEHosting => _bleHostingManager;
}
