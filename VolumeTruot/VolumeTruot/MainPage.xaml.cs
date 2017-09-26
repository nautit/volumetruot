using System;
using Xamarin.Forms;

namespace VolumeTruot
{
    public partial class MainPage : ContentPage
    {
        double UPPER_LIMIT, LOWER_LIMIT, VOLUME_STEP, BMT_STEP, vol_space, bass_space, middle_space, treble_space, volume,bass,middle,treble,temp,du = 0;

        private async void OnPanMiddle(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    temp = middle_space + e.TotalY;
                    if (temp < UPPER_LIMIT) temp = UPPER_LIMIT;
                    if (temp > LOWER_LIMIT) temp = LOWER_LIMIT;
                    await x_Middle.TranslateTo(0, temp);
                    du = temp % BMT_STEP;
                    middle = 14 - Math.Round((temp - du) / BMT_STEP);
                    x_value_Middle.Text = middle.ToString();
                    break;

                case GestureStatus.Completed:
                    middle_space = x_Middle.TranslationY;
                    break;
            }
        }

        private async void OnPanBass(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    temp = bass_space + e.TotalY;
                    if (temp < UPPER_LIMIT) temp = UPPER_LIMIT;
                    if (temp > LOWER_LIMIT) temp = LOWER_LIMIT;
                    await x_Bass.TranslateTo(0, temp);
                    du = temp % BMT_STEP;
                    bass = 14 - Math.Round((temp - du) / BMT_STEP);
                    x_value_Bass.Text = bass.ToString();
                    break;

                case GestureStatus.Completed:
                    bass_space = x_Bass.TranslationY;
                    break;
            }
        }

        private async void OnPanTreble(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    double temp = treble_space + e.TotalY;
                    if (temp < UPPER_LIMIT) temp = UPPER_LIMIT;
                    if (temp > LOWER_LIMIT) temp = LOWER_LIMIT;
                    await x_Treble.TranslateTo(0, temp);
                    double du = temp % BMT_STEP;
                    treble = 14 - Math.Round((temp - du) / BMT_STEP);
                    x_value_Treble.Text = treble.ToString();
                    break;

                case GestureStatus.Completed:
                    treble_space = x_Treble.TranslationY;
                    break;
            }
        }

        //khởi tạo giá trị ban đầu cho các cần chỉnh
        //Đưa các cần chỉnh về giá trị mặc định
        private void x_nuttruot_SizeChanged(object sender, EventArgs e)
        {
            //Khởi tạo
            UPPER_LIMIT = 0;
            LOWER_LIMIT = x_Thanhtruot.Height-x_Volume.Height;
            VOLUME_STEP = LOWER_LIMIT / 40;
            BMT_STEP = LOWER_LIMIT / 14;

            //Đưa về vị trí thấp nhất
            x_Volume.TranslationY = LOWER_LIMIT;
            x_Bass.TranslationY = LOWER_LIMIT;
            x_Middle.TranslationY = LOWER_LIMIT;
            x_Treble.TranslationY = LOWER_LIMIT;
            //Giá trị tạm
            vol_space = bass_space = middle_space = treble_space= LOWER_LIMIT;
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPanVolume(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    double temp = vol_space + e.TotalY;
                    if (temp < UPPER_LIMIT) temp = UPPER_LIMIT;
                    if (temp > LOWER_LIMIT) temp = LOWER_LIMIT;
                    await x_Volume.TranslateTo(0, temp);
                    double du = temp % VOLUME_STEP;
                    volume = 40 - Math.Round((temp - du) / VOLUME_STEP);
                    x_value_Volume.Text = volume.ToString();
                    break;

                case GestureStatus.Completed:
                    vol_space = x_Volume.TranslationY;
                    break;
            }
        }
    }
}
