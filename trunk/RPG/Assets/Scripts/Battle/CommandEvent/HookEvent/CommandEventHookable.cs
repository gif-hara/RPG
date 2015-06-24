﻿/*===========================================================================*/
/*
*     * FileName    : CommandEventHookable.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドイベントをフック可能なコンポーネント.
	/// </summary>
	public abstract class CommandEventHookable : MyMonoBehaviour
	{
		protected bool internalIsHooked = false;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.EndTurnMessage )]
		void OnEndTurn()
		{
			this.internalIsHooked = false;
		}

		protected bool InternalIsHooked
		{
			get
			{
				return CanHook && !internalIsHooked;
			}
		}

		protected abstract void OnHook( BattleMessageConstants.ExecuteCommandHook hookData );
		
		protected abstract bool CanHook{ get; }
	}
}