using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Seeds : Symbol
{
    [SerializeField] Symbol[] seedsSon;
    int minRan = 1;
    int maxRan = 24;
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
        ran = Random.Range(minRan, maxRan);
        switch (ran)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
                StartCoroutine(WaitGetSymbol());
                break;
            default:
                UIManager.Instance.ScoreManager.UpdateScore(coin,mySymbolTurn);
                break;
        }
        
    }

    IEnumerator WaitGetSymbol()
    {
        yield return new WaitForSeconds(0.8f);
        Instantiate(seedsSon[0], mySymbolTurn.rectTransform);
        UIManager.Instance.SlotMachineMgr.GetSymbols(seedsSon[0].gameObject, 1);
        UIManager.Instance.SlotMachineMgr.OnlyDeleteSymbol(gameObject, mySymbolTurn);
        Destroy(gameObject);
    }

    protected override void Buffer(Symbol symbol)
    {
        if (symbol.symbol == eSymbol.Peasant)
        {
            minRan = 4;
            maxRan = 6;
        }
    }
}
