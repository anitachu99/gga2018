using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boc {
	public class Howl : Ability {
		[SerializeField]
		private float amountToHeal = 30;
		[SerializeField]
		private AudioClip howlingSound;
		[SerializeField]
		private float cooldown;
		
	}
}