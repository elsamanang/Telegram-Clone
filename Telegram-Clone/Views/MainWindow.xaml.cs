using AdonisUI.Controls;
using Prism.Services.Dialogs;
using System.Windows;

namespace Telegram_Clone.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow, IDialogWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
