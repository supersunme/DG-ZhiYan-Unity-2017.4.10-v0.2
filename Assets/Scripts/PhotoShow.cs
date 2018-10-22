using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using se = SceneElement;
using System;
public class PhotoShow : MonoBehaviour {
	private int currentIndex = 0;
	[SerializeField]
	private RectTransform gridLayoutRect;
	public Action PhotoShowAction;
	[SerializeField]
	private int delayTime = 1;
	void Start () {
		StartCoroutine (DelayShow ());
	}
	IEnumerator DelayShow () {
		print(gridLayoutRect.childCount);
		if (currentIndex >= gridLayoutRect.childCount) {
			PhotoShowAction?.Invoke ();
			print("照片显示完成");
			yield break;
		}
		yield return new WaitForSeconds (delayTime);
		gridLayoutRect.GetChild (currentIndex).GetChild (0).gameObject.SetActive(true);
		gridLayoutRect.GetChild (currentIndex).GetChild (0).GetComponent<RawImage> ().texture =
			se.Ins.photoTxtureDict[gridLayoutRect.GetChild (currentIndex).name];
		yield return new WaitForEndOfFrame ();
		currentIndex++;
		yield return StartCoroutine (DelayShow ());
	}
}