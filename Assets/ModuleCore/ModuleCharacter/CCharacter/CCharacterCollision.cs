using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 碰撞 - 角色控制器
/// </summary>
public class CCharacterCollision : CCharacter, ICharacterFunc {

	public DataCharacter dCharacter;
	public MCharacter mCharacter;
	public HCharacterCollision hCharacter;
	public MovementCollision movement;

	public override MCharacter MCharacter => mCharacter;
	public override DataCharacter DCharacter => dCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		hCharacter = GetComponent<HCharacterCollision>();
		// 创建运动器
		movement = new MovementCollision(hCharacter.controller, hCharacter.ground);
		// 创建角色模型
		mCharacter = new MCharacter(hCharacter.animator, movement);
		mCharacter.movement.Settings(position, eulerAngles);
		// 载入功能
		hCharacter.func = this;
		// 载入数据
		dCharacter = new DataCharacter(hCharacter);
	}
	private void Update() {
		mCharacter.Update();
	}

	void OnDrawGizmos() {
		float groundedRadius = hCharacter.controller.radius;
		Vector3 position = transform.position;
		Vector3 spherePosition = new Vector3(position.x, position.y + groundedRadius, position.z);
		Gizmos.DrawWireSphere(spherePosition, groundedRadius + 0.05f);
	}

	public void EnterTrigger(string value) {
		Transform attack = null;
		if (value == "1") { attack = hCharacter.Attack1; }
		if (value == "2") { attack = hCharacter.Attack2; }
		if (value == "3") { attack = hCharacter.Attack3; }
		if (value == "4") { attack = hCharacter.Attack4; }
		if (attack == null) { return; }
		Transform temp = Instantiate(hCharacter.weapon.effects);
		temp.position = attack.position;
		temp.eulerAngles = attack.eulerAngles;
	}

	public void ExitTrigger(string value) {
		// hCharacter.weapon?.Close();
	}

	public void AnimationExit(string value) {
		// mCharacter.AnimationExit();
	}

	public void SettingsState(bool isTransition, bool isFloating, bool isInjured) {
		// throw new System.NotImplementedException();
	}
}
