using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 运动器
	/// </summary>
	public abstract class Movement {
		/// <summary> 当前速度 </summary>
		public float speed;
		/// <summary> 移动速度 </summary>
		public float moveSpeed;
		/// <summary> 加速度 </summary>
		public float acceleration;
		/// <summary> 是否接地 </summary>
		public bool grounded;

		/// <summary> 当前位置 </summary>
		public abstract Vector3 Position { get; }

		/// <summary> 设置位置 </summary>
		public abstract void Settings(Vector3 position, Vector3 eulerAngles);
		/// <summary> 移动 </summary>
		public abstract void Move(Vector2 moveDirection, bool isRotation);
		/// <summary> 移动 </summary>
		public abstract void Move(Vector2 moveDirection, float moveSpeed, float acceleration, bool isRotation);
		/// <summary> 跳跃 </summary>
		public abstract void Jump(float jumpHeight);
		/// <summary> 停止运动 </summary>
		public abstract void Stop();
		/// <summary> 更新 </summary>
		public abstract void Update();
	}
}
