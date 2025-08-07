using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准角色 - 控制器
/// </summary>
public class ControlCharacterStandard : ControlCharacter {

	public ModuleCharacter mCharacter;
	public HotCharacterStandard hCharacter;
	public MovementStandard movement;

	public override ModuleCharacter MCharacter => mCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		hCharacter = GetComponent<HotCharacterStandard>();
		hCharacter.func = this;
		moveSpeed = hCharacter.moveSpeed;
		sprintSpeed = hCharacter.sprintSpeed;
		acceleration = hCharacter.acceleration;
		jumpHeight = hCharacter.jumpHeight;
		// 创建运动器
		movement = new MovementStandard(transform, hCharacter.ground);
		movement.Settings(position, eulerAngles);
		// 创建角色模型
		mCharacter = new ModuleCharacter();
		mCharacter.Settings(hCharacter.animator, movement, new CommandIdle());
	}

	public override void Trigger(string value) {
		throw new System.NotImplementedException();
	}
	public override void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured) {
		throw new System.NotImplementedException();
	}
}
