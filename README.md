# AvaloniaGridDefinitionBehavoir

This behavior allows the adjustment of the RowDefinitions / ColumnDefinitions of Avalonia Grids. It was inspired by a [blog entry by Rachel Lim](https://rachel53461.wordpress.com/2011/09/17/wpf-grids-rowcolumn-count-properties/). This approach was initially shown for WPF Grids.

## Useage

The following code ...

```
<Grid>
	<Grid.RowDefinitions>
		<RowDefinition Height="Auto" />
		<RowDefinition Height="Auto" />
		<RowDefinition Height="Auto" />
		<RowDefinition Height="Auto" />
	</Grid.RowDefinitions>
	<Grid.ColumnDefinitions>
		<ColumnDefinition Width="Auto" />
		<ColumnDefinition Width="Auto" />
	</Grid.ColumnDefinitions>
</Grid>
```

... can be defined as follows:

```
<Grid
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.RowCount="4"
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.ColumnCount="2">
</Grid>
```

Definitions with stars must be set additionally by using regular expressions. The following output ...

```
<Grid>
	<Grid.RowDefinitions>
		<RowDefinition Height="Auto" />
		<RowDefinition Height="*" />
		<RowDefinition Height="Auto" />
		<RowDefinition Height="*" />
	</Grid.RowDefinitions>
	<Grid.ColumnDefinitions>
		<ColumnDefinition Width="*" />
		<ColumnDefinition Width="*" />
	</Grid.ColumnDefinitions>
</Grid>
```

... can be defined as follows:

```
<Grid
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.RowCount="4"
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.ColumnCount="2"
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.StarRows="\d*[13579]"
	avaloniaGridDefinitionBehavoir:GridDefinitionBehavior.StarColumns=".*">
</Grid>
```

The definitions can also be bound onto the view models. The following can be seen in the [sample data](./AvaloniaGridDefinitionBehavoirSample/Views/MainWindow.axaml.cs).

```
<ItemsControl
	x:DataType="vm:MainWindowViewModel"
	DockPanel.Dock="Top"
	ItemsSource="{Binding Elements}">

	<ItemsControl.ItemsPanel>
		<ItemsPanelTemplate>
			<Grid
				HorizontalAlignment="Stretch"
				VerticalAlignment="Stretch"
				gridbehavior:GridDefinitionBehavior.ColumnCount="{Binding Columns}"
				gridbehavior:GridDefinitionBehavior.RowCount="{Binding Rows}"
				ShowGridLines="True" />
		</ItemsPanelTemplate>
	</ItemsControl.ItemsPanel>

	<ItemsControl.Styles>
		<Style x:DataType="md:Element" Selector="ItemsControl > ContentPresenter">
			<Setter Property="Grid.Row" Value="{Binding Row}" />
			<Setter Property="Grid.Column" Value="{Binding Column}" />
		</Style>
	</ItemsControl.Styles>

	<ItemsControl.ItemTemplate>
		<DataTemplate x:DataType="md:Element">
			<TextBlock Margin="10" Text="{Binding Name}" />
		</DataTemplate>
	</ItemsControl.ItemTemplate>
</ItemsControl>
```