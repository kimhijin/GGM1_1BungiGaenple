using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public abstract class Symbol : MonoBehaviour
{
    [SerializeField] protected int defaultCoin;
    public RectTransform rectTransform { get; private set; }
    protected int coin;
    protected int index = 0;
    protected SymbolTurn mySymbolTurn;
    public eSymbol symbol;

    protected bool isUse = false;

    protected virtual void Awake()
    {
        mySymbolTurn = GetComponentInParent<SymbolTurn>();
        rectTransform = GetComponent<RectTransform>();
        coin = defaultCoin;
        Init();
    }
    public abstract void Init();
    public abstract void Use( SymbolTurn[] symbolTurn);
    public abstract void Show();
    private void CheckFuntion(SymbolTurn[] symbolTurns,int index, int i)
    {
        Symbol symbol = symbolTurns[index+i].GetComponentInChildren<Symbol>();
        Buffer(symbol);

    }
    protected abstract void Buffer(Symbol symbol);

    protected void Check(SymbolTurn[] symbolTurns)
    {
        //1  3  5  7  9
        //0  2  4  6  8
        //10 12 14 16 18
        //11 13 15 17 19
        for (index = 0; index < symbolTurns.Length; index++)
        {
            if (symbolTurns[index] == mySymbolTurn)
                break;
        }
        switch (index)
        {
            case 0:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, 3);
                CheckFuntion(symbolTurns, index, 10);
                CheckFuntion(symbolTurns, index, 12);
                break;
            case 1:
            case 11:
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, 1);
                break;
            case 2:
            case 4:
            case 6:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, 3);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, 8);
                CheckFuntion(symbolTurns, index, 10);
                CheckFuntion(symbolTurns, index, 12);
                break;
            case 3:
            case 5:
            case 7:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, -3);
                break;
            case 8:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, 8);
                CheckFuntion(symbolTurns, index, 10);
                break;
            case 9:
            case 19:
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, -3);
                break;
            case 10:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, 3);
                CheckFuntion(symbolTurns, index, -8);
                CheckFuntion(symbolTurns, index, -10);
                break;
            case 12:
            case 14:
            case 16:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, 3);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, -8);
                CheckFuntion(symbolTurns, index, -10);
                CheckFuntion(symbolTurns, index, -12);
                break;
            case 13:
            case 15:
            case 17:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, 2);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, -3);
                break;
            case 18:
                CheckFuntion(symbolTurns, index, 1);
                CheckFuntion(symbolTurns, index, -1);
                CheckFuntion(symbolTurns, index, -2);
                CheckFuntion(symbolTurns, index, -10);
                CheckFuntion(symbolTurns, index, -12);
                break;

        }
        #region
        //if (index % 10 < 8)
        //{
        //    for (int i = 1; i < 4; i++)
        //    {
        //        if (index % 10 == 1 && i == 3) continue;
        //        Symbol symbol = symbolTurns[index + i].GetComponentInChildren<Symbol>();
        //        if (symbol.symbol == compare)
        //        {
        //            Buffer();
        //        }

        //    }
        //}
        //if (index % 10 > 1)
        //{
        //    for (int i = 1; i < 4; i++)
        //    {
        //        if (!(index % 10 == 9)) continue;
        //        Symbol symbol = symbolTurns[index - i].GetComponentInChildren<Symbol>();
        //        if (symbol.symbol == compare)
        //            Buffer();
        //    }
        //}
        //if (index % 2 == 0)
        //{

        //    if (index >= 10)
        //    {
        //        Symbol symbol1 = symbolTurns[index - 10].GetComponentInChildren<Symbol>();
        //        if (symbol1.symbol == compare)
        //            Buffer();
        //        if (index % 10 == 0)
        //        {
        //            Symbol symbol = symbolTurns[index - 10 + 2].GetComponentInChildren<Symbol>();
        //            if (symbol.symbol == compare)
        //                Buffer();
        //        }
        //        else
        //        {
        //            Symbol symbol2 = symbolTurns[index - 10 - 2].GetComponentInChildren<Symbol>();

        //            if (symbol2.symbol == compare)
        //                Buffer();
        //        }

        //    }
        //    else
        //    {
        //        Symbol symbol1 = symbolTurns[index + 10].GetComponentInChildren<Symbol>();

        //        if (symbol1.symbol == compare)
        //            Buffer();
        //        if (index % 10 == 8)
        //        {
        //            Symbol symbol = symbolTurns[index + 10 - 2].GetComponentInChildren<Symbol>();

        //            if (symbol.symbol == compare)
        //                Buffer();
        //        }
        //        else
        //        {
        //            Symbol symbol2 = symbolTurns[index + 10 + 2].GetComponentInChildren<Symbol>();

        //            if (symbol2.symbol == compare)
        //                Buffer();
        //        }
        //    }

        //}
        #endregion
    }
}

public enum eSymbol
{
    None,
    All,
    Emty,
    Coin,
    Cheese,
    Drinker,
    Alcohol,
    Flower,
    Sun,
    Key,
    Boxs,
    Stone,
    Diamond,
    KingMidas,
    Thief,
    Peasant,
    Seeds,
    LuckySeven,
    Oblong,
    EmblemRads,
    EmblemGrays,
    MineWorker,
    Ore,
    OreSon,
    Luby,
    Fruit,
    Creature,
    DiamonKnife,
    Mouse,
    BananaPeel,
    Apple,
    Cherry,
    BreakOre,

}
