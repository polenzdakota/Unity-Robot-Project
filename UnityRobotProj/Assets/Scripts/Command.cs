using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Contains a queue of actions picked by the player
/// </summary>
public class Command : MonoBehaviour {
	private Queue<IActions> actions;

	void Start () {
		actions = new Queue<IActions> ();
	}

	/// <summary>
	/// Adds the action to the action queue.
	/// </summary>
	/// <param name="addedAction">Added action.</param>
	public void AddAction(IActions addedAction) {
		actions.Enqueue (addedAction);
	}

	/// <summary>
	/// Gets the next action. Returns null if the queue is empty
	/// </summary>
	/// <returns>The next action.</returns>
	public IActions GetNextAction() {
		if (actions.Count > 0) {
			return actions.Dequeue ();
		} else {
			return null;
		}
	}
}
