using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色处理器
/// </summary>
public abstract class CharacterHandle {
	/// <summary> 角色控制器 </summary>
	public abstract ControlCharacter Control { get; }
	/// <summary> 完成转换 </summary>
	public abstract bool IsTransition { get; }
	/// <summary> 更新指令 </summary>
	public abstract void Update();
	/// <summary> 指令：创建 </summary>
	public abstract void Create();
	/// <summary> 指令：移动 </summary>
	public abstract void Move(Vector2 moveInput, bool isSprint);
	/// <summary> 指令：跳跃 </summary>
	public abstract void Jump();
	/// <summary> 指令：攻击 </summary>
	public abstract void Attack(bool isAttack);
}
