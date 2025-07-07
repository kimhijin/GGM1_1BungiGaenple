using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI coinText;

    public int Coin { get; private set; } = 0;

    public void MinuceCoin(int coin, ref bool isUseMoney)
    {
        if(Coin-coin <0 )
        {
            isUseMoney = false;
            return;
        }
        Coin -= coin;
        score.text = Coin.ToString();
    }

    public void UpdateScore(int coin, SymbolTurn mySymbolTurn)
    {
        TextMeshProUGUI text = Instantiate(coinText, mySymbolTurn.rectTransform);
        text.text = coin.ToString();
        text.rectTransform.localScale = Vector2.zero;
        text.rectTransform.DOScale(Vector2.one, 0.3f).SetEase(Ease.OutBack);

        SoundManager.Instance.PlaySfx(SoundManager.Sfx.GetCoin);
        StartCoroutine(WaitGetCoin(coin, text));

    }

    private void Update()
    {
        MsterLey();
    }

    public void MsterLey()
    {
        if (Keyboard.current.cKey.isPressed)
        {
            if (Keyboard.current.iKey.isPressed)
            {
                if (Keyboard.current.oKey.wasPressedThisFrame)
                {
                    this.Coin += 10;
                    Coin = Mathf.Max(Coin, 0);
                    score.text = this.Coin.ToString();
                }
            }
        }

    }

    IEnumerator WaitGetCoin(int coin, TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(text);
        this.Coin += coin;
        Coin = Mathf.Max(Coin, 0);
        score.text = this.Coin.ToString();
    }

    public void SetScore(int coin)
    {
        this.Coin = coin;
        score.text = this.Coin.ToString();
    }
}
