using Microsoft.AspNetCore.Mvc;
using SensorsProject.Models.DataModels;
using SensorsProject.Models;

namespace SensorsProject.Models
{
    public class TempSensor : Sensor
    {
        public string ?Position { get; set; }
        public virtual TempData ?TempData { get; set; }

    }
}
