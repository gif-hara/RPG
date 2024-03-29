﻿/*===========================================================================*/
/*
*     * FileName    : SceneManager.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

/// <summary>
/// .
/// </summary>
public class SceneManager : A_Singleton<SceneManager>
{
	public enum EffectType : int
	{
		Default,
		Fast,
	}

	public class EventCatchData
	{
		private int count = 0;

		public void Catch()
		{
			count++;
		}

		public void Release()
		{
			count--;
		}

		public bool IsEndEvent
		{
			get
			{
				return count <= 0;
			}
		}
	}

	[SerializeField]
	private List<GameObject> prefabStartChangeEffectList;

	[SerializeField]
	private List<GameObject> prefabEndChangeEffectList;

	/// <summary>
	/// 親オブジェクト参照.
	/// </summary>
	[SerializeField]
	private GameObject refParentObject;

	/// <summary>
	/// シーン開始演出をする際のメッセージ.
	/// </summary>
	public const string StartEffectMessage = "OnStartSceneEffect";

	public bool CanChange
	{
		get
		{
			return isChanging == false;
		}
	}
	private bool isChanging = false;

	void Awake ()
	{
		Instance = this;
	}

	public void Change( EffectType startEffectType, EffectType endEffectType, string sceneName )
	{
		if( isChanging )
		{
			return;
		}
		StartCoroutine( ChangeCoroutine( startEffectType, endEffectType, sceneName ) );
	}

	private IEnumerator ChangeCoroutine( EffectType startEffectType, EffectType endEffectType, string sceneName )
	{
		isChanging = true;
		var obj = Instantiate( prefabStartChangeEffectList[(int)startEffectType] ) as GameObject;
		obj.transform.parent = transform;
		EventCatchData data = new EventCatchData();
		obj.BroadcastMessage( StartEffectMessage, data );

		while( !data.IsEndEvent )
		{
			yield return new WaitForEndOfFrame();
		}

		this.refParentObject.BroadcastMessage( TypeConstants.ChangeSceneMessage, sceneName, SendMessageOptions.DontRequireReceiver );
		Application.LoadLevel( sceneName );

		Destroy( obj );

		obj = Instantiate( prefabEndChangeEffectList[(int)endEffectType] ) as GameObject;
		obj.transform.parent = transform;
		data = new EventCatchData();
		obj.BroadcastMessage( StartEffectMessage, data );

		while( !data.IsEndEvent )
		{
			yield return new WaitForEndOfFrame();
		}

		Destroy( obj );
		isChanging = false;
	}
}
