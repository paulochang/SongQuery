using System;

namespace Genius.SDK
{
    public class Configuration
    {
        public Uri BaseUri { get; set; } = new Uri("https://api.genius.com");
        public TimeSpan TimeOut { get; set; } = TimeSpan.FromSeconds(90);
    }
}