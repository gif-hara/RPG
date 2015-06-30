/*===========================================================================*/
/*
*     * FileName    : DetachParent.cs
*
*     * Description : 親子関係を切り離すコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DetachParent : MyMonoBehaviour
{
	[SerializeField]
	private int delay;

	// Use this for initialization
	void Awake()
	{
		if( delay <= 0 )
		{
			transform.parent = null;
		}
		else
		{
			FrameRateUtility.StartCoroutine( delay, () => transform.parent = null );
		}
	}
}
