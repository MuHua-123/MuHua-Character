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

	public CameraController CurrentCamera => ModuleCamera.CurrentCamera;

	protected override void ModuleInput_OnInputMode(EnumInputMode mode) {
		// throw new System.NotImplementedException();
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
	}
	public void OnAttack(InputValue inputValue) {
		ManagerCharacter.I.Attack(inputValue.isPressed);
	}
	#endregion

	private void Movement() {
		if (isSprint) { ManagerCharacter.I.Sprint(MoveDirection()); }
		else { ManagerCharacter.I.Move(MoveDirection()); }
	}
	private Vector2 MoveDirection() {
		return Utilities.TransferDirection(CurrentCamera.Forward, CurrentCamera.Right, moveInput);
	}
}
