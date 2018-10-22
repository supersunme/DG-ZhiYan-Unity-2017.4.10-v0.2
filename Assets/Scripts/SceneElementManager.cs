using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using se = SceneElement;
using UnityEngine.SceneManagement;
public class SceneElementManager : MonoBehaviour {
	private int currentWorketIndex = 0;
	private bool isScene_1 = false;
	void Start () {
		se.Ins.PlayVideoButton.onClick.AddListener (() => {
			se.Ins.playVideoManager.PlayVideo (se.Ins.currentPlayVideoName);
		});
		se.Ins.playVideoManager.VideoPlayCompletEvent += VideoPlayComplete;
		se.Ins.collectSceneManager.CollectCompleteAction += CollectComplete;
		se.Ins.congratulationNextLevelBtn.onClick.AddListener (() => {
			se.Ins.confratulationObj.Close ();
			se.Ins.collectSceneManager.Close ();
			se.Ins.scene_Collect.Close ();
			if (se.Ins.collectSceneManager.currentWorkerman == WorkerMan.ZUL) {
				se.Ins.completeObj.gameObject.SetActive (true);
				return;
			}
			ShowScene_4 ();
		});
	}
	/// <summary>
	/// 有黑幕的界面
	/// </summary>
	public void ShowScene_1 () {
		isScene_1 = true;

		se.Ins.currentPlayVideoName = "0盐场";
		se.Ins.scene_0_obj.SetActive (false);
		se.Ins.backGround_js_fs_qs.SetActive (true);
		se.Ins.scene_1_obj.SetActive (true);
		//se.Ins.backGround_2_3_4
		se.Ins.CounchObj.SetActive (true);
		se.Ins.nPCManager.Play_Appearance ();

		se.Ins.PlayVideoButton.gameObject.SetActive (true);

		se.Ins.scrollRectManager.gameObject.SetActive (true);

		se.Ins.NextStepButton.onClick.AddListener (() => {
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
			ShowScene_2 ();
		});
	}
	/// <summary>
	/// 拍照的界面
	/// </summary>
	public void ShowScene_2 () {
		print ("ShowScen_2");
		//se.Ins.Scene_1_obj对象下有TweenScale和TweenMove多个组件
		//单独写一个扩展方法来隐藏对象
		se.Ins.scrollRectManager.gameObject.Close ();;
		se.Ins.scene_1_obj.Close ();
		se.Ins.PlayVideoButton.gameObject.Close ();;
		se.Ins.NextStepButton.gameObject.Close ();;
		se.Ins.CounchObj.SetActive (true);
		se.Ins.nPCManager.Next ();
		se.Ins.scene_2_obj.SetActive (true);
		se.Ins.takePhotoManager.TakePhotoCompleteAction = delegate () {
			se.Ins.NextStepButton.gameObject.SetActive (true);
		};
		se.Ins.NextStepButton.onClick.AddListener (() => {
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
			ShowScene_3 ();
		});
	}
	/// <summary>
	/// 照片ShowPhoto的界面
	/// </summary>
	public void ShowScene_3 () {
		print ("ShowScen_3");
		se.Ins.scene_2_obj.gameObject.Close ();;
		se.Ins.NextStepButton.gameObject.Close ();;
		se.Ins.CounchObj.gameObject.SetActive (false);
		se.Ins.dialogObj.Close ();
		se.Ins.scene_3_obj.gameObject.SetActive (true);
		se.Ins.photoShow.PhotoShowAction = delegate () {
			se.Ins.NextStepButton.gameObject.SetActive (true);
		};
		se.Ins.NextStepButton.onClick.AddListener (() => {
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
			ShowScene_4 ();
		});
	}
	/// <summary>
	/// 显示知识点的面板
	/// </summary>
	public void ShowScene_4 () {
		print ("ShowScene_4");

		se.Ins.NextStepButton.gameObject.Close ();;
		se.Ins.scene_3_obj.gameObject.Close ();;
		se.Ins.scrollRectManager.gameObject.SetActive (true);
		se.Ins.NextStepButton.gameObject.Close ();;
		se.Ins.PlayVideoButton.gameObject.SetActive (true);
		se.Ins.CounchObj.SetActive (true);
		se.Ins.nPCManager.Next ();

		CheckCurrentWorker (currentWorketIndex);

		//se.Ins.currentPlayVideoName="2浸泡沙土";

		se.Ins.NextStepButton.onClick.AddListener (() => {
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
			ShowScene_Collect ();

		});
	}
	/// <summary>
	/// 收集材料的界面
	/// </summary>
	public void ShowScene_Collect () {
		//检查当前是第几个场景
		se.Ins.scrollRectManager.gameObject.Close ();;
		se.Ins.PlayVideoButton.gameObject.Close ();;
		se.Ins.NextStepButton.gameObject.Close ();
		se.Ins.scene_Collect.SetActive (true);
		//se.Ins.nPCManager.Next ();
		se.Ins.nPCManager.ShowCollectDialog ();
		se.Ins.propsObj.gameObject.SetActive (true);
		se.Ins.NextStepButton.onClick.AddListener (() => {
			se.Ins.NextStepButton.onClick.RemoveAllListeners ();
		});
	}
	public void ShowScene_Congratulation () {
		print ("恭喜你场景");
		//ShowScene_4();
		//se.Ins.scene_Collect.Close ();
		se.Ins.confratulationObj.gameObject.SetActive (true);
		se.Ins.NextStepButton.gameObject.Close ();
		se.Ins.CounchObj.gameObject.SetActive (false);
		se.Ins.dialogObj.Close();
	}
	private void VideoPlayComplete () {
		if (isScene_1) {
			if (se.Ins.currentPlayVideoName == "1器具") {
				se.Ins.NextStepButton.gameObject.SetActive (true);
				isScene_1 = false;
				return;
			}
			se.Ins.scrollRectManager.ShowKnowLedge ();
			se.Ins.currentPlayVideoName = "1器具";
			return;
		}
		se.Ins.NextStepButton.gameObject.SetActive (true);
	}
	private void CollectComplete () {
		//se.Ins.NextStepButton.gameObject.SetActive (true);
		ShowScene_Congratulation ();
	}

	public void BackMainLevel () {
		SceneManager.LoadScene ("main");
	}
	private void CheckCurrentWorker (int index) {
		switch (index) {
			case 0:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.JS;
				se.Ins.currentPlayVideoName = "2浸泡沙土";
				Debug.Log (index);
				break;
			case 1:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.FS;
				se.Ins.currentPlayVideoName = "3翻沙工人";
				break;
			case 2:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.QS;
				se.Ins.currentPlayVideoName = "4取沙";
				break;
			case 3:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.ZL;
				se.Ins.currentPlayVideoName = "5制卤";
				se.Ins.backGround_js_fs_qs.gameObject.SetActive (false);
				se.Ins.background_zl_ql.gameObject.SetActive (true);
				break;
			case 4:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.QL;
				print (4);
				se.Ins.currentPlayVideoName = "6取卤";
				//se.Ins.backGround_js_fs_qs.gameObject.SetActive (false);
				se.Ins.background_zl_ql.gameObject.SetActive (true);
				break;
			case 5:
				se.Ins.collectSceneManager.currentWorkerman = WorkerMan.ZUL;
				se.Ins.currentPlayVideoName = "7煮卤";
				se.Ins.backGround_js_fs_qs.gameObject.SetActive (false);
				se.Ins.background_zl_ql.gameObject.SetActive (false);
				se.Ins.background_zul.gameObject.SetActive (true);

				break;
			case 6:

				Debug.Log ("结束");
				break;
		}
		currentWorketIndex++;
	}
}