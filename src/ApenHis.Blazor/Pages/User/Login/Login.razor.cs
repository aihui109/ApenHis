using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AntDesign;
using ApenHis.Dtos;

namespace ApenHis.Blazor.Pages.User {
    public partial class Login
    {
        private readonly LoginDto _model = new();

        [Inject] public NavigationManager NavigationManager { get; set; }


        [Inject] public MessageService Message { get; set; }

        public void HandleSubmit()
        {
            //if (_model.UserName == "admin" && _model.Password == "ant.design") {
            //  NavigationManager.NavigateTo("/");
            //  return;
            //}

            //if (_model.UserName == "user" && _model.Password == "ant.design") NavigationManager.NavigateTo("/");
        }

        public async Task GetCaptcha()
        {
            await Message.Success($"Verification code validated successfully! The verification code is: XXX");
        }
    }
}