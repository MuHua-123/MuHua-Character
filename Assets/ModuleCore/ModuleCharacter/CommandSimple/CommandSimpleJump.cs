using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 跳跃 - 简单命令
/// </summary>
public class CommandSimpleJump : Command {
	/// <summary> 基础角色 </summary>
	public readonly ModuleCharacter character;

	/// <summary> 跳跃高度 </summary>
	public float jumpHeight;
	/// <summary> 跳跃令牌 </summary>
	public bool isJumpToken = false;

	/// <summary> 是否允许转换 </summary>
	public bool IsTransition => character.isTransition;

	/// <summary> 运动器 </summary>
	public Movement movement => character.movement;

	public CommandSimpleJump(ModuleCharacter character, float jumpHeight) {
		this.character = character;
		this.jumpHeight = jumpHeight;
	}

	public override bool Transition(Command command) {
		// 如果跳跃移动
		if (command is CommandSimpleMove move) { return isJumpToken; }
		return IsTransition;
	}
	public override void Settings(string token) {

	}
	public override void StartKinesis() {
		movement.Jump(jumpHeight);
	}
	public override void UpdateKinesis() {
		if (isJumpToken == false) isJumpToken = !movement.grounded;
		if (!IsTransition) { return; }
		character.Transition(new CommandIdle());
	}
	public override void FinishKinesis() {

	}
}
