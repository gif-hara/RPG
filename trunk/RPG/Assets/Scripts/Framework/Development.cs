/*===========================================================================*/
/*
*     * FileName    : Development.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

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
			"[TODO:m]{0}",
			message
			)
		);
	}
}
