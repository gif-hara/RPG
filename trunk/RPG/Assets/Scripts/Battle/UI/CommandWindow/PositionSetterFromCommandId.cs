using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Battle;

namespace RPG.Common
{
	/// <summary>
	/// コマンドIDから座標を設定するコンポーネント.
	/// </summary>
	public class PositionSetterFromCommandId : PositionSetterFromTiled
	{
		[Attribute.MessageMethodReceiver( BattleMessageConstants.ModifiedCommandIdMessage )]
		void OnModifiedCommandId( int commandId )
		{
			Set( commandId );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow(BattleTypeConstants.CommandSelectType type)
		{
			Set( 0 );
		}
	}
}
