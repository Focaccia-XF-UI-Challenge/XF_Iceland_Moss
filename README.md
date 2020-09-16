# XF_Iceland_Moss

跟著 KymPillpotts 實作 XamairnFormsUI Challenge

---

[TOC]

## 有使用到的套件:

1. Prism.DryIoc.Forms
2. Xamarin.Forms.PancakeView
   - 用來畫方塊
3. [Resizetizer.NT](#Resizetizer.NT)

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





