using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SLotMachineMgr : MonoBehaviour
{
    [SerializeField] SymbolTurn[] symbolPos;
    [SerializeField] Button swingBtn;
    [SerializeField] Empty emty;

    //가지고있는 심볼
    [SerializeField]public List<GameObject> defaultSymbol = new List<GameObject>();
    public List<GameObject> symbolList = new List<GameObject>();
    public Dictionary<GameObject, int> haveSymbols { get; private set; } = new Dictionary<GameObject, int>();
    Dictionary<GameObject, int> useCount = new Dictionary<GameObject, int>();
    int ranCount,_stoneCount;
    GameObject deleteSymbol;

    public bool canDownShutter;

    WaitForSeconds wait= new WaitForSeconds(0.2f);

    private void OnEnable()
    {
        UIManager.Instance.BtnManager.OnTurn += UpdateSetSymols;
    }

    private void Awake()
    {
        foreach(GameObject symbolTurn in defaultSymbol)
        {
            GetSymbols(symbolTurn, 1);
        }
        ranCount = Random.Range(0, defaultSymbol.Count);
    }

    //Dictionary에 심볼 추가 
    public void GetSymbols(GameObject symbol, int count)
    {
        symbolList.Add(symbol);

        if (symbolList.Count > 20)
        {
            symbolList.Remove(emty.gameObject);
            haveSymbols[emty.gameObject]--;
        }
        if (haveSymbols.ContainsKey(symbol))
        {
            haveSymbols[symbol] += count;
        }
        else
        {
            haveSymbols[symbol] = count;
        }

    }

    //public void DeleteSymbols(GameObject symbol, SymbolTurn symbolTurn)
    //{

    //    if(symbolTurn.GetComponentInChildren<Symbol>() != emty)
    //    {
    //        Instantiate(emty.gameObject, symbolTurn.rectTransform);
    //        deleteSymbol = symbolList.FirstOrDefault(p => p.name == symbol.name.Replace("(Clone)", "").Trim());

    //        symbolList.Remove(deleteSymbol);
    //        haveSymbols[deleteSymbol]--;

    //        if (symbolList.Count <= 20)
    //        {
    //            symbolList.Add(emty.gameObject);
    //            haveSymbols[emty.gameObject]++;
    //        }
    //    }
    //}
    public void InventoryDelete(GameObject symbol)
    {
        symbolList.Remove(symbol);
        haveSymbols[symbol]--;

        if (symbolList.Count <= 20)
        {
            symbolList.Add(emty.gameObject);
            haveSymbols[emty.gameObject]++;
        }
    }

    public void OnlyDeleteSymbol(GameObject symbol, SymbolTurn mySymbolTurn)
    {
        if (mySymbolTurn.GetComponentInChildren<Symbol>() != emty)
        {
            deleteSymbol = symbolList.FirstOrDefault(p => p.name == symbol.name.Replace("(Clone)", "").Trim());

            symbolList.Remove(deleteSymbol);
            haveSymbols[deleteSymbol]--;

            if (symbolList.Count <= 20)
            {
                symbolList.Add(emty.gameObject);
                haveSymbols[emty.gameObject]++;
            }
        }
    }

    //화면에 심볼추가
    public void UpdateSetSymols()
    {
        SaveData.Instance.isShutterDown = false;
        foreach (GameObject symbol in symbolList)
        {
            useCount[symbol] = 0;
        }
        //[SeralizeField]제대로 확인좀 하자
        for(int i = 0; i<symbolPos.Length; i++)
        {
            useCount[symbolList[ranCount]]++;
            if (useCount[symbolList[ranCount]] == haveSymbols[symbolList[ranCount]]+1)
            {
                i--;
                useCount[symbolList[ranCount]]--;
                ranCount = Random.Range(0, symbolList.Count);
                continue;
            }
            GameObject symbol = Instantiate(symbolList[ranCount], symbolPos[i].rectTransform);
            symbol.transform.localPosition = Vector3.zero;
            ranCount = Random.Range(0, symbolList.Count);
            
        }
    }

    public void GetCoin()
    {
        foreach(SymbolTurn symbolTurns in symbolPos)
        {
            Symbol symbol = symbolTurns.GetComponentInChildren<Symbol>();
            StartCoroutine(UseSymbol(symbol));
        }
        StartCoroutine(OpenChooseSymbol());
        
    }

    IEnumerator UseSymbol(Symbol symbol)
    {
        yield return wait;
        symbol.Use(symbolPos);
    }

    IEnumerator OpenChooseSymbol()
    {
        yield return new WaitForSeconds(1.7f);
        UIManager.Instance.ChooseSymbol.gameObject.SetActive(true);
    }


    private void OnDestroy()
    {
        UIManager.Instance.BtnManager.OnTurn -= UpdateSetSymols;
    }

}
