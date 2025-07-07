using UnityEngine;

public class EmblemSpade : Symbol
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
        UIManager.Instance.ScoreManager.UpdateScore(coin,mySymbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
        if (symbol.symbol == eSymbol.EmblemGrays)
        {

            coin += 1;
        }
    }
}
