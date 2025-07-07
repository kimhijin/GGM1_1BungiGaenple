using System.Collections.Generic;
using UnityEngine;

public class SymbolCountMgr : MonoBehaviour
{
    public List<UISymbol> symbols = new List<UISymbol>();
    [SerializeField] GameObject item;

    private void OnEnable()
    {
        if (!item.activeSelf)
            item.SetActive(true);
        foreach(UISymbol symbol in symbols)
        {
            if(!symbol.gameObject.activeSelf)
            {

                if (!UIManager.Instance.SlotMachineMgr.haveSymbols.ContainsKey(symbol.itemData.MySymbol))
                {
                    continue;
                }
                if (UIManager.Instance.SlotMachineMgr.haveSymbols[symbol.itemData.MySymbol] > 0)
                {
                    symbol.gameObject.SetActive(true);
                }
            }

        }
    }
}
