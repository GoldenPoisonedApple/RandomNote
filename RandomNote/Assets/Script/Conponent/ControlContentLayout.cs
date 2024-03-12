using System.Collections.Generic;
using UnityEngine;

public class ControlContentLayout : MonoBehaviour
{
	private const float SPACING = 20f; // Spacing between child objects
	private const float MIN_HEIGHT = 10f; // Minimum height of the layout

	public void ArrangeChildObjects()
	{
		RectTransform layoutTransform = transform.GetComponent<RectTransform>();
		float layoutWidth = layoutTransform.rect.width;

		float currentX = 0f;
		float currentY = 0f;
		float rowHeight = 0f;

		foreach (RectTransform childTransform in layoutTransform)
		{
			float childWidth = childTransform.rect.width;
			float childHeight = childTransform.rect.height;

			// Check if the child object exceeds the layout width
			if (currentX + childWidth > layoutWidth)
			{
				currentX = 0f;
				currentY -= rowHeight + SPACING;
				rowHeight = 0f;
			}

			// Position the child object
			childTransform.anchoredPosition = new Vector2(currentX, currentY);

			// Update the current X position and row height
			currentX += childWidth + SPACING;
			rowHeight = Mathf.Max(rowHeight, childHeight);
		}

		// Adjust the layout's height based on the last row's height
		float layoutHeight = Mathf.Abs(currentY) + rowHeight + SPACING;
		layoutTransform.sizeDelta = new Vector2(layoutWidth, Mathf.Max(layoutHeight, MIN_HEIGHT));
	}
}