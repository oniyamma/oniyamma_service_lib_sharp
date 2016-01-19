using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oniyamma;

namespace Oniyamma
{
	/// <summary>
	/// Sample program using OniyammaService
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			Oniyamma.OniyammaService.Current.AddLog(new LogParameter() {
				Type = LogType.LEAVE_HOME,
				FilePath = "C:\\Hoge\\hoge.jpg",
				UserId = "569d08753846060c18fc9ef4"
			});
			Oniyamma.OniyammaService.Current.ApplyEmotion(new EmotionParameter()
			{
				Kiss = 2,
				Smile = 4
			});
			var weather = Oniyamma.OniyammaService.Current.GetWeather();
			Console.WriteLine(weather.Temperature.ToString());
		}
	}
}
