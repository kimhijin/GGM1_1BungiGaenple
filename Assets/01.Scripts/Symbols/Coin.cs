using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : Symbol
{
    public override void Init()
    {
    }

    public override void Show()
    {

    }

    public override void Use( SymbolTurn[] symbolTurns)
    {
        Check(symbolTurns);
        if(coin>=3)
        {
            rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
            StartCoroutine(DeleteSymbolWait());
        }
        else
            UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);

    }


    IEnumerator DeleteSymbolWait()
    {
        yield return new WaitForSeconds(0.8f);
        UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
    }

    //만약 치즈가 있다면 실행
    protected override void Buffer(Symbol symbol)
    {
        if(symbol.symbol == eSymbol.KingMidas)
        {
            coin *= 3;
        }
    }


}
