using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから回復を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandRecoveryFromMagicData : MyMonoBehaviour
	{
		[SerializeField]
		private int targetId;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleMember;
			var selectCommandData = executer.SelectCommandData;
			var target = selectCommandData.GetTargetBattleMemberData( this.targetId );
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
			selectCommandData.SetGiveDamage( target, damage, isCritical );
			target.Recovery( selectCommandData.GiveDamage.Damage );
		}
	}
}
