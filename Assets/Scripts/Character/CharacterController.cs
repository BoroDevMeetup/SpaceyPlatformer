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
		[SerializeField]
		[Range(0f, 100f)]
		private float speed = 5f;

		private Rigidbody2D body;
		private bool grounded = false;

		private Vector2 moveForce = Vector3.zero;

		private void Awake() {
			body = GetComponent<Rigidbody2D>();
		}

		private void Update() {
			HandleMovement();
			if (Input.GetButtonDown("Jump")) {
				Jump();
			}
		}

		void HandleMovement() {
			if (!grounded) {
				return;
			}

			moveForce = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			moveForce *= speed;
			moveForce *= Time.deltaTime;

			body.MovePosition(body.position + moveForce);
		}

		void Jump() {
			if (grounded) {
				grounded = false;
				Vector3 jumpVector = Vector3.Normalize(crosshairs.position - transform.position) * jumpPower;
				body.AddForce(jumpVector, ForceMode2D.Impulse);
				LookAt(crosshairs);
			}
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			if (!grounded && collision.gameObject.CompareTag("Grabbable")) {
				grounded = true;
				body.velocity = Vector3.zero;
				body.angularVelocity = 0f;
			}
		}

		private void OnCollisionStay2D(Collision2D collision) {
			if (!grounded && collision.gameObject.CompareTag("Grabbable")) {
				grounded = true;
			}
		}

		private void OnCollisionExit2D(Collision2D collision) {
			if (collision.gameObject.CompareTag("Grabbable")) {
				grounded = false;
			}
		}

		private void LookAt(Transform target) {
			float angle = 0;
			Vector3 relative = transform.InverseTransformPoint(target.position);
			angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
			transform.Rotate(0f, 0f, -angle);
		}
	}
}
