using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGameRandom : ContentPage
    {
        bool turno = true;
        public PageGameRandom()
        {
            InitializeComponent();
        }

        private void buttonSingle_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (string.IsNullOrEmpty(button.Text))
            {
                if (turno)
                {
                    button.Text = "X";
                    turno = !turno;
                }
                else
                {
                    button.Text = "O";
                    turno = !turno;
                }
            }
        }

        private void ReloadEvent_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = ReloadGame.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = ReloadGame.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = ReloadGame.ScaleTo(1, 250);
                var fadeInAnimationTask = ReloadGame.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);
            });

            for (int i = 0; i < 9; i++)
            {
                btn1.Text = "";
                btn2.Text = "";
                btn3.Text = "";
                btn4.Text = "";
                btn5.Text = "";
                btn6.Text = "";
                btn7.Text = "";
                btn8.Text = "";
                btn9.Text = "";
            }
        }

        public ICommand ComoJogar
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.PushModalAsync(new ComoJogar());
                });
            }
        }

        private void TapGestureRecognizer_Tapped_(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = Instruncoes.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = Instruncoes.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = Instruncoes.ScaleTo(1, 250);
                var fadeInAnimationTask = Instruncoes.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }
    }
}