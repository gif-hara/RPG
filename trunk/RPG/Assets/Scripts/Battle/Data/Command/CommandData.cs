using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 使用するコマンドに必要なデータを格納するクラス.
	/// </summary>
	public class CommandData
	{
		/// <summary>
		/// 誰に対してコマンドを実行するかのリスト.
		/// </summary>
		/// <value>The target identifier list.</value>
		public List<TargetData> TargetIdList{ private set; get; }

		/// <summary>
		/// 実行するコマンドタイプ.
		/// </summary>
		/// <value>The type.</value>
		public TypeConstants.CommandType Type{ private set; get; }

		/// <summary>
		/// 与えるダメージデータクラス.
		/// </summary>
		/// <value>The give damage.</value>
		public GiveDamageData GiveDamage{ private set; get; }

		/// <summary>
		/// 特殊能力ID.
		/// </summary>
		/// <value>The ability identifier.</value>
		public int AbilityId{ private set; get; }

		public CommandData()
		{
			this.TargetIdList = new List<TargetData>();
		}

		public void SetCommandType( TypeConstants.CommandType type )
		{
			this.Type = type;
		}

		public void SetAbilityId( int abilityId )
		{
			this.AbilityId = abilityId;
		}

		public void SetGiveDamage( BattleCharacter target, int value, bool isCritical )
		{
			this.GiveDamage = new GiveDamageData( target, value, isCritical );
		}

		public BattleCharacter GetTargetBattleMemberData( int targetId )
		{
			var targetData = this.TargetIdList[targetId];
			if( targetData.PartyType == TypeConstants.PartyType.Enemy )
			{
				return AllPartyManager.Instance.AllParty.Enemy.List[targetData.Id];
			}
			else
			{
				return AllPartyManager.Instance.AllParty.Ally.List[targetData.Id];
			}
		}
		
		public Group GetGroupBattleMemberData( int targetId )
		{
			var targetData = this.TargetIdList[targetId];
			if( targetData.PartyType == TypeConstants.PartyType.Enemy )
			{
				return AllPartyManager.Instance.AllParty.Enemy.GroupList[targetData.Id];
			}
			else
			{
				return AllPartyManager.Instance.AllParty.Ally.GroupList[targetData.Id];
			}
		}

		/// <summary>
		/// 取得出来るグループ内のキャラクターが全て戦闘不能の場合は別グループを返す.
		/// </summary>
		/// <returns>The group battle member data safe.</returns>
		/// <param name="targetId">Target identifier.</param>
		public Group GetGroupBattleMemberDataSafe( int targetId )
		{
			var result = this.GetGroupBattleMemberData( targetId );
			if( result.IsAllDead )
			{
				var targetData = this.TargetIdList[targetId];
				if( targetData.PartyType == TypeConstants.PartyType.Enemy )
				{
					return BattleEnemyPartyManager.Instance.Party.GroupList.List.Find( g => !g.IsAllDead );
				}
				else
				{
					return BattleAllyPartyManager.Instance.Party.GroupList.List.Find( g => !g.IsAllDead );
				}
			}

			return result;
		}
		
		/// <summary>
		/// ターゲットIDの追加.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddTargetId( TypeConstants.PartyType partyType, int id )
		{
			this.TargetIdList.Add( new TargetData( partyType, id ) );
		}

		/// <summary>
		/// 実行する特殊能力データ.
		/// </summary>
		/// <value>The ability data.</value>
		public Database.I_AbilityData AbilityData
		{
			get
			{
				return Database.MasterData.Instance.GetAbilityData( this.Type, this.AbilityId );
			}
		}

		public override string ToString ()
		{
			return string.Format ("[CommandData: TargetIdList={0}]", TargetIdList);
		}
	}
}
