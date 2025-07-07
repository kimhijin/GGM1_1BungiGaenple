using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FirstGuide : MonoBehaviour
{
    [SerializeField] Image image;
    private void Awake()
    {
        image.gameObject.SetActive(false);
    }

    public void ClickA4()
    {
        image.gameObject.SetActive(true);
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Paper);
    }

    public void ClickGuide()
    {
        SaveData.Instance.isStart = true;
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Paper);
        SoundManager.Instance.PlayBgm(true);
        Destroy(gameObject);
    }
}
