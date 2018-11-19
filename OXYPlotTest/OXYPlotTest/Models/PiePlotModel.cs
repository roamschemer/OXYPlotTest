using OxyPlot;
using OxyPlot.Series;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace OXYPlotTest.Models
{
    public class PiePlotModel : BindableBase
    {
        /// <summary>
        /// PlotModelのプロパティ
        /// </summary>
        public PlotModel PlotModel
        {
            get => plotModel;
            set => SetProperty(ref plotModel, value);
        }
        private PlotModel plotModel;

        /// <summary>
        /// 線の座標
        /// </summary>
        public ObservableCollection<PieSlice> PieSeriesList { get; private set; } = new ObservableCollection<PieSlice>();

        /// <summary>
        /// グラフのタイトル
        /// </summary>
        private string title;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">グラフタイトル</param>
        public PiePlotModel(string title)
        {
            this.title = title;
            PlotModel = new PlotModel();
        }

        /// <summary>
        /// ランダムに数字を与える(実験用)
        /// </summary>
        public void RandomPush()
        {
            var seed = Environment.TickCount;
            var rnd = new System.Random(seed);
            Push(rnd.Next(0, 100), rnd.Next(0, 10000));
        }

        /// <summary>
        /// 指定した数字を与える
        /// </summary>
        public void Push(double x, double y)
        {
            PieSeriesList.Add(new PieSlice("No" + x.ToString(), y));
        }

        /// <summary>
        /// グラフを更新
        /// </summary>
        public void Renewal()
        {
            var model = new PlotModel { Title = this.title };
            var pieSeries = new PieSeries() { StrokeThickness = 0.8, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 270 };
            foreach (var dp in PieSeriesList)
            {
                pieSeries.Slices.Add(dp);
            }
            model.Series.Add(pieSeries);
            model.InvalidatePlot(true);
            PlotModel = model; //グラフ情報をガッツリ代入
        }

    }
}
