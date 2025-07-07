using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CoinObj : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        rect.DOJump(rect.localPosition, 1, 1, 1);
        StartCoroutine(DestoryObj());
    }
    IEnumerator DestoryObj()
    {
        yield return new WaitForSeconds(1f);
    }
}
