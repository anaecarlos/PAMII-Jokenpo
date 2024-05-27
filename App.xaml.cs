using Jokenpô.Mvvm.Views;

namespace Jokenpô
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new JogoView();
        }
    }
}
