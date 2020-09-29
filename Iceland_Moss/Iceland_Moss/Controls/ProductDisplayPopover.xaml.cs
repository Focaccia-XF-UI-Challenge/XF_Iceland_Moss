using Iceland_Moss.Extensions;
using Iceland_Moss.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iceland_Moss.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDisplayPopover : ContentView
    {
        public ProductDisplayPopover()
        {
            InitializeComponent();
        }

        internal async Task Expand()
        {

            //[動畫]初始設定
            this.Opacity = 1;
            ProductPopoverGrid.Opacity = 0;
            btnAddToCart.ScaleX = 0;
            //[動畫]讓整個BoxView長出來
            BackgroundPannel.TranslationY = BackgroundPannel.Height;
            _ = BackgroundPannel.TranslateTo(0, 0, 200);
            //[動畫]所有 Detail 依序顯示
            _ = ProductPopoverGrid.FadeTo(1, 300);
            //[動畫]Button
            Animation animation = new Animation();
            animation.Add(0, 1,
                new Animation(t =>
                btnAddToCart.ScaleX = t, 0, 1, Easing.SpringOut));
            animation.Commit(this, "ButtonAnimation", 16, 800);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //Step1:GetParentPage
            //Step2:隱藏 PopOverPage
            ((MainPage)this.GetParentPage()).HidePopover();
        }

        private void DecreaseQuanitiy_Clicked(object sender, EventArgs e)
        {

        }

        private void IncreaseQuanitiy_Clicked(object sender, EventArgs e)
        {

        }
    }
}