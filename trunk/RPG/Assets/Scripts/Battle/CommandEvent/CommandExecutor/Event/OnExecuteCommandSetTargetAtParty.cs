using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にパーティを選択するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetTargetAtParty : Common.Conditioner, I_OnExecuteCommandHookable
	{
		private bool isInitialize = false;

		private Party targetParty;

		private BattleCharacter targetCharacter;

		private int targetId = 0;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand(Battle.MessageConstants.ExecuteCommandHook hook)
		{
			this.Initialize();

			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData;
			selectCommandData.SetTarget( this.targetCharacter );
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
