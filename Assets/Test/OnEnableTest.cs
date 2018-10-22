using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SceneE{
	yi,
	er,
	san,
	si,
	wu,
	liu,
	qi,
	ba
}
public class OnEnableTest : MonoBehaviour {
	public SceneE  sceneE;
	private SceneElementManager sceneElementManager;

	void Start()
	{
		sceneElementManager=FindObjectOfType<SceneElementManager>();
		switch(sceneE){
			case SceneE.yi:
			sceneElementManager.ShowScene_1();
			break;
			case SceneE.er:
			sceneElementManager.ShowScene_2();
			break;
			case SceneE.san:
			//sceneElementManager.ShowScene_3();
			break;
			case SceneE.si:
			//sceneElementManager.ShowScene_4();
			break;
			case SceneE.wu:
			//sceneElementManager.ShowScene_5();
			break;
		}
	}
}
