using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色控制器
/// </summary>
public abstract class ControlCharacter : MonoBehaviour, ICharacterFunc {
	[Header("角色属性")]
	/// <summary> 移动速度 </summary>
	public float moveSpeed = 2;
	/// <summary> 冲刺速度 </summary>
	public float sprintSpeed = 5.5f;
	/// <summary> 加速度 </summary>
	public float acceleration = 15;
	/// <summary> 跳跃高度 </summary>
	public float jumpHeight = 2;

	/// <summary> 角色模块 </summary>
	public abstract ModuleCharacter MCharacter { get; }

	public virtual void Update() => MCharacter?.Update();

	public abstract void Initial(Vector3 position, Vector3 eulerAngles);

	public abstract void Trigger(string value);

	public abstract void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured);

	public static ControlCharacter AddControl(HotCharacter hCharacter) {
		if (hCharacter is HotCharacterCollision collision) { return hCharacter.AddComponent<ControlCharacterCollision>(); }
		if (hCharacter is HotCharacterStandard standard) { return hCharacter.AddComponent<ControlCharacterStandard>(); }
		return null;
	}
}
