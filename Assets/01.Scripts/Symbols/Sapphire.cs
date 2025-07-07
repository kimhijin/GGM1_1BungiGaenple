using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Sapphire : Symbol
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
        if (!isUse)
            UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
        if (symbol.symbol == eSymbol.BreakOre)
        {
            if (!isUse)
            {
                isUse = true;
                rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
                StartCoroutine(DeleteSymbolWait());
            }
        }

    }

    IEnumerator DeleteSymbolWait()
    {
        yield return new WaitForSeconds(0.8f);
        UIManager.Instance.SlotMachineMgr.OnlyDeleteSymbol(gameObject, mySymbolTurn);
        UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
        Destroy(gameObject);
    }
}
