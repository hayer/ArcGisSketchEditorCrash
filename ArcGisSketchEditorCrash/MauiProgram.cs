using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;

namespace ArcGisSketchEditorCrash;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseArcGISRuntime()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services
            .AddTransient<IMauiInitializeService, InitializeArcGISRuntime>();

        return builder.Build();
	}

    private class InitializeArcGISRuntime : IMauiInitializeService
    {
        public void Initialize(IServiceProvider services)
        {
            ArcGISRuntimeEnvironment.ApiKey = "Set your own";
            ArcGISRuntimeEnvironment.SetLicense("Set your own");
            ArcGISRuntimeEnvironment.Initialize();
        }
    }
}
