using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Controls buttons and positions on the UI.
/// </summary>
public class UIControl : MonoBehaviour {
	public GameObject actionPanel;
	public GameObject TestButton;
	public GameObject command;
	public GameObject currentRobot;
	public GameObject failWindow;
	private bool inPlay;
	private List<GameObject> queuedActions = new List<GameObject>();

	void start() {
		inPlay = false;
	}

	void update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	/// <summary>
	/// Action done when a button is pressed.
	/// </summary>
	/// <param name="strAction">String action.</param>
	public void ButtonPress(string strAction) {
		if (!inPlay) {
			Vector3 dumb = new Vector3 (0, 0, 0);
			Quaternion stuff = new Quaternion (0, 0, 0, 0);
			GameObject newButton = Instantiate (TestButton, dumb, stuff) as GameObject;
			newButton.transform.SetParent (actionPanel.transform);

			newButton.GetComponentInChildren<Text> ().text = strAction;
			queuedActions.Add (newButton);

			if (strAction.Equals ("forward")) {
				MainMoveForward forward = currentRobot.GetComponent<MainMoveForward> ();
				command.GetComponent<Command> ().AddAction (forward);
			} else if (strAction.Equals ("right")) {
				MainRotateRight right = currentRobot.GetComponent<MainRotateRight> ();
				command.GetComponent<Command> ().AddAction (right);
			} else if (strAction.Equals ("left")) {
				MainRotateLeft left = currentRobot.GetComponent<MainRotateLeft> ();
				command.GetComponent<Command> ().AddAction (left);
			}
		}


		//TODO options for multiple buttons. We can use the string paran to 
		//     Differentiate between the actions.
	}
	//return the current list of queued actions
	public List<GameObject> Queue(){
		return queuedActions;
	}

	public void Execute() {
		inPlay = true;
		command.GetComponent<Command> ().ExecuteActions ();
	}

	public void Restart() {
		ClearActions ();
		currentRobot.GetComponent<Robot> ().SetInitialPosition ();
		inPlay = false;
	}

	public void ClearActions() {
		//TODO clear actions from list in Command
		command.GetComponent<Command> ().ClearActions ();
		foreach (GameObject button in queuedActions) {
			//Horrible code but I don't care
			if (button != null) {
				button.GetComponent<ActionButton>().OnPress();
			}
		}
	}

	/// <summary>
	/// Adds the action to panel.
	/// </summary>
	/// <param name="action">Action.</param>
	public void AddActionToPanel(IActions action) {
		//TODO
	}
}
