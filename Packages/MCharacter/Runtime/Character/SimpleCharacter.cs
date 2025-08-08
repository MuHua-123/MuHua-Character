using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 简单角色
	/// </summary>
	public class SimpleCharacter : CharacterModel {
		public override void Update() {
			// 更新运动器
			movement?.Update();
			// 更新指令
			currentCommand?.UpdateKinesis();
		}
	}
}