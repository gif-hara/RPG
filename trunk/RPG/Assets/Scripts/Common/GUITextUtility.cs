/*===========================================================================*/
/*
*     * FileName    : GUITextUtility.cs
*
*     * Description : GUITextユーティリティクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class GUITextUtility : MonoBehaviour
{
	public Color color = new Color( 0.0f, 0.0f, 0.0f, 1.0f );
	
	private GUIText myGUIText;
	
	// Use this for initialization
	void Start()
	{
		myGUIText = GetComponent<GUIText>();
		
		myGUIText.material.color = color;
	}
}
/* End of file ==============================================================*/
