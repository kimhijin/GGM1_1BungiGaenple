using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BigOre : Symbol
{
    [SerializeField] GameObject[] ores;
    int ran;
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
        if (symbol.symbol == eSymbol.MineWorker)
        {
            if (!isUse)
            {
                isUse = true;
                UIManager.Instance.SlotMachineMgr.OnlyDeleteSymbol(gameObject, mySymbolTurn);
                rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
                StartCoroutine(DeleteSymbolWait());

            }
        }

    }

    IEnumerator DeleteSymbolWait()
    {
        yield return new WaitForSeconds(1f);
        ran = Random.Range(0, ores.Length);
        Instantiate(ores[ran], mySymbolTurn.rectTransform);
        Destroy(gameObject);
    }
}
