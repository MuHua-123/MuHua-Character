using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自由 - 相机
/// </summary>
public class CameraLookdown : CameraController {

	public Camera mainCamera;
	public Vector3 offset; // 相机与玩家的偏移量
	[Range(0, 0.5f)]
	public float smoothSpeed = 0.125f; // 平滑跟随速度

	public override Vector3 Position {
		get => transform.position;
		set => transform.position = value;
	}
	public override Vector3 Forward {
		get => mainCamera.transform.forward;
		set => mainCamera.transform.forward = value;
	}
	public override Vector3 Right {
		get => mainCamera.transform.right;
		set => mainCamera.transform.right = value;
	}
	public override Vector3 EulerAngles {
		get => transform.eulerAngles;
		set => transform.eulerAngles = new Vector3(0, value.y, 0);
	}
	public override float VisualField {
		get => throw new System.NotImplementedException();
		set => throw new System.NotImplementedException();
	}

	public override void ModuleCamera_OnCameraMode(CameraMode mode) {
		gameObject.SetActive(mode == CameraMode.LookDown);
		if (mode == CameraMode.LookDown) { ModuleCamera.CurrentCamera = this; }
	}

	public override void ResetCamera() {
		// throw new System.NotImplementedException();
	}

	private void LateUpdate() {
		ControlCharacter player = ManagerCharacter.I.CurrentControl;
		if (player == null) { return; }
		// 计算目标位置
		Vector3 desiredPosition = player.transform.position + offset;
		// 平滑过渡到目标位置
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
