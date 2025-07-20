using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色 - 生成器
/// </summary>
public class GeneratorHEffects : VisualGenerator<HEffects> {
	/// <summary> 生成空间 </summary>
	public Transform space;

	public override HEffects CreateVisual(Transform original) {
		return Create<HEffects>(original, space);
	}
	public override void UpdateVisual(ref HEffects visual, Transform original) {
		visual = CreateVisual(original);
	}
	public override void ReleaseVisual(HEffects visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}
