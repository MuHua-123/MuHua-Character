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
	/// <summary> 连击 </summary>
	public ComboComponent combo;
	/// <summary> 武器 </summary>
	public WeaponComponent weapon;
}
