using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using TelegramClone.Models;
using TelegramClone.Utils;
using TelegramClone.Views;

namespace Telegram_Clone.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private string _sideBar = "auto";
        private ObservableCollection<Message> _messages;
        private readonly IRegionManager _regionManager;

        public DelegateCommand<Message> NavigateCommand { get; private set; }
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand OpenCommand { get; set; }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string SideBar
        {
            get => _sideBar;
            set => SetProperty(ref _sideBar, value);
        }

        public DelegateCommand<Message> SelectCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<Message>(Navigate);
            var data = MockGenerator.GenerateMessages(15);
            _messages = new ObservableCollection<Message>(data);
            SelectCommand = new(SelectionChanged);
            CloseCommand = new(OnClose);
        }

        private void OnClose()
        {
            MessageBox.Show("fermer");
            //SideBar = "0";
        }

        private void SelectionChanged(Message message)
        {
            Navigate(message);
        }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);   
        }
    
        private void Navigate(Message msg)
        {
            var param = new NavigationParameters();
            param.Add("myUser", msg);
            _regionManager.RegisterViewWithRegion("ConversationRegion", typeof(Home));
            _regionManager.RequestNavigate("ConversationRegion", "Home", param);
        }

    }
}
