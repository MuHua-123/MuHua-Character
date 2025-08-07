using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准 - 角色处理器
/// </summary>
public class CharacterHandleStandard : ICharacterHandle {

	public ControlCharacter control;
	public Func<bool> baseMotionTransition;

	public ControlCharacter Control => control;

	public bool IsTransition => baseMotionTransition == null;

	public void Update() {
		if (baseMotionTransition == null) { return; }
		if (baseMotionTransition()) { baseMotionTransition = null; }
	}

	public void Create() {
		ModuleVisual.I.ControllerControlCharacter.UpdateVisual(ref control);
	}

	public void Move(Vector2 moveInput, bool isSprint) {
		baseMotionTransition = () => Move(control, moveInput, isSprint, true);
	}
	public static bool Move(ControlCharacter control, Vector2 moveDirection, bool isSprint, bool isRotation) {
		CommandMove move = new CommandMove(control.MCharacter, moveDirection, isRotation);
		float moveSpeed = isSprint ? control.DCharacter.sprintSpeed : control.DCharacter.moveSpeed;
		move.Settings(moveSpeed, control.DCharacter.acceleration);
		return control.MCharacter.Transition(move);
	}

	public void Jump() {
		baseMotionTransition = () => Jump(control);
	}
	public static bool Jump(ControlCharacter control) {
		CommandJump jump = new CommandJump(control.MCharacter, control.DCharacter.jumpHeight);
		return control.MCharacter.Transition(jump);
	}

	public void Attack(bool isAttack) {
		baseMotionTransition = () => Attack(control, isAttack);
	}
	public static bool Attack(ControlCharacter control, bool isAttack) {
		CommandAttack attack = new CommandAttack(control.MCharacter, isAttack);
		return control.MCharacter.Transition(attack);
	}
}
