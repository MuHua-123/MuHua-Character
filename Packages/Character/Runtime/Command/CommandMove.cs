using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 移动 - 运动
	/// </summary>
	public class CommandMove : Command {
		/// <summary> 基础角色 </summary>
		public readonly CharacterModel character;

		/// <summary> 移动速度 </summary>
		public float moveSpeed = 2;
		/// <summary> 加速度 </summary>
		public float acceleration = 15;
		/// <summary> 移动方向 </summary>
		public Vector2 moveDirection;
		/// <summary> 是否旋转 </summary>
		public bool isRotation;

		/// <summary> 是否允许转换 </summary>
		public bool IsFloating => character.isFloating;

		/// <summary> 动画器 </summary>
		public Animator animator => character.animator;
		/// <summary> 运动器 </summary>
		public Movement movement => character.movement;

		public CommandMove(CharacterModel character, Vector2 moveDirection, bool isRotation) {
			this.character = character;
			this.moveDirection = moveDirection;
			this.isRotation = isRotation;
			moveSpeed = movement.moveSpeed;
			acceleration = movement.acceleration;
		}

		public void Settings(float moveSpeed, float acceleration) {
			this.moveSpeed = moveSpeed;
			this.acceleration = acceleration;
		}

		public override bool Transition(Command command) {
			// 如果是移动，则可以转换
			if (command is CommandMove move) { return true; }
			// 浮空状态不可以转换
			return !IsFloating;
		}
		public override void Settings(string token) {
			// throw new System.NotImplementedException();
		}
		public override void StartKinesis() {
			animator.applyRootMotion = false;
			movement.Move(moveDirection, moveSpeed, acceleration, isRotation);
		}
		public override void UpdateKinesis() {
			// 移动结束
			if (movement.speed == 0) { character.Transition(new CommandIdle()); }
		}
		public override void FinishKinesis() {
			animator.applyRootMotion = true;
		}
	}
}