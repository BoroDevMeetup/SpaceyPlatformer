using UnityEngine;
using GameManagement;

namespace ZeroGravLevel { 
	public class ZeroGravLevel : MonoBehaviour {
		private void Awake() {
			Physics2D.gravity = Vector2.zero;
		}
	}
}
