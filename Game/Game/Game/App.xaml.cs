using Game.View;
using Xamarin.Forms;

namespace Game
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageGame();
            // MainPage = new PageInicial();
            // MainPage = new ComoJogar();
            //   MainPage = new PageGameRandom();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
