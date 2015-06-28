/// <summary>
/// デバッグクラス.
/// </summary>
public static class Debug
{
	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void Assert( bool condition, string message )
	{
		Assert( condition, message, null );
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void Assert( bool condition, string message, UnityEngine.Object context )
	{
		if( !condition )
		{
			UnityEngine.Debug.LogException( new System.Exception( message ), context );
		}
	}

	public static void Log( object message )
	{
		UnityEngine.Debug.Log( message );
	}

	public static void Log( object message, UnityEngine.Object context )
	{
		UnityEngine.Debug.Log( message, context );
	}

	public static void LogWarning( object message )
	{
		UnityEngine.Debug.LogWarning( message );
	}
	
	public static void LogWarning( object message, UnityEngine.Object context )
	{
		UnityEngine.Debug.LogWarning( message, context );
	}

	public static void LogError( object message )
	{
		UnityEngine.Debug.LogError( message );
	}
	
	public static void LogError( object message, UnityEngine.Object context )
	{
		UnityEngine.Debug.LogError( message, context );
	}

	public static void LogException( System.Exception exception )
	{
		UnityEngine.Debug.LogException( exception );
	}
	
	public static void LogException( System.Exception exception, UnityEngine.Object context )
	{
		UnityEngine.Debug.LogException( exception, context );
	}

	public static void DrawLine( UnityEngine.Vector3 start, UnityEngine.Vector3 end )
	{
		UnityEngine.Debug.DrawLine( start, end );
	}

	public static void DrawLine( UnityEngine.Vector3 start, UnityEngine.Vector3 end, UnityEngine.Color color )
	{
		UnityEngine.Debug.DrawLine( start, end, color );
	}

	public static bool isDebugBuild
	{
		get
		{
			return UnityEngine.Debug.isDebugBuild;
		}
	}
}
