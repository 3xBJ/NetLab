﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Assignee
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }
    }
}
