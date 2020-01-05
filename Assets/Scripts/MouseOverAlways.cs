using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverAlways : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	CardFlipper flipper;
	KomaModel cardModel;

	private void Awake()
	{
		flipper = GetComponent<CardFlipper>();
		cardModel = GetComponent<KomaModel>();
	}
	// オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
	public void OnPointerEnter(PointerEventData eventData)
	{
		cardModel.ToggleFace(0);

	}
	// オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
	public void OnPointerExit(PointerEventData eventData)
	{
		flipper.FlipCard(cardModel.faces[cardModel.cardIndex], cardModel.komaBack, -1);
	}
}
