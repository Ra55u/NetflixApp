using Models;
using System.Windows.Input;

namespace Controls;

public partial class MovieInfoBox : ContentView
{
	public static readonly BindableProperty MediaProperty =
		BindableProperty.Create(nameof(Media), typeof(Media), typeof(MovieInfoBox), null);

	public MovieInfoBox()
	{
		InitializeComponent();
	}
    public Media Media
	{
		get => (Media)GetValue(MovieInfoBox.MediaProperty);
		set => SetValue(MovieInfoBox.MediaProperty, value);
	}

	public ICommand ClosedCommand { get; private set; }
	private void ExectuteClosedCommand() =>
		Closed?.Invoke(this, EventArgs.Empty);

	private void Button_Clicked(object sender, EventArgs e) =>
		Closed?.Invoke(this, EventArgs.Empty);

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var parameters = new Dictionary<string, object>
        {
            [nameof(DetailsViewModel.Media)] = Media
        };
        await Shell.Current.GoToAsync(nameof(DetailsPage), true, parameters);
    }
}