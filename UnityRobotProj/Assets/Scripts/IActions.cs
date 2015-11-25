using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for commands.
/// </summary>
public interface IActions {

	/// <summary>
	/// Invokes the action of the command.
	/// </summary>
	/// <returns><c>true</c>, if action was invoked, <c>false</c> otherwise.</returns>
	bool InvokeAction();

	/// <summary>
	/// Undos the action.
	/// </summary>
	void UndoAction();
}
