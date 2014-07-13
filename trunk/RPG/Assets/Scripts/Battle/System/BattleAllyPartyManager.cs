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
	public class BattleAllyPartyManager : MyMonoBehaviour
	{
		public class AllyParty
		{
			public List<AllyData> List{ private set; get; }

			public AllyParty()
			{
				this.List = new List<AllyData>();
			}

			public void Add( AllyData data )
			{
				this.List.Add( data );
			}

			/// <summary>
			/// 誰かしらアクティブタイムが最大値に達しているか？.
			/// </summary>
			/// <value><c>true</c> if any active time max; otherwise, <c>false</c>.</value>
			public bool IsAnyActiveTimeMax
			{
				get
				{
					return ActiveTimeMaxAllyData != null;
				}
			}

			/// <summary>
			/// アクティブタイムが最大の味方を返す.
			/// </summary>
			/// <value>The active time max ally data.</value>
			public AllyData ActiveTimeMaxAllyData
			{
				get
				{
					return List.Find( a => a.IsActiveTimeMax );
				}
			}

			/// <summary>
			/// 誰かしらの味方がコマンドを選択していないか返す.
			/// </summary>
			/// <value><c>true</c> if this instance is any none command; otherwise, <c>false</c>.</value>
			public bool IsAnyNoneCommand
			{
				get
				{
					return NoneCommandAllyData != null;
				}
			}

			/// <summary>
			/// コマンド選択していない味方を返す.
			/// </summary>
			/// <value>The none command ally data.</value>
			public AllyData NoneCommandAllyData
			{
				get
				{
					return List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );
				}
			}
		}

		public AllyParty Party{ private set; get; }

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.Party = new AllyParty();

			var initializeData = SharedData.initializeData.PlayerDataList;
			for( int i=0,imax=initializeData.Count; i<imax; i++ )
			{
				this.Party.Add( new AllyData( initializeData[i] ) );
			}
		}
	}
}
