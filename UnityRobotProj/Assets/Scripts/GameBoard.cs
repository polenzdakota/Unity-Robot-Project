using UnityEngine;
using System.Collections;

/// <summary>
/// Stores any information for the game board.
/// </summary>
public static class GameBoard {
	public static bool completed = false;

	/// <summary>
	/// Checks to see if the Positions the is valid.
	/// </summary>
	/// <returns><c>true</c>, if is position was valid, <c>false</c> otherwise.</returns>
	/// <param name="pos">Position.</param>
	public static bool PositionIsValid(Vector3 pos) {
		//TODO currently unimplemented
		return true;
	}

	public static bool GetCompletion() {
		return completed;
	}
}
