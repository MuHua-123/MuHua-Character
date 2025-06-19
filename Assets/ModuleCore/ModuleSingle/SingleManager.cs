using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 管理器
/// </summary>
public class SingleManager : ModuleSingle<SingleManager> {
	protected override void Awake() => NoReplace();
	private void Start() {
		ModuleCamera.Settings(EnumCameraMode.MoveAxis);
		ManagerCharacter.I.Create();
	}
}
