namespace SensorsProject.Models
{
    public class Pump
    {
        public string Id { get; set; }
        public string ?pumpName { get; set; }
        public string ?pumpType { get; set; }
        public DateTime timeOn {  get; set; }
        public DateTime timeOff { get; set; }
    }
}
