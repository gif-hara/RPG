﻿//================================================
/*!
    @file   MeshUVOffset.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshUVOffset : MyMonoBehaviour
{
	public GameObject refDestroyObject;
	
	public MeshFilter refMesh;
		
	public int tileX;
	
	public int tileY;
	
	public int interval;
	
	public bool loop;
	
	private Mesh mesh;
	
	private int timer = 0;
	
	private int offset = 0;
	
	private float intervalX = 0.0f;
	
	private float intervalY = 0.0f;
		
	// Use this for initialization
	void Start()
	{
		mesh = refMesh.mesh;
		Initialize();
		UpdateUv();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( timer >= interval )
		{
			offset++;
			if( !loop && offset >= (tileX * tileY) )
			{
				Destroy( refDestroyObject );
				refMesh.gameObject.SetActive( false );
				enabled = false;
			}
			UpdateUv();
			timer = 0;
			return;
		}
		timer++;
	}
	
	void OnDestroy()
	{
		Destroy( mesh );
	}
	
	private void Initialize()
	{
		intervalX = 1.0f / tileX;
		intervalY = 1.0f / tileY;
	}
	
	private void UpdateUv()
	{
		float left = intervalX * (offset % tileX);
		float top = 1.0f - (intervalY * (float)(offset / tileX));
		float right = (intervalX * (offset % tileX)) + intervalX;
		float bottom = 1.0f - (intervalY * (float)((offset / tileX) + 1));
		
		Vector2[] uvList = new Vector2[4];
		uvList[0] = new Vector2( left, bottom );
		uvList[1] = new Vector2( right, bottom );
		uvList[2] = new Vector2( left, top );
		uvList[3] = new Vector2( right, top );
		mesh.uv = uvList;
	}
}
