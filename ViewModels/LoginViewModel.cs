using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;



namespace DubClubTracker.ViewModels;


public partial class LoginViewModel : ViewModelBase
{
    private string _username = string.Empty;
    private string _password = string.Empty;

    private string _successMessage = string.Empty;
    public string SuccessMessage
    {
        get => _successMessage;
        set => this.OnPropertyChanged(nameof(SuccessMessage));
    }

    public string Username
    {
        get => _username;
        set => this.OnPropertyChanged(nameof(Username));
    }

    public string Password
    {
        get => _password;
        set => this.OnPropertyChanged(nameof(Password));    
    }


    [RelayCommand]    
    private void Login()
    {
        SuccessMessage = "Login successful!";
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        mainWindowViewModel.HasLoggedIn = true;
    }
}