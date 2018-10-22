using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WorkerMan {
	NONE=-1,
	JS=0,
	FS=1,
	QS=2,
	ZL=3,
	QL=4,
	ZUL=5,
	END=-2
}
public class SceneElement : MonoBehaviour {
	private static SceneElement _Instance;
	public static SceneElement Ins {
		get { return _Instance; }
	}
	void Awake () {
		_Instance = this;
	}
	public GameObject scene_0_obj;
	[Header ("场景一")]
	#region /*************Scene_1****************/	
	public GameObject scene_1_obj;
	#endregion
	/************Scene_2 */
	[Header ("场景二")]
	#region /************Scene_2 ****************/
	public GameObject scene_2_obj;
	[Header ("场景三")]
	public GameObject scene_3_obj;
	#endregion
	/*************CommonUI **************/
	[Header ("公共UI")]
	#region /*************CommonUI***************/
	public Button PlayVideoButton;
	public Button NextStepButton;
	public RawImage videoPlayRawImage;
	public GameObject CounchObj;
	public GameObject dialogObj;
	public PlayVideoManager playVideoManager;
	[HideInInspector]
	public string currentPlayVideoName = string.Empty;
	public NPCManager nPCManager;
	public GameObject backGround_js_fs_qs;
	public Dictionary<string, Texture> photoTxtureDict = new Dictionary<string, Texture> ();
	public TakePhotoManager takePhotoManager;
	public PhotoShow photoShow;
	//知识点列表
	public ScrollRectManager scrollRectManager;

	public GameObject background_zl_ql;
	public GameObject background_zul;
	public GameObject completeObj;
	[Header("Scene-Scrollect")]
	public GameObject scene_Collect;
	public GameObject propsObj;
	public CollectSceneManager collectSceneManager;

	[Header("恭喜你面板")]
	public GameObject confratulationObj;
	public Button congratulationNextLevelBtn;

	#endregion
}