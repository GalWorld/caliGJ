using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class PanelAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform panel;
    public float animationDuration = 0.5f;

    private void Awake()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        if (panel == null) panel = GetComponent<RectTransform>();
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        panel.localScale = Vector3.zero;
        
        Sequence.Create()
            .Group(Tween.Alpha(canvasGroup, 1f, animationDuration, Ease.OutQuad))
            .Group(Tween.Scale(panel, Vector3.one, animationDuration, Ease.OutBack));
    }

    public void HidePanel()
    {
        Sequence.Create()
            .Group(Tween.Alpha(canvasGroup, 0f, animationDuration, Ease.InQuad))
            .OnComplete(() => gameObject.SetActive(false));
    }
}
