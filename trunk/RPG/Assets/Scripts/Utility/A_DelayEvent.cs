/*===========================================================================*/
/*
*     * FileName    : A_DelayEvent.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class A_DelayEvent : MyMonoBehaviour, I_Poolable
{
	/// <summary>
	/// ディレイ.
	/// </summary>
	[SerializeField]
	private int delay;

	private int cachedDelay;

	void Start ()
	{
		this.Execute();
	}

	// Update is called once per frame
	void Update()
	{
		this.Execute();

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
			this.enabled = true;
			this.Execute();
		}

	}

	public void OnReleaseByPool()
	{

	}

	private void Execute()
	{
		if( delay <= 0 )
		{
			OnDelayEvent();
			enabled = false;
		}
	}
	
	/// <summary>
	/// ディレイアクション.
	/// </summary>
	protected abstract void OnDelayEvent();
}
