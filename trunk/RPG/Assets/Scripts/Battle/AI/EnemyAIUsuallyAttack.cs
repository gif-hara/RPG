using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// 通常攻撃のみ行う敵AI.
	/// </summary>
	public class EnemyAIUsuallyAttack : A_EnemyAI
	{
		public override void Think ( Enemy enemy )
		{
			var commandData = new CommandData();
			var allyParty = BattleAllyPartyManager.Instance.Party;
			commandData.AddTargetId( TypeConstants.PartyType.Ally, Random.Range( 0, allyParty.List.Count ) );
			commandData.SetCommandType( TypeConstants.CommandType.Attack );
			enemy.DecideCommand( commandData );
		}
	}
}
