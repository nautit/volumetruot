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
        static double old_change,volume_min,volume_max,volume,volume_step,volume_half_step = 0;
        static double BMT_step,BMT_half_step,bass,middle,treble = 0;

        private async void OnPanBass(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    old_change = 0;
                    break;
                case GestureStatus.Running:
                    if ((Math.Abs(e.TotalY - old_change) > 2) && (Math.Abs(e.TotalY - old_change) < 20))
                    {
                        bass += e.TotalY;
                        if (bass > volume_min) bass = volume_min;
                        if (bass < volume_max) bass = volume_max;
                        await x_Bass.TranslateTo(0, bass, 100, Easing.Linear);
                    }
                    old_change = e.TotalY;
                    break;

                case GestureStatus.Completed:
                    double bass_surplus = bass % BMT_step;//lấy phần dư
                    double bass_value = 14 - (bass - bass_surplus) / BMT_step;
                    if (bass_surplus > BMT_half_step)
                        bass_value += 1;
                    x_value_Bass.Text = bass_value.ToString();
                    break;
            }
        }

        private async void OnPanMiddle(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if ((Math.Abs(e.TotalY - old_change) > 3) && (Math.Abs(e.TotalY - old_change) < 20))
                    {
                        middle += e.TotalY;
                        if (middle > volume_min) middle = volume_min;
                        if (middle < volume_max) middle = volume_max;
                        await x_Middle.TranslateTo(0, middle, 200, Easing.Linear);
                    }
                    old_change = e.TotalY;
                    break;

                case GestureStatus.Completed:
                    double middle_surplus = middle % BMT_step;//lấy phần dư
                    double middle_value = 14 - (middle - middle_surplus) / BMT_step;
                    if (middle_surplus > BMT_half_step)
                        middle_value += 1;
                    x_value_Middle.Text = middle_value.ToString();
                    break;
            }
        }

        private async void OnPanTreble(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if ((Math.Abs(e.TotalY - old_change) > 3) && (Math.Abs(e.TotalY - old_change) < 20))
                    {
                        treble += e.TotalY;
                        if (treble > volume_min) treble = volume_min;
                        if (treble < volume_max) treble = volume_max;
                        await x_Treble.TranslateTo(0, treble, 200, Easing.Linear);
                    }
                    old_change = e.TotalY;
                    break;

                case GestureStatus.Completed:
                    double treble_surplus = treble % BMT_step;//lấy phần dư
                    double treble_value = 14 - (treble - treble_surplus) / BMT_step;
                    if (treble_surplus > BMT_half_step)
                        treble_value += 1;
                    x_value_Treble.Text = treble_value.ToString();
                    break;
            }
        }

        private void x_nuttruot_SizeChanged(object sender, EventArgs e)
        {
            volume_min -= x_Volume.Height;
            volume = volume_min;
            volume_step = volume_min / 40;
            volume_half_step = volume_step / 2;
            BMT_step = volume_min / 14;
            BMT_half_step = BMT_step / 2;
            x_Volume.TranslationY = x_Bass.TranslationY = x_Treble.TranslationY = x_Middle.TranslationY = volume_min;
        }

        
        public MainPage()
        {
            InitializeComponent();
        }

        private void x_thanhtruot_SizeChanged(object sender, EventArgs e)
        {
            volume_min = x_thanhtruot.Height;
        }
        
        private async void OnPanVolume(object sender, PanUpdatedEventArgs e)
        {
            
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    old_change = 0;
                    break;
                case GestureStatus.Running:
                    if (Math.Abs(e.TotalX) > 20) break;
                    if ((Math.Abs(e.TotalY-old_change) > 3) && (Math.Abs(e.TotalY-old_change) < 20))
                    {
                        volume += e.TotalY; 
                        if (volume > volume_min) volume = volume_min;
                        if (volume < volume_max) volume = volume_max;
                        await x_Volume.TranslateTo(0, volume, 100,Easing.Linear);
                    }
                    old_change = e.TotalY;
                    break;

                case GestureStatus.Completed:
                    double volume_surplus = volume % volume_step;//lấy phần dư
                    double volume_value = 40 - (volume - volume_surplus) / volume_step;
                    if (volume_surplus > volume_half_step)
                        volume_value += 1;
                    x_value_Volume.Text = volume_value.ToString();
                    break;
            }
        }
        
       
    }
}
