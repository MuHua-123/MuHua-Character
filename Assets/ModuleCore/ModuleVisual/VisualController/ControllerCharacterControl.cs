using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色 - 控制器
/// </summary>
public class ControllerCharacterControl : VisualController<CharacterControl> {
	/// <summary> 生成空间 </summary>
	public Transform space;
	/// <summary> 数据预制件 </summary>
	// public Transform prefab;

	/// <summary> 更新可视化内容 </summary>
	public override void UpdateVisual(ref CharacterControl visual) {
		if (SingleManager.I.loadMode == LoadMode.None) {
			Create(ref visual, SingleManager.I.prefab, space);
		}
		if (SingleManager.I.loadMode == LoadMode.Hot) {
			CharacterHot hCharacter = null;
			Create(ref hCharacter, SingleManager.I.prefab, space);
			visual = CharacterControl.AddControl(hCharacter);
		}
		visual.Initial(Vector3.zero, Vector3.zero);
	}
	/// <summary> 释放可视化内容 </summary>
	public override void ReleaseVisual(CharacterControl visual) {
		if (visual != null) { Destroy(visual.gameObject); }
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