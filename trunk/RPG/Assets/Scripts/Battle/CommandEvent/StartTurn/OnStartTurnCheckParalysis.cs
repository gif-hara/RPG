/*===========================================================================*/
/*
*     * FileName    : OnStartTurnCheckParalysis.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドを実行したキャラクターが麻痺状態かチェックするコンポーネント.
	/// </summary>
	public class OnStartTurnCheckParalysis : MyMonoBehaviour
	{
		[SerializeField]
		private GameObject refEventHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartTurnMessage )]
		void OnStartTurn( BattleMessageConstants.ExecuteCommandHook hook )
		{
			Development.TODO( "麻痺の実装." );
			var eventHolder = Instantiate( this.refEventHolder );
			hook.Executor.SetEventHolder( eventHolder );
		}
	}
}
