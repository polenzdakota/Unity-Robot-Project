using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the main robot forward.
/// </summary>
public class MainMoveForward : MonoBehaviour, IActions {
	//public GameObject mainRobot;
	private GameObject mainRobot;
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		//mainRobot = GameObject.FindGameObjectWithTag ("Player");
		mainRobot = GameObject.FindGameObjectWithTag ("Player");//GameObject.Find ("mainRobotTest");
		Debug.Log (mainRobot.tag);
		initialPos = mainRobot.GetComponent<Robot> ().GetPosition ();
		Debug.Log (initialPos);
	}

	/// <summary>
	/// Invokes the action of the command.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool InvokeAction() {
		//Debug.Log (mainRobot.GetComponent<Robot> ().MoveForward ());
		return mainRobot.GetComponent<Robot> ().MoveForward ();
	}

	/// <summary>
	/// Undos the action.
	/// </summary>
	public void UndoAction() {
		mainRobot.GetComponent<Robot> ().MoveToPosition (initialPos);
	}
}
