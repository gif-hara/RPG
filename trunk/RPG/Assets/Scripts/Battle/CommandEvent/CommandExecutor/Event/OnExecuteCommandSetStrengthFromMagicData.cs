using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから攻撃力の加減を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetStrengthFromMagicData : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			var target = selectCommandData.Impact.Target;
			var magicData = selectCommandData.AbilityData as Database.MagicData;

			Debug.Assert(
				magicData != null,
				string.Format(
					"術ではありません. 実行者 = {0} 特殊能力タイプ = {1} ID = {2}",
					executer.InstanceData.name,
					selectCommandData.Type,
					selectCommandData.AbilityData.ID
				));

			var value = target.AddStrengthPercentage( CalcurateDamage.Range( magicData.minPower, magicData.maxPower ) );
			selectCommandData.Impact.Strength = value;
		}
	}
}
