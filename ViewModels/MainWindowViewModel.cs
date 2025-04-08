using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using DubClubTracker.Models;
using DubClubTracker.Views;


namespace DubClubTracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public List<TimeModel> YourTime { get; set; } = [];
    private string _success = string.Empty;
    public string Success
    {
        get => _success;
        set
        {
            _success = value;
            OnPropertyChanged(nameof(Success));
        }
    }

    private object _currentView = new SplashView(); // Default view is the splash screen
    public object CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    private bool _hasLoggedIn = false;
    public bool HasLoggedIn
    {
        get => _hasLoggedIn;
        set
        {
            _hasLoggedIn = value;
            OnPropertyChanged(nameof(HasLoggedIn));
        }
    }

    public MainWindowViewModel()
    {
        ShowSplashScreen();
    }

    private async void ShowSplashScreen()
    {
        CurrentView = new SplashView();
        await Task.Delay(2000); // Simulate a delay for the splash screen
        CurrentView = new LoginView(); // Switch to the main view after the delay

        if (_hasLoggedIn)
        {
            CurrentView = new MainContentView(); // Switch to the main view after login
        }
    }

    
}
