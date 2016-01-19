using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oniyamma
{
	/// <summary>
	/// Parameters of `AddLog` method.
	/// </summary>
	public class LogParameter
	{
		public LogType? Type;
		public string UserId;
		public string FilePath;
	}

	/// <summary>
	/// Parameters of `ApplyEmotionHue`
	/// </summary>
	public class EmotionParameter
	{
		public int? Kiss;
		public int? Smile;
		public int? MouthOpen;
		public int? EyesUp;
		public int? EyesDown;
		public int? EyesClosedLeft;
		public int? EyesClosedRight;
	}

	/// <summary>
	/// Informations of weather
	/// </summary>
	public class WeatherInfo
	{
		public float Temperature;
		public WeatherType Type;
	}

	/// <summary>
	/// Definition of Weather type
	/// </summary>
	public enum WeatherType
	{
		/// <summary>
		/// 晴れ
		/// </summary>
		SUNNY,

		/// <summary>
		/// 曇り
		/// </summary>
		CLOUDY,

		/// <summary>
		/// 雨
		/// </summary>
		RAINY,

		/// <summary>
		/// 雷
		/// </summary>
		THUNDERSTORM,

		/// <summary>
		/// 雪
		/// </summary>
		SNOW,

		/// <summary>
		/// 霧
		/// </summary>
		MIST,

		/// <summary>
		/// その他
		/// </summary>
		ANOTHER
	}

	/// <summary>
	/// Type for `AddLog` method
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// いってきます
		/// </summary>
		LEAVE_HOME,

		/// <summary>
		/// ただいま
		/// </summary>
		GO_HOME
	}
	
	/// <summary>
	/// Extends for LogType enum
	/// </summary>
	static class LogTypeExt
	{
		public static string DisplayName(this LogType type)
		{
			string[] names = { "leave_home", "go_home" };
			return names[(int)type];
		}
	}

	/// <summary>
	/// Interface of OniyammaService
	/// </summary>
	public interface IOniyammaService
	{
		/// <summary>
		/// Add log to server
		/// </summary>
		/// <param name="param"></param>
		/// <example>
		/// Oniyamma.OniyammaService.Current.AddLog(new LogParameter() {
		///		Type = LogType.GO,
		///		FilePath = "C:\\Hoge\\hoge.jpg",
		///		UserId = "569d08753846060c18fc9ef4"
		///	});
		/// </example>
		void AddLog(LogParameter param);

		/// <summary>
		/// Apply emotion value
		/// </summary>
		/// <param name="param"></param>
		/// <example>
		/// Oniyamma.OniyammaService.Current.ApplyEmotion(new EmotionParameter() {
		///		Kiss = 100,
		///		Smile = 50
		/// });
		/// </example>
		void ApplyEmotion(EmotionParameter param);

		/// <summary>
		/// Get weather info
		/// </summary>
		/// <example>
		/// var weatherInfo = Oniyamma.OniyammaService.Current.GetWeather();
		/// console.WriteLine(weatherInfo.Temperature.ToString());
		/// </example>
		/// <returns></returns>
		WeatherInfo GetWeather();
	}

	/// <summary>
	/// Oniyamma-web service
	/// </summary>
	public class OniyammaService : IOniyammaService
	{
		/// <summary>
		/// API's base url
		/// </summary>
		public const string API_BASE_URL = "http://localhost:3000";

		/// <summary>
		/// Rest client
		/// </summary>
		public RestClient client = new RestClient(API_BASE_URL);

		/// <summary>
		/// Shared instance
		/// </summary>
		private static IOniyammaService Instance;

		/// <summary>
		/// Get shared instance
		/// </summary>
		public static IOniyammaService Current
		{
			get
			{
				return Instance == null ? Instance = new OniyammaService() : Instance;
			}
		}

		/// <summary>
		/// Add log to server
		/// </summary>
		/// <param name="param"></param>
		public void AddLog(LogParameter param)
		{
			var request = new RestRequest("/api/v1/add_log", Method.GET);
			if (param.Type.HasValue)
				request.AddQueryParameter("type", LogTypeExt.DisplayName(param.Type.Value)); // adds to POST or URL querystring based on Method
			if (param.UserId != null)
				request.AddQueryParameter("user_id", param.UserId);
			if (param.FilePath != null)
				request.AddQueryParameter("file_path", param.FilePath);
			client.ExecuteAsync(request, response => 
			{
				// noop
			});
		}

		/// <summary>
		/// Apply emotion value
		/// </summary>
		public void ApplyEmotion(EmotionParameter param)
		{
			var request = new RestRequest("/api/v1/apply_emotion", Method.GET);
			if (param.Kiss.HasValue)
				request.AddQueryParameter("kiss", param.Kiss.Value.ToString());
			if (param.Smile.HasValue)
				request.AddQueryParameter("smile", param.Smile.Value.ToString());
			if (param.MouthOpen.HasValue)
				request.AddQueryParameter("mouse_open", param.MouthOpen.Value.ToString());
			if (param.EyesUp.HasValue)
				request.AddQueryParameter("eyes_up", param.EyesUp.Value.ToString());
			if (param.EyesDown.HasValue)
				request.AddQueryParameter("eyes_down", param.EyesDown.Value.ToString());
			if (param.EyesClosedLeft.HasValue)
				request.AddQueryParameter("eyes_closed_left", param.EyesClosedLeft.Value.ToString());
			if (param.EyesClosedRight.HasValue)
				request.AddQueryParameter("eyes_closed_right", param.EyesClosedRight.Value.ToString());
			// TODO: Call Api
		}

		/// <summary>
		/// Get weather info
		/// </summary>
		public WeatherInfo GetWeather()
		{
			var request = new RestRequest("/api/v1/get_weather", Method.GET);
			// var response = client.Execute(request);
			// TODO: Call Api
			// Return dummy info
			return new WeatherInfo()
			{
				Temperature = 2.4f,
				Type = WeatherType.SNOW
			};
		}

	}
}
