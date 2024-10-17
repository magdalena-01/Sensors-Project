namespace SensorsProject.Models.DataModels
{
    public class PhData 
    {
        public int Id { get; set; } // Primary key
        public double Ph { get; set; }
        public DateTime Timestamp { get; set; }

        public string ?PhSensorId { get; set; } // Foreign key to PhSensor
        public virtual PhSensor? PhSensor { get; set; }
    }
}
