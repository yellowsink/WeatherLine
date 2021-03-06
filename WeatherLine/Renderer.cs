using System;
using System.Text;

namespace WeatherLine
{
	public static class Renderer
	{
		public static string Render(this MetaWeather.ConsolidatedWeather weather)
		{
			var sb = new StringBuilder();

			sb.AppendSeparator($"{Icon(weather.WeatherAbbreviation)} {weather.WeatherState}");
			
			if (weather.Temp.HasValue)
				sb.AppendSeparator($"đĄ {Math.Round(weather.Temp.Value, 1)}Â°C / {Math.Round(1.8 * weather.Temp.Value + 32, 1)}Â°F");
			
			if (weather.High.HasValue && weather.Low.HasValue)
				sb.AppendSeparator($"â {Math.Round(weather.Low.Value, 1)}Â°C â {Math.Round(weather.High.Value, 1)}Â°C");
			
			if (weather.Visibility.HasValue)
				sb.AppendSeparator($"đ {Math.Round(weather.Visibility.Value, 1)}mi");

			if (weather.WindSpeed.HasValue)
				sb.AppendSeparator($"đ¨ {Math.Round(weather.WindSpeed.Value, 1)}mph đ§­ {weather.WindCompass}");
				
				
			return sb.ToString();
		}

		public static void AppendSeparator(this StringBuilder sb) => sb.Append("    ");

		public static void AppendSeparator(this StringBuilder sb, string str)
		{
			sb.Append(str); 
			sb.AppendSeparator();
		}

		public static string Icon(string abbr) 
			=> abbr switch
			{
				"sn" => "đ¨ī¸",
				"sl" => "đ¨ī¸",
				"h"  => "âī¸",
				"t"  => "đŠī¸",
				"hr" => "đ§ī¸",
				"lr" => "đĻī¸",
				"s"  => "đ§",
				"hc" => "âī¸",
				"lc" => "âī¸",
				"c"  => "âī¸",
				_    => throw new ArgumentOutOfRangeException(nameof(abbr), abbr, null)
			};
		
		public static class Colors
		{
			public const string Black   = "\u001b[30m";
			public const string Red     = "\u001b[31m";
			public const string Green   = "\u001b[32m";
			public const string Yellow  = "\u001b[33m";
			public const string Blue    = "\u001b[34m";
			public const string Magenta = "\u001b[35m";
			public const string Cyan    = "\u001b[36m";
			public const string White   = "\u001b[37m";
		}
	}
}