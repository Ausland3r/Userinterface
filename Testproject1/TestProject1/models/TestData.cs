using Newtonsoft.Json;

namespace TestProject1.Models
{
    public class TestData
    {
        [JsonProperty("startTime")]
        public string? StartTime { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        [JsonProperty("numberOfInterests")]
        public int InterestsNumber { get; set; }

        [JsonProperty("uploadAvatarScript")]
        public string? UploadAvatarScript { get; set; }

        [JsonProperty("passwordLength")]
        public int PasswordLength { get; set; }

        [JsonProperty("emailLength")]
        public int EmailLength { get; set; }

        [JsonProperty("domainLength")]
        public int DomainLength { get; set; }
    }
}
