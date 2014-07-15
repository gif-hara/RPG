/*===========================================================================*/
/*
*     * FileName    : CommandData.cs
*
*     * Description : コマンドデータ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドデータ.
	/// </summary>
	public abstract class CommandData : FactoryElement
	{
		public CommandData( BattleTypeConstants.CommandType type )
			:base( (int)type )
		{

		}

		/// <summary>
		/// コマンドを実行するバトルメンバー.
		/// </summary>
		/// <value>The executable member.</value>
		public BattleMemberData executableMember{ private set; get; }

		/// <summary>
		/// 誰に対してコマンドを実行するかのリスト.
		/// </summary>
		/// <value>The target identifier list.</value>
		public List<int> TargetIdList{ private set; get; }
	}
}
