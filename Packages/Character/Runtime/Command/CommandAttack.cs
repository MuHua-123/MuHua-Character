using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 攻击 - 运动
	/// </summary>
	public class CommandAttack : Command {
		/// <summary> 基础角色 </summary>
		public readonly CharacterModel character;

		/// <summary> 发动攻击 </summary>
		public bool isAttack = false;
		/// <summary> 开始令牌 </summary>
		public bool isAttackToken = false;

		/// <summary> 是否允许转换 </summary>
		public bool IsTransition => character.isTransition;

		/// <summary> 动画器 </summary>
		public Animator animator => character.animator;
		/// <summary> 运动器 </summary>
		public Movement movement => character.movement;

		public CommandAttack(CharacterModel character, bool isAttack) {
			this.character = character;
			this.isAttack = isAttack;
		}

		public override bool Transition(Command kinesis) {
			// 如果 取消攻击 则需要结束攻击动画才能再次攻击
			if (!isAttack) { return isAttackToken && IsTransition; }
			// 如果连击中，则更新攻击命令
			if (kinesis is CommandAttack attack) { return true; }
			// 需要进入攻击动画 激活开始令牌 才能进行转换
			return isAttackToken && IsTransition;
		}
		public override void Settings(string token) {
			// 激活攻击令牌
			if (!isAttackToken) { isAttackToken = token == "Attack"; }
		}
		public override void StartKinesis() {
			isAttackToken = !isAttack;
			animator.SetBool("Attack", isAttack);
			if (isAttack) { movement.Stop(); }
		}
		public override void UpdateKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void FinishKinesis() {
			// throw new System.NotImplementedException();
		}
	}
}