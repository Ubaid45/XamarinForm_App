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
