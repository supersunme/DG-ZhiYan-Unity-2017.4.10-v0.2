using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameObjectExpansion {
	/// <summary>
	/// 扩展方法，查找父级对象是否包含T组件
	/// </summary>
	/// <param name="obj"></param>
	public static void Close (this GameObject obj) {
		TweenMove[] tweenMoves = FindInChild<TweenMove> (obj);
		foreach (var item in tweenMoves) {
			item.Close ();
		}
		TweenScale[] tweensScales = FindInChild<TweenScale> (obj);
		foreach (var item in tweensScales) {
			item.Close ();
		}
	}
	private static T[] FindInChild<T> (GameObject obj) where T : Component {
		var childs = obj.GetComponentsInChildren<T> ();
		return childs;
	}
	/// <summary>
	/// 用于获取组件，并调用组件的方法
	/// </summary>
	/// <param name="component"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static void Close<T> (this Transform obj) where T : TweenScale {
		T temp = obj.GetComponent<T> ();
		temp?.Close ();
	}
}