using Microsoft.Maui.ApplicationModel.Communication;

namespace MAUIApp3;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnDial(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(PhoneNum.Text) || PhoneNum.Text.Any(char.IsLetter))
                throw new ArgumentException();

            PhoneDialer.Open(PhoneNum.Text);
        }
        catch
        {
            await DisplayAlert("Invalid input", "Please enter a valid phone number", "OK");
        }
    }
}
