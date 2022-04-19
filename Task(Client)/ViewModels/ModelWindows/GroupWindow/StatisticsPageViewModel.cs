using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task_Client_.Models.Statistics_Grup;
using Task_Client_.ViewModels.Command;

namespace Task_Client_.ViewModels.ModelWindows.GroupWindow
{
    class StatisticsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SeriesCollection _SeriesCollection = new SeriesCollection();

        public SeriesCollection SeriesCollection
        {
            get { return _SeriesCollection; }
            set
            {
                _SeriesCollection = value;
            }
        }

        public List<string> _Labels = new List<string>();
        public List<string> Labels
        {
            get { return _Labels; }
            set
            {
                _Labels = value;
            }
        }

        public string _ShortStringList;
        public string ShortStringList
        {
            get { return _ShortStringList; }
            set
            {
                _ShortStringList = value;
            }
        }

        public ICommand BuildGraph
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    _SeriesCollection.Clear();
                    Statistics_Product randomSeries = new Statistics_Product();
                    SeriesCollection SeriesCollection = new SeriesCollection();
                    ChartValues<double> Points = new ChartValues<double>();
                    if (_ShortStringList == "0")
                    {
                        randomSeries.Genre_statistics_Count("Записи");
                        _SeriesCollection.AddRange(randomSeries.BuidChart("Записи"));
                        _Labels = randomSeries.masstype;
                    }
                    if (_ShortStringList == "1")
                    {
                        randomSeries.Genre_statistics_Count("Участники");
                        _SeriesCollection.AddRange(randomSeries.BuidChart("Участники"));
                        _Labels = randomSeries.masstype;
                    }
                    OnPropertyChanged("SeriesCollection");
                    OnPropertyChanged("Labels");
                });
            }
        }
    }
}
