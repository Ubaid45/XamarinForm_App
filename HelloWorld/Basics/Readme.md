# XAML Essenntials

## XAML vs Code-behind

- Everything we do with XAML, can be done with code. 
- At run-time, XAML parser will process our XAML files and instantiate C# objects. 
- We should aim to use XAML for defining the visual appearance of our apps, and use C# for implementing behaviour.

## Handling Events
### In XAML:
```html
<Button Clicked="Handle_Clicked" />
```
### In Code behind:
```csharp
private void Handle_Clicked (object source, EventArgs e){}
```
## Names
We use **x:Name** attribute to assign an identifier to an element. This will generate a private field that we can access in code-behind or XAML:
```html
<Slider x:Name="slider" />
```

## Property Element Syntax
We use property element syntax to assign complex objects to attributes.
```html
<ContentPage.Padding>    
   <OnPlatform x:TypeArguments="Thickness"
      iOS="0, 20, 0, 0"
      Android="0, 40, 0, 0" 
   />
</ContentPage.Padding>
```

## Content Property
Some XAML elements (eg **ContentPage** and **StackLayout**) have content property. That means, what we put between their start and end tags will be assigned to their content property. And with this, we don’t need to explicitly specify the content property. So, instead of
```html
<ContentPage>
  <ContentPage.Content>
    <Label />
  </ContentPage.Content>
</ContentPage> 
```
We can simply use
```html
<ContentPage>
  <Label />
</ContentPage> 
```
## Data Binding
```html
 <Label Text="{Binding
    Source={x:Reference slider},
    Path=Value,
    StringFormat='Value is {0:F2}'
 }" />
```
If we have multiple bindings to an object, we can simplify our binding expressions by setting **BindingContext**:
```html 
<Label BindingContext="{x:Reference slider}"
       Text="{Binding Value, StringFormat='Value is {0:F2}'}"
       Opacity="{Binding Value}" />
```
When **BindingContext** applied to a container element, it’ll be inherited by all its children. This is useful if we have multiple elements in a **StackLayout** (or a **ContentPage**) that reference the same object as their binding source.
```html 
<StackLayout BindingContext="{x:Reference slider}" HorizontalOptions="Center">
  <BoxView Color="Green" Opacity="{Binding Value}" />
  <Label
         Text="{Binding Value, StringFormat='Value is {0:F2}'}"
         Opacity="{Binding Value}" />
</StackLayout>
```
## Dealing with Device Differences
### In XAML:
To differentiate between various devices, we can use **OnPlatform** tag:
```html
 <ContentPage.Padding>
    <OnPlatform x:TypeArguments="Thickness">
        <On Platform="iOS">0,20,0,0</On>
    </OnPlatform>
</ContentPage.Padding>
```
### In Code:
We can use **Device.RuntimePlatform** method:
```csharp
switch(Device.RuntimePlatform)
{
    case Device.iOS:
      return new Thickness(5, 5, 5, 0);
    default:
      return new Thickness(5, 5, 5, 0);
}
```
