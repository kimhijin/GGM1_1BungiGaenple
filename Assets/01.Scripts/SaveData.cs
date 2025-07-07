using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int erazerCount = 0;
    public bool isShutterDown = false;
    public bool isClickErazer = false;
    public bool isDebtYes = false;

    public int debtCoin = 1000;
    public bool isStart = false;

}
