using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof (Button))]
public class PropCollect : MonoBehaviour {
	[SerializeField]
	private int direction = -1;
	private bool isHave = false;
	void Start () {

		this.GetComponent<Button> ().onClick.AddListener (() => {
			if (isHave) return;
			FindObjectOfType<CollectSceneManager> ().Collect (this.GetComponent<RectTransform> (), direction);
			isHave = true;
			this.gameObject.SetActive (false);
		});
	}
}