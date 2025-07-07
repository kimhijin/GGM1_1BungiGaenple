using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Stone : Symbol
{
    [SerializeField] Symbol diamond;
    int ran;
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        ran = Random.Range(0, 30);
        if(ran == 0)
        {
            rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
            StartCoroutine(WaitGetSymbol());
        }
    }

    IEnumerator WaitGetSymbol()
    {
        yield return new WaitForSeconds(0.8f);
        UIManager.Instance.SlotMachineMgr.GetSymbols(diamond.gameObject, 1);
        Instantiate(diamond, mySymbolTurn.rectTransform);
        UIManager.Instance.SlotMachineMgr.OnlyDeleteSymbol(gameObject, mySymbolTurn);
        Destroy(gameObject);
    }

    //public void SpinCount(int spinCount)
    //{
    //    this.spinCount = spinCount;
    //}

    protected override void Buffer(Symbol symbol)
    {
    }
}
