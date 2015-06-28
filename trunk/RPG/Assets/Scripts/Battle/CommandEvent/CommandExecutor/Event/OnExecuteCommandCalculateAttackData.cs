using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に通常攻撃に必要なデータ類を計算するコンポーネント.
	/// </summary>
	public class OnExecuteCommandCalculateAttackData : MonoBehaviour
	{
		[SerializeField]
		private AttackData refAttackData;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( BattleMessageConstants.ExecuteCommandHook hook )
		{
			var member = AllPartyManager.Instance.ActiveTimeMaxBattleMember;
			refAttackData.CalcurlateNumber( member );
		}
	}
}
