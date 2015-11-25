using UnityEngine;
using System.Collections;

public interface IRobot {

	/// <summary>
	/// Moves the robot forward.
	/// </summary>
	/// <returns><c>true</c>, if forward was moved, <c>false</c> otherwise.</returns>
	bool MoveForward();

	/// <summary>
	/// Rotates the robot right.
	/// </summary>
	void RotateRight();

	/// <summary>
	/// Rotates the robot left.
	/// </summary>
	void RotateLeft();

	/// <summary>
	/// Moves the robot to the given position.
	/// </summary>
	/// <returns><c>true</c>, if to position was moved, <c>false</c> otherwise.</returns>
	/// <param name="pos">Position.</param>
	bool MoveToPosition(Vector3 pos);

}
