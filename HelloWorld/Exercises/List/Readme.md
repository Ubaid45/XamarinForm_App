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
