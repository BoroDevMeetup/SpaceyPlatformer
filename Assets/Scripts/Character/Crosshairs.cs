using UnityEngine;

namespace Character { 
	public class Crosshairs : MonoBehaviour {
		private void Awake() {
			Cursor.visible = false;
		}
		private void Update() {
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
		}
	}
}
