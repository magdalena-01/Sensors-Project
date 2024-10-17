namespace SensorsProject.Models.DataModels
{
    public class ECData 
    {
        public string? Id { get; set; } // Primary key
        public double Ec { get; set; }
        public DateTime Timestamp { get; set; }

        public string? EcSensorId { get; set; } // Foreign key to ECSensor
        public virtual ECSensor? ECSensor { get; set; }
    }
}
