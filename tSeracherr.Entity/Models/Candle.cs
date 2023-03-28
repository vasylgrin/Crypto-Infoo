namespace tSeracherr.Entity.Models
{
    public sealed class Candle
    {
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }

        public Candle() { }
        public Candle(double open, double close, double high, double low)
        {
            if (open < 0)
                throw new ArgumentNullException(nameof(open), "Open cannot be less than zero.");
            if (close < 0)
                throw new ArgumentNullException(nameof(close), "Close cannot be less than zero.");
            if (high < 0)
                throw new ArgumentNullException(nameof(high), "High cannot be less than zero.");
            if (low < 0)
                throw new ArgumentNullException(nameof(low), "Low cannot be less than zero.");

            Open = open;
            Close = close;
            High = high;
            Low = low;
        }

        public bool Equals(Candle candle)
        {
            return candle != null
                && candle.Open == Open
                && candle.Close == Close
                && candle.High == High
                && candle.Low == Low;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Open, Close, High, Low);
        }
    }
}
