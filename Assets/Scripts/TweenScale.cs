using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TweenScale : MonoBehaviour {
	public float durationTime=1.0f;
	public Ease easeTypeOut=Ease.OutBounce;
	public Ease easeTypeIn=Ease.InBounce;
	public float delayTime=0f;
	void OnEnable()
	{
		this.GetComponent<RectTransform>().localScale=Vector2.zero;
		this.GetComponent<RectTransform>().DOScale(Vector3.one,durationTime).SetEase(easeTypeOut).SetDelay(delayTime);
	}
	public  void Close(){
		this.GetComponent<RectTransform>().DOScale(Vector3.zero,durationTime/3).SetEase(easeTypeIn).SetDelay(delayTime/3).OnComplete(()=>{
			this.gameObject.SetActive(false);
			this.GetComponent<RectTransform>().localScale=Vector2.zero;
		});
	}
}
