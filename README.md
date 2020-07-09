# XF_Iceland_Moss

跟著 KymPillpotts 實作 XamairnFormsUI Challenge

---

[TOC]

## 有使用到的套件:

1. Prism.DryIoc.Forms
2. Xamarin.Forms.PancakeView

---

## 使用到的特殊技巧

### (Part1)

- [1.Converter](#Converter)
- [2.Google Fonts](#GoogleFonts)
- 3.[FlexLayout](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/user-interface/layouts/flex-layout) + [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)

### (Part2)

- 4.畫面翻轉寬度調整(OnSizeAllocated)
  - 只要畫面改變都會觸發的事件
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
![Test](D:\simon\XF_Challenge\Prism_Iceland_Moss\readme\Test.png) public class BoolToStringConverter : IValueConverter
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