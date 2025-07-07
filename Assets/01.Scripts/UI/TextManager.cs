using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject chooseItem;
    [SerializeField] Image image;
    public event Action onClickX;
    public event Action timerReset;
    bool isGoodEnd;
    bool isBedEnd;
    RectTransform rect;

    private void Awake()
    {
        image.gameObject.SetActive(false);
        rect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        rect.localScale=new Vector2(1,0);
        rect.DOScaleY(1, 0.5f).SetEase(Ease.OutCirc);
    }

    public void OnClickX()
    {
        if(isGoodEnd||isBedEnd)
        {
            image.gameObject.SetActive(true);
            image.DOFade(1f, 1.5f).OnComplete(() =>
            {
                if (isGoodEnd)
                {
                    SceneManager.LoadScene(0);

                }
                else if (isBedEnd)
                {
                    SceneManager.LoadScene("GameOver");
                }
            });
        }
        else
        {
            rect.DOScaleY(0, 1).SetEase(Ease.OutCirc).OnComplete(() =>
            {
                if (SaveData.Instance.isDebtYes)
                {
                    onClickX?.Invoke();
                    timerReset?.Invoke();
                    gameObject.SetActive(false);
                }
                else
                {
                    chooseItem.SetActive(true);
                    gameObject.SetActive(false);
                }
            });
        }
    }

    public void ResetTimer()
    {
        timerReset?.Invoke();
    }

    //빚갚았을때
    public void DebtClickYes(int debt)
    {
        text.text = $"빚을 갚으셨습니다. 하지만 아직 {debt}정도의  빚이 남았습니다.";
    }

    public void SuccessDebtClick()
    {
        isGoodEnd = true;
        text.text = $"축하합니다! 모든 빛을 다 갚으셨습니다";
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Win);
        SoundManager.Instance.PlayBgm(false);
    }

    //빚을 갚을려했지만 돈이 없을때
    public void ErrorDebtClickYes()
    {
        text.text = $"당신은 돈이 없습니다. 훠이훠이 돈이나 더 모으고 와라";
    }

    //빚을 안 갚을때
    public void DebtClickNo(int debt)
    {
        text.text = $"갚아야 할 빛이 {debt}으로 늘어 났습니다.";
    }

    public void CanotGiveMoney()
    {
        isBedEnd = true;
        text.text = "빚이 너무 많습니다. 사채업자는 더이상 기다려 줄 수 없었습니다..";
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.GameOver);
        SoundManager.Instance.PlayBgm(false);
    }
}
