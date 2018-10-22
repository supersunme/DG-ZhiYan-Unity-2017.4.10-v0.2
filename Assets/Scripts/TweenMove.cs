using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public enum MoveDirection {
	LeftToRight,
	RightToLeft,
	TopToBottom,
	BottomToTop
}
public class TweenMove : MonoBehaviour {

	public Ease easeInType = Ease.InBounce;
	public Ease easeOutType = Ease.OutBounce;
	public MoveDirection moveDirection;
	public float durationTime = 1.0f;
	public float delayTimeIn = 0.0f;

	public float delayTimeOut = 0.0f;
	void OnEnable () {
		switch (moveDirection) {
			case MoveDirection.TopToBottom:
				this.GetComponent<RectTransform> ().DOAnchorPosY (
						this.GetComponent<RectTransform> ().anchoredPosition.y + this.GetComponent<RectTransform> ().sizeDelta.y, durationTime )
					.SetEase (easeOutType).SetDelay (delayTimeOut);
				break;
			case MoveDirection.BottomToTop:
				this.GetComponent<RectTransform> ().DOAnchorPosY (
						this.GetComponent<RectTransform> ().anchoredPosition.y - this.GetComponent<RectTransform> ().sizeDelta.y, durationTime )
					.SetEase (easeOutType).SetDelay (delayTimeOut);
				break;
			case MoveDirection.LeftToRight:
				this.GetComponent<RectTransform> ().DOAnchorPosX (
						this.GetComponent<RectTransform> ().anchoredPosition.x + this.GetComponent<RectTransform> ().sizeDelta.x, durationTime )
					.SetEase (easeOutType).SetDelay (delayTimeOut);
				break;
			case MoveDirection.RightToLeft:
				this.GetComponent<RectTransform> ().DOAnchorPosX (
						this.GetComponent<RectTransform> ().anchoredPosition.x - this.GetComponent<RectTransform> ().sizeDelta.x, durationTime )
					.SetEase (easeOutType).SetDelay (delayTimeOut);
				break;
		}
	}
	public void Close () {
		switch (moveDirection) {
			case MoveDirection.TopToBottom:
				this.GetComponent<RectTransform> ().DOAnchorPosY (
						this.GetComponent<RectTransform> ().anchoredPosition.y - this.GetComponent<RectTransform> ().sizeDelta.y, durationTime / 3)
					.SetEase (easeOutType).SetDelay (delayTimeIn)
					.OnComplete (() => {
						this.gameObject.SetActive (false);
					});
				break;
			case MoveDirection.BottomToTop:
				this.GetComponent<RectTransform> ().DOAnchorPosY (
						this.GetComponent<RectTransform> ().anchoredPosition.y + this.GetComponent<RectTransform> ().sizeDelta.y, durationTime / 3)
					.SetEase (easeOutType).SetDelay (delayTimeIn)
					.OnComplete (() => {
						this.gameObject.SetActive (false);
					});;
				break;
			case MoveDirection.LeftToRight:
				this.GetComponent<RectTransform> ().DOAnchorPosX (
						this.GetComponent<RectTransform> ().anchoredPosition.x - this.GetComponent<RectTransform> ().sizeDelta.x, durationTime / 3)
					.SetEase (easeOutType).SetDelay (delayTimeIn)
					.OnComplete (() => {
						this.gameObject.SetActive (false);
					});;
				break;
			case MoveDirection.RightToLeft:
				this.GetComponent<RectTransform> ().DOAnchorPosX (
						this.GetComponent<RectTransform> ().anchoredPosition.x + this.GetComponent<RectTransform> ().sizeDelta.x, durationTime / 3)
					.SetEase (easeOutType).SetDelay (delayTimeIn)
					.OnComplete (() => {
						this.gameObject.SetActive (false);
					});;
				break;
		}
	}
}