/*===========================================================================*/
/*
*     * FileName    : CommandExecutorHolder.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 実際にコマンドを実行するデータを保持するコンポーネント.
	/// </summary>
	public class CommandExecutorHolder : MyMonoBehaviour
	{
		[SerializeField]
		private List<CommandExecutor> executorList;

		public GameObject Get( BattleTypeConstants.CommandType type )
		{
			var executor = executorList.Find( e => e.CommandType == type ).gameObject;
			Debug.Assert( executor, string.Format( "CommandExecutorがありません. {0} に対応したCommandExecutorが登録されているか確認してください.", type ), this );

			return executor;
		}
	}
}
