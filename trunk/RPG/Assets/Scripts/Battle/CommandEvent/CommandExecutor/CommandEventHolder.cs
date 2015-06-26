using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドイベントを保持するコンポーネント.
	/// </summary>
	public class CommandEventHolder : MyMonoBehaviour
	{
		[System.Serializable]
		public class Data
		{
			public BattleTypeConstants.CommandType CommandType{ get{ return this.commandType; } }
			[SerializeField]
			private BattleTypeConstants.CommandType commandType;

			public CommandEventMediator PrefabMediator{ get{ return this.prefabMediator; } }
			[SerializeField]
			private CommandEventMediator prefabMediator;
		}

		[SerializeField]
		private List<Data> database;

		public GameObject Get( BattleTypeConstants.CommandType type )
		{
			var data = database.Find( e => e.CommandType == type );
			Debug.Assert( data != null, string.Format( "CommandEventMediatorがありません. {0} に対応したCommandEventMediatorが登録されているか確認してください.", type ), this );

			return data.PrefabMediator.gameObject;
		}
	}
}
