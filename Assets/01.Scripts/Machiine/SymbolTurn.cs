using UnityEngine;

public class SymbolTurn : MonoBehaviour
{
    [SerializeField] bool isEndSymbol = false;
    public RectTransform rectTransform { get; private set; }
    SymbolTurnMgr turnMgr;
    Vector3 firstPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        turnMgr = GetComponentInParent<SymbolTurnMgr>();
    }

    private void Start()
    {
        UIManager.Instance.BtnManager.OnDestroy += InitSymbol;
        firstPos = rectTransform.localPosition;
    }



    private void Update()
    {
        if(turnMgr.isRoll)
        {
            rectTransform.localPosition += Vector3.down * turnMgr.speed;
            if (rectTransform.localPosition.y <= -400f)
            {
                rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, 400, 0);
                turnMgr.CheckTurnCount(isEndSymbol);
            }
        }
        if(turnMgr.isStop)
        {
            rectTransform.localPosition = firstPos;
        }
    }

    public void InitSymbol()
    {
        int numOfChildren = this.transform.childCount;
        for(int i = 0; i<numOfChildren; i++)
        {
            GameObject symbolObj = transform.GetChild(i).gameObject;
            Destroy(symbolObj);
        }
    }

    private void OnDestroy()
    {
        UIManager.Instance.BtnManager.OnDestroy -= InitSymbol;
    }

}
