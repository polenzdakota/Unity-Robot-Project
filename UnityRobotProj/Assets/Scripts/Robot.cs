using UnityEngine;
using System.Collections;

/// <summary>
/// Class for the main robot.
/// </summary>
/// Don't need to use quaternion 
public class Robot : MonoBehaviour, IRobot {
	public GameObject playerPosition;
	public Vector3 initialPosition;// = new Vector3(0,0,0);
	public float moveDistance = 1f;
	private Vector3 currentPosition;

	//Dx and Dy indicate the direction the robot is facing
	//With dx = 1 and dy = 0 the robot is facing right and
	//will move in that direction with a move forward command
	public static int dx = 1;
	public static int dy = 0;
	/// </summary>

	// Use this for initialization
	void Start () {
		currentPosition = playerPosition.transform.position;//initialPosition;
		//dx = 1;
		//dy = 0;
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
		Debug.Log ("dx: " + dx + "dy: " + dy);
		float nextX = currentPosition.x + (dx * moveDistance);
		float nextY = currentPosition.y + (dy * moveDistance);
		float newMoveDistance = 0;
		/// Need to check the four conditions to see if move is going left, right, up or down
		/// If not moving up or down
		if (dx == 1 || dx == -1) {
			/// Going right
			if(dx == 1){
				Debug.Log("moving right");
				newMoveDistance += moveDistance;
			}
			/// Going left
			if(dx == -1){
				Debug.Log("moving left");
				newMoveDistance += moveDistance * -1;
			}
		}
		/// If not moving left or right
		if (dy == 1 || dy == -1) {
			/// Going up
			if(dy == 1){
				Debug.Log("moving up");
				newMoveDistance += moveDistance;
			}
			/// Going down
			if(dy == -1){
				Debug.Log("moving down");
				newMoveDistance += moveDistance * -1;
			}
		}

		Vector3 vectorCheck = new Vector3 (nextX, nextY, 0);
		if (!GameBoard.PositionIsValid (vectorCheck)) {
			return false;
		}
		//print ("Next X coordinate: "+nextX);
		currentPosition.Set (nextX, nextY, 0);

		/// If robot is moving left or right
		if ((dx == 1 || dx == -1) && dy == 0) {
			transform.Translate (newMoveDistance,currentPosition.y, Time.deltaTime*moveDistance);
		}
		//if robot is moving up or down
		if ((dy == 1 || dy == -1) && dx == 0) {
			transform.Translate (currentPosition.x, newMoveDistance, Time.deltaTime * moveDistance);
		}
		//transform.Translate (nextX, nextY, 0);
		print (currentPosition);

		return true;
	}

	/// <summary>
	/// Rotates the robot right.
	/// </summary>
	public void RotateRight() {
		Debug.Log("Rotating right");
		///check the position
		/// If facing right, face down
		bool turn = false;
		if (dx == 1 && turn == false) {
			Debug.Log("facing down now");
			dy = -dx;
			dx = 0;
			turn = true;
		}
		/// If facing down, face left
		if (dx == 0 && dy == -1 && turn == false) {
			Debug.Log("facing left now");
			dx = dy;
			dy = 0;
			turn = true;
			Debug.Log (dx);
			Debug.Log (dy);
		}
		/// If facing left, face up
		if (dx == -1 && turn == false) {
			dy = -dx;
			dx = 0;
			turn = true;
		}
		/// If facing up, face right
		if (dx == 0 && dy == 1 && turn == false) {
			dx = dy;
			dy = 0;
			turn = true;
		}
	}

	/// <summary>
	/// Rotates the robot left.
	/// </summary>
	public void RotateLeft() {
		Debug.Log("Rotating left");
		///check the position
		/// If facing right, face up
		bool turn = false;
		if (dx == 1 && turn == false) {
			Debug.Log("facing down now");
			dy = dx;
			dx = 0;
			turn = true;
		}
		/// If facing up, face left
		if (dx == 0 && dy == 1 && turn == false) {
			Debug.Log("facing left now");
			dx = -dy;
			dy = 0;
			turn = true;
		}
		/// If facing left, face down
		if (dx == -1 && turn == false) {
			dy = dx;
			dx = 0;
			turn = true;
		}
		/// If facing up, face right
		if (dx == 0 && dy == -1 && turn == false) {
			dx = -dy;
			dy = 0;
			turn = true;
		}
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