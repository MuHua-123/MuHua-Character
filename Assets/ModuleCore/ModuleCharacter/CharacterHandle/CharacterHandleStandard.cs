using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准 - 角色处理器
/// </summary>
public class CharacterHandleStandard : CharacterHandle {

	public CharacterControl control;
	public Func<bool> baseMotionTransition;

	public override CharacterControl Control => control;
	public override bool IsTransition => baseMotionTransition == null;

	public override void Update() {
		if (baseMotionTransition == null) { return; }
		if (baseMotionTransition()) { baseMotionTransition = null; }
	}

	public override void Create() {
		ModuleVisual.I.ControllerCharacterControl.UpdateVisual(ref control);
	}

	public override void Move(Vector2 moveInput, bool isSprint) {
		baseMotionTransition = () => Move(control, moveInput, isSprint, true);
	}
	public static bool Move(CharacterControl control, Vector2 moveDirection, bool isSprint, bool isRotation) {
		CommandMove move = new CommandMove(control.MCharacter, moveDirection, isRotation);
		float moveSpeed = isSprint ? control.sprintSpeed : control.moveSpeed;
		move.Settings(moveSpeed, control.acceleration);
		return control.MCharacter.Transition(move);
	}

	public override void Jump() {
		baseMotionTransition = () => Jump(control);
	}
	public static bool Jump(CharacterControl control) {
		CommandJump jump = new CommandJump(control.MCharacter, control.jumpHeight);
		return control.MCharacter.Transition(jump);
	}

	public override void Attack(bool isAttack) {
		baseMotionTransition = () => Attack(control, isAttack);
	}
	public static bool Attack(CharacterControl control, bool isAttack) {
		CommandAttack attack = new CommandAttack(control.MCharacter, isAttack);
		return control.MCharacter.Transition(attack);
	}
}
