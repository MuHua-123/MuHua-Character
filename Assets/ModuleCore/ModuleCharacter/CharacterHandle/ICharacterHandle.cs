using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色处理器
/// </summary>
public interface ICharacterHandle {
	/// <summary> 角色控制器 </summary>
	public ControlCharacter Control { get; }
	/// <summary> 完成转换 </summary>
	public bool IsTransition { get; }
	/// <summary> 指令：创建 </summary>
	public void Create();
	/// <summary> 指令：移动 </summary>
	public void Move(Vector2 moveInput, bool isSprint);
	/// <summary> 指令：跳跃 </summary>
	public void Jump();
	/// <summary> 指令：攻击 </summary>
	public void Attack(bool isAttack);
}
