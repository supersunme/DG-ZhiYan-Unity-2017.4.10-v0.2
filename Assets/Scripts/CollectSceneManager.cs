using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using se = SceneElement;
using System;
using System.Text;
using DG.Tweening;
public class CollectSceneManager : MonoBehaviour {
	[SerializeField]
	private PropConfig[] propConfigs;
	[SerializeField]
	private Image leftImage;
	[SerializeField]
	private Image rightImage;
	[SerializeField]
	private Image avatarImage;
	public WorkerMan currentWorkerman = WorkerMan.NONE;
	public Action CollectCompleteAction;
	//道具数
	private int currentPropCount = 0;
	//总道具数
	public int propCounts = 2;
	[SerializeField]
	public RectTransform propRectParent;
	void OnEnable () {
		Init ();
	}
	private void Init () {
		switch (currentWorkerman) {
			case WorkerMan.NONE:
				break;
			case WorkerMan.JS:
				Temp (currentWorkerman);
				break;
			case WorkerMan.FS:
				Temp (currentWorkerman);
				break;
			case WorkerMan.QS:
				Temp (currentWorkerman);
				break;
			case WorkerMan.QL:
				Temp (currentWorkerman);
				break;
			case WorkerMan.ZL:
				Temp (currentWorkerman);
				break;
			case WorkerMan.ZUL:
				Temp (currentWorkerman);
				break;
			case WorkerMan.END:
				break;
			default:
				break;
		}
	}
	void Temp (WorkerMan workerman) {
		propRectParent.GetChild ((int) workerman).gameObject.SetActive (true);

		leftImage.sprite = propConfigs[(int) workerman].leftPropSprite;
		rightImage.sprite = propConfigs[(int) workerman].rightPropSprite;
		avatarImage.sprite = propConfigs[(int) workerman].avatarSprite;
		avatarImage.transform.GetChild (0).GetComponent<RawImage> ().texture =
			se.Ins.photoTxtureDict[Enum.GetName (currentWorkerman.GetType (), currentWorkerman)];
		//Debug.Log ((int) currentWorkerman);
	}
	public void Close () {
		//currentWorkerman = WorkerMan.NONE;
		//avatarImage.transform.GetChild (0).GetComponent<RawImage> ().texture = null;
		for (var i = 0; i < propRectParent.childCount; i++) {
			propRectParent.GetChild (i).gameObject.SetActive (false);
		}
		currentPropCount = 0;
	}
	public void Collect (RectTransform rect, int dir) {
		if (currentPropCount >= propCounts) return;
		var direction = dir == -1 ? leftImage.GetComponent<RectTransform> () : rightImage.GetComponent<RectTransform> ();
		GameObject obj = Instantiate (rect.gameObject);
		obj.GetComponent<Image> ().sprite = rect.GetComponent<Image> ().sprite;
		obj.transform.SetParent (propRectParent);
		obj.transform.SetAsLastSibling ();
		obj.GetComponent<Image> ().SetNativeSize ();
		obj.GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		obj.GetComponent<RectTransform> ().anchoredPosition = rect.anchoredPosition;
		obj.GetComponent<RectTransform> ().localScale = rect.localScale;
		obj.GetComponent<RectTransform> ().DOAnchorPos (direction.anchoredPosition, 1f).SetEase (Ease.InFlash);
		obj.GetComponent<RectTransform> ().DOScale (Vector3.one, 1f).SetEase (Ease.Flash);

		currentPropCount++;
		obj.GetComponent<RectTransform> ().DOLocalRotate (Vector3.zero, 1f).OnComplete (() => {
			if (currentPropCount >= propCounts) {
				CollectCompleteAction?.Invoke ();
				print ("收集完成");
			}
		});
	}
}