using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 连击组件
/// </summary>
public class HCombo : MonoBehaviour {
	/// <summary> 连击 </summary>
	public List<Transform> combos;

	/// <summary> 获取连击位置 </summary>
	public Transform Get(string value) {
		return combos.FirstOrDefault(obj => obj.name == value);
	}
}
