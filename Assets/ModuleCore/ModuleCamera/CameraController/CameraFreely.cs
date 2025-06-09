using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自由 - 相机
/// </summary>
public class CameraFreely : CameraController {

	public Camera mainCamera;

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
		set => transform.eulerAngles = value;
	}
	public override float VisualField {
		get => throw new System.NotImplementedException();
		set => throw new System.NotImplementedException();
	}

	public override void ModuleCamera_OnCameraMode(EnumCameraMode mode) {
		ModuleCamera.CurrentCamera = this;
	}

	public override void ResetCamera() {
		// throw new System.NotImplementedException();
	}
}
