using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 碰撞 - 角色控制器
/// </summary>
public class CCharacterCollision : CCharacter, IAnimationEvents {

	public DataCharacter dCharacter;
	public HCharacterCollision hCharacter;
	public MCharacterCollision mCharacter;

	public override MCharacter MCharacter => mCharacter;
	public override DataCharacter DCharacter => dCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		hCharacter = GetComponent<HCharacterCollision>();
		mCharacter = new MCharacterCollision(hCharacter.animator, hCharacter.controller, hCharacter.ground);
		mCharacter.movement.Settings(position, eulerAngles);
		hCharacter.animationEvents = this;

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

	public void EnterTrigger() {
		hCharacter.weapon?.Open();
	}

	public void ExitTrigger() {
		hCharacter.weapon?.Close();
	}

	public void AnimationExit() {
		mCharacter.AnimationExit();
	}
}
