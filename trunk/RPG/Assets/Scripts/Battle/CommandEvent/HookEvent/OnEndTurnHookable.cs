/*===========================================================================*/
/*
*     * FileName    : OnEndTurnHookable.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// OnEndTurnのタイミングでコマンドイベントをフック可能なコンポーネント.
	/// </summary>
	public abstract class OnEndTurnHookable : CommandEventHookable
	{
		void OnEndExecuteCommand( BattleMessageConstants.ExecuteCommandHook hookData )
		{
			if( !hookData.Hooked && this.InternalIsHooked )
			{
				this.OnHook( hookData );
				hookData.Hook();
			}
		}
	}
}
