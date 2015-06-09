/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandSetInformation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG
{
	/// <summary>
	/// コマンド実行イベントをキャッチして情報テキストを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetInformation : MyMonoBehaviour
	{
		void OnExecuteCommand()
		{
			Debug.Log( "Hello." );
		}
	}
}
