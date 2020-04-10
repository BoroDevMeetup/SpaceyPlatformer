using UnityEngine;

namespace Character { 
	[RequireComponent(typeof(Rigidbody2D))]
	public class CharacterController : MonoBehaviour {
		[SerializeField]
		private Transform crosshairs = null;

		[Header("Speed")]
		[SerializeField]
		[Range(0f, 100f)]
		private float jumpPower = 5f;

		private Rigidbody2D body;
		private bool grounded = false;

		private void Awake() {
			body = GetComponent<Rigidbody2D>();
		}

		private void Update() {
			if (Input.GetButtonDown("Jump")) {
				Jump();
			}
		}

		void Jump() {
			if (grounded) {
				grounded = false;
				Vector3 jumpVector = Vector3.Normalize(crosshairs.position - transform.position) * jumpPower;
				body.AddForce(jumpVector, ForceMode2D.Impulse);
			}
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			if (!grounded && collision.gameObject.CompareTag("Grabbable")) {
				Debug.Log("Grab!");
				grounded = true;
				body.velocity = Vector3.zero;
				body.angularVelocity = 0f;
			}
		}
	}
}
