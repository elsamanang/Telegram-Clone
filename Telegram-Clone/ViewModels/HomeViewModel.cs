using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TelegramClone.Models;

namespace TelegramClone.ViewModels
{
    class HomeViewModel : BindableBase, INavigationAware
    {
        private Message _message;

        public HomeViewModel() 
        { 
           
        }

        public Message Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Message = (Message)navigationContext.Parameters["myUser"];
        }
    }
}
