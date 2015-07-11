using UnityEngine;
using System.Collections.Generic;
using RPG.Framework;

/// <summary>
/// 開発で扱う関数群.
/// </summary>
public static class Development
{
	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void TODO( string message )
	{
		Debug.Log(
			string.Format(
			"{0}{1}",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.TODO ),
			message
			)
		);
	}
}
