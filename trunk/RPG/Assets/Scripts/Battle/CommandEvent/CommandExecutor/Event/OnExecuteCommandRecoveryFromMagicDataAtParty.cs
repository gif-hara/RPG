using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データからパーティに対して回復を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandRecoveryFromMagicDataAtParty : Common.Conditioner
	{
		private bool isInitialize = false;
		
		private Party targetParty;
		
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

			var isCritical = Random.Range( 0, 100 ) < 1;	Development.TODO( "会心の術の実装." );
			var damage = CalcurateDamage.Range( magicData.minPower, magicData.maxPower );
			selectCommandData.SetGiveDamage( this.targetCharacter, damage, isCritical );
			this.targetCharacter.Recovery( selectCommandData.GiveDamage.Damage );
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
			this.targetParty = selectCommandData.TargetParty;
			this.SetTargetCharacter();
		}
		
		private void SetTargetCharacter()
		{
			this.targetCharacter = null;
			for( int i=this.targetId,imax=this.targetParty.List.Count; i<imax; i++ )
			{
				this.targetId++;
				if( this.targetParty.List[i].IsDead )
				{
					continue;
				}
				
				this.targetCharacter = this.targetParty.List[i];
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
