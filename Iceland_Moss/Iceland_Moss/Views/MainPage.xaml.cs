using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Iceland_Moss.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    SizeChanged += MainPage_SizeChanged;
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    SizeChanged -= MainPage_SizeChanged;
        //}

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
        }


        const int margin = 20;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //

            //購物車
            Rectangle baskedRect = new Rectangle(
                x: width - (icon購物.Width + margin),
                y: margin,
                width: icon購物.Width,
                height: icon購物.Height);

            AbsoluteLayout.SetLayoutBounds(icon購物, baskedRect);


            #region 查詢區塊
            Rectangle searchRect = new Rectangle(
              x: margin,
              y: 200,
              width: icon查詢.Width,
              height: icon查詢.Height);

            AbsoluteLayout.SetLayoutBounds(icon查詢, searchRect);

            Rectangle searchBackGroundRect = new Rectangle(
              x: margin,
              y: 200,
              width: icon設定.Bounds.X - (margin + margin),
              height: boxView查詢.Height);

            AbsoluteLayout.SetLayoutBounds(boxView查詢, searchBackGroundRect);
            #endregion

            //設定區塊
            Rectangle settingRect = new Rectangle(
              x: width - (icon設定.Width + margin),
              y: 200,
              width: icon設定.Width,
              height: icon設定.Height);

            AbsoluteLayout.SetLayoutBounds(icon設定, settingRect);

            //可捲動的區塊
            Rectangle scrollContainerRect = new Rectangle(
             x: margin,
             y: icon查詢.Bounds.Bottom + margin,
             width: width - (2 * margin),
             height: height - (icon查詢.Bounds.Bottom + margin));

            AbsoluteLayout.SetLayoutBounds(scrollContainer, scrollContainerRect);
        }

    }
}