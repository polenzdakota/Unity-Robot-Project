using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour, IRobot {

	public Vector3 initialPosition = new Vector3(0,0,0);
	public float moveDistance = 10;
	private Vector3 currentPosition;

	//Dx and Dy indicate the direction the robot is facing
	//With dx = 1 and dy = 0 the robot is facing right and
	//will move in that direction with a move forward command
	public int dx = 1;
	public int dy = 0;

	// Use this for initialization
	void Start () {
		currentPosition.Set (initialPosition);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Moves the robot forward.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool MoveForward() {
		float nextX = (currentPosition.x + moveDistance) * dx;
		float nextY = (currentPosition + moveDistance) * dy;
		currentPosition.Set (nextX, nextY);

		//TODO add check to see if the next position is valid.
		return true;
	}

	/// <summary>
	/// Rotates the robot right.
	/// </summary>
	public void RotateRight() {
		int tmp = dy;
		dy = -dx;
		dx = tmp;
		//TODO add rotation for the robot in the scene.
	}

	/// <summary>
	/// Rotates the robot left.
	/// </summary>
	public void RotateLeft() {
		int tmp = dx;
		dx = -dy;
		dy = tmp;
		//TODO add rotation for the robot in the scene.
	}

	/// <summary>
	/// Moves the robot to the given position.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="pos">Position.</param>
	public bool MoveToPosition(Vector3 pos) {
		currentPosition.Set (pos);

		//TODO add check to see if position is valid.
		return true;
	}
}
