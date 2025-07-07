using System;
using UnityEngine;

public class SymbolBtn : MonoBehaviour
{
    [SerializeField] GameObject choosePos;
    [SerializeField] bool isItem = false;
    Symbol symbol;
    bool isUseMoney = true;
    public event Action OnClickMe;

    private void OnEnable()
    {
        if(!isItem)
            symbol  = choosePos.GetComponentInChildren<Symbol>();
    }

    public void OnAddSymbol()
    {
        UIManager.Instance.SlotMachineMgr.GetSymbols(symbol.gameObject, 1);
        UIManager.Instance.BtnManager.isRoll = true;
        OnClickMe?.Invoke();
    }

    public void OnAddItem()
    {
        UIManager.Instance.ScoreManager.MinuceCoin(30, ref isUseMoney);
        if(isUseMoney)
            SaveData.Instance.erazerCount++;
    }

    private void OnDisable()
    {
        if(!isItem)
            Destroy(gameObject);
    }
}
