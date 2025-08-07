using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色控制器
/// </summary>
public abstract class ControlCharacter : MonoBehaviour {

	/// <summary> 角色模块 </summary>
	public abstract ModuleCharacter MCharacter { get; }
	/// <summary> 角色数据 </summary>
	public abstract DataCharacter DCharacter { get; }

	public abstract void Initial(Vector3 position, Vector3 eulerAngles);

	public static ControlCharacter AddControl(HotCharacter hCharacter) {
		if (hCharacter is HotCharacterCollision collision) { return hCharacter.gameObject.AddComponent<ControlCharacterCollision>(); }
		if (hCharacter is HotCharacterStandard standard) { return hCharacter.gameObject.AddComponent<ControlCharacterStandard>(); }
		return null;
	}
}
