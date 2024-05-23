using NetflixApp.Pages;

namespace NetflixApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
    }
}
