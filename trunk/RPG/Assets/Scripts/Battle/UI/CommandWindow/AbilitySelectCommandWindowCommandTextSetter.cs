using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RPG.Battle
{
	/// <summary>
	/// 特殊能力選択コマンドウィンドウのコマンドテキストを設定するコンポーネント.
	/// </summary>
	public class AbilitySelectCommandWindowCommandTextSetter : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[SerializeField]
		private int initializeId;
		
		[Attribute.MessageMethodReceiver( MessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( TypeConstants.CommandSelectType type )
		{
			if( type != TypeConstants.CommandSelectType.Ability )	return;

			var allyInstanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var abilityList = allyInstanceData.abilityList;
			var builder = new StringBuilder();
			for( int i=initializeId, imax=abilityList.Count; i<imax; i+=2 )
			{
				builder.AppendLine( Database.MasterData.Instance.GetAbilityData( abilityList[i] ).Name );
			}

			refText.text = builder.ToString();
		}
	}
}
