using UnityEngine;

public class LuckySeven : Symbol
{
    [SerializeField] GameObject luckyItem;
    public override void Init()
    {
    }

    public override void Show()
    {
    }

    public override void Use(SymbolTurn[] symbolTurn)
    {
        Debug.Log("세븐 아이템 추가");
        Destroy(gameObject);
    }

    protected override void Buffer(Symbol symbol)
    {
    }
}
