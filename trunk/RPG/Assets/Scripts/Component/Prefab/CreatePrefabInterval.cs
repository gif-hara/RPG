/*===========================================================================*/
/*
*     * FileName    : CreatePrefabInterval.cs
*
*     * Description : 一定間隔でプレハブを生成するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

public class CreatePrefabInterval : MyMonoBehaviour, I_Poolable
{
	/// <summary>
	/// 親オブジェクト参照.
	/// </summary>
	[SerializeField]
	private Transform refParent;
	
	/// <summary>
	/// 生成した時に親を外すか.
	/// </summary>
	[SerializeField]
	private bool isParentDetach;
	
	/// <summary>
	/// 生成するプレハブ.
	/// </summary>
	[SerializeField]
	private List<GameObject> prefabList;
	
	/// <summary>
	/// 生成最低値.
	/// </summary>
	[SerializeField]
	public Vector2 min;
	
	/// <summary>
	/// 生成最大値.
	/// </summary>
	[SerializeField]
	public Vector2 max;
	
	/// <summary>
	/// 生成間隔.
	/// </summary>
	[SerializeField]
	public int interval;
	
	/// <summary>
	/// 生成する回数.
	/// </summary>
	[SerializeField]
	public int createNum;

	[SerializeField]
	private CommonDefine.CreateType createType = CommonDefine.CreateType.Instantiate;
	
	private int currentInterval = 0;

	private int cachedCreateNum;

	// Update is called once per frame
	void Update()
	{
		if( currentInterval >= interval )
		{
			Vector3 pos = new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0.0f );

			Transform obj = null;

			if( this.createType == CommonDefine.CreateType.Instantiate )
			{
				obj = Instantiate( prefabList[Random.Range( 0, prefabList.Count)], transform ).transform;
			}
			else
			{
				obj = ObjectPool.Instance.GetGameObject( prefabList[Random.Range( 0, prefabList.Count)] ).transform;
				obj.parent = transform;
			}

			obj.localPosition = pos;
			
			if( isParentDetach )
			{
				obj.parent = null;
			}
			else
			{
				obj.parent = refParent;
			}
			currentInterval = 0;
			createNum--;
			if( createNum <= 0 )
			{
				enabled = false;
			}
			return;
		}
		
		currentInterval++;
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			if( refParent == null )
			{
				refParent = transform;
			}

			this.cachedCreateNum = this.createNum;
		}
		else
		{
			this.createNum = this.cachedCreateNum;
		}

		this.enabled = true;
		this.currentInterval = 0;
	}

	public void OnReleaseByPool()
	{

	}
	
	void OnDrawGizmosSelected()
	{
		if( !enabled )	return;
		
		var center = refParent == null ? Vector3.zero : refParent.position;
		
		// 左.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + min.x, center.y + max.y, 0.0f ) );
		
		// 上.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + min.y, 0.0f ) );
		
		// 右.
		Gizmos.DrawLine( new Vector3( center.x + max.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
		
		// 下.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + max.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
	}
}