using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 複数条件に対応可能なコンポーネント.
	/// </summary>
	public class ConditionerInclusion : Conditioner
	{
		public enum ConditionType : int
		{
			And = 0,
			Or,
		}

		[System.Serializable]
		public class Data
		{
			public Conditioner Conditioner{ get{ return this.refConditioner; } }
			[SerializeField]
			private Conditioner refConditioner;

			public ConditionType ConditionType{ get{ return this.type; } }
			[SerializeField]
			private ConditionType type;
		}

		[SerializeField]
		private List<Data> database;

		public override bool Condition
		{
			get
			{
				bool result = this.database[0].Conditioner.Condition;
				for( int i=1, imax=this.database.Count; i<imax; i++ )
				{
					var conditionType = this.database[i-1].ConditionType;
					if( conditionType == ConditionType.And )
					{
						result = result && this.database[i].Conditioner.Condition;
					}
					else
					{
						result = result || this.database[i].Conditioner.Condition;
					}
				}

				return result;
			}
		}
	}
}
