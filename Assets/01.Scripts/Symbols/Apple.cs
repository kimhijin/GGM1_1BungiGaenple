using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Apple : Symbol
{
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        Check(symbolTurn);
        if (isUse)
        {
            rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
            StartCoroutine(DeleteSymbolWait());
        }
        else
            UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);

    }

    protected override void Buffer(Symbol symbol)
    {
        if(symbol.symbol == eSymbol.Peasant)
        {
            coin *= 2;
            isUse = true;
        }
    }

    IEnumerator DeleteSymbolWait()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
    }
}
