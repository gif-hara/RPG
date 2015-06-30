/*===========================================================================*/
/*
*     * FileName    : LookAtObject.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LookAtObject : MyMonoBehaviour
{
	public Transform refTarget;
	
	public Vector3 refTargetPosition;
	
	public float lookSpeed;

	private Transform cachedTransform;

	void Start()
	{
		this.cachedTransform = this.transform;
	}

	// Update is called once per frame
	void Update()
	{
		SyncRotationObjectPosition();
		
		if( lookSpeed >= 1.0f )
		{
			this.cachedTransform.LookAt( refTargetPosition, Vector3.forward );
			this.cachedTransform.rotation *= Quaternion.AngleAxis( -90.0f, Vector3.right );
		}
		else
		{
			Quaternion tmpRotation = this.cachedTransform.rotation;
			this.cachedTransform.LookAt( refTargetPosition, Vector3.forward );
			this.cachedTransform.rotation *= Quaternion.AngleAxis( -90.0f, Vector3.right );
			this.cachedTransform.rotation = Quaternion.Lerp( tmpRotation, this.cachedTransform.rotation, lookSpeed );
		}
		
		if( refTarget != null )
		{
			refTargetPosition = refTarget.position;
		}
	}
	
	private void SyncRotationObjectPosition()
	{
		var pos = this.cachedTransform.position;
		this.cachedTransform.position = new Vector3( pos.x, pos.y, refTargetPosition.z );
	}
	
	public static LookAtObject Begin( Transform parent, Transform target, float lookSpeed )
	{
		GameObject obj = new GameObject( "[LookAtObject] Chase-> " + target.name );
		var instance = obj.AddComponent<LookAtObject>();
		obj.transform.parent = parent;
		obj.transform.localPosition = Vector3.zero;
		instance.refTarget = target;
		instance.refTargetPosition = target.position;
		instance.lookSpeed = lookSpeed;
		
		return instance;
	}
	
	public static LookAtObject Begin( Transform parent, Vector3 target, float lookSpeed )
	{
		GameObject obj = new GameObject( "[LookAtObject] Chase-> " + target.ToString() );
		var instance = obj.AddComponent<LookAtObject>();
		obj.transform.parent = parent;
		obj.transform.localPosition = Vector3.zero;
		instance.refTargetPosition = target;
		instance.lookSpeed = lookSpeed;
		
		return instance;
	}
}
