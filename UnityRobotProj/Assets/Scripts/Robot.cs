using UnityEngine;
using System.Collections;

/// <summary>
/// Class for the main robot.
/// </summary>
/// Don't need to use quaternion 
public class Robot : MonoBehaviour, IRobot {
	public GameObject playerPosition;
	public static Vector3 initialPosition;// = new Vector3(0,0,0);
	public float moveDistance = 1f;
	private static Vector3 currentPosition;
	private static Vector3 nextPositionToGo;
	private static Vector3 targetPosition;
	private static Sprite currentSprite;
	public Sprite rightSprite;
	public Sprite leftSprite;
	public Sprite upSprite;
	public Sprite downSprite;

	//Dx and Dy indicate the direction the robot is facing
	//With dx = 1 and dy = 0 the robot is facing right and
	//will move in that direction with a move forward command
	public static int dx = 1;
	public static int dy = 0;
	/// </summary>

	// Use this for initialization
	void Start () {
		currentPosition = playerPosition.transform.position;//initialPosition;
		initialPosition = playerPosition.transform.position;
		targetPosition = initialPosition;
		currentSprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		MoveTowardsTarget ();
	}
	private void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target
		float speed = 5;
		//move towards the center of the world (or where ever you like)

		
		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if (Vector3.Distance (currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize ();
			//scale the movement on each axis by the directionOfTravel vector components
			
			transform.Translate (
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		} else {
			transform.position = targetPosition;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Death")
		{
			print ("Collision hit!");
			//Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "Win")
		{
			print ("Level Completed");
			//Destroy(col.gameObject);
			Application.LoadLevel("Gameover");
		}
	}

	public void SetInitialPosition() {
		transform.position = initialPosition;

		//Sets initial dx and dy
		dx = 1;
		dy = 0;
		targetPosition = initialPosition;

	}

	/// <summary>
	/// Moves the robot forward.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	public bool MoveForward() {
		Debug.Log ("dx: " + dx + "dy: " + dy);
		currentPosition = transform.position;
		float nextX = currentPosition.x + (dx * moveDistance);
		float nextY = currentPosition.y + (dy * moveDistance);
		float newMoveDistance = 0;

		Vector3 vectorCheck = new Vector3 (nextX, nextY, 0);
		if (!GameBoard.PositionIsValid (vectorCheck)) {
			return false;
		}

		Vector3 next = new Vector3 (nextX, nextY);
		targetPosition = next;
		print ("target pos: " + targetPosition);
		print ("Current pos: " +currentPosition);


		return true;
	}

	/// <summary>
	/// Rotates the robot right.
	/// </summary>
	public void RotateRight() {
		///check the position
		/// If facing right, face down
		bool turn = false;
		if (dx == 1 && turn == false) {
			dy = -dx;
			dx = 0;
			turn = true;
		}
		/// If facing down, face left
		if (dx == 0 && dy == -1 && turn == false) {
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
		changeSprite();
	}

	/// <summary>
	/// Rotates the robot left.
	/// </summary>
	public void RotateLeft() {
		///check the position
		/// If facing right, face up
		bool turn = false;
		if (dx == 1 && turn == false) {
			dy = dx;
			dx = 0;
			turn = true;
		}
		/// If facing up, face left
		if (dx == 0 && dy == 1 && turn == false) {
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
		changeSprite();
	}

	public void changeSprite() {
		if (dx == 1) {
			GetComponent<SpriteRenderer>().sprite = rightSprite;
		} else if (dx == -1) {
			GetComponent<SpriteRenderer>().sprite = leftSprite;
		} else if (dy == 1) {
			GetComponent<SpriteRenderer>().sprite = upSprite;
		} else {
			GetComponent<SpriteRenderer>().sprite = downSprite;
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
		changeSprite();
	}
}