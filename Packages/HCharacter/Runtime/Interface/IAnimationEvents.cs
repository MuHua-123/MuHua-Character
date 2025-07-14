using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画事件接口
/// </summary>
public interface IAnimationEvents {
	/// <summary> 进入触发器 </summary>
	public void EnterTrigger(string value);
	/// <summary> 退出触发器 </summary>
	public void ExitTrigger(string value);
	/// <summary> 动画结束 </summary>
	public void AnimationExit(string value);
}
