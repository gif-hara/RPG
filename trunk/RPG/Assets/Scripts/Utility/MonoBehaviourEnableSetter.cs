/*===========================================================================*/
/*
*     * FileName    : MonoBehaviourEnableSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonoBehaviourEnableSetter : A_DelayEvent
{
	public List<MonoBehaviour> refTargetList;
	
	public bool isEnable;
	
	protected override void OnDelayEvent()
	{
			refTargetList.ForEach( (obj) =>
			{
				obj.enabled = isEnable;	
			});
	}
}
