using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlyMyKeyClient.Domain.Entities
{
    public class PasswordData
    {
        [JsonPropertyName("login")]
        public string? Login { get; set; }
        [JsonPropertyName("encryptedPassword")]
        public string? EncryptedPassword { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
