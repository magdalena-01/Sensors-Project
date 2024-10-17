using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SensorsProject.Library;
using SensorsProject.Models;
using System.Diagnostics;
using System.IO.Ports;
using Microsoft.Extensions.Logging;

namespace SensorsProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SerialPortConnector _serialPortConnector;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _serialPortConnector = new SerialPortConnector();   
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OnOff()
        {
            return View();
        }

        /* public IActionResult Send(string command, string roomNumber)
         {
             // Validate input
             if (!int.TryParse(roomNumber, out int roomNum) || roomNum < 1 || roomNum > 3)
             {
                 return BadRequest("Invalid room number.");
             }


             try
             {
                 _serialPortConnector.Send(command + roomNumber); //if command is ON and roomNumber is 1, this becomes 1 which will turn on roomNumber 1 light 
                 return Ok("Successful.");
             }
             catch (Exception)
             { 
                 return BadRequest("Failed.");
             }
         }*/

        public IActionResult Send(string command, string roomNumber)
        {
            // Validate input for roomNumber
            if (!int.TryParse(roomNumber, out int roomNum) || roomNum < 1 || roomNum > 3)
            {
                return BadRequest("Invalid room number.");
            }

            // Ensure command is either "on" or "off"
            if (string.IsNullOrEmpty(command) || (command != "on" && command != "off"))
            {
                return BadRequest("Invalid command. Use 'on' or 'off'.");
            }

            try
            {
                // Prepare the message to send to Arduino
                string message = command + roomNumber; // e.g., "on1", "off2"
                _serialPortConnector.Send(message);
                return Ok("Successful.");
            }
            catch (IOException ex)
            {
                // Log exception details here for debugging
                return StatusCode(500, $"Failed to communicate with Arduino: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other exceptions
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
