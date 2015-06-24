/*===========================================================================*/
/*
*     * FileName    : OnStartTurnHookable.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// OnStartTurnのタイミングでコマンドイベントをフック可能なコンポーネント.
	/// </summary>
	public abstract class OnStartTurnHookable : CommandEventHookable
	{
		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartTurnMessage )]
		void OnStartTurn( BattleMessageConstants.ExecuteCommandHook hookData )
		{
			if( !hookData.Hooked && this.InternalIsHooked )
			{
				this.OnHook( hookData );
				hookData.Hook();
			}
		}

	}
}
