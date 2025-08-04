using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 跳跃 - 运动
	/// </summary>
	public class CommandJump : Command {
		/// <summary> 基础角色 </summary>
		public readonly MCharacter character;

		/// <summary> 跳跃高度 </summary>
		public float jumpHeight;
		/// <summary> 跳跃令牌 </summary>
		public bool isJumpToken = false;
		/// <summary> 落地令牌 </summary>
		public bool isLandToken = false;

		/// <summary> 是否允许转换 </summary>
		public bool IsTransition => character.isTransition;

		/// <summary> 动画器 </summary>
		public Animator animator => character.animator;
		/// <summary> 运动器 </summary>
		public Movement movement => character.movement;

		public CommandJump(MCharacter character, float jumpHeight) {
			this.character = character;
			this.jumpHeight = jumpHeight;
		}

		public override bool Transition(Command command) {
			// 如果跳跃移动
			if (command is CommandMove move) { return isJumpToken; }
			return isJumpToken && isLandToken && IsTransition;
		}
		public override void Settings(string token) {
			// 激活跳跃令牌
			if (!isJumpToken) { isJumpToken = token == "Jump"; }
			// 激活落地令牌
			if (!isLandToken) { isLandToken = token == "Land"; }
			if (isLandToken) { movement.Stop(); }
		}
		public override void StartKinesis() {
			animator.SetTrigger("Jump");
			animator.applyRootMotion = false;
			movement.Jump(jumpHeight);
		}
		public override void UpdateKinesis() {
			if (!isJumpToken || !isLandToken || !IsTransition) { return; }
			character.Transition(new CommandIdle());
		}
		public override void FinishKinesis() {
			animator.applyRootMotion = true;
		}
	}
}
