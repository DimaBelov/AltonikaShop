using System;
using System.IO;
using AltonikaShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class LogController : Controller
    {
        const string LOG_PATH = @"Logs\Frontend";

        [HttpPost]
        public void Log([FromBody] LogModel model)
        {
            if(model == null)
                throw new ArgumentNullException(nameof(model));

            if (!Directory.Exists(LOG_PATH))
                Directory.CreateDirectory(LOG_PATH);

            System.IO.File.AppendAllText(
                $@"{LOG_PATH}\log-{DateTime.Today:ddMMyyyy}.txt",
                $"{DateTime.Now}\n" +
                $"{model.Url}\n" +
                $"{model.Message}" +
                $"{model.StackTrace}\n\n");
        }
    }
}
