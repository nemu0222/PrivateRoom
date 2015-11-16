using UnityEngine;
using System.Collections;

public class TitleMgr : MonoBehaviour
{
	void OnGUI()
	{
		// フォントサイズ
		Util.SetFontSize(32);
		// 中央揃え
		Util.SetFontAlignment(TextAnchor.MiddleCenter);

		// フォント位置
		float w = 128;	// 幅
		float h = 32;	// 高さ
		float px = Screen.width / 2 - w / 2;
		float py = Screen.height / 2 - h / 2;

		// フォント描画
		Util.GUILabel (px,py,w,h,"Mini Game");

		// ボタン少しずらす
		py += 60;

		if (GUI.Button (new Rect (px, py, w, h), "START"))
		{
			// メインゲーム開始
			Application.LoadLevel("main");
		}
	}
}

// EOF