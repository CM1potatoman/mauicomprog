using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;

namespace musika;

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
            var input = PhoneNum.Text?.Trim() ?? "";

            if (!Regex.IsMatch(input, @"^\+?[0-9\s()\-]+$"))
                throw new ArgumentException();

            var number = new string(input.Where(c => char.IsDigit(c) || c == '+').ToArray());
            var digitCount = number.Count(char.IsDigit);

            if (digitCount < 3 || digitCount > 15)
                throw new ArgumentException();

            PhoneDialer.Open(number);
        }
        catch (ArgumentException)
        {
            await DisplayAlert("Invalid input", "Please enter a valid phone number", "OK");
        }
        catch (Exception)
        {
            await DisplayAlert("Dialer unavailable", "Unable to open your phone's dialer", "OK");
        }
    }
}
