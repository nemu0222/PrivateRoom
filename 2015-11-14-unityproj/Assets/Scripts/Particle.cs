using UnityEngine;
using System.Collections;

public class Particle : Token
{
	// プレハブ
	static GameObject _prefab = null;
	// パーティクル生成
	public static Particle Add(float x,float y)
	{
		// プレハブ取得
		_prefab = GetPrefab(_prefab,"Particle");
		// プレハブからインスタンス生成
		return CreateInstance2<Particle>(_prefab,x,y);
	}

	// 初期化
	IEnumerator Start()
	{
		// 移動方向と速さをランダムに決める
		float dir = Random.Range(0, 359);
		float spd = Random.Range(10.0f, 20.0f);
		SetVelocity(dir, spd);
		
		// 見えなくなるまで小さく
		while (ScaleX > 0.01f)
		{
			// 0.01秒ゲームループに制御返す
			yield return new WaitForSeconds(0.01f);
			// だんだん小さく
			MulScale(0.9f);
			// だんだん減速
			MulVelocity(0.9f);
		}
		
		// オブジェクト破棄
		DestroyObj();		
	}
	
	// 更新
	void Update()
	{
	
	}
}

// EOF