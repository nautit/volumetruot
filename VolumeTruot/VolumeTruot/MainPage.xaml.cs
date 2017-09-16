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
        static double volume = 0;
        static bool isChange = false;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnPanVolume(object sender, PanUpdatedEventArgs e)
        {
            
            switch (e.StatusType)
            {
                
                case GestureStatus.Started:
                    isChange = true;
                    Debug.WriteLine(isChange);
                    break;
                case GestureStatus.Running:
                    Debug.WriteLine(e.TotalY);
                    Debug.WriteLine(isChange);
                    if (isChange && Math.Abs(e.TotalY) > 1){
                        volume += e.TotalY;
                        isChange = false;
                        x_Volume.TranslateTo(0, volume, 100);
                    }    
                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Muc volume: " + volume);
                    break;
            }
                
            
            
            
            
        }
    }
}
