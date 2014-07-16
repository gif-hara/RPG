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
		/// <summary>
		/// 誰に対してコマンドを実行するかのリスト.
		/// </summary>
		/// <value>The target identifier list.</value>
		public List<int> TargetIdList{ private set; get; }

		public CommandData( BattleTypeConstants.CommandType type )
			:base( (int)type )
		{
			this.TargetIdList = new List<int>();
		}

		public override string ToString ()
		{
			return string.Format ("[CommandData: TargetIdList={0}]", TargetIdList);
		}
	}
}
