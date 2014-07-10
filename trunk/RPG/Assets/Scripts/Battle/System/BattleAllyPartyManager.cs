/*===========================================================================*/
/*
*     * FileName    : BattleAllyPartyManager.cs
*
*     * Description : .
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
	/// .
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
		}
		public class AllyData
		{
			public CharacterData Data{ private set; get; }

			private float activeTime;

			public BattleTypeConstants.CommandType SelectCommandType{ private set; get; }

			public AllyData( CharacterData data )
			{
				this.Data = data;
				this.activeTime = 0.0f;
				this.SelectCommandType = BattleTypeConstants.CommandType.None;
			}

			/// <summary>
			/// コマンド決定処理.
			/// </summary>
			/// <param name="type">Type.</param>
			public void DecisionCommand( BattleTypeConstants.CommandType type )
			{
				this.SelectCommandType = type;
				this.activeTime = 0.0f;
			}

			/// <summary>
			/// アクティブタイムの更新処理.
			/// </summary>
			/// <param name="value">Value.</param>
			public void UpdateActiveTime( float value )
			{
				this.activeTime += value;
			}

			public bool IsActiveTimeMax
			{
				get
				{
					return this.activeTime >= 1.0f;
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
