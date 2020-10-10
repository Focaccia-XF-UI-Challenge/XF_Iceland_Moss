# XF_Iceland_Moss

跟著 KymPillpotts 實作 XamairnFormsUI Challenge

---

[TOC]

## 有使用到的套件:

1. Prism.DryIoc.Forms
2. Xamarin.Forms.PancakeView
   - 用來畫方塊
3. [Resizetizer.NT](#Resizetizer.NT)
4. [com.ptdave.xamarin](#com.ptdave.xamarin)
5. SkiaSharp.Views.Forms
   - 用來畫 麵包屑

---

## 使用到的特殊技巧

### (Part1)

- [1.Converter](#Converter)
- [2.Google Fonts](#GoogleFonts)
- 3.[FlexLayout](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/user-interface/layouts/flex-layout) + [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)

### (Part2)

- 4.畫面翻轉寬度調整(OnSizeAllocated)
  
  - 只要畫面改變都會觸發的事件
  - 異動為寫在OnAppearing SizeChanged中(因為會出現錯誤訊息好像是個不太好的寫法所以改掉了)
  
- [5.Storyboard](#Storyboard)

  

### (Part4)

- 6.加入了一個PopOverPage

- 7.小技巧:每次都要記得如果元件是可重複使用的記得包出來變成一個元件，可參考 InfoPanel.xaml

  - 加入了Snippet:bprop

  - 建立了 1.Title 2.TitleIcon 3. Value 可綁定的屬性使用起來就真的比較簡潔

  - ```xaml
    <controls:InfoPanel
                        Title="Humidity"
                        Grid.Column="0"
                        TitleIcon="{Static fas:FontAwesomeIcons.Subscript}"
                        Value="50-75%" />
    <controls:InfoPanel
                        Title="Light"
                        Grid.Column="1"
                        TitleIcon="{Static fas:FontAwesomeIcons.Sun}"
                        Value="5K - 10K lux" />
    
    <controls:InfoPanel
                        Title="Temperature"
                        Grid.Column="2"
                        TitleIcon="{Static fas:FontAwesomeIcons.TemperatureHigh}"
                        Value="18 - 27 °C" />
    ```

- 8.彈出ProductDisplayPopover.xaml 頁面後使用返回鍵要關閉頁面，但物件是在ParenPage定義的所以加入了 ViewExtension.cs

- 9.技巧 非同步 

  - 可以使用  Task.WhenAll 確定所有都完成再做別的事情

    ```c#
    internal async void HidePopover()
            {
                //Fade Out(慢慢透明) 元件
                await Task.WhenAll(
                    new Task[]
                    {
                        FakeProduct.FadeTo(0),
                        PagePopover.FadeTo(0)
                    });
    
                //確定都透明了再做別的事
                //1.隱藏假的產品
                FakeProduct.IsVisible = false;
                //2.隱藏Popupover
                PagePopover.IsVisible = false;
            }
    ```


### (Part5)

------

- 技巧 : Content頁面建立event供MainPage呼叫。

- [52:51] 時出現UI相關比較難理解的狀況，因為這一整塊都可以觸發點擊的事件 ，當 右上方+號新增了自己的事件後卻不會觸發，這邊的解法是 針對這個大區塊 加入  屬性    CascadeInputTransparent="True"  &     InputTransparent="True"  這段有點難理解

  

![MEMO_1](D:\simon\XF_Challenge\Prism_Iceland_Moss\readme\MEMO_1.png)

- [02:07:51] 使用 SkiaSharp 畫出 麵包屑

  可以使用 [SkiaSharp Fiddle](https://github.com/mattleibow/SkiaSharpFiddle )  加速開發 不然每次都要停止再重新編譯才會看到結果(好物😎)

- [02:41:08]刪除購物車內的項目使用 Command 的方式刪除但這邊的寫法跟之前使用的不太一樣要再研究

  ```xaml
  <Label
    Grid.Column="4" Text="x" HorizontalOptions="Center" Style="{StaticResource ShoppingCartItemLable}">
    <Label.GestureRecognizers>
        <TapGestureRecognizer 
            Command="{Binding Source={RelativeSource AncestorType={x:Type vm:MainPageViewModel}}, 
                      Path=RemoveItemCommand}" 
            CommandParameter="{Binding .}" />
    </Label.GestureRecognizers>
  </Label>
  ```

  

#### Converter

---

建立了一個 class 透過輸入 True or False 讓圖片變高或變短

(這真的是需要去學習的項目可參考➡ [Xamarin.Forms.Converter](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/data-binding/converters))

- 設定:

```xaml
 <converters:BoolToStringConverter
                x:Key="FeatureHeightConverter"
                FalseString="170"
                TrueString="240" />
```

- 本專案實作出來的範例(BoolToStringConverter.cs):

```c#
 public class BoolToStringConverter : IValueConverter
 {
        public string TrueString { get; set; }
        public string FalseString { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return TrueString;
            else
                return FalseString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
 }
```

- 實際使用

這裡只針對高度去作綁定

```xaml
<pancake:PancakeView
            Margin="10"
            BackgroundColor="{Binding HeroColor}"
            CornerRadius="20"
            HeightRequest="{Binding IsFeatured, Converter={StaticResource FeatureHeightConverter}}"
            WidthRequest="160">
</pancake:PancakeView>
```



#### GoogleFonts

---



<img src="readme\Test.png" alt="替代文字" style="zoom:50%;" />



#### Storyboard

---

參考 章節  Part2  [53:50]

畫面上方的圖示動畫移動都是靠這個方法執行的

#### Resizetizer.NT

---

參考資料: [Resizetizer.NT]( https://www.youtube.com/watch?v=zcUPh5cVWaE&amp;amp;feature=youtu.be )

放圖片很方便的工具不需要每次都把圖片一個一個塞到各個平台的專案，也不需要分大小。

- 安裝套件(All)
- 設定圖片屬性(F4)- 建置動作 改為SharedImaged
- 發行完可以在obj\resizetizer\看到圖片



#### com.ptdave.xamarin

---

透過這個套件使用 Font awesome 

可以使用的平台

- Android

- UWP(version:16299)

  

或是可以直接加入一個FontAwesomeIcons.cs 自己呼叫也是可以的(不會有UWP版本的問題)

可以參考文章[Font Awesome](https://medium.com/@tsjdevapps/use-fontawesome-in-a-xamarin-forms-app-2edf25311db4)

注意! 於App.xaml

```xaml
 <On Platform="UWP" Value="/Assets/FontAwesome5Brands.otf#Font Awesome 5 free" />
```

#後面一定要這樣寫不然會顯示不出來