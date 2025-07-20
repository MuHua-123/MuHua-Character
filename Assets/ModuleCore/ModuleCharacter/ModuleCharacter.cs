using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色模块
/// </summary>
public static class ModuleCharacter {
	/// <summary> 创建角色 </summary>
	public static void CreateCharacter(ref CCharacter character) {
		ModuleVisual.I.ControllerCCharacter.UpdateVisual(ref character);
	}
	/// <summary> 命令：移动 </summary>
	public static bool Move(this CCharacter character, Vector2 moveDirection, bool isSprint, bool isRotation) {
		CommandMove move = new CommandMove(character.MCharacter, moveDirection, isRotation);
		float moveSpeed = isSprint ? character.DCharacter.sprintSpeed : character.DCharacter.moveSpeed;
		move.Settings(moveSpeed, character.DCharacter.acceleration);
		return character.MCharacter.Transition(move);
	}
	/// <summary> 命令：跳跃 </summary>
	public static bool Jump(this CCharacter character) {
		CommandJump jump = new CommandJump(character.MCharacter, character.DCharacter.jumpHeight);
		return character.MCharacter.Transition(jump);
	}
	/// <summary> 命令：攻击 </summary>
	public static bool Attack(this CCharacter character, bool isAttack) {
		CommandAttack attack = new CommandAttack(character.MCharacter, isAttack);
		return character.MCharacter.Transition(attack);
	}
}
