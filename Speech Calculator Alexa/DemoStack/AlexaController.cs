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
    public class AlexaDemoController : Controller
    {
        [HttpPost]
        [Route("Calc")]
        public ActionResult Calc()
        {
            var content = Request.Body.ReadAll();
            var jsonContent = Encoding.UTF8.GetString(content);
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<SkillRequest>(jsonContent);
            var speech = "Das habe ich leider nicht verstanden.";

            var requestType = request.GetRequestType();
            if (requestType == typeof(IntentRequest))
            {
                speech = HandleIntentRequest(request.Request as IntentRequest);
            }
            else if (requestType == typeof(LaunchRequest))
            {
                speech = HandleLaunchRequest(request.Request as LaunchRequest);
            }

            var response = ResponseBuilder.Tell(new Alexa.NET.Response.PlainTextOutputSpeech() { Text = speech });
            return Ok(response);
        }

        private string HandleLaunchRequest(LaunchRequest launchRequest)
        {
            return "Willkommen beim Taschenrechner. Hier kannst Du beliebige Zahlen addieren.";
        }

        private string HandleIntentRequest(IntentRequest intentRequest)
        {
            switch (intentRequest.Intent.Name)
            {
                case "Add":
                    return HandleAddIntentRequest(intentRequest);
                default:
                    return "Upps, das kann ich nicht";
            }
        }

        private string HandleAddIntentRequest(IntentRequest intentRequest)
        {
            var firstSlot = intentRequest.Intent.Slots["first"];
            var secondSlot = intentRequest.Intent.Slots["second"];
            var firstNumber = double.Parse(firstSlot.Value, CultureInfo.InvariantCulture);
            var secondNumber = double.Parse(secondSlot.Value, CultureInfo.InvariantCulture);

            var result = $"{firstNumber} plus {secondNumber} macht {firstNumber + secondNumber}";
            return result;
        }
    }
}
