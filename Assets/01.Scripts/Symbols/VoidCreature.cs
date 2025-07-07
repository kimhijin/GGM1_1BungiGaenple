using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class VoidCreature : Symbol
{
    int noVoid = 0;
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        Check(symbolTurn);
        if (noVoid <3)
        {
            coin = 8;
            rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
            StartCoroutine(DeleteSymbolWait());
        }
        else
        {
            UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
        }


    }

    IEnumerator DeleteSymbolWait()
    {
        yield return new WaitForSeconds(0.8f);
        UIManager.Instance.SlotMachineMgr.OnlyDeleteSymbol(gameObject, mySymbolTurn);
        UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
        Destroy(gameObject);
    }

    protected override void Buffer(Symbol symbol)
    {
        if (symbol.symbol == eSymbol.Emty)
        {
            noVoid++;
            coin += 1;

        }

    }
}
