using ApenHis.AppIServices;
using IdentityModel.OidcClient;
using Volo.Abp.DependencyInjection;

namespace ApenHis.Maui.Client
{
    public partial class MainPage : ContentPage, ISingletonDependency
    {
        private readonly ITestAppService _testAppService;
        protected OidcClient OidcClient { get; }
        int count = 0;

        public MainPage(ITestAppService testAppService, OidcClient oidcClient)
        {
            InitializeComponent();
            _testAppService = testAppService;
            OidcClient = oidcClient;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var loginResult = await OidcClient.LoginAsync(new LoginRequest());
            if (loginResult.IsError)
            {
                await DisplayAlert("Error", loginResult.Error, "Close");
                return;
            }

            await SecureStorage.SetAsync(OidcConsts.AccessTokenKeyName, loginResult.AccessToken);
            await SecureStorage.SetAsync(OidcConsts.RefreshTokenKeyName, loginResult.RefreshToken);

            var r = await _testAppService.GetTestDto(new Dtos.TestInput { Password1 = "1", PhoneNumber1 = "2", UserName1 = "3" });

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}