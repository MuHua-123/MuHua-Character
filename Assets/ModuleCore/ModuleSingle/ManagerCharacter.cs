using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 玩家管理器
/// </summary>
public class ManagerCharacter : ModuleSingle<ManagerCharacter> {

	/// <summary> 单机玩家 </summary>
	public SingleCharacterHandle singleHandle;

	/// <summary> 当前角色处理器 </summary>
	public ICharacterHandle handle => singleHandle;
	/// <summary> 当前玩家控制器 </summary>
	public CCharacter CurrentControl => handle.Control;

	protected override void Awake() {
		NoReplace(false);
		singleHandle = new SingleCharacterHandle();
	}

	public void Update() => singleHandle.Update();

	#region 单机
	/// <summary> 创建角色 </summary>
	public void Create() => handle.Create();
	#endregion

	#region 输入
	/// <summary> 玩家操作：移动 </summary>
	public void Move(Vector2 moveDirection) => handle.Move(moveDirection);
	/// <summary> 冲刺 </summary>
	public void Sprint(Vector2 moveDirection) => handle.Sprint(moveDirection);
	/// <summary> 玩家操作：跳跃 </summary>
	public void Jump(Vector2 moveDirection) => handle.Jump(moveDirection);
	/// <summary> 玩家操作：攻击 </summary>
	public void Attack(bool isAttack) => handle.Attack(isAttack);
	#endregion
}
/// <summary>
/// 角色处理器
/// </summary>
public interface ICharacterHandle {
	/// <summary> 角色控制器 </summary>
	public CCharacter Control { get; }
	/// <summary> 创建 </summary>
	public void Create();
	/// <summary> 移动 </summary>
	public void Move(Vector2 moveInput);
	/// <summary> 冲刺 </summary>
	public void Sprint(Vector2 moveInput);
	/// <summary> 跳跃 </summary>
	public void Jump(Vector2 moveInput);
	/// <summary> 攻击 </summary>
	public void Attack(bool isAttack);
}
/// <summary>
/// 单机 - 角色处理器
/// </summary>
public class SingleCharacterHandle : ICharacterHandle {

	public CCharacter control;
	public Func<bool> baseMotionTransition;

	public CCharacter Control => control;

	public void Update() {
		if (baseMotionTransition == null) { return; }
		if (baseMotionTransition()) { baseMotionTransition = null; }
	}
	public void Create() {
		ModuleCharacter.CreateCharacter(ref control);
	}
	public void Move(Vector2 moveInput) {
		baseMotionTransition = () => control.Move(moveInput, true);
	}
	public void Sprint(Vector2 moveInput) {
		baseMotionTransition = () => control.Sprint(moveInput, true);
	}
	public void Jump(Vector2 moveInput) {
		baseMotionTransition = () => control.Jump(moveInput, true);
	}
	public void Attack(bool isAttack) {
		baseMotionTransition = () => control.Attack(isAttack);
	}
}
