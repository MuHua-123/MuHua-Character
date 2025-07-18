using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 角色 - 模块
	/// </summary>
	public class MCharacter {
		/// <summary> 动画器 </summary>
		public Animator animator;
		/// <summary> 运动器 </summary>
		public Movement movement;
		/// <summary> 当前指令 </summary>
		public Command currentCommand;

		/// <summary> 是否允许转换 </summary>
		public bool isTransition = true;

		public MCharacter(Animator animator, Movement movement) {
			this.animator = animator;
			this.movement = movement;
			currentCommand = new CommandIdle();
		}

		/// <summary> 更新 </summary>
		public void Update() {
			// 更新动画器
			animator.SetFloat("MoveSpeed", movement.Speed);
			animator.SetBool("Grounded", movement.Grounded);
			// 更新运动器
			movement.Update();
			// 更新指令
			currentCommand.UpdateKinesis();
		}
		/// <summary> 动作过渡 </summary>
		public bool Transition(Command command) {
			// 不可以转换
			currentCommand.Transition(command);
			if (!isTransition) { return false; }
			// 进行转换
			currentCommand?.FinishKinesis();
			currentCommand = command;
			currentCommand?.StartKinesis();
			return true;
		}
	}
}