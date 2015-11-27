using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Contains a queue of actions picked by the player
/// </summary>
public class Command : MonoBehaviour {
	private List<IActions> actions;
	private List<IRobot> robots;

	void Start () {
		actions = new List<IActions> ();

		//Test data
		IActions forward = new MainMoveForward ();
		AddAction (forward);
		AddAction (forward);
		AddAction (forward);

		ExecuteActions ();
	}

	/// <summary>
	/// Adds the action to the action list.
	/// </summary>
	/// <param name="addedAction">Added action.</param>
	public void AddAction(IActions addedAction) {
		actions.Add (addedAction);
	}

	/// <summary>
	/// Gets the robot from the given index.
	/// </summary>
	/// <returns>The robot.</returns>
	/// <param name="index">Index.</param>
	public IRobot GetRobot(int index) {
		return robots [index];
	}

	/// <summary>
	/// Executes the actions in the action list.
	/// </summary>
	public void ExecuteActions() {
		foreach (IActions action in actions) {
			bool valid = action.InvokeAction();
			if (!valid) {
				TriggerFail();
			}
		}
		if (!GameBoard.GetCompletion()) {
			TriggerFail();
		}
	}

	/// <summary>
	/// Triggers the fail state.
	/// </summary>
	public void TriggerFail() {
		//TODO do stuff.
	}

	/// <summary>
	/// Adds the robot.
	/// </summary>
	/// <returns><c>true</c>, if robot was added, <c>false</c> otherwise.</returns>
	/// <param name="robot">Robot.</param>
	public void AddRobot(IRobot robot) {
		robots.Add (robot);
	}

	/// <summary>
	/// Gets the next action. Returns null if the queue is empty
	/// </summary>
	/// <returns>The next action.</returns>
	public IActions GetNextAction() {
		if (actions.Count > 0) {
			return actions[0];
		} else {
			return null;
		}
	}

	/// <summary>
	/// Removes the given action.
	/// </summary>
	/// <returns><c>true</c>, if action was removed, <c>false</c> otherwise.</returns>
	/// <param name="index">Index.</param>
	public void RemoveAction(int index) {
		actions.RemoveAt (index);
	}
}
