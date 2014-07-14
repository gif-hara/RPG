/*===========================================================================*/
/*
*     * FileName    : PositionSetterFromCommandId.cs
*
*     * Description : コマンドIDから座標を設定するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Battle;

namespace RPG.Common
{
	/// <summary>
	/// コマンドIDから座標を設定するコンポーネント.
	/// </summary>
	public class PositionSetterFromCommandId : MyMonoBehaviour
	{
		[SerializeField]
		private List<Transform> refTargetPositionList;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ModifiedCommandIdMessage )]
		void OnModifiedCommandId( int commandId )
		{
			transform.localPosition = refTargetPositionList[commandId].localPosition;
		}
	}
}
