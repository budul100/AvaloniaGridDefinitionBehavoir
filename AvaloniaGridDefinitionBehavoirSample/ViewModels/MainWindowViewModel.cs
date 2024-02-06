using AvaloniaGridDefinitionBehavoirSample.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AvaloniaGridDefinitionBehavoirSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields

        private readonly object lockObject = new();

        private int columns;
        private int round;
        private int rows;

        #endregion Private Fields

        #region Public Constructors

        public MainWindowViewModel()
        {
            Task.Run(() => CreateGrid());
        }

        #endregion Public Constructors

        #region Public Properties

        public int Columns
        {
            get { return columns; }
            set { SetProperty(ref columns, value); }
        }

        public ObservableCollection<Element> Elements { get; } = new ObservableCollection<Element>();

        public int Rows
        {
            get { return rows; }
            set { SetProperty(ref rows, value); }
        }

        #endregion Public Properties

        #region Private Methods

        private void CreateGrid(int size)
        {
            round++;

            Elements.Clear();

            Columns = size;
            Rows = size;

            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    var element = new Element
                    {
                        Row = row,
                        Column = column,
                        Name = $"Round: {round} | R:{row} | C:{column}"
                    };

                    Elements.Add(element);
                }
            }
        }

        private void CreateGrid()
        {
            lock (lockObject)
            {
                var size = (int)(DateTime.Now.Ticks % 10);

                CreateGrid(size);
            }

            Task.Delay(3000).Wait();

            Task.Run(() => CreateGrid());
        }

        #endregion Private Methods
    }
}