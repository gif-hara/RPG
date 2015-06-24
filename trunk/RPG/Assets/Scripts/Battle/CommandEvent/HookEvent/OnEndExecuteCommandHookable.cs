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
	/// OnEndExecuteCommandのタイミングでコマンドイベントをフック可能なコンポーネント.
	/// </summary>
	public abstract class OnEndExecuteCommandHookable : CommandEventHookable
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
