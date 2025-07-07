using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [field: SerializeField] public BtnManager BtnManager { get; private set; }
    [field: SerializeField] public ScoreManager ScoreManager { get; private set; }
    [field: SerializeField] public ChooseSymbol ChooseSymbol { get; private set; }
    [field: SerializeField] public TextManager TextManager { get; private set; }
    [field: SerializeField] public SLotMachineMgr SlotMachineMgr { get; private set; }
    public static UIManager Instance { get; private set; }

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
}
