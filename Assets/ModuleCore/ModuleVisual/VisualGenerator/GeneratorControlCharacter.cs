using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色 - 生成器
/// </summary>
public class GeneratorControlCharacter : VisualGenerator<ControlCharacter> {
	/// <summary> 生成空间 </summary>
	public Transform space;
	/// <summary> 数据预制件 </summary>
	// public Transform prefab;

	public override ControlCharacter CreateVisual(Transform original) {
		ControlCharacter visual = null;
		UpdateVisual(ref visual, SingleManager.I.prefab);
		return visual;
	}

	public override void UpdateVisual(ref ControlCharacter visual, Transform original) {
		HotCharacter hCharacter = Create<HotCharacter>(original, space);
		visual = ControlCharacter.AddControl(hCharacter);
		visual.Initial(Vector3.zero, Vector3.zero);
	}

	public override void ReleaseVisual(ControlCharacter visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}
