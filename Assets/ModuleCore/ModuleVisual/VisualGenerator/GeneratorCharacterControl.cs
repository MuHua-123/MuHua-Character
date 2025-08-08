using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色 - 生成器
/// </summary>
public class GeneratorCharacterControl : VisualGenerator<CharacterControl> {
	/// <summary> 生成空间 </summary>
	public Transform space;
	/// <summary> 数据预制件 </summary>
	// public Transform prefab;

	public override CharacterControl CreateVisual(Transform original) {
		CharacterControl visual = null;
		UpdateVisual(ref visual, SingleManager.I.prefab);
		return visual;
	}

	public override void UpdateVisual(ref CharacterControl visual, Transform original) {
		CharacterHot hCharacter = Create<CharacterHot>(original, space);
		visual = CharacterControl.AddControl(hCharacter);
		visual.Initial(Vector3.zero, Vector3.zero);
	}

	public override void ReleaseVisual(CharacterControl visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}
