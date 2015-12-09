using UnityEngine;
using System.Collections;

/// <summary>
/// Class for the main robot.
/// </summary>
/// Don't need to use quaternion 
public class Robot : MonoBehaviour, IRobot {
	public GameObject playerPosition;
	public Vector3 initialPosition;// = new Vector3(0,0,0);
	public float moveDistance = 100;
	private Vector3 currentPosition;

	//Dx and Dy indicate the direction the robot is facing
	//With dx = 1 and dy = 0 the robot is facing right and
	//will move in that direction with a move forward command
	public int dx = 1;
	public int dy = 0;

	// Use this for initialization
	void Start () {
		currentPosition = playerPosition.transform.position;//initialPosition;
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
		Vector3 vectorCheck = new Vector3 (nextX, nextY, 0);
		if (!GameBoard.PositionIsValid (vectorCheck)) {
			return false;
		}
		float speed = 10.0f;
		float step = speed * Time.deltaTime;
		currentPosition.Set (nextX, nextY, 0);
		transform.position = Vector3.MoveTowards(transform.position, currentPosition, step);
		print (currentPosition);

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

	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <returns>The position.</returns>
	public Vector3 GetPosition() {
		return currentPosition;
	}

	public int[] GetRotation() {
		return new int[2] {dx, dy};
	}

	/// <summary>
	/// Sets the rotation.
	/// </summary>
	/// <param name="rotation">Rotation.</param>
	public void SetRotation(int[] rotation) {
		dx = rotation [0];
		dy = rotation [1];
	}
}