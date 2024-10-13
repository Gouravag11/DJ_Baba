using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Animation;


namespace DJ_Baba
{
    public partial class DJBabaActivity : Window
    {
        public DJBabaActivity()
        {
            InitializeComponent();
            this.Closed += DJBabaActivity_Closed;
        }

        private void DJBabaActivity_Closed(object sender, EventArgs e)
        {
            // Reopen MainWindow when DJBabaActivity is closed
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void LoadInput1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files|*.mp4;*.mp3;*.wav;*.avi;*.mkv";
            if (openFileDialog.ShowDialog() == true)
            {
                InputMedia1.Source = new Uri(openFileDialog.FileName);
                InputMedia1.Play();
            }
        }

        private void LoadInput2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files|*.mp4;*.mp3;*.wav;*.avi;*.mkv";
            if (openFileDialog.ShowDialog() == true)
            {
                InputMedia2.Source = new Uri(openFileDialog.FileName);
                InputMedia2.Play();
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (InputMedia1.Source != null)
            {
                InputMedia1.Play();
            }

            if (InputMedia2.Source != null)
            {
                InputMedia2.Play();
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (InputMedia1.Source != null)
            {
                InputMedia1.Pause();
            }

            if (InputMedia2.Source != null)
            {
                InputMedia2.Pause();
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (InputMedia1.Source != null)
            {
                InputMedia1.Stop();
            }

            if (InputMedia2.Source != null)
            {
                InputMedia2.Stop();
            }
        }

        private void FadeToPause_Click(object sender, RoutedEventArgs e)
        {
            FadeOut(InputMedia1);
            FadeOut(InputMedia2);
        }

        private void FadeToPlay_Click(object sender, RoutedEventArgs e)
        {
            FadeIn(InputMedia1);
            FadeIn(InputMedia2);
        }


        private void FadeOut(MediaElement mediaElement)
        {
            if (mediaElement.Source != null)
            {
                var fadeOut = new System.Windows.Media.Animation.DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(2)
                };
                mediaElement.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                mediaElement.Pause();
            }
        }

        private void FadeIn(MediaElement mediaElement)
        {
            if (mediaElement.Source != null)
            {
                var fadeIn = new System.Windows.Media.Animation.DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(2)
                };
                mediaElement.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                mediaElement.Play();
            }
        }
    }
}