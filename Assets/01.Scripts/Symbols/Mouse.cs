using DG.Tweening;
using UnityEngine;

public class Mouse : Symbol
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
        //if(coin>=10)
        //{
        //    rectTransform.DOShakeAnchorPos(0.5f, 10, 180, 5, false, false);
        //}
        UIManager.Instance.ScoreManager.UpdateScore(coin, mySymbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
        if(symbol.symbol == eSymbol.Cheese)
        {
            if(!isUse)
            {
                isUse = true;
                coin = 10;
            }
            else
            {
                coin += 10;
            }
        }
    }
}
