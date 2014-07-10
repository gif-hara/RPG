/*===========================================================================*/
/*
*     * FileName    : BattleDebugTextMesh.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RPG.Battle
{
	/// <summary>
	/// .
	/// </summary>
	public class BattleDebugTextMesh : MyMonoBehaviour
	{
		[SerializeField]
		private TextMesh refText;

		[SerializeField]
		private BattleAllyPartyManager refAllyManager;

		void Update()
		{
			StringBuilder builder = new StringBuilder();
			var party = refAllyManager.Party;
			for( int i=0,imax=party.List.Count; i<imax; i++ )
			{
				builder.AppendLine( string.Format( "{0} ActiveTime = {1}", party.List[i].Data.name, party.List[i].ActiveTime ) );
			}

			refText.text = builder.ToString();
		}
	}
}
