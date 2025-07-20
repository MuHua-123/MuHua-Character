using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 触发 - 命令
	/// </summary>
	public class CommandTrigger : Command {
		/// <summary> 基础角色 </summary>
		public readonly MCharacter character;

		/// <summary> 触发值 </summary>
		public string value;
		/// <summary> 根运动 </summary>
		public bool rootMotion;
		/// <summary> 原始根运动 </summary>
		public bool original;

		/// <summary> 动画器 </summary>
		public Animator animator => character.animator;
		/// <summary> 运动器 </summary>
		public Movement movement => character.movement;

		public CommandTrigger(MCharacter character, string value, bool rootMotion) {
			this.character = character;
			this.value = value;
			this.rootMotion = rootMotion;
		}

		public override bool Transition(Command kinesis) {
			throw new System.NotImplementedException();
		}
		public override void Settings(string token) {
			throw new System.NotImplementedException();
		}
		public override void StartKinesis() {
			original = animator.applyRootMotion;
			animator.SetTrigger(value);
			animator.applyRootMotion = rootMotion;
		}
		public override void UpdateKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void FinishKinesis() {
			animator.applyRootMotion = original;
		}
		public override void AnimationExit() {
			// throw new System.NotImplementedException();
		}
	}
}