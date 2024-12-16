using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlyMyKeyClient.Domain.Entities
{
    public class UserData
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("avatarUrl")]
        public string? AvatarUrl { get; set; }
    }
}
