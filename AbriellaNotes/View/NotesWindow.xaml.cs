using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
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
using System.Windows.Shapes;

namespace AbriellaNotes.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private async void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            string region = "uksouth";
            string key = "c95e75a911e64892bd6cf6db93744f2f";

            var speechConfig = SpeechConfig.FromSubscription(key, region);
            using (var audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using (var recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    var result = await recognizer.RecognizeOnceAsync();

                }
            }

        }

        private void ContentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int amountOfCharacters = (new TextRange(ContentRichTextBox.Document.ContentStart, ContentRichTextBox.Document.ContentEnd)).Text.Length;

            statusTextBlock.Text = $"Document Lenght: {amountOfCharacters}  characters";

        }

        private void Boldbutton_Click(object sender, RoutedEventArgs e)
        {

            ContentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);

        }
    }
}
