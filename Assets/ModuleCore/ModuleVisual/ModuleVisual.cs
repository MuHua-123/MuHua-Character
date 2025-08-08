using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 可视化模块
/// </summary>
public class ModuleVisual : ModuleSingle<ModuleVisual> {

	[Header("控制器")]
	/// <summary> 角色控制器 </summary>
	public VisualController<CharacterControl> ControllerCharacterControl;

	[Header("生成器")]
	/// <summary> 角色生成器 </summary>
	public VisualGenerator<CharacterControl> GeneratorCharacterControl;
	/// <summary> 特效生成器 </summary>
	public VisualGenerator<HEffects> HEffects;

	protected override void Awake() => NoReplace();

}
