/*===========================================================================*/
/*
*     * FileName    : InformationCommandEventLabelSetter.cs
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
	/// .
	/// </summary>
	public class InformationCommandEventLabelSetter : MyMonoBehaviour
	{
		[SerializeField]
		private UILabel refLabel;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.NoticeCommandEventMessage )]
		void OnNoticeCommandEvent( BattleMessageConstants.NoticeCommandEventArgument parameter )
		{
			for( int i=0,imax=parameter.CommandEventList.Count; i<imax; i++ )
			{
				var commandEvent = parameter.CommandEventList[i];
				if( commandEvent.EventType != CommandEventConstants.EventType.Information )
				{
					continue;
				}

				var infoEvent = commandEvent as InformationLabelSetterCommandEvent;
				refLabel.text = infoEvent.Message( parameter.AllParty, parameter.ExecuteMember, parameter.CommandData );
			}
		}
	}
}
