/*===========================================================================*/
/*
*     * FileName    : MeshColorSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshColorSetter : MyMonoBehaviour
{
	public MeshFilter refMeshFilter;
	
	public Color color;

	private MeshColorManager meshManager;

	[ContextMenu( "AttachMeshFilter" )]
	void AttachMeshFilter()
	{
		this.refMeshFilter = GetComponent( typeof( MeshFilter ) ) as MeshFilter;
	}

	// Use this for initialization
	void Start()
	{
		if( refMeshFilter == null )
		{
			refMeshFilter = GetComponent<MeshFilter>();
		}

		meshManager = new MeshColorManager();
		meshManager.Initialize( refMeshFilter );
		meshManager.SetColor( color );
	}
}
