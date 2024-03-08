using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TelegramClone.Components.Views;
using TelegramClone.Models;
using TelegramClone.Utils;
using TelegramClone.Views;

namespace TelegramClone.ViewModels
{
    class HomeViewModel : BindableBase, INavigationAware
    {
        private Message _message;
        private int _share;
        private int _voice;
        private int _profilTab;
        private string _placeholder;
        private readonly IDialogService dialogService;

        private ObservableCollection<MessageItem> _messageItems;

        public string Placeholder
        {
            get => _placeholder;
            set => SetProperty(ref _placeholder, value);
        }

        public ObservableCollection<MessageItem> MessageItems
        {
            get => _messageItems;
            set => SetProperty(ref _messageItems, value);
        }

        public Message Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public int ProfilTab
        {
            get => _profilTab;
            set => SetProperty(ref _profilTab, value);
        }
        public int Share
        {
            get => _share;
            set => SetProperty(ref _share, value);
        }

        public int Voice
        {
            get => _voice;
            set => SetProperty(ref _voice, value);
        }

        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand CallCommand { get; set; }
        public DelegateCommand HandleWriteCommand { get; set; }
        public DelegateCommand<string> HandleChangeCommand { get; set; }

        public HomeViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CloseCommand = new(CloseTab);
            CallCommand = new(OnCall);
            HandleChangeCommand = new(OnChange);
            HandleWriteCommand = new(OnWrite);
            var data = MockGenerator.GenerateMessageItems(15);
            _messageItems = new ObservableCollection<MessageItem>(data.OrderBy(m => m.Heure));
        }

        private void OnCall()
        {
            var userSerialize = JsonSerializer.Serialize(Message);
            var param = new DialogParameters($"{nameof(Message)}={userSerialize}");
            dialogService.Show(nameof(CallViewDialog), param,null, nameof(CallDialog));
        }

        private void OnWrite()
        {
            Placeholder = "";
        }

        
        public void CloseTab()
        {
            ProfilTab = 0;
        }

        public void OnChange(string msg)
        {
            var actualTime = DateTime.Now.ToString("HH:mm");
            var newMessage = new MessageItem { Heure = actualTime, Message= msg, Orientation= "Right" };
            MessageItems.Add(newMessage);
            Placeholder = "Write a message";
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
            Share = Random.Shared.Next(1, 20);
            Voice = Random.Shared.Next(1, 20);
            Placeholder = "Write a message";
            ProfilTab = 300;
            Message = (Message)navigationContext.Parameters["myUser"];
            var data = MockGenerator.GenerateMessageItems(15);
            MessageItems = new ObservableCollection<MessageItem>(data.OrderBy(m => m.Heure));
        }
    }
}
