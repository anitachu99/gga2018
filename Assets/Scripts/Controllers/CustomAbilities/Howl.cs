using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boc {[CreateAssetMenu (menuName = "ScriptableObjects/abilities/howling")]
	public class Howl : Ability {
		[SerializeField]
		private float amountToHeal = 30;
		[SerializeField]
		private AudioClip howlingSound;
		[SerializeField]
		private float cooldown;
		private IHealth health;
		private AudioSource source;
		[SerializeField]
		private KeyCode abilitykey;
		private float cooldowntimer;
		public override void OnAbilityStart (GameObject player) {
			health = player.GetComponent<IHealth> ();
			source = player.GetComponent<AudioSource> ();
		}
		public override void OnAbilityUpdate (GameObject player) {
			cooldowntimer -= Time.deltaTime;
			if (cooldowntimer <= 0) {
				if (Input.GetKeyDown (abilitykey)) {
					health.Heal (amountToHeal);
					source.clip = howlingSound;
					source.Play ();
					cooldowntimer = cooldown;
				}
			}
		}
	}
}