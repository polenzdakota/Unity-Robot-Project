using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
	public GameObject actionPanel;
	public GameObject TestButton;


	public void ButtonPress(string strAction) {
		print ("Trigger with action: " + strAction);
		Vector3 dumb = new Vector3 (0, 0, 0);
		Quaternion stuff = new Quaternion (0,0,0,0);
		GameObject newButton = Instantiate (TestButton, dumb, stuff) as GameObject;
		print (newButton.transform.position.x);
		newButton.transform.SetParent (actionPanel.transform);

		//TODO
	}

	public void AddActionToPanel(IActions action) {
		//TODO
	}
}
