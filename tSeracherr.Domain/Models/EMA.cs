namespace tSeracherr.Domain.Models
{
    public class EMA
    {
        public List<double> Input { get; set; } = new List<double>();
        public List<double> Value { get; set; } = new List<double>();
        public int Period { get; set; }
        public int CurrentBar { get; set; }

        public double Constant1 { get; set; }
        public double Constant2 { get; set; }
    }
}
