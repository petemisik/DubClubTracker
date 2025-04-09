using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace DubClubTracker.ViewModels;

public partial class ProfileViewModel : ViewModelBase
{
    private readonly Action _onSaveComplete;

    public ProfileViewModel(Action onSaveComplete)
    {
        _onSaveComplete = onSaveComplete;
    }

    private string _successMessage = string.Empty;
    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _profileImage = "avares://DubClubTracker/Assets/emptyman.png";

    public string SuccessMessage
    {
        get => _successMessage;
        set
        {
            _successMessage = value;
            OnPropertyChanged(nameof(SuccessMessage));
        }
    }
    
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
    
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    public string ProfileImage
    {
        get => _profileImage;
        set => SetProperty(ref _profileImage, value, nameof(ProfileImage));
    }

    [RelayCommand]
    private async Task Save()
    {
        // Save the profile information to a file or database
        // For example, you can use JSON serialization to save the data
        // You can also use a dialog to show success message
        // Example: Show a message box or update a label in the UI
        SuccessMessage = "Profile saved successfully!";
        OnPropertyChanged(nameof(SuccessMessage));
        await Task.Delay(1000); // Simulate a delay for saving

        _onSaveComplete?.Invoke();
    }
    
}