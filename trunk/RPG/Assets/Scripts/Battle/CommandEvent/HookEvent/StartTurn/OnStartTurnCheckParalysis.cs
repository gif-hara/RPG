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
	public class OnStartTurnCheckParalysis : OnStartTurnHookable
	{
		[SerializeField]
		private GameObject refEventHolder;

		protected override void OnHook ( BattleMessageConstants.ExecuteCommandHook hookData )
		{
			Development.TODO( "麻痺の実装." );
			var eventHolder = Instantiate( this.refEventHolder );
			hookData.Executor.InsertEventHolder( eventHolder );
			this.internalIsHooked = true;
		}

		protected override bool CanHook
		{
			get
			{
				return false;
			}
		}
	}
}
