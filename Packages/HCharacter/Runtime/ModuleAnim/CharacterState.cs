using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色状态
/// </summary>
public class CharacterState : StateMachineBehaviour {
	/// <summary> 是否允许转换 </summary>
	public bool isTransition;
	/// <summary> 是否浮空 </summary>
	public bool isFloating;
	/// <summary> 是否受到伤害 </summary>
	public bool isInjured;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (!animator.TryGetComponent(out HCharacter character)) { return; }
		character.SettingsState(isTransition, isFloating, isInjured);
	}

}
