/*===========================================================================*/
/*
*     * FileName    : CreatePrefab.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;


public class CreatePrefab : MyMonoBehaviour, I_Poolable
{
	[System.Serializable]
	public class Element
	{
		public GameObject prefab;
		
		public Transform parent;
		
		public bool detachParent = false;
	}
	
	public enum CreateType : int
	{
		Awake,
		Start,
		Update,
	}
	
	public CreateType createType;
	
	public List<Element> elementList;
	
	public int delay;

	[SerializeField]
	private CommonDefine.CreateType objectCreateType = CommonDefine.CreateType.Instantiate;

	private int cachedDelay;

	void Awake()
	{
		if( createType == CreateType.Awake )
		{
			Create();
		}
	}
	// Use this for initialization
	void Start()
	{
		if( createType == CreateType.Start )
		{
			Create();
		}
	}
	void Update()
	{
		if( createType != CreateType.Update )	return;
		
		if( delay <= 0 )
		{
			Create();
			enabled = false;
		}
		
		delay--;
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedDelay = this.delay;
			return;
		}

		if( createType == CreateType.Awake || createType == CreateType.Start )
		{
			Create();
		}
		else
		{
			this.delay = this.cachedDelay;
			enabled = true;
		}
	}

	public void OnReleaseByPool()
	{

	}

	private void Create()
	{
		elementList.ForEach( (obj) => 
		{
			Create( obj );
		});
	}

	private void Create( Element element )
	{
		Transform obj = null;

		if( this.objectCreateType == CommonDefine.CreateType.Pool )
		{
			obj = ObjectPool.Instance.GetGameObject( element.prefab ).transform;
			if( element.parent != null )
			{
				obj.parent = element.parent;
			}
		}
		else
		{
			obj = element.parent == null
				? (Instantiate( element.prefab, element.prefab.transform.position, element.prefab.transform.rotation ) as GameObject).transform
				: Instantiate( element.prefab, element.parent ).transform;
		}

		obj.gameObject.layer = element.prefab.layer;

		if( element.parent != null )
		{
			obj.localRotation = Quaternion.identity;
			obj.localPosition = Vector3.zero;
		}

		if( element.detachParent )
		{
			obj.parent = null;
		}
	}
}
