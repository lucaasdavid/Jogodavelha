using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGame : ContentPage
    {
        int rodadas = 1, placarXis = 0, placarO = 0, empate = 0;
        bool turno = true;

        public PageGame()
        {
            InitializeComponent();
            BindingContext = this;
        }

        #region BUTTONS EFFECT
        private void PlayEvent_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = Play.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = Play.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = Play.ScaleTo(1, 250);
                var fadeInAnimationTask = Play.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }

        private void InstrucEvent_Tapped(object sender, EventArgs e)
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

        public void ReloadEvent_Tapped(object sender, EventArgs e)
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

            rodadas = 1;
            RodadasN.Text = rodadas.ToString();
            placarXis *= 0;
            placarX.Text = placarXis.ToString();
            placarO *= 0;
            placarBola.Text = placarO.ToString();
            placar2.BorderColor = Color.FromHex("#ffae05");
            placar1.BorderColor = Color.FromHex("#ffae05");
            ResetaJogo();
        }
        #endregion

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


        public void button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (String.IsNullOrEmpty(button.Text))
            {
                if (turno)
                {
                    button.Text = "X";
                    turno = !turno;
                    placar2.BorderColor = Color.FromHex("#ffae05");
                    placar1.BorderColor = Color.Transparent;
                }
                else
                {
                    button.Text = "O";
                    turno = !turno;
                    placar1.BorderColor = Color.FromHex("#ffae05");
                    placar2.BorderColor = Color.Transparent;
                }
                empate++;
                ValidarGanhador();
            }
        }

        public void ValidarGanhador()
        {
            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && !string.IsNullOrWhiteSpace(btn1.Text)) // LINHA 1
            {
                QuemGanhou();
            }
            else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && !string.IsNullOrWhiteSpace(btn4.Text)) // LINHA 2
            {
                QuemGanhou();
            }
            else if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && !string.IsNullOrWhiteSpace(btn7.Text)) // LINHA 3
            {
                QuemGanhou();
            }
            else if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && !string.IsNullOrWhiteSpace(btn1.Text)) // COLUNA 1
            {
                QuemGanhou();
            }
            else if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && !string.IsNullOrWhiteSpace(btn2.Text)) // COLUNA 2
            {
                QuemGanhou();
            }
            else if ((btn3.Text == btn6.Text) && (btn6.Text == btn7.Text) && !string.IsNullOrWhiteSpace(btn3.Text)) // COLUNA 3
            {
                QuemGanhou();
            }
            else if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && !string.IsNullOrWhiteSpace(btn1.Text)) // DIAGONAL 1
            {
                QuemGanhou();
            }
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && !string.IsNullOrWhiteSpace(btn3.Text)) // DIAGONAL 2
            {
                QuemGanhou();
            } 
            else if (empate == 9)
            {
                ValidarEmpate();
                empate = 0;
                ResetaJogo();
            }
        }

        public void ResetaJogo()
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

        public void QuemGanhou()
        {
            if (turno)
            {
                empate = 0;
                rodadas++;
                placarO++;
                DisplayAlert("Rodada nº " + rodadas + " finalizada", "O ganhador da rodada foi o O", "ir para próxima");
                RodadasN.Text = rodadas.ToString();
                placarBola.Text = placarO.ToString();
                ResetaJogo();
            }
            if (!turno)
            {
                empate = 0;
                rodadas++;
                placarXis++;
                DisplayAlert("Rodada nº " + rodadas + " finalizada", "O ganhador da rodada foi o X", "ir para próxima");
                RodadasN.Text = rodadas.ToString();
                placarX.Text = placarXis.ToString();
                ResetaJogo();
            }
        }

        public void ValidarEmpate()
        {
            DisplayAlert("Rodada nº " + rodadas, "DEU VELHA!", "ir para próxima");
            rodadas++;
            RodadasN.Text = rodadas.ToString();
        }
    }
}