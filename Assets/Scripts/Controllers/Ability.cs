using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace boc {
	public abstract class Ability : ScriptableObject {
		public virtual void OnAbilityStart () { }
		public virtual void OnAbilityUpdate () { }
		public virtual void OnAbilityEnd () { }

	}
}