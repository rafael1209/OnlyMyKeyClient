﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlyMyKeyClient.Domain.Entities
{
    public class UrlData
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
