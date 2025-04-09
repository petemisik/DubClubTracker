using System;
using Avalonia.Controls;
using DubClubTracker.ViewModels;

namespace DubClubTracker.Views;

public partial class ProfileView : UserControl
{
    public ProfileView(Action onSaveComplete)
    {
        InitializeComponent();
        DataContext = new ProfileViewModel(onSaveComplete);
    }
}