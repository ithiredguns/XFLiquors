using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFLiquors.Models;

namespace XFLiquors.ViewModels
{
	public class DetailsPageViewModel:BaseViewModel
	{
        private Product selectedLiquor;
        public Product SelectedLiquor
        {
            get { return selectedLiquor; }
            set
            {
                selectedLiquor = value;
                OnPropertyChanged();
            }
        }
        public Command NavigateToDiscoverPageCommand { get; }

        public DetailsPageViewModel()
		{
            NavigateToDiscoverPageCommand = new Command(async () => await ExecuteNavigateToDiscoverPageCommand());
        }
        private async Task ExecuteNavigateToDiscoverPageCommand()
        {
            //Check login values and then go to Discover Page
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

