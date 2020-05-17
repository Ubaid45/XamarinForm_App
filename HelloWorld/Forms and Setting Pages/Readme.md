# Forms and Settings

## Switch 
For capturing a boolean value.
```html
<Switch IsToggled="true" Toggled="..." />
```
## Slider and Stepper

**Slider**: a double between 0 and 1 (by default).
```html
<Slider Maximum="255" Minimum="10" Value="50" ValueChanged="..." />
```
**Stepper**: an integer between 0 and 100 (by default).
```html
<Stepper Increment="5" /> 
```

## Entry and Editor
**Entry** for capturing one line of text, **Editor** for capturing multiple lines.
```html
<Entry Keyboard="..." Placeholder="Phone" IsPassword="true"
      Completed="..." TextChanged="..." />

<Editor />
```
## Picker
For allowing the user to select from a short list of items. Prefer to use picker with navigation technique.
### In XAML:
```html
<Picker>
   <Picker.ItemsSource>
      <x:String>...</x:String>
      <x:String>...</x:String>
   </Picker.ItemsSource>
</Picker>
```
### In code-behind:
```csharp
foreach (var str in list)
     picker.Items.Add(str);
```

## Date and Time Picker
To notify UI about changes in the state of an object:
```html
<DatePicker Date="..." MinimumDate="..." MaximumDate="..."
       Format="d MMM yyyy" DateSelected="..." />

<TimePicker Time="13:00" Format="..." />
```

## Referencing static members in XAML 
```html
<ContentPage xmlns:sys="clr-namespace:System;assembly=mscorlib">
    <DatePicker Date="{x:Static sys:DateTime.Today}" />
</ContentPage>
```
## TableView
```html
<TableView Intent="Form">
    <TableRoot>
        <TableSection Title="Section1">
            ... (one or more cells)
        </TableSection>
    </TableRoot>
</TableView>
```
### Cell types:
- TextCell
- ImageCell
- EntryCell
- SwitchCell
- ViewCell (for implementing custom cells)
```html
<TextCell Text="..." Detail="..." />
<EntryCell Label="Title" Placeholder="(eg shopping)" />
<SwitchCell Text="Notifications" On="true" OnChanged="..." />
```
## Bindable Properties
```csharp
public class DateCell: ViewCell {

	public static readonly BindableProperty LabelProperty = 
               BindableProperty.Create(
                  "Label",
                  typeof(string),
                  typeof(DateCell));

	public string Label {
		get {
			return (string) GetValue(LabelProperty);
		}
		set {
			SetValue(LabelProperty, value);
		}
	}
}
```
## Picker with Navigation
### In XAML:
```html
<ViewCell Tapped="Handle_Tapped">
     <StackLayout>
         <Label ... />
         <Label x:Name="contactMethod" ... />
     </StackLayout>
</ViewCell>
```
### In code-behind: 
```csharp
void Handle_Tapped(...) {

	var page = new ContactMethodsPage();

	page.ContactMethods.ItemSelected += (source, args) = >
        {
		contactMethod.Text = args.SelectedItem.ToString();
		Navigation.PopAsync();
	};

	Navigation.PushAsync(page);
}
```
This requires exposing the ListView in ContactDetails page via a public property.
