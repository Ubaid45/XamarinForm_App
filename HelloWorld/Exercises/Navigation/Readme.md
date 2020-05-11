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
