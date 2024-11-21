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

using System.Speech.Synthesis;
using System.Speech.Recognition;
using Lego.Ev3.Core;

using Lego.Ev3.Desktop;
namespace voic_Recognetion_robot
{
    /// <summary>
    /// Interaction logic for voicecontrol.xaml
    /// </summary>
    public partial class voicecontrol : Window
    {
        SpeechRecognitionEngine RecEngine = new SpeechRecognitionEngine();
        //making the pc speak
        SpeechSynthesizer ssynth = new SpeechSynthesizer();
        PromptBuilder Pbuilder = new PromptBuilder();

        Brick _brick;
        bool issearch = false;
        public voicecontrol()
        {
            
            InitializeComponent();
        }
        public voicecontrol( Brick b )
        {
            _brick = b;
            InitializeComponent();
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Choices command = new Choices();
            command.Add(new string[] { " left", " right ", "  forward", "  back" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(command);
            Grammar grammer = new Grammar(gbuilder);
            RecEngine.LoadGrammarAsync(grammer);
            RecEngine.SetInputToDefaultAudioDevice();
            RecEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            RecEngine.SpeechRecognitionRejected += RecEngine_SpeechRecognitionRejected;


        }

        private void RecEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Pbuilder.ClearContent();
            Pbuilder.AppendText("rejected ");
            ssynth.Speak(Pbuilder);
        }
    
        private async void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

           
            if (e.Result.Text == "left")
            {
                Pbuilder.ClearContent();
                Pbuilder.AppendText("moving left");
                ssynth.Speak(Pbuilder);
                commands_txt.Text = " moving left";


                _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 50, 600, false);
                _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, -50, 600, false);

                await _brick.BatchCommand.SendCommandAsync();
                System.Threading.Thread.Sleep(1000);

                if (issearch == true)
                {
                    search();
                }
            }
            if (e.Result.Text == "right")
            {
                Pbuilder.ClearContent();
                Pbuilder.AppendText("moving right ");
                ssynth.Speak(Pbuilder);
                commands_txt.Text = " moving right  ";
                _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -50, 1000, false);
                _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 50, 1000, false);
                await _brick.BatchCommand.SendCommandAsync();
                System.Threading.Thread.Sleep(1000);

                if (issearch == true)
                {
                    search();
                }
            }

            if (e.Result.Text == "forward")
            {
                Pbuilder.ClearContent();
                Pbuilder.AppendText("moving forward");
                ssynth.Speak(Pbuilder);
                commands_txt.Text = "moving forward";
                await _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B | OutputPort.C, 25, 1000, false);
                System.Threading.Thread.Sleep(1000);

                if (issearch == true)
                {
                    search();
                }
            }

            if (e.Result.Text == "back")
            {
                Pbuilder.ClearContent();
                Pbuilder.AppendText("moving backward");
                ssynth.Speak(Pbuilder);
                commands_txt.Text = " moving backward ";
                await _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B | OutputPort.C, -25, 1000, true);
                System.Threading.Thread.Sleep(1000);

                if (issearch == true)
                {
                    search();
                }
            }
            commands_txt.Text = e.Result.Text;


        }

        private void start_voice_recogBtn_Click(object sender, RoutedEventArgs e)
        {
            stop_voice_recogBtn.IsEnabled = true;
            Pbuilder.ClearContent();
            Pbuilder.AppendText(" voice recognition system is activated ");
            ssynth.Speak(Pbuilder);
            RecEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnFreeDrive.IsEnabled = true;
        }
        private void stop_voice_recogBtn_Click(object sender, RoutedEventArgs e)
        {
            RecEngine.RecognizeAsyncStop();
            stop_voice_recogBtn.IsEnabled = false;
            btnFreeDrive.IsEnabled = false;
            stopbtnFreeDrive.IsEnabled = false;
        }
        private async void btnFreeDrive_Click(object sender, RoutedEventArgs e)
        {
            search();
            issearch = true;
            stopbtnFreeDrive.IsEnabled = true;
            btnFreeDrive.IsEnabled = false;

        }

        private void stopbtnFreeDrive_Click(object sender, RoutedEventArgs e)
        {
            btnFreeDrive.IsEnabled = true;
            stopbtnFreeDrive.IsEnabled = false;
            issearch = false;
        }

        private async void search()
        {



            float distance = _brick.Ports[InputPort.One].SIValue;
            while (distance > 20)
            {
                await _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B | OutputPort.C, 25, 1000, false);
                System.Threading.Thread.Sleep(1000);
                distance = _brick.Ports[InputPort.One].SIValue;


            }
            if (distance <= 10)
            {
                Pbuilder.ClearContent();
                Pbuilder.AppendText("obstacle ahead what do you want me to do ");
                ssynth.Speak(Pbuilder);
                commands_txt.Text = "obstacle ahead ";
                System.Threading.Thread.Sleep(1000);


            }

        }


        
    }
}
