using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Controls buttons and positions on the UI.
/// </summary>
public class UIControl : MonoBehaviour {
	public GameObject actionPanel;
	public GameObject TestButton;

	/// <summary>
	/// Action done when a button is pressed.
	/// </summary>
	/// <param name="strAction">String action.</param>
	public void ButtonPress(string strAction) {
		print ("Trigger with action: " + strAction);
		Vector3 dumb = new Vector3 (0, 0, 0);
		Quaternion stuff = new Quaternion (0,0,0,0);
		GameObject newButton = Instantiate (TestButton, dumb, stuff) as GameObject;
		print (newButton.transform.position.x);
		newButton.transform.SetParent (actionPanel.transform);

		//TODO options for multiple buttons. We can use the string paran to 
		//     Differentiate between the actions.
	}

	/// <summary>
	/// Adds the action to panel.
	/// </summary>
	/// <param name="action">Action.</param>
	public void AddActionToPanel(IActions action) {
		//TODO
	}
}
