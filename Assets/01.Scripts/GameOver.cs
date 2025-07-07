using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    RectTransform rect;
    [SerializeField] Image image;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        image.DOFade(0, 4).OnComplete(() => { Destroy(image); });
        rect.DOScale(Vector2.one, 6).SetEase(Ease.OutCirc);
    }
}
