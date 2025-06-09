using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准角色 - 控制器
/// </summary>
public class CCharacterStandard : ControlCharacter {

	[Header("扩展功能")]
	public Animator animator;
	public LayerMask ground;

	private MCharacterStandard mCharacter;

	public override MCharacter MCharacter => mCharacter;

	private void Awake() {
		mCharacter = new MCharacterStandard(animator, transform, ground);
	}
	private void Update() {
		mCharacter.Update();
	}
	public void AnimationExit() {
		mCharacter.AnimationExit();
	}
}
