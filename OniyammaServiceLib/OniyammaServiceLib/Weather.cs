using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oniyamma
{
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
}
