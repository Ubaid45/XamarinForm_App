# Xamarin

## XAML vs Code-behind

- Everything you do with XAML, can be done with code. 
- At run-time, XAML parser will process our XAML files and instantiate C# objects. 
- We should aim to use XAML for defining the visual appearance of our apps, and use C# for implementing behaviour.

## Handling Events
**In XAML:**
```html
<Button Clicked=“Handle_Clicked” />
```
**In Code behind:**
```csharp
private void Handle_Clicked (object source, EventArgs e){}
```
