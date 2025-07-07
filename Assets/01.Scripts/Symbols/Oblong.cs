using System;
using UnityEngine;

public class Oblong : Symbol
{
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        CheckConner(symbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
    }

    protected void CheckConner(SymbolTurn[] symbolTurns)
    {
        for (index = 0; index < symbolTurns.Length; index++)
        {
            if (symbolTurns[index] == mySymbolTurn)
                break;
        }
        switch (index)
        {
            case 1:
            case 11:
            case 9:
            case 19:
                UIManager.Instance.ScoreManager.UpdateScore(coin,mySymbolTurn);
                break;
            default:
                break;
        }
    }
}
