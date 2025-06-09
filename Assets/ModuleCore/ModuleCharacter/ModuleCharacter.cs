using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 角色模块
/// </summary>
public static class ModuleCharacter {
	public static void Move(this ControlCharacter character, Vector2 moveDirection, bool isRotation) {
		KMove move = new KMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.moveSpeed, character.acceleration);
		character.MCharacter.Transition(move);
	}
	public static void Move(this ControlCharacter character, Vector2 moveDirection, bool isRotation, Vector3 position, Vector3 eulerAngles) {
		KMove move = new KMove(character.MCharacter, moveDirection, isRotation);
		move.Settings(character.moveSpeed, character.acceleration);
		move.Settings(position, eulerAngles);
		character.MCharacter.Transition(move);
	}

	public static void Jump(this ControlCharacter character, Vector2 moveDirection, float jumpHeight, bool isRotation) {
		KJump jump = new KJump(character.MCharacter, moveDirection, jumpHeight, isRotation);
		jump.Settings(character.moveSpeed, character.acceleration);
		character.MCharacter.Transition(jump);
	}
	public static void Jump(this ControlCharacter character, Vector2 moveDirection, float jumpHeight, bool isRotation, Vector3 position, Vector3 eulerAngles) {
		KJump jump = new KJump(character.MCharacter, moveDirection, jumpHeight, isRotation);
		jump.Settings(character.moveSpeed, character.acceleration);
		jump.Settings(position, eulerAngles);
		character.MCharacter.Transition(jump);
	}
}
