using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private Image guideObj;
    [SerializeField] private TextMeshProUGUI guideText;
    Vector3 minucePos = new Vector3(230, -270, 0);


    //[SerializeField] private GameObject guideObj;
    //[SerializeField] private RectTransform guidePos;
    //[SerializeField] private TextMeshProUGUI itemGuide;
    public ItemSO itemData;
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
        itemCount.text = SaveData.Instance.erazerCount.ToString();
    }

    public void PointEnter()
    {
        guideObj.gameObject.SetActive(true);
        guideText.text = itemData.ItemGuide;
        guideObj.transform.position = Input.mousePosition - minucePos;
    }
    public void PointExit()
    {
        guideObj.gameObject.SetActive(false);
    }

    public void ClickItemBtn()
    {
        if(SaveData.Instance.erazerCount>0)
        {
            SaveData.Instance.isClickErazer = true;
        }
    }
}
