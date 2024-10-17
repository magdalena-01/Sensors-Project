using System.ComponentModel.DataAnnotations;

namespace SensorsProject.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }  // The time the measurement was taken

        [Required]
        public float Temperature { get; set; }  // Temperature reading

        [Required]
        public float SoilMoisture { get; set; }  // Soil moisture reading

        [Required]
        public float WaterUsage { get; set; }  // Water usage reading

        [Required]
        public bool IsSensorOn { get; set; }  // Indicates if the sensor is on or off
    }
}
