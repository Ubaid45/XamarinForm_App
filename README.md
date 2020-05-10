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
# Images

## Image Sources

- Images can be platform-independent (e.g. backgrounds) and can be downloaded using a URI or embedded in the PCL (to ship with the app).
- Or, they can be platform-specific (e.g. icons). They should be added to each application project.
- Image.Source is of type ImageSource, which is an abstract class. Its derivates are **UriImageSource, ResourceImageSource** and **FileImageSource**. 

## Downloading Images
### In XAML:  
Caching is enabled by default.
```html
<Image Source="http://..." />
```
### In Code:
Useful for disabling caching or overriding validity period. 
```csharp
image.Source = new UriImageSource {
    Uri = new Uri("http://..."),
    CachingEnabled = false,
    CacheValidity = TimeSpan.FromHours(1)
 };
```
## Embedding Images
Add to PCL and set the Build Action to **EmbeddedResource**.
### In XAML:
Create a custom markup extension:
```csharp
public class EmbeddedImage : IMarkupExtension { ... } 
```
```html
<ContentPage
   xmlns:local="clr-namespace:HelloWorld;assembly=HelloWorld">

    <Image Source="{local:EmbeddedImage ResourceId}"/>
```
### In Code: 
```csharp
image.Source = ImageSource.FromResource("...resourceId...");
```

## Platform-specific Images
Add to each application project. 
### iOS
- Resources/clock.png
- Resources/clock@2x.png
- Resources/clock@3x.png2

### Android
- Resources/drawable/clock.png
- Resources/drawable-hdpi/clock.png
- Resources/drawable-xhdpi/clock.png
- Resources/drawable-xxhdpi/clock.png

### In XAML:
```html
<Image Source="clock.png" />
```

### In Code:
```csharp
image.Source = ImageSource.FromFile("clock.png");
```

## Image Aspects
- **AspectFit** (default): image is scaled to fit the container. 
- **AspectFill**: image is cropped to fill the container.
- **Fill**: image fills the container but it can get distorted

## Activity Indicator
```html
 <ActivityIndicator
     Color="White"
     IsRunning="{Binding
                   Source={x:Reference image},
                   Path=IsLoading}" />
```
# Lists

## A Basic List

### In XAML:  
```html
<ListView x:Name="listView" /> 
```
### In Code:
```csharp
listView.ItemsSource = new List<string> { ... };
```
## Cell Types
- TextCell
- ImageCell
```html
<ListView>
   <ListView.ItemTemplate>
       <DataTemplate>
           <TextCell Text="{Binding Name}"
                      Detail="{Binding Status}" />
       </DataTemplate>
   </ListView.ItemTemplate>
</ListView>
```
## Custom Cells 
```html
<DataTemplate>
     <ViewCell>
        <StackLayout>...</StackLayout>
     </ViewCell>
</DataTemplate>
```

## Grouping Items

### In XAML:
```html
<ListView
     IsGroupingEnabled="true"
     GroupDisplayBinding="{Binding Title}"
    GroupShortNameBinding="{Binding ShortTitle}" /> 
```

### In Code:
```csharp
listView.ItemsSource = new List<ContactGroup> {
     new ContactGroup("A", "A")
     {
           new Contact { ... }
     }
 }
```

## Handling Selections
```html
 <ListView ItemTapped="..." ItemSelected="...">
```

## Context Actions
```html
 <TextCell>
     <TextCell.ContextActions>
           <MenuItem Text="Call" Clicked="..."
              CommandParameter="{Binding .}" />          
           <MenuItem Text="Delete" Clicked="..."
              IsDestructive="true" />
     </TextCell.ContextActions>
</TextCell>
```

## Pull to Refresh
```html
 <ListView IsPullToRefreshEnabled="true" Refreshing="..."> 
```
```csharp
 listView.EndRefresh();
```
## Search Bar
```html
 <SearchBar Placeholder="Search..." TextChanged="..." />
```
# Navigation

## Hierarchical Navigation

### App:  
```csharp
MainPage = new NavigationPage(new WelcomePage());
```
### WelcomePage:
```csharp
await Navigation.PushAsync(new IntroductionPage());
```
### IntroductionPage:
```csharp
await Navigation.PopAsync();
```
## Navigation Bar
### Setting the title
```html
<ContentPage Title="Welcome">
```
### Hiding the navigation bar
```html
<ContentPage NavigationPage.HasNavigationBar="false">
```
### Changing the colors
```csharp
MainPage = new NavigationPage(new WelcomePage()) {
    BarBackgroundColor = Color.Gray,
    BarTextColor = Color.White
 }
```
### Hiding the back button
```html
<ContentPage NavigationPage.HasBackButton="false">
```
### Disabling the physical back button on Android and Windows:
```csharp
protected override bool OnBackButtonPressed(){
    return true;
 }
```
## Modal Pages

```csharp
await Navigation.PushModalAsync(new IntroductionPage());
await Navigation.PopModalAsync();
```

## Master Detail 
```html
<MasterDetailPage IsPresented="true">
    <MasterDetailPage.Master>
        <ContentPage Title="Contacts">
            ... add a list view
        </ContentPage>
    </MasterDetailPage>
    <MasterDetailPage.Detail>
      <ContentPage />
    </MasterDetailPage.Detail>
</MasterDetailPage>
```

```csharp
async void Handle_ItemSelected(...){
     var contact = e.SelectedItem as Contact;
     Detail = new NavigationPage(new DetailPage(contact));
     IsPresented = false;
 } 
```

## Handling Selections
```html
 <ListView ItemTapped="..." ItemSelected="...">
```

## Context Actions
```html
 <TextCell>
     <TextCell.ContextActions>
           <MenuItem Text="Call" Clicked="..."
              CommandParameter="{Binding .}" />          
           <MenuItem Text="Delete" Clicked="..."
              IsDestructive="true" />
     </TextCell.ContextActions>
</TextCell>
```

## Tabbed Page
```html
<TabbedPage ...
    xmlns:local="clr-namespace:HelloWorld">
    <local:ConctactsPage Title="..." Icon="..." />
    <ContentPage Title="..." Icon="...">...</ContentPage>
    <NavigationPage Title="..." Icon="...">
      <x:Arguments>
         <ContentPage>...</ContentPage>
      </x:Arguments>
    </NavigationPage>
</TabbedPage>
```

## CarouselPage 
```html
<CarouselPage ...
    xmlns:local="clr-namespace:HelloWorld">
    <local:ConctactsPage Title="..." Icon="..." />
    <ContentPage Title="..." Icon="...">...</ContentPage>
</CarouselPage> 
```

## Displaying Popups
### Alerts
```csharp
var confirmation = await DisplayAlert(...);
if (confirmation) ...
```
### Action Sheets
```csharp
var response = await DisplayActionSheet(...);
```
## Toolbar Items
```html
<ContentPage>
    <ContentPage.ToolbarItems>
         <ToolbarItem Icon="..." Activated="..." />
    </ContentPage.ToolbarItems>
</ContentPage> 
```
