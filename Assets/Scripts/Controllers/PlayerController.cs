using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boc {
	public class PlayerController : MonoBehaviour {

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
		}

	}
}