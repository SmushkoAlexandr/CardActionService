﻿using System.Text.Json.Serialization;

namespace CardActionService.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardAction
    {
        ACTION1,
        ACTION2,
        ACTION3,
        ACTION4,
        ACTION5,
        ACTION6,
        ACTION7,
        ACTION8,
        ACTION9,
        ACTION10,
        ACTION11,
        ACTION12,
        ACTION13
    }
}
