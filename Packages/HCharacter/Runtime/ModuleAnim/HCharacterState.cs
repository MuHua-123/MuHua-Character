using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画状态
/// </summary>
public class HCharacterState : StateMachineBehaviour {
	/// <summary> 是否允许转换 </summary>
	public string token;
	/// <summary> 是否允许转换 </summary>
	public bool isTransition;
	/// <summary> 是否浮空 </summary>
	public bool isFloating;
	/// <summary> 是否受到伤害 </summary>
	public bool isInjured;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (!animator.TryGetComponent(out ICharacterFunc func)) { return; }
		func.SettingsState(token, isTransition, isFloating, isInjured);
	}
}
