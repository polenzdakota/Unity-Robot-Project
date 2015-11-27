using UnityEngine;
using System.Collections;

public class MainRotateRight : MonoBehaviour, IActions {
	private GameObject mainRobot;

	/// <summary>
	/// Invokes the action of the command.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool InvokeAction() {
		mainRobot.GetComponent<Robot> ().RotateRight ();
		return true;
	}

	/// <summary>
	/// Undos the action.
	/// </summary>
	public void UndoAction() {
		mainRobot.GetComponent<Robot> ().RotateLeft ();
	}
}
