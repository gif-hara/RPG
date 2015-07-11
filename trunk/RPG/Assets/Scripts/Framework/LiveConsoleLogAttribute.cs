using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Framework
{
	/// <summary>
	/// LiveConsole用のログ属性を管理するクラス.
	/// </summary>
	public static class LiveConsoleLogAttribute
	{
		public enum Attribute : int
		{
			Message,
			TODO,
			Debug,
		}
		public static string Get( Attribute attribute )
		{
			string[] result =
			{
				"[Message:b]",
				"[TODO:m]",
				"[Debug:y]",
			};
			
			return result[(int)attribute];
		}
	}
}
