/*===========================================================================*/
/*
*     * FileName    : FrameRateSetter.cs
*
*     * Description : フレームレートを設定するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Framework
{
	/// <summary>
	/// フレームレートを設定するコンポーネント.
	/// </summary>
	public class FrameRateSetter : MyMonoBehaviour
	{
		[SerializeField]
		private int frameRate;

		void Awake ()
		{
			Application.targetFrameRate = frameRate;
		}
	}
}
