using AvaloniaGridDefinitionBehavoirSample.Models;
using System.Collections.Generic;

namespace AvaloniaGridDefinitionBehavoirSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Public Constructors

        public MainWindowViewModel()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var element = new Element
                    {
                        Column = column,
                        Row = row,
                        Name = $"Row: {row} / Column: {column}"
                    };

                    Elements.Add(element);
                }
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public int Columns => 5;

        public List<Element> Elements { get; } = new List<Element>();

        public int Rows => 5;

        #endregion Public Properties
    }
}