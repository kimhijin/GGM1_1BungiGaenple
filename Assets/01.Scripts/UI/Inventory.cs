using DG.Tweening;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        rect.DOMoveY(500, 0.5f);
    }

    private void OnDisable()
    {
        rect.localPosition = new Vector3(0, -1030, 0);
    }
}
