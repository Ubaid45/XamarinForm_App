
# Beyond the basics

## Resource Dictionary
```html
<ContentPage.Resources>
    <ResourceDictionary>
        <x:Int32 x:Key="borderRadius">20</x:Int32>
        <x:String x:Key="...">...</x:String>        
        <Color x:Key="...">...</Color>
    </ResourceDictionary>
</ContentPage.Resources>
```
If resources need to be shared across multiple-pages, we should add them to the App.

To reference resources:
```html
<Button BorderRadius="{StaticResource borderRadius}" />
```
## Dynamic Resources 
If the value of the resource changes, the references get updated.
### In XAML:
```html
<Button BorderRadius="{DynamicResource borderRadius}" />
```
### In Code: 
```csharp
Resources["buttonBackgroundColor"] = Color.Red;
```

## Explicit Styles

```html
<ContentPage.Resources>
    <ResourceDictionary>
        <Style x:key="button" TargetType="Button">
             <Setter Property="BackgroundColor" Value="Gray" />
             ...
        </Style>
    </ResourceDictionary>
</ContentPage.Resources> 
```

### Using a style:
```html
<Button Style="{StaticResource button}" />
```

## Style Inheritance
```html
 <Style x:key="primaryButton" TargetType="Button"
     BasedOn="{StaticResource button}" />
```
## Implicit Styles
Remove the key. The style gets applied automatically based on TargetType:
```html
 <Style TargetType="Button">
    <Setter Property="BackgroundColor" Value="Gray" />
 </Style>
```
## Messaging Center
### In the publisher:
Remove the key. The style gets applied automatically based on TargetType:
```csharp
 MessagingCenter.Send(this, "SliderValueChanged", e.NewValue);
```
### In the subscriber:
```csharp
 MesagingCenter.Subscribe<TargetPage, double>
     (this, "SliderValueChanged", (source, arg) => { });
```
We can also unsubscribe (in the subscriber):
```csharp
 MessagingCenter.Unsubscribe<MainPage>
     (this, "SliderValueChanged");
```
## Accessing Common Mobile Device Functionality
Details are well documented on:
[http://github.com/xamarin/XamarinComponents](http://github.com/xamarin/XamarinComponents)
