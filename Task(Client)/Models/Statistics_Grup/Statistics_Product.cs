using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.Views.GroupWindowsViews.Model;
using Task_Data_.Entities;

namespace Task_Client_.Models.Statistics_Grup
{
    class Statistics_Product
    {
        ActionsGroups actionsGroups = new();
        public List<string> masstype = new();
        public List<double> masscount = new();

        public void Genre_statistics_Count(string _type)
        {
            if (_type == "Записи")
            {
                List<tgroups_post> posts = actionsGroups.GetPost(new List<string> { UserNow.groups.ToString(), "10" });
                int index = -1;
                if (posts != null)
                {
                    foreach (tgroups_post post in posts)
                    {
                        index = masstype.IndexOf(post.user.ToString());
                        if (index != -1)
                        {
                            masscount[index]++;
                        }
                        else
                        {
                            masstype.Add(post.user.ToString());
                            masscount.Add(1);
                        }
                        index = -1;
                    }
                    foreach (members_group type in UserNow.userMass)
                    {
                        index = masstype.IndexOf(type.id.ToString());
                        if (index != -1)
                        {
                            masstype[index] = type.surname;
                        }
                        index = -1;
                    }
                }
            }
            if(_type == "Участники")
            {
                var typeChek = DateTime.Now.AddMonths(-1);
                var typeMass = DateTime.UtcNow.Subtract(typeChek);
                for (int i = 0; i < typeMass.Days; i++)
                {
                    masstype.Add(typeChek.Day.ToString() + "." + typeChek.Month.ToString() + "." + typeChek.Year.ToString());
                    masscount.Add(0);
                    typeChek = typeChek.AddDays(1);
                }
                foreach (members_group type in UserNow.userMass)
                {
                    DateTime pDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(type.date);
                    DateTime NewDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    var result = NewDate.Subtract(pDate);
                    if (DateTime.DaysInMonth(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month) > result.Days)
                    {
                        masscount[pDate.Day]++;
                    }
                }
            }
        }

        public LineSeries GenerateSeries(string title)
        {
            ChartValues<ObservablePoint> series = new ChartValues<ObservablePoint>();
            for (int i = 0; i < masscount.Count; i++)
            {
                if (masscount[i] != 0)
                {
                    series.Add(new ObservablePoint(i, masscount[i]));
                }
            }
            var testSeries = new LineSeries
            {
                Title = title,
                Values = series,
                PointGeometry = DefaultGeometries.Square,
                PointGeometrySize = 10
            };
            return testSeries;
        }

        public SeriesCollection Series { get; private set; }
        public SeriesCollection BuidChart(string title)
        {
            Random randomSeries = new Random();

            Series = new SeriesCollection
            {
                GenerateSeries(title)
            };
            return Series;
        }
    }
}
