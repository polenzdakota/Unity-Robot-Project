using UnityEngine;
using System.Collections;

public class MainRotateLeft : MonoBehaviour, IActions {
	private GameObject mainRobot;
	private int[] initialRotation; 
	
	// Use this for initialization
	void Start () {
		//mainRobot = GameObject.FindGameObjectWithTag ("Player");
		mainRobot = GameObject.FindGameObjectWithTag ("Player");//GameObject.Find ("mainRobotTest");
		Debug.Log (mainRobot.tag);
		initialRotation = mainRobot.GetComponent<Robot> ().GetRotation ();
	}
	/// <summary>
	/// Invokes the action of the command.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool InvokeAction() {
		mainRobot.GetComponent<Robot> ().RotateLeft ();
		return true;
	}
	
	/// <summary>
	/// Undos the action.
	/// </summary>
	public void UndoAction() {
		mainRobot.GetComponent<Robot> ().SetRotation (initialRotation);
	}
}
