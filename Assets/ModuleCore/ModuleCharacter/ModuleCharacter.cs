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
		character = ModuleVisual.I.CCharacter.CreateVisual(null);
	}

	public static bool Move(this CCharacter character, Vector2 moveDirection, bool isRotation) {
		CommandMove move = new CommandMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.DCharacter.moveSpeed, character.DCharacter.acceleration);
		return character.MCharacter.Transition(move);
	}
	public static bool Move(this CCharacter character, Vector2 moveDirection, bool isRotation, Vector3 position, Vector3 eulerAngles) {
		CommandMove move = new CommandMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.DCharacter.moveSpeed, character.DCharacter.acceleration);
		move.Settings(position, eulerAngles);
		return character.MCharacter.Transition(move);
	}

	public static bool Sprint(this CCharacter character, Vector2 moveDirection, bool isRotation) {
		CommandMove move = new CommandMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.DCharacter.sprintSpeed, character.DCharacter.acceleration);
		return character.MCharacter.Transition(move);
	}
	public static bool Sprint(this CCharacter character, Vector2 moveDirection, bool isRotation, Vector3 position, Vector3 eulerAngles) {
		CommandMove move = new CommandMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.DCharacter.sprintSpeed, character.DCharacter.acceleration);
		move.Settings(position, eulerAngles);
		return character.MCharacter.Transition(move);
	}

	public static bool Jump(this CCharacter character, Vector2 moveDirection, bool isRotation) {
		CommandJump jump = new CommandJump(character.MCharacter, moveDirection, character.DCharacter.jumpHeight, isRotation);
		jump.Settings(character.DCharacter.moveSpeed, character.DCharacter.acceleration);
		return character.MCharacter.Transition(jump);
	}
	public static bool Jump(this CCharacter character, Vector2 moveDirection, bool isRotation, Vector3 position, Vector3 eulerAngles) {
		CommandJump jump = new CommandJump(character.MCharacter, moveDirection, character.DCharacter.jumpHeight, isRotation);
		jump.Settings(character.DCharacter.moveSpeed, character.DCharacter.acceleration);
		jump.Settings(position, eulerAngles);
		return character.MCharacter.Transition(jump);
	}

	public static bool Attack(this CCharacter character, bool isAttack) {
		CommandAttack attack = new CommandAttack(character.MCharacter, isAttack);
		return character.MCharacter.Transition(attack);
	}
	public static bool Attack(this CCharacter character, bool isAttack, Vector3 position, Vector3 eulerAngles) {
		CommandAttack attack = new CommandAttack(character.MCharacter, isAttack);
		attack.Settings(position, eulerAngles);
		return character.MCharacter.Transition(attack);
	}
}
