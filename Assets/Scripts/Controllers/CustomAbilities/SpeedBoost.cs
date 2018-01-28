using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace boc {
	[CreateAssetMenu (menuName = "ScriptableObjects/abilities/speedboost")]
	public class SpeedBoost : Ability {
		[SerializeField]
		private float speedmultiplier = 5;
		[SerializeField]
		private float abilityduration = 5;
		[SerializeField]
		private float cooldown = 5;
		[SerializeField]
		private KeyCode abilityKey;
		private float abilitytimer;
		private float cooldowntimer;
		private float oldspeed;
		private AbilityStage currentstage;
		private PlayerController controller;
		public enum AbilityStage {
			Idle,
			Active,
			Cooldown
		}

		public override void OnAbilityStart (GameObject player) {
			controller = player.GetComponent<PlayerController> ();
		}
		public override void OnAbilityUpdate (GameObject player) {
			switch (currentstage) {
				case AbilityStage.Idle:
					if (Input.GetKeyDown (abilityKey)) {
						oldspeed = controller.Speed;
						controller.Speed = oldspeed * speedmultiplier;
						abilitytimer = abilityduration;
						currentstage = AbilityStage.Active;
					}
					break;
				case AbilityStage.Active:
					abilitytimer -= Time.deltaTime;
					if (abilitytimer <= 0) {
						controller.Speed = oldspeed;
						cooldowntimer = cooldown;
						currentstage = AbilityStage.Cooldown;

					}
					break;
				case AbilityStage.Cooldown:
					cooldowntimer -= Time.deltaTime;
					if (cooldowntimer <= 0) {
						currentstage = AbilityStage.Idle;
					}
					break;

			}
		}

	}
}