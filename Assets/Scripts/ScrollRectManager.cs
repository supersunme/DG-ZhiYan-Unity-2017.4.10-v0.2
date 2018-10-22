using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectManager : MonoBehaviour {
	[SerializeField]
	private ScrollRect scrollRect;
	[SerializeField]
	private Sprite[] knowLedgeImage;
	[SerializeField]
	private RectTransform content;
	private int currentIndex=0;
	private void OnEnable() {
		ShowKnowLedge ();
		scrollRect.verticalScrollbar.value=1;
	}
	public void ShowKnowLedge () {
		scrollRect.content.anchoredPosition=new Vector2(scrollRect.content.anchoredPosition.x,0);
		if (currentIndex >= knowLedgeImage.Length-1) return;
		scrollRect.verticalScrollbar.value=1;
		
		content.GetComponent<Image> ().sprite = knowLedgeImage[currentIndex];
		scrollRect.verticalScrollbar.value=1;
		content.GetComponent<Image> ().SetNativeSize ();
		scrollRect.content = content;	
		scrollRect.content.anchoredPosition=new Vector2(scrollRect.content.anchoredPosition.x,0);
		currentIndex++;

		scrollRect.verticalScrollbar.value=1;
	}
}