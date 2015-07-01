using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// InformationTextDataから文字列を構築するコンポーネント.
	/// </summary>
	public static class InformationTextBuilder
	{
		public static string Build( InformationTextData data )
		{
			return StringAsset.Format( data.Key, FormatArguments( data ) );
		}
		
		private static object[] FormatArguments( InformationTextData data )
		{
			List<object> result = new List<object>();
			for( int i=0,imax=data.Parameter.Count; i<imax; i++ )
			{
				switch( data.Parameter[i] )
				{
				case BattleTypeConstants.InformationParameterType.ExecuteCharacterName:
					result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.InstanceData.name );
					break;
				case BattleTypeConstants.InformationParameterType.GiveDamage:
					result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.GiveDamage.Damage );
					break;
				case BattleTypeConstants.InformationParameterType.TargetName:
					result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.GiveDamage.Target.InstanceData.name );
					break;
				case BattleTypeConstants.InformationParameterType.AbilityName:
					result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.AbilityData.Name );
					break;
				}
			}
			return result.ToArray();
		}
	}
}
