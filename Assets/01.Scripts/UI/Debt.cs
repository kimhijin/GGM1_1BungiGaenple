using DG.Tweening;
using TMPro;
using UnityEngine;

public class Debt : MonoBehaviour
{
    [SerializeField] int defaultDebtCoin;
    [SerializeField] float multiplyCoin;
    [SerializeField] GameObject textWindow;
    [SerializeField] GameObject chooseItem;
    [SerializeField] TextMeshProUGUI debtCoinText;
  
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        SaveData.Instance.debtCoin = defaultDebtCoin;
        debtCoinText.text = "ºú: " + SaveData.Instance.debtCoin.ToString();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);
        rect.localScale = Vector2.one;
    }

    public void OnClickYes()
    {
        SaveData.Instance.isDebtYes = true;

        SaveData.Instance.debtCoin -= UIManager.Instance.ScoreManager.Coin;
        SaveData.Instance.debtCoin = Mathf.Max(SaveData.Instance.debtCoin, 0);
        rect.DOScaleY(0, 0.4f).SetEase(Ease.OutCirc).OnComplete(() =>
        {
            if (UIManager.Instance.ScoreManager.Coin == 0)
            {
                UIManager.Instance.TextManager.ErrorDebtClickYes();
                textWindow.SetActive(true);
                return;
            }
            if (SaveData.Instance.debtCoin <= 0)//ºú°±±â ¼º°ø
            {
                UIManager.Instance.ScoreManager.SetScore(-SaveData.Instance.debtCoin);
                UIManager.Instance.TextManager.SuccessDebtClick();
                textWindow.SetActive(true);
            }
            else//¾ÆÁ÷ ºÎÁ·
            {
                UIManager.Instance.ScoreManager.SetScore(0);
                SaveData.Instance.debtCoin = (int)(SaveData.Instance.debtCoin * multiplyCoin);
                if (SaveData.Instance.debtCoin >= defaultDebtCoin * 5)
                {
                    UIManager.Instance.TextManager.CanotGiveMoney();
                    textWindow.SetActive(true);
                }
                else
                {
                    UIManager.Instance.TextManager.DebtClickYes(SaveData.Instance.debtCoin);
                    textWindow.SetActive(true);
                }

            }
            debtCoinText.text = "ºú: "+SaveData.Instance.debtCoin.ToString();
            gameObject.SetActive(false);
        });

       
    }

    public void OnClickNo()
    {
        SaveData.Instance.isDebtYes = false;

        SaveData.Instance.debtCoin = (int)(SaveData.Instance.debtCoin * multiplyCoin);
        if(SaveData.Instance.debtCoin >= defaultDebtCoin*3)
        {
            UIManager.Instance.TextManager.CanotGiveMoney();
            textWindow.SetActive(true);
        }
        else
        {
            textWindow.SetActive(true);
            UIManager.Instance.TextManager.DebtClickNo(SaveData.Instance.debtCoin);
        }
        debtCoinText.text = "ºú: " + SaveData.Instance.debtCoin.ToString();
        gameObject.SetActive(false);
    }
}
