using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰撞 - 角色热更数据
/// </summary>
public class HCharacterCollision : HCharacter {
	[Header("扩展功能")]
	public CharacterController controller;

	[Header("特效属性")]
	/// <summary> 武器 </summary>
	public ISpecialEffects weapon;
	/// <summary> 攻击位置1 </summary>
	public Transform Attack1;
	public Transform Attack2;
	public Transform Attack3;
	public Transform Attack4;
	public Transform Attack5;
	public Transform Attack6;
}
