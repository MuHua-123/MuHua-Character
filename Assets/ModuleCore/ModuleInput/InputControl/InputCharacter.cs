using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 角色 - 输入
/// </summary>
public class InputCharacter : InputControl {

	public Vector2 moveInput;

	public CameraController CurrentCamera => ModuleCamera.CurrentCamera;

	protected override void ModuleInput_OnInputMode(EnumInputMode mode) {
		// throw new System.NotImplementedException();
	}

	protected override void ModuleInput_OnTemporarilyDisable(bool obj) {
		// throw new System.NotImplementedException();
	}

	#region 输入系统
	public void OnMove(InputValue inputValue) {
		// 获取移动输入
		moveInput = inputValue.Get<Vector2>();
		Vector2 moveDirection = Utilities.TransferDirection(CurrentCamera.Forward, CurrentCamera.Right, moveInput);

		ManagerPlayer.I.Move(moveDirection, true);
	}
	public void OnJump(InputValue inputValue) {
		Vector2 moveDirection = Utilities.TransferDirection(CurrentCamera.Forward, CurrentCamera.Right, moveInput);
		ManagerPlayer.I.Jump(moveDirection, 2, true);
	}
	#endregion
}
