using UnityEngine;

public class Diamond : Symbol
{
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        UIManager.Instance.ScoreManager.UpdateScore(coin,mySymbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
    }
}
