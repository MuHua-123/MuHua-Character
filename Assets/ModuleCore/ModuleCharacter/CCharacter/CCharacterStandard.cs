using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准角色 - 控制器
/// </summary>
public class CCharacterStandard : CCharacter {

	public DataCharacter dCharacter;
	public HCharacterStandard hCharacter;
	public MCharacterStandard mCharacter;

	public override MCharacter MCharacter => mCharacter;
	public override DataCharacter DCharacter => dCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		hCharacter = GetComponent<HCharacterStandard>();
		mCharacter = new MCharacterStandard(hCharacter.animator, transform, hCharacter.ground);
		mCharacter.movement.Settings(position, eulerAngles);
		hCharacter.animationExit = mCharacter.AnimationExit;

		dCharacter = new DataCharacter(hCharacter);
	}
	private void Update() {
		mCharacter.Update();
	}
}
