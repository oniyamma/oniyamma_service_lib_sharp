using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oniyamma
{
	/// <summary>
	/// Interface of OniyammaService
	/// </summary>
	public interface IOniyammaService
	{
		/// <summary>
		/// Initialize OniyammaService
		/// </summary>
		/// <param name="apiBaseUrl"></param>
		void Init(string apiBaseUrl = "http://localhost:3000");

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
		WeatherInfo GetWeather(WeatherType dummyType = WeatherType.SUNNY);
	}
}
