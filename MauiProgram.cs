using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Services;

namespace NetflixApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
			});

		builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName, 
			httpClient => httpClient.BaseAddress = new Uri("https://api.themoviedb.org"));

		return builder.Build();
	}
}
