using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SceneShutter : MonoBehaviour
{
    [SerializeField] bool isDown;
    [SerializeField] GameObject shutter;

    private void Awake()
    {
        if(isDown)
        {
            shutter.transform.DOMoveY(1080 / 2, 1.4f).SetEase(Ease.OutBounce);
        }
        else
        {
            shutter.transform.DOMoveY(2160, 1.4f);
            StartCoroutine(DeleteActiveFalse());
        }

        IEnumerator DeleteActiveFalse()
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }
    }
}
