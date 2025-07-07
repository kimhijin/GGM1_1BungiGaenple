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

    //����������
    public void DebtClickYes(int debt)
    {
        text.text = $"���� �����̽��ϴ�. ������ ���� {debt}������  ���� ���ҽ��ϴ�.";
    }

    public void SuccessDebtClick()
    {
        isGoodEnd = true;
        text.text = $"�����մϴ�! ��� ���� �� �����̽��ϴ�";
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Win);
        SoundManager.Instance.PlayBgm(false);
    }

    //���� ������������ ���� ������
    public void ErrorDebtClickYes()
    {
        text.text = $"����� ���� �����ϴ�. �������� ���̳� �� ������ �Ͷ�";
    }

    //���� �� ������
    public void DebtClickNo(int debt)
    {
        text.text = $"���ƾ� �� ���� {debt}���� �þ� �����ϴ�.";
    }

    public void CanotGiveMoney()
    {
        isBedEnd = true;
        text.text = "���� �ʹ� �����ϴ�. ��ä���ڴ� ���̻� ��ٷ� �� �� �������ϴ�..";
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.GameOver);
        SoundManager.Instance.PlayBgm(false);
    }
}
