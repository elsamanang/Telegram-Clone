using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Components.ViewModels
{
    public class CallDialogViewModel : BindableBase/*, IDialogAware*/
    {
        private Message _user;

        public string Title => throw new NotImplementedException();

        public Message User {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var _userParam = parameters.GetValue<string>(nameof(Message));
            if (!string.IsNullOrWhiteSpace(_userParam))
            {
                var user = JsonSerializer.Deserialize<Message>(_userParam);
                User = user;
            }
        }
    }
}
