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
	/// <summary> 角色处理器类型 </summary>
	public HandleType handleType = HandleType.Simple;
	/// <summary> 加载模式 </summary>
	public LoadMode loadMode = LoadMode.Hot;

	protected override void Awake() => NoReplace();

	private void Start() {
		ModuleCamera.Settings(EnumCameraMode.MoveAxis);
		ManagerCharacter.I.Create();
	}
}
/// <summary>
/// 加载模式
/// </summary>
public enum LoadMode {
	/// <summary> 无 </summary>
	None,
	/// <summary> 热更新 </summary>
	Hot
}