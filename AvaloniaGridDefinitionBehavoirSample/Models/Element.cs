using AvaloniaGridDefinitionBehavoirSample.ViewModels;
using System.Collections.ObjectModel;

namespace AvaloniaGridDefinitionBehavoirSample.Models
{
    public class Element
    : ViewModelBase
    {
        #region Private Fields

        private int column;
        private int row;

        #endregion Private Fields

        #region Public Properties

        public int Column
        {
            get { return column; }
            set { SetProperty(ref column, value); }
        }

        public ObservableCollection<Element> Elements { get; } = new ObservableCollection<Element>();

        public string? Name { get; set; }

        public int Row
        {
            get { return row; }
            set { SetProperty(ref row, value); }
        }

        #endregion Public Properties
    }
}