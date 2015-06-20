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
		public List<TargetData> TargetIdList{ private set; get; }

		/// <summary>
		/// タイプ
		/// </summary>
		/// <value>The type.</value>
		public BattleTypeConstants.CommandType Type{ private set; get; }

		public GiveDamageData GiveDamage{ private set; get; }

		public CommandData()
		{
			this.TargetIdList = new List<TargetData>();
		}

		public void SetCommandType( BattleTypeConstants.CommandType type )
		{
			this.Type = type;
		}

		public void SetGiveDamage( BattleMemberData target, int value )
		{
			this.GiveDamage = new GiveDamageData( target, value );
		}

		public BattleMemberData GetTargetBattleMemberData( int targetId )
		{
			var targetData = this.TargetIdList[targetId];
			if( targetData.PartyType == BattleTypeConstants.PartyType.Enemy )
			{
				return AllPartyManager.Instance.AllParty.EnemyParty.List[targetData.Id];
			}
			else
			{
				return AllPartyManager.Instance.AllParty.AllyParty.List[targetData.Id];
			}
		}
		
		public List<BattleMemberData> GetGroupBattleMemberData( int targetId )
		{
			var targetData = this.TargetIdList[targetId];
			if( targetData.PartyType == BattleTypeConstants.PartyType.Enemy )
			{
				return AllPartyManager.Instance.AllParty.EnemyParty.GroupList[targetData.Id].List;
			}
			else
			{
				return AllPartyManager.Instance.AllParty.AllyParty.GroupList[targetData.Id].List;
			}
		}

		/// <summary>
		/// 取得出来るグループ内のキャラクターが全て戦闘不能の場合は別グループを返す.
		/// </summary>
		/// <returns>The group battle member data safe.</returns>
		/// <param name="targetId">Target identifier.</param>
		public List<BattleMemberData> GetGroupBattleMemberDataSafe( int targetId )
		{
			return null;
		}
		
		/// <summary>
		/// ターゲットIDの追加.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddTargetId( BattleTypeConstants.PartyType partyType, int id )
		{
			this.TargetIdList.Add( new TargetData( partyType, id ) );
		}

		public override string ToString ()
		{
			return string.Format ("[CommandData: TargetIdList={0}]", TargetIdList);
		}
	}
}
