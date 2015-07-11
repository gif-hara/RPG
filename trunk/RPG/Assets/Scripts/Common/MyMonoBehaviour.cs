using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Framework;

/// <summary>
/// RPG用のMonoBehaviourクラス.
/// </summary>
public class MyMonoBehaviour : MonoBehaviour
{
	public static void BroadcastMessage( MonoBehaviour sender, string methodName )
	{
		#if DEBUG
		Debug.Log(
			string.Format(
				@"{0}{1}.BroadcastMessage( ""{2}"" );",
				LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
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
			@"{0}{1}.BroadcastMessage( ""{2}"" );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
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
			@"{0}{1}.BroadcastMessage( ""{2}"", {3} );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
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
			@"{0}{1}.BroadcastMessage( ""{2}"", {3} );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
			sender.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
		#endif
		sender.BroadcastMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
	}

	public static void SendMessage( GameObject sender, string methodName )
	{
#if DEBUG
		Debug.Log(
			string.Format(
			@"{0}{1}.BroadcastMessage( ""{2}"" );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
			sender.gameObject.name,
			methodName
			),
			sender
			);
#endif
		sender.SendMessage( methodName, SendMessageOptions.DontRequireReceiver );
	}

	public static void SendMessage( GameObject sender, string methodName, object parameter )
	{
#if DEBUG
		Debug.Log(
			string.Format(
			@"{0}{1}.BroadcastMessage( ""{2}"", {3} );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
			sender.gameObject.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
#endif
		sender.SendMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
	}

	public static void SendMessage( MonoBehaviour sender, string methodName )
	{
#if DEBUG
		Debug.Log(
			string.Format(
			@"{0}{1}.BroadcastMessage( ""{2}"" );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
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
			@"{0}{1}.BroadcastMessage( ""{2}"", {3} );",
			LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Message ),
			sender.gameObject.name,
			methodName,
			parameter.ToString()
			),
			sender
			);
#endif
		sender.SendMessage( methodName, parameter, SendMessageOptions.DontRequireReceiver );
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
