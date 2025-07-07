using System.Runtime.InteropServices;
using UnityEngine;

public class MineWorker : Symbol
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
        if (symbol.symbol == eSymbol.Ore)
        {
            coin += 15;
        }

    }
}
