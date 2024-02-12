using Prism.Mvvm;
using System.Collections.ObjectModel;
using TelegramClone.Models;
using TelegramClone.Utils;

namespace Telegram_Clone.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private ObservableCollection<Message> _messages;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            var data = MockGenerator.GenerateMessages(15);
            _messages = new ObservableCollection<Message>(data);
        }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);   
        }
    }
}
