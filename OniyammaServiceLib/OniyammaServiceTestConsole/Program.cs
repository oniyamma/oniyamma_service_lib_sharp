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
				FilePath = @"C:\Hoge\hoge.jpg",
				UserId = "56a2e232af1841280d9f1061"
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
