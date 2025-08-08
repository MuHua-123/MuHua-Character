using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 默认相机
/// </summary>
public class CameraDefault : CameraController {

	public Camera mainCamera;

	private Vector3 position;
	private Vector3 forward;
	private Vector3 right;
	private Vector3 eulerAngles;
	private float visualField;

	public override Vector3 Position {
		get => transform.position;
		set => position = value;
	}
	public override Vector3 Forward {
		get => mainCamera.transform.forward;
		set => forward = value;
	}
	public override Vector3 Right {
		get => mainCamera.transform.right;
		set => right = value;
	}
	public override Vector3 EulerAngles {
		get => transform.eulerAngles;
		set => eulerAngles = value;
	}
	public override float VisualField {
		get => throw new System.NotImplementedException();
		set => visualField = value;
	}

	public override void ModuleCamera_OnCameraMode(CameraMode mode) {
		gameObject.SetActive(mode == CameraMode.None);
		if (mode == CameraMode.None) { ModuleCamera.CurrentCamera = this; }
	}

	public override void ResetCamera() {
		// transform.position = HotUpdateScene.I.StartPoint.position;
		// transform.eulerAngles = HotUpdateScene.I.StartPoint.eulerAngles;
	}
}
