using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 效果组件
/// </summary>
public class HEffects : MonoBehaviour {
	/// <summary> 设置位置 </summary>
	public void Settings(Transform combo) {
		transform.position = combo.position;
		transform.eulerAngles = combo.eulerAngles;
	}
}
