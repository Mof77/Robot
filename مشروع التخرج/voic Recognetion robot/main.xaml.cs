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
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        Brick _brick;

        public main()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            _brick = new Brick(new UsbCommunication());
            _brick.BrickChanged += _brick_BrickChanged;
            await _brick.ConnectAsync();
            await _brick.DirectCommand.PlayToneAsync(100, 1000, 300);


        }

        private void _brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
        }
    }
}
