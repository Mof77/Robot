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
using Lego.Ev3.Core;

using Lego.Ev3.Desktop;


namespace voic_Recognetion_robot
{
    /// <summary>
    /// Interaction logic for manualcontrol.xaml
    /// </summary>
    public partial class manualcontrol : Window

    {

        Brick _brick;
       


        public manualcontrol()
        {
            InitializeComponent();
        }
        public manualcontrol(Brick  b )
        {
            _brick = b;
            InitializeComponent();
        }



        private async void forward_btn_Click_1(object sender, RoutedEventArgs e)
        {
            await _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B | OutputPort.C, 25, 1000, false);

        }

        private async void right_btn_Click_1(object sender, RoutedEventArgs e)
        {



            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -50, 1000, false);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 50, 1000, false);
            await _brick.BatchCommand.SendCommandAsync();


        }

        private async void left_btn_Click_1(object sender, RoutedEventArgs e)
        {

            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 60, 600, false);
            _brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, -50, 600, false);
            await _brick.BatchCommand.SendCommandAsync();
        }

        private async void backward_btn_Click_1(object sender, RoutedEventArgs e)
        {
            await _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B | OutputPort.C, -25, 1000, true);

        }
    }
}
