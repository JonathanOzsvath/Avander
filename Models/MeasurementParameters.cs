namespace Avander.Models
{
    public class MeasurementParameters : QueryStringParameters
    {
        public string MeasurementPoint { get; set; }
        public string Vehicle { get; set; }
        public string Shop { get; set; }
        public string Dates { get; set; }
    }
}