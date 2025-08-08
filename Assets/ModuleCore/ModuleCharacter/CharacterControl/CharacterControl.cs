using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色控制器
/// </summary>
public abstract class CharacterControl : MonoBehaviour, ICharacterFunc {
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
	public abstract CharacterModel MCharacter { get; }

	public virtual void Update() => MCharacter?.Update();

	public abstract void Initial(Vector3 position, Vector3 eulerAngles);

	public abstract void Trigger(string value);

	public abstract void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured);

	/// <summary> 添加控制器 </summary>
	public static CharacterControl AddControl(CharacterHot hCharacter) {
		if (hCharacter is CharacterHotCollision) { return AddControl<CharacterControlCollision>(hCharacter); }
		if (hCharacter is CharacterHotStandard) { return AddControl<CharacterControlStandard>(hCharacter); }
		return null;
	}
	/// <summary> 添加控制器 </summary>
	public static T AddControl<T>(CharacterHot hCharacter) where T : CharacterControl {
		return hCharacter.gameObject.AddComponent<T>();
	}
}
