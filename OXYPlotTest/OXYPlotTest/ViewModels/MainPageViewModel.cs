using Prism.Navigation;

using Reactive.Bindings;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OXYPlotTest.Models;
using Reactive.Bindings.Extensions;
using System;

namespace OXYPlotTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //折れ線グラフ
        public ReactiveProperty<PlotModel> LineChart { get; private set; }
        public ReactiveCommand LinePushTapped { get; } = new ReactiveCommand();
        public LinePlotModel linePlotModel = new LinePlotModel("lineChert", OxyColors.Red);

        //円グラフ
        public ReactiveProperty<PlotModel> PieChart { get; private set; }
        public ReactiveCommand PiePushTapped { get; } = new ReactiveCommand();
        public PiePlotModel piePlotModel = new PiePlotModel("pieChert");

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //折れ線グラフ
            //VM←M
            LineChart = linePlotModel.ObserveProperty(x => x.PlotModel).ToReactiveProperty();
            //Button
            LinePushTapped.Subscribe(_ =>
            {
                linePlotModel.RandomPush();
                linePlotModel.Renewal();
            });

            //円グラフ
            //VM←M
            PieChart = piePlotModel.ObserveProperty(x => x.PlotModel).ToReactiveProperty();
            //Button
            PiePushTapped.Subscribe(_ =>
            {
                piePlotModel.RandomPush();
                piePlotModel.Renewal();
            });

        }

    }
}
