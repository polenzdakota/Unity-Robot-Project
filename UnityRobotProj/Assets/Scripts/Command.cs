using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Contains a queue of actions picked by the player
/// </summary>
public class Command : MonoBehaviour {
	public GameObject currentRobot;
	private List<IActions> actions;
	private List<IRobot> robots;
	//public List<Robot> robots;
	private GameObject eventSystem;


	void Start () {
		actions = new List<IActions> ();
		currentRobot = GameObject.FindGameObjectWithTag ("Player");

		//Test data
		/*MainMoveForward forward = currentRobot.GetComponent<MainMoveForward>();
		AddAction (forward);

		/// Now the robot should move left
		MainRotateRight rotateright = currentRobot.GetComponent<MainRotateRight> ();
		AddAction (rotateright);
		AddAction (rotateright);
		AddAction (forward); 
		AddAction (forward); 
		AddAction (forward); 
		AddAction (forward);

		//Now the robot should move right
		MainRotateLeft rotateleft = currentRobot.GetComponent<MainRotateLeft> ();
		AddAction (rotateleft);
		AddAction (rotateleft);
		AddAction (forward); 
		AddAction (forward); 
		AddAction (forward);
		AddAction (forward);

		///Now the robot should move up
		MainRotateLeft rotateup = currentRobot.GetComponent<MainRotateLeft> ();
		AddAction (rotateup);
		AddAction (forward);
		AddAction (forward);
		AddAction (forward);	

		//Now the robot should move down
		MainRotateRight rotatedown = currentRobot.GetComponent<MainRotateRight> ();
		AddAction (rotatedown);
		AddAction (rotatedown);
		AddAction (forward);
		AddAction (forward);
		AddAction (forward);
	
		//executes actions
		ExecuteActions ();
		*/
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
		print ("enter");
		foreach (IActions action in actions) {
			print ("step");
			bool valid = action.InvokeAction();
			if (!valid) {
				print ("fail");
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

	public void ClearActions() {
		actions.Clear();
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
