using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色 - 可视化控制器
/// </summary>
public class ControllerCCharacter : VisualController<CCharacter> {
	/// <summary> 生成空间 </summary>
	public Transform space;
	/// <summary> 数据预制件 </summary>
	public Transform prefab;

	/// <summary> 更新可视化内容 </summary>
	public override void UpdateVisual(ref CCharacter visual) {
		Create(ref visual, prefab, space);
		visual.Initial(Vector3.zero, Vector3.zero);
	}
	/// <summary> 释放可视化内容 </summary>
	public override void ReleaseVisual(CCharacter visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}
