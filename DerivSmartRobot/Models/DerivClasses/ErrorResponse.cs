using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class ErrorResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}