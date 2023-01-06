using ApenHis.AppIServices;
using Volo.Abp.DependencyInjection;

namespace ApenHis.Maui.Client
{
    public partial class MainPage : ContentPage, ISingletonDependency
    {
        private readonly ITestAppService _testAppService;

        int count = 0;

        public MainPage(ITestAppService testAppService)
        {
            _testAppService = testAppService;
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            var r = await _testAppService.GetTestDto(new Dtos.TestInput { Password1 = "1", PhoneNumber1 = "2", UserName1 = "3" });

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}