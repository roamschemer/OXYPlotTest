using OxyPlot;
using OxyPlot.Series;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OXYPlotTest.Models
{
    /// <summary>
    /// OXYPlotを使った線チャート
    /// </summary>
    public class LinePlotModel : BindableBase
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
        public ObservableCollection<DataPoint> dataPointList { get; private set; } = new ObservableCollection<DataPoint>();

        /// <summary>
        /// グラフのタイトル
        /// </summary>
        private string title;
        
        /// <summary>
        /// グラフの色
        /// </summary>
        private OxyColor lineColor;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">グラフタイトル</param>
        /// <param name="lineColor">グラフの色</param>
        public LinePlotModel(string title, OxyColor lineColor)
        {
            this.title = title;
            this.lineColor = lineColor;
            PlotModel = new PlotModel();
        }

        /// <summary>
        /// ランダムに数字を与える(実験用)
        /// </summary>
        public void RandomPush()
        {
            var seed = Environment.TickCount;
            var rnd = new System.Random(seed);
            Push(rnd.Next(0, 10000), rnd.Next(0, 10000));
        }

        /// <summary>
        /// 指定した数字を与える
        /// </summary>
        public void Push(double x,double y)
        {
            dataPointList.Add(new DataPoint(x, y));
        }

        /// <summary>
        /// グラフを更新
        /// </summary>
        public void Renewal()
        {
            var model = new PlotModel { Title = this.title };
            var lineSeries = new LineSeries() { Color = lineColor };
            foreach (var dp in dataPointList)
            {
                lineSeries.Points.Add(dp);
            }
            model.Series.Add(lineSeries);
            model.InvalidatePlot(true);
            PlotModel = model; //グラフ情報をガッツリ代入
        }

    }
}
