using System;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour {
	[SerializeField]
	private Sprite[] diaLogSprite;
	[SerializeField]
	private Image dialogImage;
	private int currentIndex = 0;
	[SerializeField]
	private Sprite collectSprite;
	public UnityArmatureComponent unityArmatureComponent;
	void OnEnable()
	{
		
	}
	public void Next () {
		dialogImage.transform.parent.gameObject.SetActive (true);
		if (currentIndex >= diaLogSprite.Length) return;
		unityArmatureComponent?.animation.FadeIn("出场",-1,1);
		dialogImage.sprite = diaLogSprite[currentIndex];
		dialogImage.SetNativeSize ();
		currentIndex++;
	}
	public void Hide () {
		dialogImage.transform.gameObject.SetActive (false);
	}
	public void ShowCollectDialog () {
		unityArmatureComponent?.animation.FadeIn("出场",-1,1);
		dialogImage.transform.parent.gameObject.SetActive (true);
		dialogImage.sprite = collectSprite;
		dialogImage.SetNativeSize ();
	}
	/// <summary>
	/// 播放恭喜动画
	/// </summary>
	public void Play_Congratulations () {
		unityArmatureComponent.animation.FadeIn ("站立");
	}
	public void Play_Appearance(){
		unityArmatureComponent.animation.FadeIn ("出场",-1,1);
		this.unityArmatureComponent.AddDBEventListener(EventObject.COMPLETE,this.AnimationPlayComplete);
		//print("出场了");
	}
	private void AnimationPlayComplete (string type, EventObject eventObject) {
		//Debug.Log(eventObject.name);
		switch (eventObject.animationState.name) {
			case "出场":
				unityArmatureComponent.animation.FadeIn ("说话",-1,1);
				//print("出场动画播放完成");
				break;
			case "说话":
				unityArmatureComponent.animation.FadeIn ("待机",-1,0);
				// print("说话动画播放完成");
				// print("待机中");
				break;
		}
	}
}