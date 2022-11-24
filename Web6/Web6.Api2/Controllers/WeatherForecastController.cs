using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Web6.Common.Confs;
using Web6.Common.Dtos;
using Web6.Data.Entities;
using Web6.Plugin.Abstracts;
using Web6.Send;
using Web6.Service.Abstracts;

namespace Web6.Api2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"  };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOpenApi openApi;
        private readonly SaloonsConf saloonsConf;
        private readonly IStudentService studentService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMessageProducer messagePublisher,
            IOpenApi openApi,
            IOptions<SaloonsConf> saloonsConf
,
            IStudentService studentService)
        {
            _logger = logger;
            _messagePublisher = messagePublisher;
            this.openApi = openApi;
            this.saloonsConf = saloonsConf.Value;
            this.studentService = studentService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var result =await studentService.GetAsync(p => p.Address == "");
            //var message = new MessageDto
            //{
            //    Title = "Baþlýk",
            //    Content = "Test",
            //    Via = "q1",
            //    Vias=Common.Enums.Vias.Op1

            //};
            //_messagePublisher.SendMessage(message);
            //var message2 = new MessageDto
            //{
            //    Title = "Baþlýk",
            //    Content = "Test",
            //    Via = "q2",
            //    Vias = Common.Enums.Vias.Op2

            //};
            //_messagePublisher.SendMessage(message2);

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