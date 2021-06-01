using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string VideoClipFilePath { get; set; }
        private bool IsPlaying = false;
        private bool VolumeOn = true;
        /**
         * TO-DO: Add proper file filters.
         */
        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false };
            //openFileDialog.Filter = "Video Files (*.mp4; *.mvw)|*.mp4; *.mvw|";
            if (openFileDialog.ShowDialog() == true)
            {
                VideoClipFilePath = openFileDialog.FileName;
            }
            
            videoClip.Source = new Uri(VideoClipFilePath);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPlaying)
            {
                videoClip.Play();
                IsPlaying = true;
                PlayButton.Content = "Pause";
            }
            else
            {
                videoClip.Pause();
                IsPlaying = false;
                PlayButton.Content = "Play";
            }
        }
        private void PlayInputKeySpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!IsPlaying)
                {
                    videoClip.Play();
                    IsPlaying = true;
                    PlayButton.Content = "Pause";
                }
                else
                {
                    videoClip.Pause();
                    IsPlaying = false;
                    PlayButton.Content = "Play";
                }
            }
        }
        private void Forward10s_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan tenSeconds = new TimeSpan(0, 0, 10);
            videoClip.Position += tenSeconds;
        }
        private void Back10s_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan tenSeconds = new TimeSpan(0, 0, 10);
            videoClip.Position += tenSeconds;
        }

        private void VolumeOffButton_Click(object sender, RoutedEventArgs e)
        {
            if (VolumeOn)
            {
                videoClip.Volume = 0;
                VolumeOffButton.Content = "Volume Off";
                VolumeOn = false;
            }
            else
            {
                videoClip.Volume = 100;
                VolumeOffButton.Content = "Volume On";
                VolumeOn = true;
            }
        }
        /**
         * TO-DO: 
         * TimeCode. It should show time code of a video
         */
        
    }
}
