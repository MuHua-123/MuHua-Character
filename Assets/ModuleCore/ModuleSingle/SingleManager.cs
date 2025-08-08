using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 管理器
/// </summary>
public class SingleManager : ModuleSingle<SingleManager> {
	/// <summary> 角色预制件 </summary>
	public Transform prefab;
	/// <summary> 加载模式 </summary>
	public LoadMode loadMode = LoadMode.Hot;
	/// <summary> 输入模式 </summary>
	public InputMode inputMode = InputMode.Simple;
	/// <summary> 相机模式 </summary>
	public CameraMode cameraMode = CameraMode.LookDown;
	/// <summary> 角色处理器类型 </summary>
	public HandleType handleType = HandleType.Simple;

	protected override void Awake() => NoReplace();

	private void Start() {
		ModuleCamera.Settings(cameraMode);
		ModuleInput.Settings(inputMode);
		ManagerCharacter.I.Create();
	}
}