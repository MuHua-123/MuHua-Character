using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 空闲 - 运动
	/// </summary>
	public class CommandIdle : Command {
		public override bool Transition(Command kinesis) {
			return true;
		}
		public override void StartKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void UpdateKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void FinishKinesis() {
			// throw new System.NotImplementedException();
		}
		public override void AnimationExit() {
			// throw new System.NotImplementedException();
		}
	}
}
