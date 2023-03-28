using LiveCharts;
using LiveCharts.Defaults;

namespace tSeracher.Domain.ModelDomain
{
    public class CandleDomainModel
    {
        public ChartValues<ObservableValue> ChartValuesObseravableCollection1 { get; set; } = new();
        public ChartValues<ObservableValue> ChartValuesObseravableCollection2 { get; set; } = new();
        public ChartValues<OhlcPoint> ChartValuesOhlcPoint { get; set; } = new();
    }
}
