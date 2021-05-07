using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
	private RectTransform panelSafeArea;

	private Rect currentSafeArea = new Rect();
	private ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;

	private void Start()
	{
		panelSafeArea = GetComponent<RectTransform>();

		currentSafeArea = Screen.safeArea;
		currentOrientation = Screen.orientation;

		ApplySafeArea();
	}

	private void Update()
	{
		if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
		{
			ApplySafeArea();
		}
	}

	private void ApplySafeArea()
	{
		var safeArea = Screen.safeArea;

		var anchorMin = safeArea.position;
		var anchorMax = safeArea.position + safeArea.size;

		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;

		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;

		panelSafeArea.anchorMin = anchorMin;
		panelSafeArea.anchorMax = anchorMax;
	}
}
