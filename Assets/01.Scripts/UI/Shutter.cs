using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    [SerializeField] GameObject debt;
    RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        UIManager.Instance.TextManager.onClickX += GoUp;
    }

    private void OnEnable()
    {
        debt.SetActive(true);
        SoundManager.Instance.EffectBgm(true);
        _rect.DOMoveY(1080 / 2, 1).SetEase(Ease.OutBounce);
    }

    public void GoUp()
    {
        SoundManager.Instance.EffectBgm(false);
        _rect.DOMoveY(2160, 1);
        StartCoroutine(DeleteActiveFalse());
    }

    IEnumerator DeleteActiveFalse()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void OnDestory()
    {
        UIManager.Instance.TextManager.onClickX -= GoUp;
    }
}
