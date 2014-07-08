/*===========================================================================*/
/*
*     * FileName    : DebugSystem.cs
*
*     * Description : デバッグシステムクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections.Generic;

public class DebugSystem : MonoBehaviour
{
	[System.Serializable]
	public class DebugGUIOption
	{
		public int logCount = 10;
		public int fontSize = 12;
	}
	
	public GUIText debugGUI;
	
	public DebugGUIOption debugGUIOption;
	
	private List<string> logList = new List<string>();
	
	private static DebugSystem instance;
	
	// Use this for initialization
	void Awake()
	{
		instance = this;
		//InitDebugGUI();
		ClearLog();
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	
	public static void Log( object obj )
	{
		if( !Debug.isDebugBuild )	return;
		
		if( instance.debugGUI == null )
		{
			Debug.LogError( "There is no debugGUI" );
			return;
		}
		
		instance.logList.Add( obj.ToString() );
		if( instance.logList.Count >= instance.debugGUIOption.logCount )
		{
			instance.logList.RemoveAt( 0 );
		}
		instance.Repaint();
	}
	public static void Log( string format, params object[] objs )
	{
		Log( string.Format( format, objs ) );
	}
	
	public static void ClearLog()
	{
		if( instance.debugGUI == null )	return;
		
		instance.debugGUI.text = "";
	}
	
	private void InitDebugGUI()
	{
		if( debugGUI == null )	return;
		
		debugGUI.fontSize = debugGUIOption.fontSize;
	}
	
	private void Repaint()
	{
		instance.debugGUI.text = "";
		
		for( int i=0; i<instance.logList.Count; i++ )
		{
			instance.debugGUI.text += instance.logList[i] + System.Environment.NewLine;
		}
	}
}
/* End of file ==============================================================*/
