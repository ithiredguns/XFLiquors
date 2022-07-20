using System.Threading.Tasks;
using Xamarin.Forms;
using XFLiquors.Services;
using XFLiquors.Views;

namespace XFLiquors.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Company = "R & L";
            NavigateToDiscoverPageCommand = new Command(async () => await ExecuteNavigateToDiscoverPageCommand());
            var deviceInfoService = DependencyService.Get<IDeviceInfoService>();

            if (deviceInfoService != null)
            {
                DeviceModel= deviceInfoService.GetDeviceInfo();
            }


        }

        public Command NavigateToDiscoverPageCommand { get; }

        private string _company;
        private string _email;
        private string _password; 
        private string _deviceModel;

        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Password { get => _password; set => _password = value; }

        public string DeviceModel { get => _deviceModel; set => SetProperty(ref _deviceModel, value); }

        private async Task ExecuteNavigateToDiscoverPageCommand()
        {
            //Check login values and then go to Discover Page
            await Navigation.PushAsync(new DiscoverPage());
        }
    }
}
