using Microsoft.Extensions.Logging;
using Shiny;

namespace BluetoothMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterRoutes();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	static MauiAppBuilder RegisterRoutes(this MauiAppBuilder builder)
	{
		var s = builder.Services;
		s.AddBluetoothLE();
		s.AddBluetoothLeHosting();

		return builder;
	}
}
