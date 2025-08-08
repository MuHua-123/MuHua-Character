using System.Collections;
using System.Collections.Generic;
using MuHua;
using UnityEngine;

/// <summary>
/// 简单 - 角色控制器
/// </summary>
public class CharacterControlSimple : CharacterControl {

	[Header("角色组件")]
	/// <summary> 控制器 </summary>
	public CharacterController controller;
	/// <summary> 地面图层 </summary>
	public LayerMask ground;

	public SimpleCharacter mCharacter;
	public override CharacterModel MCharacter => mCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		// 创建运动器
		MovementCollision movement = new MovementCollision(controller, ground);
		movement.Settings(position, eulerAngles);
		// 创建角色模型
		mCharacter = new SimpleCharacter();
		mCharacter.Settings(null, movement, new CommandIdle());
	}
	public override void Trigger(string value) {
		// throw new System.NotImplementedException();
	}
	public override void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured) {
		mCharacter.Settings(token, isTransition, isFloating, isInjured);
	}
}
