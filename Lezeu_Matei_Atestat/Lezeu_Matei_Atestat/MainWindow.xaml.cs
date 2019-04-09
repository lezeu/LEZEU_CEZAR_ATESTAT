using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Lezeu_Matei_Atestat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        AdditionalCode additionalCode = new AdditionalCode();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(tick);
            timer.Start();
            frame.Content = new Page1();
        }
        public void tick(object sender , EventArgs e)
        {
            //if(additionalCode.update == true)
            //{
            //    if(additionalCode.lvl ==1)
            //    {
            //        frame.Content = new Lvl1() ;
            //        additionalCode.update = false;
            //    }
            //}

        }
    }
}
