using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

	public void OnPress() {
		Destroy (gameObject);
	}
}