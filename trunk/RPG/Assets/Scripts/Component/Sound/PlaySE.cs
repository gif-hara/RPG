/*===========================================================================*/
/*
*     * FileName    : PlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaySE : MyMonoBehaviour, I_Poolable
{
	public string label;
	
	public int delay;

	private int cachedDelay;
	
	// Update is called once per frame
	void Update()
	{
		if( delay <= 0 )
		{
			SoundManager.Instance.Play( label );
			enabled = false;
		}
		
		delay--;
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedDelay = this.delay;
		}
		else
		{
			this.delay = this.cachedDelay;
		}

		this.enabled = true;
	}

	public void OnReleaseByPool()
	{

	}
}
