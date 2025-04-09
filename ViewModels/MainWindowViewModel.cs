using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.Input;
using DubClubTracker.Models;
using DubClubTracker.Views;


namespace DubClubTracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public List<TimeModel> YourTime { get; set; } = [];

    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _eventTitle = string.Empty;
    private string _eventDate = string.Empty;
    private string _startTime = string.Empty;
    private string _endTime = string.Empty;
    private string _successMessage = string.Empty;
    private Bitmap _profileImage = new(AssetLoader.Open(new Uri(@"avares://DubClubTracker/Assets/emptyman.png")));

    public Bitmap ProfileImage
    {
        get => _profileImage;
        set => SetProperty(ref _profileImage, value, nameof(ProfileImage));
    }
    
    private Profile profile = new();

    public string EventTitle
    {
        get => _eventTitle;
        set
        {
            _eventTitle = value;
            OnPropertyChanged(nameof(EventTitle));
        }
    }

    public string EventDate
    {
        get => _eventDate;
        set
        {
            _eventDate = value;
            OnPropertyChanged(nameof(EventDate));
        }
    }

    public string StartTime
    {
        get => _startTime;
        set
        {
            _startTime = value;
            OnPropertyChanged(nameof(StartTime));
        }
    }

    public string EndTime
    {
        get => _endTime;
        set
        {
            _endTime = value;
            OnPropertyChanged(nameof(EndTime));
        }
    }
    
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
        profile = LoadProfile();
    }

    private Profile LoadProfile()
    {
        Profile profile = new Profile
        {
            ProfilePicture = "avares://DubClubTracker/Assets/emptyman.png",
            FirstName = " ",
            LastName = " "
        };

        ProfileImage = new Bitmap(AssetLoader.Open(new Uri(profile.ProfilePicture)));
        return profile;
    }

    [RelayCommand]
    private void Start()
    {
        StartTime = DateTime.Now.ToString("HH:mm:ss");
    }

    [RelayCommand]
    private void Stop()
    {
        EndTime = DateTime.Now.ToString("HH:mm:ss");
        TimeSpan timeSpent = DateTime.Parse(_endTime) - DateTime.Parse(_startTime);
        string today = DateTime.Now.ToString("MM/dd/yyyy");
        TimeModel timeModel = new TimeModel
        {
            LastName = profile.FirstName,
            FirstName = profile.LastName,
            StartTime = _startTime,
            EndTime = _endTime,
            TotalTime = ((int)Math.Floor(timeSpent.TotalMinutes)).ToString(),
            Date = today,
            Event = _eventTitle
        };

        Console.WriteLine("TimeModel created:");
        Console.WriteLine($"LastName: {timeModel.LastName}");
        Console.WriteLine($"FirstName: {timeModel.FirstName}");
        Console.WriteLine($"StartTime: {timeModel.StartTime}");
        Console.WriteLine($"EndTime: {timeModel.EndTime}");
        Console.WriteLine($"TotalTime: {timeModel.TotalTime} minutes");
        Console.WriteLine($"Date: {timeModel.Date}");
        Console.WriteLine($"Event: {timeModel.Event}");
    }

    [RelayCommand]
    private void EditProfile()
    {
        // Logic to edit the profile
        Console.WriteLine("Edit Profile button clicked!");
        CurrentView = new ProfileView(() => 
        {
            CurrentView = new MainContentView
            {
                DataContext = this
            };
        });
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
