using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから範囲ダメージをグループに対して行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandRangeAttackFromMagicDataAtGroup : Common.Conditioner
	{
		private bool isInitialize = false;

		private Group targetGroup;

		private BattleCharacter targetCharacter;

		private int targetId = 0;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			this.Initialize();

			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			var magicData = selectCommandData.AbilityData as Database.MagicData;

			Debug.Assert(
				magicData != null,
				string.Format(
					"術ではありません. 実行者 = {0} 特殊能力タイプ = {1} ID = {2}",
					executer.InstanceData.name,
					selectCommandData.Type,
					selectCommandData.AbilityData.ID
				));

			var damage = CalcurateDamage.Range( magicData.minPower, magicData.maxPower );
			selectCommandData.SetGiveDamage( this.targetCharacter, damage, false );
			this.targetCharacter.TakeDamage( selectCommandData.GiveDamage.Damage );
			SetTargetCharacter();
		}

		private void Initialize()
		{
			if( this.isInitialize )
			{
				return;
			}

			this.isInitialize = true;
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			this.targetGroup = selectCommandData.GetTargetGroupSafe();
			this.SetTargetCharacter();
		}

		private void SetTargetCharacter()
		{
			this.targetCharacter = null;
			for( int i=this.targetId,imax=this.targetGroup.Count; i<imax; i++ )
			{
				this.targetId++;
				if( this.targetGroup.List[i].IsDead )
				{
					continue;
				}

				this.targetCharacter = this.targetGroup[i];
				break;
			}
		}

		public override bool Condition
		{
			get
			{
				return this.targetCharacter != null;
			}
		}
	}
}
