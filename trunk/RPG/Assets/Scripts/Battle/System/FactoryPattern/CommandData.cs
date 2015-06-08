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
	public class CommandData
	{
		/// <summary>
		/// 誰に対してコマンドを実行するかのリスト.
		/// </summary>
		/// <value>The target identifier list.</value>
		public List<int> TargetIdList{ private set; get; }

		/// <summary>
		/// タイプ
		/// </summary>
		/// <value>The type.</value>
		public BattleTypeConstants.CommandType Type{ private set; get; }

		public CommandData()
		{
			this.TargetIdList = new List<int>();
		}

		public void SetCommandType( BattleTypeConstants.CommandType type )
		{
			this.Type = type;
		}

		/// <summary>
		/// ターゲットIDの追加.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddTargetId( int id )
		{
			this.TargetIdList.Add( id );
		}

		/// <summary>
		/// 内部初期化処理.
		/// </summary>
		protected void InternalInitialize()
		{
			this.TargetIdList.Clear();
		}

		public override string ToString ()
		{
			return string.Format ("[CommandData: TargetIdList={0}]", TargetIdList);
		}
	}
}
