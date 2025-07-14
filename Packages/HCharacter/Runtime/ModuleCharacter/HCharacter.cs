using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色热更数据
/// </summary>
public abstract class HCharacter : MonoBehaviour {
	[Header("基本组件")]
	/// <summary> 地面图层 </summary>
	public LayerMask ground;
	/// <summary> 动画器 </summary>
	public Animator animator;
	[Header("运动属性")]
	/// <summary> 移动速度 </summary>
	public float moveSpeed = 2;
	/// <summary> 冲刺速度 </summary>
	public float sprintSpeed = 5.5f;
	/// <summary> 加速度 </summary>
	public float acceleration = 15;
	/// <summary> 跳跃高度 </summary>
	public float jumpHeight = 2;

	/// <summary> 动画事件 </summary>
	public IAnimationEvents animationEvents;
	/// <summary> 动画进入触发 </summary>
	public virtual void EnterTrigger(string value) => animationEvents?.ExitTrigger(value);
	/// <summary> 动画退出触发 </summary>
	public virtual void ExitTrigger(string value) => animationEvents?.ExitTrigger(value);
	/// <summary> 动画结束 </summary>
	public virtual void AnimationExit(string value) => animationEvents?.AnimationExit(value);
}
