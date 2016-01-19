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
}
