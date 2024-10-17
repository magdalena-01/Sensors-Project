using SensorsProject.Models.DataModels;

namespace SensorsProject.Models
{
    public class PhSensor : Sensor
    {
        public string? Position { get; set; }
        public virtual ICollection<PhData> PhData { get; set; } = new List<PhData>();
    }
}
