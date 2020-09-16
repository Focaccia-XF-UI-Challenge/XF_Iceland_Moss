using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iceland_Moss.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDisplay : ContentView
    {
        public ProductDisplay()
        {
            InitializeComponent();
        }


        public static readonly BindableProperty ImageOffsetYProperty =
            BindableProperty.Create(nameof(ImageOffsetY), typeof(int), typeof(ProductDisplay), 0);

        public static readonly BindableProperty ImageOffsetXProperty =
    BindableProperty.Create(nameof(ImageOffsetX), typeof(int), typeof(ProductDisplay), 0);


        public int ImageOffsetY
        {
            get => (int)GetValue(ImageOffsetYProperty);
            set => SetValue(ImageOffsetYProperty, value);
        }

        public int ImageOffsetX
        {
            get => (int)GetValue(ImageOffsetXProperty);
            set => SetValue(ImageOffsetXProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ImageOffsetYProperty.PropertyName)
                ProductImage.TranslationY = ImageOffsetY;

            if (propertyName == ImageOffsetYProperty.PropertyName)
                ProductImage.TranslationX = ImageOffsetX;
        }

        const uint animationSpeed = 500;

        internal async Task ExpanToFill(Rectangle bounds)
        {
            AddBackground.Opacity = .5;
            AddButton.Opacity = 1;
            NameLabel.Opacity = 1;
            PriceLabel.Opacity = 1;
            SortLabel.Opacity = 1;
            ProductImage.Scale = 1;
            //彈出來的時候維持原本的位置
            ProductImage.TranslationX = ImageOffsetX;
            ProductImage.TranslationY = ImageOffsetY;

            var destRect = new Rectangle(
             x: (bounds.Width / 2) - (this.Width / 2),
             y: 40,
             width: this.Width,
             height: this.Height);


            //todo [Learn] Part2 我不太懂這是幹嘛的 但不加入會報錯
            _ = AddBackground.FadeTo(0, animationSpeed / 2);
            _ = AddButton.FadeTo(0, animationSpeed / 2);
            _ = NameLabel.FadeTo(0, animationSpeed / 2);
            _ = PriceLabel.FadeTo(0, animationSpeed / 2);
            _ = SortLabel.FadeTo(0, animationSpeed / 2);

            _ = ProductImage.TranslateTo(0, ProductImage.TranslationY, animationSpeed * 2);

            await this.LayoutTo(destRect, (int)(animationSpeed * 1.5), Easing.SinInOut);

            _ = ProductImage.ScaleTo(1.1, animationSpeed * 2);
            _ = ProductImage.TranslateTo(0, 80, animationSpeed * 2);
            await this.LayoutTo(bounds.Inflate(50, 50), (int)(animationSpeed * 1.5), Easing.SinInOut);


        }
    }
}