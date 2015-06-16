/*===========================================================================*/
/*
*     * FileName    : MyMonoBehaviour.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class MyMonoBehaviour : MonoBehaviour
{
	public static void BroadcastMessage( MonoBehaviour sender, string methodName )
	{
		#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>Broadcast[{1}]</color>",
			sender.gameObject.name,
			methodName
			),
			sender
			);
		#endif
		sender.BroadcastMessage( methodName, SendMessageOptions.DontRequireReceiver );
	}
	public static void BroadcastMessage( GameObject sender, string methodName )
	{
		#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>Broadcast[{1}]</color>",
			sender.name,
			methodName
			),
			sender
			);
		#endif
		sender.BroadcastMessage( methodName, SendMessageOptions.DontRequireReceiver );
	}
	public static void BroadcastMessage( MonoBehaviour sender, string methodName, object parameter )
	{
		#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>Broadcast[{1}]</color> <color=yellow>parameter[{2}]</color>",
			sender.gameObject.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
		#endif
		sender.BroadcastMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
	}
	public static void BroadcastMessage( GameObject sender, string methodName, object parameter )
	{
		#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>Broadcast[{1}]</color> <color=yellow>parameter[{2}]</color>",
			sender.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
		#endif
		sender.BroadcastMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
	}

	public static void SendMessage( MonoBehaviour sender, string methodName )
	{
#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>SendMessage[{1}]</color>",
			sender.gameObject.name,
			methodName
			),
			sender
			);
#endif
		sender.SendMessage( methodName, SendMessageOptions.DontRequireReceiver );
	}

	public static void SendMessage( MonoBehaviour sender, string methodName, object parameter )
	{
#if DEBUG
		Debug.Log(
			string.Format(
			"<color=red>Sender[{0}]</color> <color=blue>SendMessage[{1}]</color> <color=yellow>parameter[{2}]</color>",
			sender.gameObject.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
#endif
		sender.SendMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
	}
	
	public static void TODO( string message )
	{
		Debug.Log(
			string.Format(
			"<color=magenta>TODO[{0}]</color>",
			message
			)
			);
	}

	public GameObject Instantiate( GameObject prefab, Transform parent )
	{
		var obj = Instantiate( prefab ) as GameObject;
		obj.transform.parent = parent;
		obj.transform.localPosition = prefab.transform.localPosition;
		obj.transform.localScale = prefab.transform.localScale;
		obj.transform.localRotation = prefab.transform.localRotation;

		return obj;
	}
}
