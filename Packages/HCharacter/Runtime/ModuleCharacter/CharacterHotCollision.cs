using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰撞 - 角色热更数据
/// </summary>
public class CharacterHotCollision : CharacterHot {
	[Header("组件")]
	/// <summary> 地面图层 </summary>
	public LayerMask ground;
	/// <summary> 动画器 </summary>
	public Animator animator;
	/// <summary> 控制器 </summary>
	public CharacterController controller;
	/// <summary> 连击 </summary>
	public HCombo combo;
	/// <summary> 武器 </summary>
	public HWeapon weapon;

	[Header("属性")]
	/// <summary> 移动速度 </summary>
	public float moveSpeed = 2;
	/// <summary> 冲刺速度 </summary>
	public float sprintSpeed = 5.5f;
	/// <summary> 加速度 </summary>
	public float acceleration = 15;
	/// <summary> 跳跃高度 </summary>
	public float jumpHeight = 2;
}
