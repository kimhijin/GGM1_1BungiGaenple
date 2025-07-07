using UnityEngine;

public class ChooseSymbol : MonoBehaviour
{
    [SerializeField] RectTransform[] choosePos;
    [SerializeField] SymbolBtn[] normalSymbolBtn;
    [SerializeField] SymbolBtn[] advancedSymbolBtn;
    [SerializeField] SymbolBtn[] rareSymbolBtn;
    [SerializeField] SymbolBtn[] langendSymbolBtn;
    SymbolBtn[] symbolBtns = new SymbolBtn[3];
    int ran = 1;
    int ranSymbol;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        SetSymbolBtn();
    }

    public void OnSkip()
    {
        UIManager.Instance.BtnManager.isRoll = true;
        SaveData.Instance.isShutterDown = true;
        gameObject.SetActive(false);
    }

    void SetSymbolBtn()
    {
        switch (ran)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                for (int i=0; i<choosePos.Length; i++)
                {
                    ranSymbol = Random.Range(0, normalSymbolBtn.Length);
                    symbolBtns[i] = Instantiate(normalSymbolBtn[ranSymbol], choosePos[i]);
                    symbolBtns[i].OnClickMe += OnClickBtn;
                }
                break;
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
                for (int i = 0; i < choosePos.Length; i++)
                {
                    ranSymbol = Random.Range(0, advancedSymbolBtn.Length);
                    symbolBtns[i] = Instantiate(advancedSymbolBtn[ranSymbol], choosePos[i]);
                    symbolBtns[i].OnClickMe += OnClickBtn;
                }
                break;

            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
                for (int i = 0; i < choosePos.Length; i++)
                {
                    ranSymbol = Random.Range(0, rareSymbolBtn.Length);
                    symbolBtns[i] = Instantiate(rareSymbolBtn[ranSymbol], choosePos[i]);
                    symbolBtns[i].OnClickMe += OnClickBtn;
                }
                break;
            case 50:
            case 49:
            case 48:
                for (int i = 0; i < choosePos.Length; i++)
                {
                    ranSymbol = Random.Range(0, langendSymbolBtn.Length);
                    symbolBtns[i] = Instantiate(langendSymbolBtn[ranSymbol], choosePos[i]);
                    symbolBtns[i].OnClickMe += OnClickBtn;
                }
                break;
        }
        ran = Random.Range(1, 51);


    }
    void OnClickBtn()
    {
        SaveData.Instance.isShutterDown = true;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        for (int i = 0; i < symbolBtns.Length; i++)
        {
            if (symbolBtns[i] != null)
                symbolBtns[i].OnClickMe -= OnClickBtn;
        }
    }


}
