using UnityEngine;
using System.Collections;

/// <summary>
/// Action button component used to delete itself on click.
/// </summary>
public class ActionButton : MonoBehaviour {

	/// <summary>
	/// Deletes the button and the action from Command.
	/// </summary>
	public void OnPress() {
		//TODO add deleting the action that this button correlates to from
		//     the list of actions in command
		Destroy (gameObject);
	}
}