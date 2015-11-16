using UnityEngine;
using System.Collections;

// enemy関数
public class Enemy : Token
{
	// 生存数
	public static int Count = 0;

	// 初期化
	void Start()
	{
		// 生存数増加
		Count++;

		// enemyのサイズ設定
		SetSize(SpriteWidth / 2, SpriteHeight / 2);
		// ランダムな方向に移動
		// 方向をランダムに決める
		float dir = Random.Range(0,359);
		
		// 速さ
		float speed = 2;
		SetVelocity(dir,speed);
	}

	// 更新
	void Update()
	{
		// カメラの左下座標取得
		Vector2 min = GetWorldMin();
		// カメラの右上座標取得
		Vector2 max = GetWorldMax();

		if (X < min.x || max.x < X)
		{
			// x座標が画面外
			VX *= -1;
			// 画面内に移動
			ClampScreen();
		}

		if (Y < min.y || max.y < Y)
		{
			// y座標が画面外
			VY *= -1;
			// 画面内に移動
			ClampScreen();
		}
	}

	// クリック処理
	public void OnMouseDown()
	{
		// 生存数減少
		Count--;

		for (int i = 0; i < 32; i++)
		{
			Particle.Add(X,Y);
		}

		// オブジェクト破棄
		DestroyObj();
	}
}

// EOF