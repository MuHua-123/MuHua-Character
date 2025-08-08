using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色 - 热更数据
/// </summary>
public abstract class CharacterHot : MonoBehaviour {
	/// <summary> 动画接口 </summary>
	public ICharacterFunc func;
	/// <summary> 动画触发 </summary>
	public virtual void Trigger(string value) => func?.Trigger(value);
}
/// <summary>
/// 动画事件接口
/// </summary>
public interface ICharacterFunc {
	/// <summary> 触发 </summary>
	public void Trigger(string value);
	/// <summary> 设置状态 </summary>
	public void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured);
}