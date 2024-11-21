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
using System.Speech.Synthesis;
using System.Speech.Recognition;
using Lego.Ev3.Core;

using Lego.Ev3.Desktop;



namespace voic_Recognetion_robot
{
    /// <summary>

        /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SpeechRecognitionEngine RecEngine = new SpeechRecognitionEngine();
        ////making the pc speak
        //SpeechSynthesizer ssynth = new SpeechSynthesizer();
        //PromptBuilder Pbuilder = new PromptBuilder();

        Brick _brick;



        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            if (manual_control.IsEnabled == false)
            {
                _brick = new Brick(new UsbCommunication());
                await _brick.ConnectAsync();
                await _brick.DirectCommand.PlayToneAsync(100, 1000, 300);
            }
            manual_control.IsEnabled = true;

            voice_control.IsEnabled = true;
        }

        private void manual_control_Click(object sender, RoutedEventArgs e)
        {

            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is manualcontrol)
                {
                    isOpen = true;
                    w.Activate();
                }
            }


            if (isOpen == false)
            {
                manualcontrol m = new manualcontrol(_brick);

                m.Show();
            }
        }

        private void voice_control_Click(object sender, RoutedEventArgs e)
        {

            bool isOpen = false;

            foreach (Window w in Application.Current.Windows)
            {
                if (w is voicecontrol)
                {
                    isOpen = true;
                    w.Activate();
                }
            }

            if (isOpen == false)
            {
                voicecontrol m = new voicecontrol(_brick);

                m.Show();
            }
          
        }

      
    }
}
