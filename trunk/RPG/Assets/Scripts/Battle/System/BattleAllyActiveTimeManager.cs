/*===========================================================================*/
/*
*     * FileName    : BattleAllyActiveTimeManager.cs
*
*     * Description : プレイヤーのアクティブタイムを管理するコンポーネント.
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
	/// プレイヤーのアクティブタイムを管理するコンポーネント.
	/// </summary>
	public class BattleAllyActiveTimeManager : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( BattleAllyModelCreator.CreateExtensionMessage, typeof( BattleAllyModelCreator.CreateExtensionArgument ) )]
		void OnBattleCreatePlayerModelExtension( BattleAllyModelCreator.CreateExtensionArgument parameter )
		{
			TODO( "アクティブタイム管理を行う." );
		}
	}
}
