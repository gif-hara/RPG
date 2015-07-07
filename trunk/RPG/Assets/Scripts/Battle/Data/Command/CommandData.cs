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
		public TargetData TargetData{ private set; get; }

		/// <summary>
		/// 実行するコマンドタイプ.
		/// </summary>
		/// <value>The type.</value>
		public TypeConstants.CommandType Type{ private set; get; }

		/// <summary>
		/// このコマンドでステータスの影響を受けたデータ.
		/// </summary>
		/// <value>The give damage.</value>
		public CommandImpactData Impact{ private set; get; }

		/// <summary>
		/// 特殊能力ID.
		/// </summary>
		/// <value>The ability identifier.</value>
		public int AbilityId{ private set; get; }

		public CommandData()
		{
			this.TargetData = null;
		}

		public void SetCommandType( TypeConstants.CommandType type )
		{
			this.Type = type;
		}

		public void SetAbilityId( int abilityId )
		{
			this.AbilityId = abilityId;
		}

		public void SetTarget( BattleCharacter target )
		{
			this.Impact = new CommandImpactData( target );
		}

		public BattleCharacter GetTargetBattleCharacter( int id )
		{
			return TargetParty.List[id];
		}
		
		public BattleCharacter GetTargetBattleCharacter()
		{
			return this.GetTargetBattleCharacter( this.TargetData.Id );
		}
		
		public Group GetTargetGroup()
		{
			return TargetParty.GroupList[this.TargetData.Id];
		}

		/// <summary>
		/// 取得出来るグループ内のキャラクターが全て戦闘不能の場合は別グループを返す.
		/// </summary>
		/// <returns>The group battle member data safe.</returns>
		/// <param name="targetId">Target identifier.</param>
		public Group GetTargetGroupSafe()
		{
			var result = this.GetTargetGroup();
			if( result.IsAllDead )
			{
				return TargetParty.GroupList.List.Find( g => !g.IsAllDead );
			}

			return result;
		}

		public Party TargetParty
		{
			get
			{
				if( this.TargetData.PartyType == TypeConstants.PartyType.Enemy )
				{
					return AllPartyManager.Instance.AllParty.Enemy;
				}
				else
				{
					return AllPartyManager.Instance.AllParty.Ally;
				}
			}
		}
		
		/// <summary>
		/// ターゲットIDの追加.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddTargetId( TypeConstants.PartyType partyType, int id )
		{
			this.TargetData = new TargetData( partyType, id );
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
			return string.Format ("[CommandData: TargetIdList={0}]", TargetData);
		}
	}
}
