using Avalonia.Controls;

namespace AvaloniaGridDefinitionBehavoirSample.Views
{
    public partial class MainWindow : Window
    {
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();

            var gridItem = this
                .FindControl<ItemsControl>("Grid");
        }

        #endregion Public Constructors
    }
}