using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFLiquors.Models;
using XFLiquors.Services;
using XFLiquors.Views;

namespace XFLiquors.ViewModels
{
    public class DiscoverPageViewModel : BaseViewModel
    {
        public DiscoverPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Groups = new ObservableRangeCollection<Group>();
            Products = new ObservableRangeCollection<Product>(); 
            NavigateToMainPageCommand = new Command(async () => await ExecuteNavigateToMainPageCommand());
            SelectGroupCommand = new Command<Group>((model) => ExecuteSelectGroupCommand(model));
            GetGroups();
            GetProducts();
           
        }
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            var SearchResults = DataService.GetSearchResults(query);
            if(SearchResults!=null&&SearchResults.Any())
            {
                Products.Clear(); 
                Products.AddRange(SearchResults);
                UnselectGroupItems();
            }
        });
        public Command NavigateToMainPageCommand { get; }
        public Command SelectGroupCommand { get; }
        public ICommand SelectionCommand => new Command(DisplayDetail);

        private void DisplayDetail()
        {
            if(SelectedProduct!=null)
            {
                var viewModel = new DetailsPageViewModel { SelectedLiquor = SelectedProduct };
                var detailsPage = new DetailsPage { BindingContext = viewModel };
                SelectedProduct = null;
                Navigation.PushAsync(detailsPage, true);
                
            }
        }

        public ObservableRangeCollection<Group> Groups { get; set; }
        public ObservableRangeCollection<Product> Products { get; set; }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        void GetGroups()
        {
            Groups.Add(new Group()
            {
                groupId = 0,
                description = "ALL",
                backGroundColor = "Transparent",
                textColor = "#5B5F62"
            });
            Groups.Add(new Group()
            {
                groupId = 1,
                description = "WHISKEY",
                backGroundColor = "Transparent",
                textColor = "#5B5F62"  
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
            Products.Clear();
            Products.AddRange(DataService.Products.OrderBy(x=>x.groupId).ThenBy(y=>y.description));
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
            if (model.groupId > 0)
            {
                var filteredProducts = DataService.Products.Where(s => s.groupId == model.groupId);
                if (filteredProducts != null && filteredProducts.Any())
                {
                    Products.Clear();
                    Products.AddRange(filteredProducts.OrderBy(x => x.groupId).ThenBy(y => y.description));
                }
                else
                {
                    Products.Clear();
                }
            }
            else
            {
                Products.Clear();
                Products.AddRange(DataService.Products.OrderBy(x => x.groupId).ThenBy(y => y.description));
            }


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
