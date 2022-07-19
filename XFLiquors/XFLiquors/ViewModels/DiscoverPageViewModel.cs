using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFLiquors.Models;
using XFLiquors.Views;

namespace XFLiquors.ViewModels
{
    public class DiscoverPageViewModel : BaseViewModel
    {
        public DiscoverPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Groups = new ObservableCollection<Group>();
            Products = new ObservableCollection<Product>();
            BestPrices = new ObservableCollection<Product>();
            NavigateToMainPageCommand = new Command(async () => await ExecuteNavigateToMainPageCommand());
            SelectGroupCommand = new Command<Group>((model) => ExecuteSelectGroupCommand(model));
            GetGroups();
            GetProducts();
            GetBestPrices();
        }

        public Command NavigateToMainPageCommand { get; }
        public Command SelectGroupCommand { get; }
        public ICommand SelectionCommand => new Command(DisplayDetail);

        private void DisplayDetail()
        {
            if(SelectedBestPrice!=null)
            {
                var viewModel = new DetailsPageViewModel { SelectedLiquor = SelectedBestPrice };
                var detailsPage = new DetailsPage { BindingContext = viewModel };
                SelectedBestPrice = null;
                Navigation.PushAsync(detailsPage, true);
                
            }
        }

        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> BestPrices { get; set; }

        private Product selectedBestPrice;
        public Product SelectedBestPrice
        {
            get { return selectedBestPrice; }
            set
            {
                selectedBestPrice = value;
                OnPropertyChanged();
            }
        }

        void GetGroups()
        {
            Groups.Add(new Group()
            {
                groupId = 1,
                description = "WHISKEY",
                backGroundColor = "#D99D60",
                textColor = "#FFFFFF",
                selected = true,
            });

            Groups.Add(new Group()
            {
                groupId = 2,
                description = "BEER",
                backGroundColor = "Transparent",
                textColor = "#5B5F62",
            });

            Groups.Add(new Group()
            {
                groupId = 3,
                description = "LIQUERS",
                backGroundColor = "Transparent",
                textColor = "#5B5F62",
            });

            Groups.Add(new Group()
            {
                groupId = 4,
                description = "VODKA",
                backGroundColor = "Transparent",
                textColor = "#5B5F62",
            });

            Groups.Add(new Group()
            {
                groupId = 5,
                description = "WINE",
                backGroundColor = "Transparent",
                textColor = "#5B5F62",
            });
        }

        void GetProducts()
        {
            Products.Add(new Product()
            {
                image = "octomore101.png",
                description = "Bruichladdich Octomore 10.1",
                rating = 4.5,
                weight = 750,
                price = 199.99
            });

            Products.Add(new Product()
            {
                image = "ardbeg.png",
                description = "Ardbeg An Oa",
                rating = 5,
                weight = 750,
                price = 85.99
            });

            Products.Add(new Product()
            {
                image = "jack_daniels.png",
                description = "Jack Daniel's Old No. 7 Tennessee",
                rating = 4.7,
                weight = 1.75,
                price = 45.99
            });
        }

        void GetBestPrices()
        {
            BestPrices.Add(new Product()
            {
                image = "dalmore.png",
                description = "The Dalmore 12 Year",
                weight = 750,
                price = 64.99,
                rating=3.0,
                groupId= 1,
                longDescription = "The Dalmore 12 is recognized as a whisky with character far beyond its age. The spirit is initially matured in American white oak ex-Bourbon casks, yielding soft vanilla and honey notes."
            });

            BestPrices.Add(new Product()
            {
                image = "charlotte.png",
                description = "Bruichladdich Port Charlotte Scotch",
                weight = 700,
                price = 63.99,
                rating = 4.0,
                groupId = 1,
                longDescription = "This Port Charlotte 10 year old has been conceived, distilled, matured and bottled on Islay alone."
            });
            BestPrices.Add(new Product()
            {
                image = "jack_daniels.png",
                description = "Jack Daniel's Old No. 7 Tennessee",
                rating = 4.7,
                weight = 1.75,
                price = 45.99,
                groupId = 1,
                longDescription = "Mellowed drop by drop through 10-feet of sugar maple charcoal, then matured in handcrafted barrels of our own making."
            });
        }

        private async Task ExecuteNavigateToMainPageCommand()
        {
            await Navigation.PopAsync();
        }

        private void ExecuteSelectGroupCommand(Group model)
        {
            var index = Groups
                .ToList()
                .FindIndex(p => p.groupId == model.groupId);

            if (index > -1)
            {
                UnselectGroupItems();

                Groups[index].selected = true;
                Groups[index].backGroundColor = "#D99D60";
                Groups[index].textColor = "#FFFFFF";
            }

            //TO DO --> filter 
        }

        void UnselectGroupItems()
        {
            Groups.ForEach((item) =>
            {
                item.selected = false;
                item.backGroundColor = "Transparent";
                item.textColor = "#5B5F62";
            });
        }
    }
}
