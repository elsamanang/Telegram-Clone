using Prism.Ioc;
using System.Windows;
using Telegram_Clone.Views;
using TelegramClone.Components.ViewModels;
using TelegramClone.Components.Views;
using TelegramClone.Views;

namespace Telegram_Clone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<CallViewDialog, CallViewDialogViewModel>(nameof(CallViewDialog));
            containerRegistry.RegisterDialogWindow<CallDialog>(nameof(CallDialog));
        }
    }
}
