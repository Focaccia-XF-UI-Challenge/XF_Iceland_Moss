using Iceland_Moss.ViewModels;
using Prism.Navigation;
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

        enum States
        {
            SearchExpanded,
            SearchHidden
        }

        public MainPage()
        {
            InitializeComponent();
        }
        private int animationSpeed = 1000;
        const int margin = 20;
        Storyboard _storyboard = new Storyboard();


        protected override void OnAppearing()
        {
            base.OnAppearing();
            SizeChanged += MainPage_SizeChanged;
            scrollContainer.Scrolled += ScrollContainer_Scrolled;
        }



        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SizeChanged -= MainPage_SizeChanged;
            scrollContainer.Scrolled -= ScrollContainer_Scrolled;
        }

        private async void ScrollContainer_Scrolled(object sender, ScrolledEventArgs e)
        {
            if ((e.ScrollY > 0) && (CurrentState != States.SearchHidden))
            {
                _storyboard.Go(States.SearchHidden);
                CurrentState = States.SearchHidden;
                scrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                scrollContainer.IsEnabled = true;
            }
            else if ((e.ScrollY == 0) && (CurrentState != States.SearchExpanded))
            {
                _storyboard.Go(States.SearchExpanded);
                CurrentState = States.SearchExpanded;
                scrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                scrollContainer.IsEnabled = true;
            }
        }


        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _storyboard = new Storyboard();
            var width = this.Width;
            var height = this.Height;

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

            Rectangle searchRectCollapsed = new Rectangle(
               x: icon購物.Bounds.Left - (margin + icon設定.Width + margin + icon查詢.Width),
               y: margin,
               width: icon查詢.Width,
               height: icon查詢.Height);

            Rectangle searchBackGroundCollapsed = new Rectangle(
             x: icon購物.Bounds.Left - (margin + icon設定.Width + margin + icon查詢.Width),
                y: margin,
                width: icon設定.Width,
                height: icon設定.Height);
            #endregion

            #region 設定區塊
            Rectangle settingRect = new Rectangle(
              x: this.Width - (icon設定.Width + margin),
              y: 200,
              width: icon設定.Width,
              height: icon設定.Height);
            AbsoluteLayout.SetLayoutBounds(icon設定, settingRect);

            Rectangle settingRectCollapsed = new Rectangle(
                x: icon購物.Bounds.Left - (margin + icon設定.Width),
                y: margin,
                width: icon設定.Width,
                height: icon設定.Height);
            #endregion

            //可捲動的區塊
            Rectangle scrollContainerRect = new Rectangle(
             x: margin,
             y: icon查詢.Bounds.Bottom + margin,
             width: width - (2 * margin),
             height: height - (icon查詢.Bounds.Bottom + margin));
            AbsoluteLayout.SetLayoutBounds(scrollContainer, scrollContainerRect);


            Rectangle scrollContainerRectCollapsed = new Rectangle(
            x: margin,
            y: margin + icon購物.Height + margin,
            width: width - (2 * margin),
            height: height - (margin + icon購物.Height + margin));
            AbsoluteLayout.SetLayoutBounds(scrollContainer, scrollContainerRect);

            //方塊的排序
            //if (width > height)
            //    flexLayoutProducts.Direction = FlexDirection.Row;
            //else
            //    flexLayoutProducts.Direction = FlexDirection.Column;

            //設定畫面元件定位
            _storyboard.Add(States.SearchExpanded, new[]
           {
                new ViewTransition(Header, AnimationType.Opacity,1),
                new ViewTransition(SearchEntry, AnimationType.Opacity,1),
                new ViewTransition(icon設定, AnimationType.Layout, settingRect),
                new ViewTransition(icon查詢, AnimationType.Layout, searchRect),
                new ViewTransition(boxView查詢, AnimationType.Layout, searchBackGroundRect),
                 new ViewTransition(scrollContainer, AnimationType.Layout, scrollContainerRect)

            });

            _storyboard.Add(States.SearchHidden, new[]
            {
                     new ViewTransition(Header, AnimationType.Opacity,0.01),
                new ViewTransition(SearchEntry, AnimationType.Opacity,0.01),
                new ViewTransition(icon設定, AnimationType.Layout, settingRectCollapsed),
                new ViewTransition(icon查詢, AnimationType.Layout, searchRectCollapsed),
                new ViewTransition(boxView查詢, AnimationType.Layout, searchBackGroundCollapsed),
                 new ViewTransition(scrollContainer, AnimationType.Layout, scrollContainerRectCollapsed)
            });

        }

       

        /// <summary>
        /// 當畫面大小改變時(Part2 會報錯所以搬到 MainPage_SizeChanged 寫了)
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }


        States CurrentState = States.SearchExpanded;

        private void HambuergerButton_Clicked(object sender, EventArgs e)
        {
            States newState;
            if (CurrentState == States.SearchExpanded)
                newState = States.SearchHidden;
            else
                newState = States.SearchExpanded;

            _storyboard.Go(newState);

            CurrentState = newState;
        }

        //https://youtu.be/-m1Q29s2lhs?t=7847
    }
}