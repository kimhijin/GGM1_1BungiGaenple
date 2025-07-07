using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SymbolTurnMgr : MonoBehaviour
{
    [field: SerializeField] public float speed { get; private set; } = 2;
    [SerializeField] bool a;
    public int turnCount { get; private set; }
    public bool isRoll { get; private set; }
    public bool isStop { get; private set; }

    private void Start()
    {
        UIManager.Instance.BtnManager.OnTurn += OnRoll;
    }

    public void CheckTurnCount(bool isEndSymbol)
    {
        if (isEndSymbol)
        {
            turnCount++;
            if (turnCount == 3)
            {
                isRoll = false;
                isStop = true;
                if(a)
                {
                    UIManager.Instance.SlotMachineMgr.GetCoin();
                }
                turnCount = 0;
            }
        }
    }

    void OnRoll()
    {
        isRoll = true;
        isStop = false;
    }

    private void OnDestroy()
    {
        UIManager.Instance.BtnManager.OnTurn -= OnRoll;
    }

}
