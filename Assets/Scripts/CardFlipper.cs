﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	KomaModel model;

	public AnimationCurve scaleCurve;　
    public float duration = 0.5f;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		model = GetComponent<KomaModel>();
	}

	public void FlipCard(Sprite startImage, Sprite endImage, int cardIndex)
	{
		StopCoroutine(Flip(startImage, endImage, cardIndex));
		StartCoroutine(Flip(startImage, endImage, cardIndex));
	}

	//コールーチンで動くメソッドFlipの定義。
	IEnumerator Flip(Sprite startImage, Sprite endImage, int cardIndex)
	{
		spriteRenderer.sprite = startImage;
		float time = 0f;
		while (time <= 1f)      // time が１と等しいか小さい場合下記処理を繰り返す
		{
			float scale = scaleCurve.Evaluate(time);    //小数点scale の宣言とtimeに対応するAnimationCurveグラフでのScaleの値の代入。
			time = time + Time.deltaTime / duration;    //time に　time+PCの単位時間をdurationで割ったものを代入
			Vector3 localScale = transform.localScale;  //localScaleというVector3の宣言と現在のtransformlocalScaleの値の代入。
			localScale.x = scale;             //localScaleのx成分だけ上で定義したscaleを代入する。
			transform.localScale = localScale;      //現在のtransformにx成分変更後のlocalscaleを代入する。
			if (time >= 0.5f)                     //もしtimeが0.5以上の場合
			{
				spriteRenderer.sprite = endImage;  //次の面をレンダー
			}
			yield return new WaitForFixedUpdate();  // 一定間隔待って次のwhile処理に移ります。
		}
		if (cardIndex == -1)  //もしcardIndex が-1と等しい場合
		{
			model.ToggleFace(1); //裏面をレンダーします
		}
		else    //それ以外の場合は
		{
			model.cardIndex = cardIndex;  //  modelのカードインデックスの値をcardIndex とし、
			model.ToggleFace(0);  // 表面をレンダーします
		}
	}
}
