using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boc {
	public class PlayerController : MonoBehaviour {
		[SerializeField]
		private float speed = 3;

		[SerializeField]
		private bool isActive;

		[SerializeField, Header ("Controls")]
		private string horizontalName = "Horizontal";
		[SerializeField]
		private string verticalName = "Vertical";

		private CharacterController controller;

		private void Awake () {
			controller = GetComponent<CharacterController> ();
		}

		private void Update () {
			if (!isActive) { return; }
			float horizontal = Input.GetAxis (horizontalName);
			float vertical = Input.GetAxis (verticalName);
			Vector3 direction = new Vector3 (horizontal, 0, vertical);
			controller.Move (direction * Time.deltaTime * speed);
		}

	}
}