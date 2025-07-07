using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISymbol : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI symbolText;
    [SerializeField] private TextMeshProUGUI itemText;

    [SerializeField] private GameObject guideObj;
    [SerializeField] private RectTransform guidePos;
    [SerializeField] private TextMeshProUGUI itemGuide;
    public ItemSO itemData;
    Vector3 minucePos = new Vector3(-230,270,0);
    public ItemSO GetData()
    {
        return itemData;
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        itemImage.sprite = itemData.ItemImage;

        if (UIManager.Instance.SlotMachineMgr.haveSymbols[itemData.MySymbol]<=0)
        {
            gameObject.SetActive(false);
            return;
        }
        symbolText.text = UIManager.Instance.SlotMachineMgr.haveSymbols[itemData.MySymbol].ToString();
    }

    public void PointEnter()
    {
        guideObj.SetActive(true);
        itemGuide.text = itemData.ItemGuide;
        guidePos.position = Input.mousePosition- minucePos;
    }
    public void PointExit()
    {
        guideObj.SetActive(false);
    }

    public void OnDrop()
    {
        if(SaveData.Instance.isClickErazer)
        {
            SaveData.Instance.erazerCount--;
            itemText.text = SaveData.Instance.erazerCount.ToString();

            UIManager.Instance.SlotMachineMgr.InventoryDelete(itemData.MySymbol);
            if (UIManager.Instance.SlotMachineMgr.haveSymbols[itemData.MySymbol] <= 0)
            {
                gameObject.SetActive(false);
                return;
            }
            symbolText.text = UIManager.Instance.SlotMachineMgr.haveSymbols[itemData.MySymbol].ToString();
            SaveData.Instance.isClickErazer = false;

        }
    }
}
