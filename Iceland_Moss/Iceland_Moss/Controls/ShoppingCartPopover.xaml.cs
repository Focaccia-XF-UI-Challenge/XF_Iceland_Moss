using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iceland_Moss.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCartPopover : ContentView
    {
        public ShoppingCartPopover()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
        }

        /// <summary>
        /// 畫出麵包屑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            //參考  https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/user-interface/graphics/skiasharp/basics/integration
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();


            SKPaint 畫布 = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Xamarin.Forms.Color.FromHex("75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true,
            };


            SKPaint 填滿圓圈畫布 = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = Xamarin.Forms.Color.FromHex("75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true,
            };

            SKPaint 虛線畫布 = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Xamarin.Forms.Color.FromHex("75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true,
                PathEffect = SKPathEffect.CreateDash(new float[] { 30, 10 }, 0)
            };

            float margion = 30;
            float radius = 15;
            float linePadding = 120;

            //畫實圓圈
            canvas.DrawCircle(new SKPoint(margion, info.Height / 2), radius, 填滿圓圈畫布);
            canvas.DrawCircle(new SKPoint(margion, info.Height / 2), radius * 2, 畫布);
            //畫實線
            canvas.DrawLine(
                new SKPoint(linePadding, info.Height / 2),
                new SKPoint(info.Width / 2 - linePadding / 2, info.Height / 2),
                畫布
                );

            //畫虛圓圈
            canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), radius, 畫布);
            canvas.DrawCircle(new SKPoint(info.Width - margion, info.Height / 2), radius, 畫布);

            //畫虛線
            canvas.DrawLine(
              new SKPoint(info.Width / 2 + linePadding / 2, info.Height / 2),
              new SKPoint(info.Width - linePadding, info.Height / 2),
              虛線畫布
              );
        }
    }
}