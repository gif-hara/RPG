/*===========================================================================*/
/*
*     * FileName    : ChaseGameObject.cs
*
*     * Description : 指定したゲームオブジェクトに追従するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ChaseGameObject : MyMonoBehaviour
{
	/// <summary>
	/// 追従するオブジェクト参照.
	/// </summary>
	public Transform refChaseObject;
	
	/// <summary>
	/// 速度.
	/// </summary>
	public float speed;

	private Transform cachedTransform;

	void Awake()
	{
		this.cachedTransform = this.transform;
	}
	// Update is called once per frame
	void LateUpdate()
	{
		if( refChaseObject == null )	return;
		
		this.cachedTransform.position = Vector3.Lerp( this.cachedTransform.position, refChaseObject.position, speed );
	}

	public void ChangeChaseObject( Transform changeObject )
	{
		this.refChaseObject = changeObject;
	}
}
