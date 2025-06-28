using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 角色 - 输入
/// </summary>
public class InputCharacter : InputControl {

	public bool isSprint = false;
	public Vector2 moveInput;

	private bool isMoveAfterAttack = false;

	public CameraController CurrentCamera => ModuleCamera.CurrentCamera;

	protected override void ModuleInput_OnInputMode(EnumInputMode mode) {
		// throw new System.NotImplementedException();
	}
	private void Update() {
		if (!isMoveAfterAttack) { return; }
		// 如果攻击后移动，则重新执行移动
		if (moveInput == Vector2.zero || !ManagerCharacter.I.IsTransition) { return; }
		Movement();
	}

	#region 输入系统
	public void OnMove(InputValue inputValue) {
		// 获取移动输入
		moveInput = inputValue.Get<Vector2>();
		Movement();
	}
	public void OnSprint(InputValue inputValue) {
		isSprint = !isSprint;
		Movement();
	}
	public void OnJump(InputValue inputValue) {
		ManagerCharacter.I.Jump(MoveDirection());
		if (moveInput == Vector2.zero) { return; }
		isMoveAfterAttack = true;
	}
	public void OnAttack(InputValue inputValue) {
		bool isAttack = inputValue.isPressed;
		ManagerCharacter.I.Attack(isAttack);
		if (isAttack || moveInput == Vector2.zero) { return; }
		isMoveAfterAttack = true;
	}
	#endregion

	private void Movement() {
		isMoveAfterAttack = false;
		if (isSprint) { ManagerCharacter.I.Sprint(MoveDirection()); }
		else { ManagerCharacter.I.Move(MoveDirection()); }
	}
	private Vector2 MoveDirection() {
		return Utilities.TransferDirection(CurrentCamera.Forward, CurrentCamera.Right, moveInput);
	}
}
