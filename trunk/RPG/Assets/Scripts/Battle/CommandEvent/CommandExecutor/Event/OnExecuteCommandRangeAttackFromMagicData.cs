using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから範囲ダメージを行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandRangeAttackFromMagicData : MyMonoBehaviour
	{
		[SerializeField]
		private int targetId;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
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

			var damage = CalcurateDamage.Range( magicData.minPower, magicData.maxPower );
			selectCommandData.SetGiveDamage( target, damage, false );
			target.TakeDamage( selectCommandData.GiveDamage.Damage );
		}
	}
}
