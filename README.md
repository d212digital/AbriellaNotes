# AbriellaNotes

Simple Note taking App built with WPF 

Sample Screenshot:

![screenshot](https://user-images.githubusercontent.com/33350634/189292355-39f56b24-258c-4e35-937c-0e0f87c467ab.png)


I've used Microsoft STT API endpoints using Azure and Microsoft.CognitiveServicesSpeechServices. To use it on your project, create an AI resource over on Azure, get your API Key, add your key to the SpeechButton_Click method in NotesWindow.xaml.cs build and click the speech button, dictate your note and it will auto update the note. It's brilliantly accurate. 

I have tried also creating it using the built in Windows SpeechRecognition Engine and whilst it works, it's nowhere near as accurate. 

```
public partial class NotesWindow : Window
    {
        SpeechRecognitionEngine recognizer;
        public NotesWindow()
        {
            InitializeComponent();

            var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
                                 where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                                 select r).FirstOrDefault();
            recognizer = new SpeechRecognitionEngine(currentCulture);

            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            Grammar grammaer = new Grammar(builder);

            recognizer.LoadGrammar(grammaer);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;

            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        bool isRecognizing = false;
        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRecognizing)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
            }
            else
            {
                recognizer.RecognizeAsyncStop();
                isRecognizing = false;
            }
}
