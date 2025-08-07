using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰撞 - 角色热更数据
/// </summary>
public class HotCharacterCollision : HotCharacter {
	[Header("扩展功能")]
	/// <summary> 控制器 </summary>
	public CharacterController controller;

	[Header("特效属性")]
	/// <summary> 连击 </summary>
	public HCombo combo;
	/// <summary> 武器 </summary>
	public HWeapon weapon;
}
