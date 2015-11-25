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
		currentPosition = initialPosition;
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
		float nextX = currentPosition.x + (dx * moveDistance);
		float nextY = currentPosition.y + (dy * moveDistance);
		currentPosition.Set (nextX, nextY, 0);

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
		//TODO add rotation for the robot in the scene using quaterion.
	}

	/// <summary>
	/// Rotates the robot left.
	/// </summary>
	public void RotateLeft() {
		int tmp = dx;
		dx = -dy;
		dy = tmp;
		//TODO add rotation for the robot in the scene using quaterion.
	}

	/// <summary>
	/// Moves the robot to the given position.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="pos">Position.</param>
	public bool MoveToPosition(Vector3 pos) {
		Vector3 vectorCheck = pos;
		if (!GameBoard.PositionIsValid (vectorCheck)) {
			return false;
		}
		currentPosition = pos;
		return true;
	}
}
