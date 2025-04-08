using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using DubClubTracker.Models;
using DubClubTracker.Views;


namespace DubClubTracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public List<TimeModel> YourTime { get; set; } = [];

    private string _username = string.Empty;
    private string _password = string.Empty;

    private string _successMessage = string.Empty;
    public string SuccessMessage
    {
        get
        {
            return _successMessage;
        }

        set
        {
            _successMessage = value;
            OnPropertyChanged(nameof(SuccessMessage));
        }
    }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Password
    {
        get => _password;
        set 
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    
    private object _currentView = new SplashView(); // Default view is the splash screen
    public object CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value, nameof(CurrentView));
    }

    private bool _hasLoggedIn = false;
    public bool HasLoggedIn
    {
        get => _hasLoggedIn;
        set
        {
            Console.WriteLine($"HasLoggedIn: {value}");
            _hasLoggedIn = value;
            OnPropertyChanged(nameof(HasLoggedIn));
        }
    }

    public MainWindowViewModel()
    {
        // Switch to the main view after login
        ShowSplashScreen();
    }

    private async void ShowSplashScreen()
    {
        CurrentView = new SplashView();
        await Task.Delay(2000); // Simulate a delay for the splash screen
        CurrentView = new LoginView(); // Switch to the main view after the delay
    }

    [RelayCommand]    
    private async Task Login()
    {
        Console.WriteLine($"Username: {Username}, Password: {Password}");
        Console.WriteLine("Login button clicked!"); 
        SuccessMessage = "Login successful!";
        await Task.Delay(1000);

        CurrentView = new MainContentView(); // Switch to the main view after login
        
    }
}
