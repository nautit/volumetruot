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
        double y = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPanVolume(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    x_Volume.TranslationY = y + e.TotalY;
                    break;

                case GestureStatus.Completed:
                    y = x_Volume.TranslationY;
                    break;
            }
        }
    }
}
