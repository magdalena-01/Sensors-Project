using SensorsProject.Models.DataModels;

namespace SensorsProject.Models
{
    public class ECSensor : Sensor
    {
        public string? Position { get; set; }
        public virtual ICollection<ECData> ECData { get; set; } = new List<ECData>();

    }
}
