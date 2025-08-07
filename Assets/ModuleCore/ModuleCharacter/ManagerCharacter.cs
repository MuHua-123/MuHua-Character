using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色处理器类型
/// </summary>
public enum HandleType {
	Simple, Standard,
}
/// <summary>
/// 玩家管理器
/// </summary>
public class ManagerCharacter : ModuleSingle<ManagerCharacter> {

	/// <summary> 简单处理器 </summary>
	public CharacterHandleSimple simpleHandle;
	/// <summary> 标准处理器 </summary>
	public CharacterHandleStandard standardHandle;

	/// <summary> 当前角色处理器 </summary>
	public CharacterHandle handle => Handle();
	/// <summary> 当前玩家控制器 </summary>
	public ControlCharacter CurrentControl => handle.Control;
	/// <summary> 完成转换 </summary>
	public bool IsTransition => handle.IsTransition;

	protected override void Awake() {
		NoReplace(false);
		simpleHandle = new CharacterHandleSimple();
		standardHandle = new CharacterHandleStandard();
	}
	/// <summary> 设置当前处理器 </summary>
	public CharacterHandle Handle() {
		switch (SingleManager.I.handleType) {
			case HandleType.Simple: return simpleHandle;
			case HandleType.Standard: return standardHandle;
		}
		return standardHandle;
	}

	public void Update() => handle.Update();
	/// <summary> 创建角色 </summary>
	public void Create() => handle.Create();

	#region 指令
	/// <summary> 指令：移动 </summary>
	public void Move(Vector2 moveDirection, bool isSprint) => handle.Move(moveDirection, isSprint);
	/// <summary> 指令：跳跃 </summary>
	public void Jump() => handle.Jump();
	/// <summary> 指令：攻击 </summary>
	public void Attack(bool isAttack) => handle.Attack(isAttack);
	#endregion
}

