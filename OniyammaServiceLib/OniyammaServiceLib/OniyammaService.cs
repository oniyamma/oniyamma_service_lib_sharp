using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oniyamma
{
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
		public WeatherInfo GetWeather(WeatherType dummyType = WeatherType.SUNNY)
		{
			var request = new RestRequest("/api/v1/get_weather", Method.GET);
			// var response = client.Execute(request);
			// TODO: Call Api
			// Return dummy info
			Random rnd = new Random();
			return new WeatherInfo()
			{
				Temperature = (float)Math.Round(rnd.Next(1, 20) + rnd.NextDouble(), 1),
				Type = dummyType
			};
		}

	}
}
