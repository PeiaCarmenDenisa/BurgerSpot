using BurgerSpot.Model;
using BurgerSpot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BurgerSpot.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            burgers = GetBurgers();
        }
        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers
        {
            get { return burgers; }
            set
            {
                burgers = value;
                OnPropertyChange();

            }
        }
        private Burger selectedBurger;
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChange();
            }
        }
        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if (selectedBurger != null)
            {
                var viewModel = new DetailsViewModel { SelectedBurger = selectedBurger, Burgers = burgers, Position = burgers.IndexOf(selectedBurger) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };
            }
        }
        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger {Name ="CLASSIC", Price=13.99f, Image="classic.png", Description="The best choice"},
            new Burger { Name = "DOUBLE", Price = 19.99f, Image = "double.png", Description = "Men's burgers" },
            new Burger { Name = "SHARK", Price = 19.99f, Image = "shark.png", Description = "The best choice for woman" },
            new Burger { Name = "CHICKEN", Price = 15.99f, Image = "chicken.png", Description = "The best choice for childrens" },
            new Burger { Name = "MEAT", Price = 11.99f, Image = "meat.png", Description = "For beef lovers" },
            new Burger { Name = "BBQ", Price = 14.99f, Image = "BBQ.png", Description = "The best choice for chilly lovers" },
            };
        }
    }
}

