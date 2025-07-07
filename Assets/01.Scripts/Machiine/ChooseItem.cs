using DG.Tweening;
using UnityEngine;

public class ChooseItem : MonoBehaviour
{
    [SerializeField] Shutter shutter;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        rectTransform.localScale = Vector2.zero;
        rectTransform.DOScale(Vector2.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void OnSkip()
    {
        UIManager.Instance.TextManager.ResetTimer();
        shutter.GoUp();
        gameObject.SetActive(false);
    }

}
