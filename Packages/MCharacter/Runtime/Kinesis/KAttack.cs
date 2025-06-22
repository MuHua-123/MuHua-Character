using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 攻击 - 运动
	/// </summary>
	public class KAttack : IKinesis {
		/// <summary> 基础角色 </summary>
		public readonly MCharacter character;

		/// <summary> 初始设置 </summary>
		public bool isInitial = false;
		/// <summary> 允许转换 </summary>
		public bool isTransition;
		/// <summary> 初始位置 </summary>
		public Vector3 position;
		/// <summary> 初始角度 </summary>
		public Vector3 eulerAngles;

		/// <summary> 动画器 </summary>
		public Animator animator => character.animator;
		/// <summary> 运动器 </summary>
		public Movement movement => character.movement;

		public KAttack(MCharacter character) {
			this.character = character;
		}

		public void Settings(Vector3 position, Vector3 eulerAngles) {
			this.position = position;
			this.eulerAngles = eulerAngles;
			isInitial = true;
		}

		public override bool Transition(IKinesis kinesis) {
			if (kinesis is KAttack attack) {
				if (attack.isInitial) { movement.Settings(attack.position, attack.eulerAngles); }
			}
			return isTransition;
		}
		public override void StartKinesis() {
			isTransition = false;
			animator.SetBool("Attack", true);

			if (!isInitial) { return; }
			movement.Settings(position, eulerAngles);
		}
		public override void UpdateKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void FinishKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void AnimationExit() {
			isTransition = true;
			animator.SetBool("Attack", false);
			// 转换到移动
			character.Transition(new KIdle());
		}
	}
}