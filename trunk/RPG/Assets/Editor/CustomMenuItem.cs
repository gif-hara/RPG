/*===========================================================================*/
/*
*     * FileName    : CustomMenuItem.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class CustomMenuItem : MonoBehaviour
{
	[MenuItem("RPG/Selection Test %#q")]
	static void SelectionTest()
	{
		Selection.activeInstanceID = -268314;
		Debug.Log( Selection.activeInstanceID );
	}

	[MenuItem("RPG/Scene/Open Battle %#1")]
	static void GotoBattleScene()
	{
		AssetDatabase.OpenAsset( 13642 );
	}
	
	[MenuItem("RPG/Scene/Open WorldMap %#2")]
	static void GotoWorldMapScene()
	{
		AssetDatabase.OpenAsset( 13644 );
	}
	
	[MenuItem("RPG/Debug/Output InstanceID")]
	static void OutputInstanceId()
	{
		Debug.Log( Selection.activeInstanceID );
	}
}
