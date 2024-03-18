using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class LongPressControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private RectTransform bar;

	private bool isPointerDown;
	private float pressDuration;
	private const float longPressDuration = 0.5f;

	private Action longPressAction = () => { Debug.Log("Long Pressed"); };

	private void Update()
	{
		if (isPointerDown)
		{
			pressDuration += Time.deltaTime;
			bar.anchorMax = new Vector2(pressDuration/longPressDuration, bar.anchorMax.y);

			if (pressDuration >= longPressDuration)
			{
				longPressAction();
				isPointerDown = false;
				pressDuration = 0f;
				bar.anchorMax = new Vector2(0f, bar.anchorMax.y);
			}
		}
	}

	/// <summary>
	/// 長押し時のアクションを設定
	/// </summary>
	/// <param name="action">アクション</param>
	public void SetLongPressAction(Action action)
	{
		longPressAction = action;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown = true;
		pressDuration = 0f;
		bar.anchorMax = new Vector2(0f, bar.anchorMax.y);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown = false;
		pressDuration = 0f;
		bar.anchorMax = new Vector2(0f, bar.anchorMax.y);
	}
}