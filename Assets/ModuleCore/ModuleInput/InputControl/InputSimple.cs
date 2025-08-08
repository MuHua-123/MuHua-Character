using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 简单 - 输入
/// </summary>
public class InputSimple : InputControl {

	public bool isSprint = false;
	public Vector2 moveInput;

	private bool isEnable = false;
	private bool isMoveAfterAttack = false;

	public CameraController CurrentCamera => ModuleCamera.CurrentCamera;

	protected override void ModuleInput_OnInputMode(InputMode mode) {
		isEnable = mode == InputMode.Simple;
		if (!isEnable) { return; }
	}
	private void Update() {
		if (!isMoveAfterAttack) { return; }
		// 如果攻击后移动，则重新执行移动
		if (moveInput == Vector2.zero || !ManagerCharacter.I.IsTransition) { return; }
		isMoveAfterAttack = false;
		ManagerCharacter.I.Move(MoveDirection(), isSprint);
	}

	#region 输入系统
	public void OnMove(InputValue inputValue) {
		if (!isEnable) { return; }
		// 获取移动输入
		moveInput = inputValue.Get<Vector2>();
		isMoveAfterAttack = false;
		ManagerCharacter.I.Move(MoveDirection(), isSprint);
	}
	public void OnSprint(InputValue inputValue) {
		if (!isEnable) { return; }
		isSprint = !isSprint;
		isMoveAfterAttack = false;
		ManagerCharacter.I.Move(MoveDirection(), isSprint);
	}
	public void OnJump(InputValue inputValue) {
		if (!isEnable) { return; }
		ManagerCharacter.I.Jump();
		if (moveInput == Vector2.zero) { return; }
		isMoveAfterAttack = true;
	}
	#endregion

	private Vector2 MoveDirection() {
		return Utilities.TransferDirection(CurrentCamera.Forward, CurrentCamera.Right, moveInput);
	}
}
