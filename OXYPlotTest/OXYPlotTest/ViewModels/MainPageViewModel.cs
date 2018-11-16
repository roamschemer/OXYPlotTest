using Prism.Navigation;

using Reactive.Bindings;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;


namespace OXYPlotTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ReactiveProperty<PlotModel> GraphModel { get; private set; } = new ReactiveProperty<PlotModel>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GraphPlot();
        }

        private void GraphPlot()
        {
            var model = new PlotModel { Title = "LineChart" };

            var X_line = new LineSeries();
            X_line.Color = OxyColors.Red;
            X_line.Points.Add(new DataPoint(0, 0));
            X_line.Points.Add(new DataPoint(1, 4));
            X_line.Points.Add(new DataPoint(2, 1));
            X_line.Points.Add(new DataPoint(3, 3));
            model.Series.Add(X_line);

            // グラフの要素を画面に反映する
            model.InvalidatePlot(true);
            GraphModel.Value = model;
        }
    }
}
