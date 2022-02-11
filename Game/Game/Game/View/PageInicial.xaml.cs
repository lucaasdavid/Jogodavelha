using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInicial : ContentPage
    {
        public PageInicial()
        {
            InitializeComponent();
            BindingContext = this;
        }

        #region EFEITOS BUTTON
        // Button SINGLEPLAYER
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = SinglePLayer.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = SinglePLayer.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = SinglePLayer.ScaleTo(1, 250);
                var fadeInAnimationTask = SinglePLayer.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }
        
        // Button MULTIPLAYER
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = MULTIPLAYER.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = MULTIPLAYER.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = MULTIPLAYER.ScaleTo(1, 250);
                var fadeInAnimationTask = MULTIPLAYER.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);
            });
        }

        // Button FACEBOOK
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = Facebook.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = Facebook.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = Facebook.ScaleTo(1, 250);
                var fadeInAnimationTask = Facebook.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }

        // Button SOUND
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = Sound.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = Sound.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = Sound.ScaleTo(1, 250);
                var fadeInAnimationTask = Sound.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }

        // Button SETTINGS
        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Task<bool> scaleUpAnimationTask = settings.ScaleTo(1.09, 250);
                var fadeOutAnimationTask = settings.FadeTo(1.0, 250);

                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);
                var scaleDownAnimationTask = settings.ScaleTo(1, 250);
                var fadeInAnimationTask = settings.FadeTo(1, 250);

                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

            });
        }
        #endregion

        #region COMMAND DE NAVEGAÇÃO
       
        public ICommand Multiplayer
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.PushModalAsync(new PageGame());
                });
            }
        }
        #endregion
    }
}