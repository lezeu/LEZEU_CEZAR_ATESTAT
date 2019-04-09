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
using System.Windows.Threading;

namespace Lezeu_Matei_Atestat
{
    /// <summary>
    /// Interaction logic for Lvl1.xaml
    /// </summary>
    public partial class Lvl1 : Page
    {
        DispatcherTimer timer = new DispatcherTimer();


        public Lvl1()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
        private void timer_tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.A))
            {
                
                if(Canvas.GetLeft(om)>0)
                {
                    Canvas.SetLeft(om, Canvas.GetLeft(om) - 4);
                }
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (Canvas.GetTop(om) > 0)
                {
                    Canvas.SetTop(om, Canvas.GetTop(om) - 4);
                }
                    
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (Canvas.GetLeft(om) + om.Width < 1200)
                {
                    Canvas.SetLeft(om, Canvas.GetLeft(om) + 4);
                }
                    
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (Canvas.GetTop(om) + om.Height < 1000)
                {
                    Canvas.SetTop(om, Canvas.GetTop(om) + 4);
                }

            }

        }
    }
}
