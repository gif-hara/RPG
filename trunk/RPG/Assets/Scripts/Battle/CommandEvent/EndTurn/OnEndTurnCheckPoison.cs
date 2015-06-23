/*===========================================================================*/
/*
*     * FileName    : OnEndTurnCheckPoison.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ターン終了時に毒状態かチェックするコンポーネント.
	/// </summary>
	public class OnEndTurnCheckPoison : MyMonoBehaviour
	{
		[SerializeField]
		private GameObject prefabEventHolder;

		void OnEndExecuteCommand( BattleMessageConstants.ExecuteCommandHook hook )
		{
			Development.TODO( "毒状態の実装." );

//			var eventObject = Instantiate( this.prefabEventHolder );
//			hook.Executor.SetEventHolder( eventObject );
		}
	}
}
