using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 玩家 - 管理器
/// </summary>
public class ManagerPlayer : ModuleSingle<ManagerPlayer> {

	public ControlCharacter character;

	protected override void Awake() => NoReplace(false);

	public void Move(Vector2 moveDirection, bool isRotation) {
		ModuleCharacter.Move(character, moveDirection, isRotation);
	}
	public void Jump(Vector2 moveDirection, float jumpHeight, bool isRotation) {
		ModuleCharacter.Jump(character, moveDirection, jumpHeight, isRotation);
	}
}
