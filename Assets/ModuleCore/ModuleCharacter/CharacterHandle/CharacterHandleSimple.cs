using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 简单 - 角色处理器
/// </summary>
public class CharacterHandleSimple : CharacterHandle {

	public ControlCharacter control;
	public Func<bool> baseMotionTransition;

	public override ControlCharacter Control => control;
	public override bool IsTransition => baseMotionTransition == null;

	public override void Update() {
		if (baseMotionTransition == null) { return; }
		if (baseMotionTransition()) { baseMotionTransition = null; }
	}

	public override void Create() {
		ModuleVisual.I.ControllerControlCharacter.UpdateVisual(ref control);
	}

	public override void Move(Vector2 moveInput, bool isSprint) {
		baseMotionTransition = () => Move(control, moveInput, isSprint, true);
	}
	public static bool Move(ControlCharacter control, Vector2 moveDirection, bool isSprint, bool isRotation) {
		CommandSimpleMove move = new CommandSimpleMove(control.MCharacter, moveDirection, isRotation);
		float moveSpeed = isSprint ? control.sprintSpeed : control.moveSpeed;
		move.Settings(moveSpeed, control.acceleration);
		return control.MCharacter.Transition(move);
	}

	public override void Jump() {
		baseMotionTransition = () => Jump(control);
	}
	public static bool Jump(ControlCharacter control) {
		CommandSimpleJump jump = new CommandSimpleJump(control.MCharacter, control.jumpHeight);
		return control.MCharacter.Transition(jump);
	}

	public override void Attack(bool isAttack) {
		// baseMotionTransition = () => Attack(control, isAttack);
	}
	public static bool Attack(ControlCharacter control, bool isAttack) {
		CommandAttack attack = new CommandAttack(control.MCharacter, isAttack);
		return control.MCharacter.Transition(attack);
	}
}
