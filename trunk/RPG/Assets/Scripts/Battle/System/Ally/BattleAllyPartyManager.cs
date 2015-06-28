/*===========================================================================*/
/*
*     * FileName    : BattleAllyPartyManager.cs
*
*     * Description : 味方パーティデータ管理者コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 味方パーティデータ管理者コンポーネント.
	/// </summary>
	public class BattleAllyPartyManager : A_Singleton<BattleAllyPartyManager>
	{
		public Party<Ally> Party{ private set; get; }

		void Awake()
		{
			Instance = this;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.Party = new Party<Ally>();

			var initializeData = SharedData.initializeData.PlayerDataList;
			for( int i=0,imax=initializeData.Count; i<imax; i++ )
			{
				this.Party.Add( new Ally( initializeData[i] ) );
			}
		}
	}
}
