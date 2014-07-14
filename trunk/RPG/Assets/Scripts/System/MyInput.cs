/*===========================================================================*/
/*
*     * FileName    : MyInput.cs
*
*     * Description : 入力処理オーバーライド.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Common

{
	/// <summary>
	/// 入力処理オーバーライド.
	/// </summary>
	public static class MyInput
	{
		public static bool Left
		{
			get
			{
				return Input.GetKeyDown( KeyCode.LeftArrow );
			}
		}
		public static bool Right
		{
			get
			{
				return Input.GetKeyDown( KeyCode.RightArrow );
			}
		}
		public static bool Up
		{
			get
			{
				return Input.GetKeyDown( KeyCode.UpArrow );
			}
		}
		public static bool Down
		{
			get
			{
				return Input.GetKeyDown( KeyCode.DownArrow );
			}
		}

		public static bool Decision
		{
			get
			{
				return Input.GetKeyDown( KeyCode.Z ) || Input.GetKeyDown( KeyCode.Return );
			}
		}

		public static bool Cancel
		{
			get
			{
				return Input.GetKeyDown( KeyCode.X ) || Input.GetKeyDown( KeyCode.Backspace );
			}
		}
	}
}
