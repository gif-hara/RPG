/*===========================================================================*/
/*
*     * FileName    : OnEndExecuteCommandCheckPoison.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ターン終了時に毒状態かチェックするコンポーネント.
	/// </summary>
	public class OnEndExecuteCommandCheckPoison : OnEndTurnHookable
	{
		[SerializeField]
		private GameObject prefabEventHolder;

		protected override void OnHook (MessageConstants.ExecuteCommandHook hookData)
		{
			Development.TODO( "毒状態の実装." );

			var eventObject = Instantiate( this.prefabEventHolder );
			hookData.Executer.InsertEventHolder( eventObject );
			this.internalIsHooked = true;
		}

		protected override bool CanHook
		{
			get
			{
				return false;
			}
		}
	}
}
