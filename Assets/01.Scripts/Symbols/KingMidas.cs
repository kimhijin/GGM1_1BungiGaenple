using UnityEngine;

public class KingMidas : Symbol
{
    [SerializeField] Symbol coinSymbol;
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        UIManager.Instance.SlotMachineMgr.GetSymbols(coinSymbol.gameObject, 1);
        UIManager.Instance.ScoreManager.UpdateScore(coin,mySymbolTurn);
    }

    protected override void Buffer(Symbol symbol)
    {
    }
}
