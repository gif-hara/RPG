using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// パーティ.
	/// </summary>
	public class Party<TBattleMember> where TBattleMember : BattleCharacter
	{
		public List<TBattleMember> List{ private set; get; }

		public GroupList GroupList{ private set; get; }
		
		public Party()
		{
			this.List = new List<TBattleMember>();
			this.GroupList = new GroupList();
		}
		
		public void Add( TBattleMember data )
		{
			this.List.Add( data );
			this.GroupList.Add( data );
		}

		public void Rename()
		{
			this.GroupList.Rename();
		}

		/// <summary>
		/// 全滅しているか？.
		/// </summary>
		/// <value><c>true</c> if this instance is all dead; otherwise, <c>false</c>.</value>
		public bool IsAllDead
		{
			get
			{
				return this.List.Find( m => !m.IsDead ) == null;
			}
		}

		/// <summary>
		/// 誰かしらアクティブタイムが最大値に達しているか？.
		/// </summary>
		/// <value><c>true</c> if any active time max; otherwise, <c>false</c>.</value>
		public bool IsAnyActiveTimeMax
		{
			get
			{
				return ActiveTimeMaxBattleMember != null;
			}
		}
		
		/// <summary>
		/// アクティブタイムが最大のバトルメンバーを返す.
		/// </summary>
		/// <value>The active time max ally data.</value>
		public TBattleMember ActiveTimeMaxBattleMember
		{
			get
			{
				return List.Find( a => !a.IsDead && a.IsActiveTimeMax );
			}
		}
		
		/// <summary>
		/// 誰かしらのバトルメンバーがコマンドを選択していないか返す.
		/// </summary>
		/// <value><c>true</c> if this instance is any none command; otherwise, <c>false</c>.</value>
		public bool IsAnyNoneCommand
		{
			get
			{
				return NoneCommandBattleMember != null;
			}
		}
		
		/// <summary>
		/// コマンド選択していないバトルメンバーを返す.
		/// </summary>
		/// <value>The none command ally data.</value>
		public TBattleMember NoneCommandBattleMember
		{
			get
			{
				return List.Find( a => a.SelectCommandType == TypeConstants.CommandType.None );
			}
		}
	}
}
