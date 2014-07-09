/*===========================================================================*/
/*
*     * FileName    : SceneRootBase.cs
*
*     * Description : シーンルートコンポーネントの抽象クラス.
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
	/// シーンルートコンポーネントの抽象クラス.
	/// </summary>
	public class SceneRootBase : MyMonoBehaviour
	{
		public static SceneRootBase Root{ private set; get; }

		void Awake()
		{
			Root = this;
		}
	}
}
