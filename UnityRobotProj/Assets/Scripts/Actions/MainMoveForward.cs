using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the main robot forward.
/// </summary>
public class MainMoveForward : MonoBehaviour, IActions {
	public GameObject mainRobot;
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = mainRobot.GetComponent<Robot> ().GetPosition ();
		mainRobot = GameObject.Find ("mainRobotTest");
	}

	/// <summary>
	/// Invokes the action of the command.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool InvokeAction() {
		return mainRobot.GetComponent<Robot> ().MoveForward ();
	}

	/// <summary>
	/// Undos the action.
	/// </summary>
	public void UndoAction() {
		mainRobot.GetComponent<Robot> ().MoveToPosition (initialPos);
	}
}
