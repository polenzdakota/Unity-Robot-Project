using UnityEngine;
using System.Collections;

/// <summary>
/// This class contains all methods regarding chaning levels.
/// </summary>
public static class Transitions : MonoBehaviour {

	/// <summary>
	/// Saves the attribute to the given key.
	/// </summary>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	public void SaveAttribute(string key, float value) {
		PlayerPrefs.SetFloat (key, value);
	}

	/// <summary>
	/// Gets the attibute from the key.
	/// </summary>
	/// <returns>The attibute.</returns>
	/// <param name="key">Key.</param>
	public float GetAttibute(string key) {
		return PlayerPrefs.GetFloat (key);
	}

	/// <summary>
	/// Loads the level given the name.
	/// </summary>
	/// <param name="toLevel">To level.</param>
	public void LoadLevel(string toLevel) {
		Application.LoadLevel (toLevel);
	}
}
