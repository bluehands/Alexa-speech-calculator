using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using Speech_Calculator.Controllers;

namespace SpeechCalculator.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : Controller
    {
        [HttpPost]
        [Route("Calc")]
        public ActionResult Calc()
        {
            //Get the ask message. bytes->json->SkillRequest

            //Get the request type

            //Handle the request

            //Return speech. ResponseBuilder.Tell
            return Ok();
        }

    }
}
