using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 特效
/// </summary>
public abstract class ISpecialEffects : MonoBehaviour {
	/// <summary> 开启 </summary>
	public abstract void Open();
	/// <summary> 关闭 </summary>
	public abstract void Close();
}
