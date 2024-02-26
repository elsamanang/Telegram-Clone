﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TelegramClone.Models;
using TelegramClone.Utils;

namespace TelegramClone.ViewModels
{
    class HomeViewModel : BindableBase, INavigationAware
    {
        private Message _message;
        private int _share;
        private int _voice;
        private int _profilTab;
        private ObservableCollection<MessageItem> _messageItems;

        public HomeViewModel()
        {
            CloseCommand = new(CloseTab);
            var data = MockGenerator.GenerateMessageItems(20);
            _messageItems = new ObservableCollection<MessageItem>(data.OrderBy(m => m.Heure));
        }

        public DelegateCommand CloseCommand { get; set; }

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

        public void CloseTab()
        {
            ProfilTab = 0;
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
            ProfilTab = 300;
            Message = (Message)navigationContext.Parameters["myUser"];
        }
    }
}
