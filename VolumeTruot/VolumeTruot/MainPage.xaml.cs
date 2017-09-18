using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VolumeTruot
{
    public partial class MainPage : ContentPage
    {
        static double old_change,volume_min,volume_max,volume,volume_space = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void x_Volume_SizeChanged(object sender, EventArgs e)
        {
            volume_min -= x_Volume.Height;
            volume = volume_min;
            volume_space = volume_min / 41;
            Debug.WriteLine("........................................................" + volume_min);
            Debug.WriteLine("........................................................" + volume_max);
            x_Volume.TranslationY = volume_min;
        }

        private void x_thanhtruot_SizeChanged(object sender, EventArgs e)
        {
            volume_min = x_thanhtruot.Height;
        }
        

        private async void OnPanVolume(object sender, PanUpdatedEventArgs e)
        {
            
            switch (e.StatusType)
            {
                
                case GestureStatus.Running:
                    if ((Math.Abs(e.TotalY-old_change) > 3) && (Math.Abs(e.TotalY-old_change) < 40))
                    {
                        volume += e.TotalY;
                        
                        if (volume > volume_min) volume = volume_min;
                        if (volume < volume_max) volume = volume_max;
                        Debug.WriteLine("........................................................" + volume);
                        await x_Volume.TranslateTo(0, volume, 170, Easing.Linear);
                        
                    }
                    old_change = e.TotalY;
                    break;

                case GestureStatus.Completed:volume_space = volume / 41;
                    double du = volume % volume_space;
                    double real_volume = volume / volume_space;
                    if (du<real_volume/2)
                        x_value_Volume.Text = (41 - real_volume-du).ToString();
                    else
                        x_value_Volume.Text = (40 - real_volume - du).ToString();
                    break;
            }
        }
        
       
    }
}
