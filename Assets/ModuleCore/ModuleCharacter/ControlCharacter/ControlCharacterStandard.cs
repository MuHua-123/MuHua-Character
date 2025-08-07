using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准角色 - 控制器
/// </summary>
public class ControlCharacterStandard : ControlCharacter {

	public DataCharacter dCharacter;
	public ModuleCharacter mCharacter;
	public HotCharacterStandard hCharacter;
	public MovementStandard movement;

	public override ModuleCharacter MCharacter => mCharacter;
	public override DataCharacter DCharacter => dCharacter;

	public override void Initial(Vector3 position, Vector3 eulerAngles) {
		hCharacter = GetComponent<HotCharacterStandard>();
		// 创建运动器
		movement = new MovementStandard(transform, hCharacter.ground);
		movement.Settings(position, eulerAngles);
		// 创建角色模型
		mCharacter = new ModuleCharacter();
		mCharacter.Settings(hCharacter.animator, movement, new CommandIdle());
		// hCharacter.animationEvents = this;

		dCharacter = new DataCharacter(hCharacter);
	}
	private void Update() {
		mCharacter.Update();
	}
}
