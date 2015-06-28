using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 通常攻撃に必要なデータを格納するクラス.
	/// </summary>
	public class AttackData : MyMonoBehaviour
	{
		/// <summary>
		/// 攻撃可能回数.
		/// </summary>
		/// <value>The number.</value>
		public int Number{ private set; get; }

		public void CalcurlateNumber( BattleMemberData member )
		{
			Development.TODO( "攻撃回数の計算処理の実装." );

			this.Number = Random.Range( 0, 100 ) < 10 ? 2 : 1;
		}

		public void Attacked()
		{
			this.Number--;
		}

		/// <summary>
		/// 連続攻撃であるか返す.
		/// </summary>
		/// <value><c>true</c> if this instance is continuity attack; otherwise, <c>false</c>.</value>
		public bool IsContinuityAttack
		{
			get
			{
				return this.Number > 1;
			}
		}

		/// <summary>
		/// 攻撃可能であるか返す.
		/// </summary>
		/// <value><c>true</c> if this instance can attack; otherwise, <c>false</c>.</value>
		public bool CanAttack
		{
			get
			{
				return this.Number > 0;
			}
		}
	}
}
