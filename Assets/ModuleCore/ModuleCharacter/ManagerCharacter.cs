using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 玩家管理器
/// </summary>
public class ManagerCharacter : ModuleSingle<ManagerCharacter> {

	/// <summary> 标准处理器 </summary>
	public CharacterHandleStandard standardHandle;

	/// <summary> 当前角色处理器 </summary>
	public ICharacterHandle handle => standardHandle;
	/// <summary> 当前玩家控制器 </summary>
	public ControlCharacter CurrentControl => handle.Control;
	/// <summary> 完成转换 </summary>
	public bool IsTransition => handle.IsTransition;

	protected override void Awake() {
		NoReplace(false);
		standardHandle = new CharacterHandleStandard();
	}

	public void Update() => standardHandle.Update();

	#region 单机
	/// <summary> 创建角色 </summary>
	public void Create() => handle.Create();
	#endregion

	#region 输入
	/// <summary> 玩家操作：移动 </summary>
	public void Move(Vector2 moveDirection, bool isSprint) => handle.Move(moveDirection, isSprint);
	/// <summary> 玩家操作：跳跃 </summary>
	public void Jump() => handle.Jump();
	/// <summary> 玩家操作：攻击 </summary>
	public void Attack(bool isAttack) => handle.Attack(isAttack);
	#endregion
}

