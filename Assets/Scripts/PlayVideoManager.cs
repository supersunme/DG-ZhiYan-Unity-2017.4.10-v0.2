using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class PlayVideoManager : MonoBehaviour {
	[SerializeField]
	private VideoPlayer videoPlayer;
	[SerializeField]
	private RawImage rawImage;
	public Action VideoPlayCompletEvent;
	private RenderTexture CreateRenderTexture () {
		var rt = new RenderTexture (1920, 1080, 16, RenderTextureFormat.ARGB32);
		return rt;
	}
	public void PlayVideo (string videoName) {
		var rt = CreateRenderTexture ();
		videoPlayer.gameObject?.SetActive (true);
		rawImage.color = new Color (1, 1, 1, 1);
		rawImage.texture = rt;
		videoPlayer.targetTexture = rt;
		videoPlayer.url = Application.streamingAssetsPath + "/" + videoName + ".mp4";
		videoPlayer.loopPointReached += VideoPlayComple;
		videoPlayer.Play ();
	}
	public void CloseVideo () {
		videoPlayer.GetComponent<TweenScale> ()?.Close ();
		videoPlayer.Stop ();
		videoPlayer.targetTexture = null;
		rawImage.texture = null;
		rawImage.color = new Color (1, 1, 1, 0);
		this.GetComponent<TweenScale> ()?.Close ();
		VideoPlayCompletEvent?.Invoke ();
	}
	private void VideoPlayComple (VideoPlayer source) {
		CloseVideo ();
		VideoPlayCompletEvent?.Invoke ();
	}
	void Update () {
		if (videoPlayer.isPlaying) {
			if (Input.GetMouseButtonDown (0)) {
				CloseVideo ();
			}
		}
	}
}