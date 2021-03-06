using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AKSoftware.Blazor.Utilities;

namespace BlazorUtilitiesSample.Pages
{
    public partial class MyAccount
    {

        private string _username = UserSettings.DefaultUsername;

        private void OnEnterClicked(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                UpdateUsername();
            }
        }

        private void UpdateUsername()
        {
            // Set the new value of the username 
            UserSettings.DefaultUsername = _username;

            // Send the updated
            // You can use the Send function to send the sender object with the value you want to send 
            MessagingCenter.Send(this, "username_updated", _username);
        }

        private void OnInputChange(ChangeEventArgs e)
        {
            _username = e.Value.ToString();
        }

    }
}