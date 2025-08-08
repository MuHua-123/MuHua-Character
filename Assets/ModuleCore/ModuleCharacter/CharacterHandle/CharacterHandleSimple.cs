using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 简单 - 角色处理器
/// </summary>
public class CharacterHandleSimple : CharacterHandle {

	public CharacterControl control;
	public Func<bool> CommandTransition;

	public override CharacterControl Control => control;
	public override bool IsTransition => CommandTransition == null;

	public override void Update() {
		if (CommandTransition == null) { return; }
		if (CommandTransition()) {
			CommandTransition = null;
			ManagerCharacter.I.currentCommand = ManagerCharacter.I.prepareCommand;
			ManagerCharacter.I.prepareCommand = "";
		}
	}

	public override void Create() {
		ModuleVisual.I.ControllerCharacterControl.UpdateVisual(ref control);
	}

	public override void Move(Vector2 moveInput, bool isSprint) {
		ManagerCharacter.I.prepareCommand = "Move";
		CommandTransition = () => Move(control, moveInput, isSprint, true);
	}
	public static bool Move(CharacterControl control, Vector2 moveDirection, bool isSprint, bool isRotation) {
		CommandSimpleMove move = new CommandSimpleMove(control.MCharacter, moveDirection, isRotation);
		float moveSpeed = isSprint ? control.sprintSpeed : control.moveSpeed;
		move.Settings(moveSpeed, control.acceleration);
		return control.MCharacter.Transition(move);
	}

	public override void Jump() {
		ManagerCharacter.I.prepareCommand = "Jump";
		CommandTransition = () => Jump(control);
	}
	public static bool Jump(CharacterControl control) {
		CommandSimpleJump jump = new CommandSimpleJump(control.MCharacter, control.jumpHeight);
		return control.MCharacter.Transition(jump);
	}

	public override void Attack(bool isAttack) {
		// baseMotionTransition = () => Attack(control, isAttack);
	}
	public static bool Attack(CharacterControl control, bool isAttack) {
		CommandAttack attack = new CommandAttack(control.MCharacter, isAttack);
		return control.MCharacter.Transition(attack);
	}
}
