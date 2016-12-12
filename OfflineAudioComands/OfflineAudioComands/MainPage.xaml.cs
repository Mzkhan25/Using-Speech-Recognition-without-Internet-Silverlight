using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OfflineAudioComands.Resources;
using Windows.Phone.Speech.Recognition;

namespace OfflineAudioComands
{
    public partial class MainPage : PhoneApplicationPage
    {
        SpeechRecognizer speechrecognizer;
       
        public MainPage()
        {
            InitializeComponent();
            speechrecognizer = new SpeechRecognizer();
            string[] commands = { "Hello", "This", "is", "easy"};

            speechrecognizer.Grammars.AddGrammarFromList("Commandset1", commands);
      
        }

      

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            speechrecognizer.Settings.InitialSilenceTimeout = TimeSpan.FromMinutes(1.00);
            SpeechRecognitionResult result = await speechrecognizer.RecognizeAsync();

            if (result.TextConfidence == SpeechRecognitionConfidence.High || result.TextConfidence == SpeechRecognitionConfidence.Medium || result.TextConfidence == SpeechRecognitionConfidence.Low)
            {
                try
                {
                    textbox.Text = result.Text;

                }
                catch (Exception ex)
                {

                }
            }
        }

    
    }
}