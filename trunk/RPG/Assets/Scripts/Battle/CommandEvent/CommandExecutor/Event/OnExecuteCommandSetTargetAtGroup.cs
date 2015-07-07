using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にグループを選択するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetTargetAtGroup : Common.Conditioner, I_OnExecuteCommandHookable
	{
		private bool isInitialize = false;

		private Group targetGroup;

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
