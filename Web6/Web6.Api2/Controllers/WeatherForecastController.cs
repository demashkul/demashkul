using Microsoft.AspNetCore.Mvc;
using System;
using Web6.Common.Dtos;
using Web6.Plugin.Abstracts;
using Web6.Send;

namespace Web6.Api2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOpenApi openApi;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMessageProducer messagePublisher,
            IOpenApi openApi)
        {
            _logger = logger;
            _messagePublisher = messagePublisher;
            this.openApi = openApi;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var message = new MessageDto
            {
                Title = "Baþlýk",
                Content = "Test",
                Via = "q1",
                Vias=Common.Enums.Vias.Op1

            };
            _messagePublisher.SendMessage(message);
            var message2 = new MessageDto
            {
                Title = "Baþlýk",
                Content = "Test",
                Via = "q2",
                Vias = Common.Enums.Vias.Op2

            };
            _messagePublisher.SendMessage(message2);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}