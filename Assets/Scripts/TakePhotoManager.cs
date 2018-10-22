using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using se = SceneElement;
using System;
using DG.Tweening;
public class TakePhotoManager : MonoBehaviour {
	private WebCamTexture webCameraTexture;
	[SerializeField]
	private RawImage rawImage;

	[SerializeField]
	private Image white_flash;

	[SerializeField]
	private RawImage[] rawImages;
	private int currentIndex = 0;
	[SerializeField]
	private Button takeBtn;

	public Action TakePhotoCompleteAction;
	void Start () {
		OpenCamera ();
		takeBtn.onClick.AddListener (() => {
			Pause ();
		});
	}
	private RenderTexture CreateRenderTexture () {
		var rt = new RenderTexture ((int) rawImage.GetComponent<RectTransform> ().sizeDelta.x,
			(int) rawImage.GetComponent<RectTransform> ().sizeDelta.y, 16, RenderTextureFormat.ARGB32);
		return rt;
	}
	public void Pause () {
		webCameraTexture?.Pause ();
		if (currentIndex >= rawImages.Length) {
			takeBtn.interactable = false;
			return;
		}
		GetWebCameraTexture ();
	}
	void GetWebCameraTexture () {
		StartCoroutine (GetTexture ());
	}
	IEnumerator GetTexture () {
		takeBtn.interactable = false;
		yield return null;

		Texture2D mtexture = new Texture2D (webCameraTexture.width, webCameraTexture.height, TextureFormat.ARGB32, false);
		mtexture.SetPixels (webCameraTexture.GetPixels (0, 0, webCameraTexture.width, webCameraTexture.height));
		mtexture.Apply ();
		yield return new WaitForEndOfFrame ();

		se.Ins.photoTxtureDict.Add (rawImages[currentIndex].gameObject.name, mtexture);

		white_flash.transform.gameObject.SetActive (true);
		white_flash.transform.GetChild (0).GetComponent<RawImage> ().texture = mtexture;
		white_flash.transform.DOScale (0.35f, 1f);
		white_flash.DOFade (0, 1).OnComplete (() => {

			rawImages[currentIndex].gameObject.SetActive (true);
			rawImages[currentIndex].texture = mtexture;

			white_flash.transform.localScale = Vector3.one;
			white_flash.DOFade (1, 0f);

			white_flash.gameObject.SetActive (false);

			takeBtn.interactable = true;
			if (currentIndex >= rawImages.Length - 1) {
				takeBtn.interactable = false;
			}
			//white_flash.transform.localScale=Vector3.one;

			currentIndex++;
		});

		if (currentIndex >= rawImages.Length - 1) {
			takeBtn.interactable = false;
			TakePhotoCompleteAction?.Invoke ();
			CloseCamera ();
			yield break;
		}
		yield return new WaitForEndOfFrame ();
		//mtexture = null;
		webCameraTexture.Play ();
	}
	void OpenCamera () {
		WebCamDevice[] devices = WebCamTexture.devices;
		webCameraTexture = new WebCamTexture (devices[0].name, 1078, 689, 60);
		webCameraTexture.Play ();
		rawImage.texture = webCameraTexture;
	}
	void CloseCamera () {
		webCameraTexture.Stop ();
		webCameraTexture = null;
	}
}