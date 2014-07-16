/*===========================================================================*/
/*
*     * FileName    : AllySelectCommandWindowFrameSetter.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 味方選択ウィンドウのフレームのスケールを設定するコンポーネント.
	/// </summary>
	public class AllySelectCommandWindowFrameSetter : CommandWindowFrameSetter
	{
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		protected override int ElementCount
		{
			get
			{
				return refAllyPartyManager.Party.List.Count;
			}
		}
	}
}
