using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 碰撞 - 角色控制器
/// </summary>
public class ControlCharacterCollision : ControlCharacter {

	public ModuleCharacter mCharacter;
	public HotCharacterCollision hCharacter;
	public MovementCollision movement;

	public override ModuleCharacter MCharacter => mCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		// 载入功能
		hCharacter = GetComponent<HotCharacterCollision>();
		hCharacter.func = this;
		moveSpeed = hCharacter.moveSpeed;
		sprintSpeed = hCharacter.sprintSpeed;
		acceleration = hCharacter.acceleration;
		jumpHeight = hCharacter.jumpHeight;
		// 创建运动器
		movement = new MovementCollision(hCharacter.controller, hCharacter.ground);
		movement.Settings(position, eulerAngles);
		// 创建角色模型
		mCharacter = new ModuleCharacter();
		mCharacter.Settings(hCharacter.animator, movement, new CommandIdle());
	}
	public override void Trigger(string value) {
		Transform combo = hCharacter.combo.Get(value);
		if (combo == null) { return; }
		Transform prefab = hCharacter.weapon.effects.transform;
		ModuleVisual.I.HEffects.CreateVisual(prefab).Settings(combo);
	}
	public override void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured) {
		mCharacter.Settings(token, isTransition, isFloating, isInjured);
	}

	// 绘制地面检测
	private void OnDrawGizmos() {
		float groundedRadius = hCharacter.controller.radius;
		Vector3 position = transform.position;
		Vector3 spherePosition = new Vector3(position.x, position.y + groundedRadius, position.z);
		Gizmos.DrawWireSphere(spherePosition, groundedRadius + 0.05f);
	}
}
