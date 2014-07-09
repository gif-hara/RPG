/*===========================================================================*/
/*
*     * FileName    : BattlePlayerActiveTimeManager.cs
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
	public class BattlePlayerActiveTimeManager : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( BattlePlayerModelCreator.CreateExtensionMessage, typeof( BattlePlayerModelCreator.CreateExtensionArgument ) )]
		void OnBattleCreatePlayerModelExtension( BattlePlayerModelCreator.CreateExtensionArgument parameter )
		{
			TODO( "アクティブタイム管理を行う." );
		}
	}
}
