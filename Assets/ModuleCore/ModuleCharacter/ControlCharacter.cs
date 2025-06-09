using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色控制器
/// </summary>
public abstract class ControlCharacter : MonoBehaviour {

	[Header("移动功能")]
	/// <summary> 移动速度 </summary>
	public float moveSpeed;
	/// <summary> 加速度 </summary>
	public float acceleration;

	/// <summary> 角色模块 </summary>
	public abstract MCharacter MCharacter { get; }
}
