using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider timer;
    bool isTimeEnd = false;
    [SerializeField] Shutter shutter;
    [SerializeField] ChooseSymbol chooseSymbol;
    [SerializeField] SymbolTurnMgr symbolTurnMgr;

    private void Awake()
    {
        timer = GetComponent<Slider>();
    }
    private void OnEnable()
    {
        UIManager.Instance.TextManager.timerReset += RestartTimer;
    }

    private void Update()
    {
        //만약 처음 창을 닫으면 시작
        if(SaveData.Instance.isStart)
        {
            if(!isTimeEnd)
            {
                timer.value -= Time.deltaTime;
                timer.value = Mathf.Clamp(timer.value, 0, timer.maxValue);
                if (timer.value <= 0)
                {
                    isTimeEnd = true;
                }
            }
            else
            { 
                if(SaveData.Instance.isShutterDown)
                {
                    shutter.gameObject.SetActive(true);
                    SaveData.Instance.isShutterDown = false;
                    
                }
            }

        }
    }

    void RestartTimer()
    {
        isTimeEnd = false;
        timer.value = timer.maxValue;
    }
    private void OnDisable()
    {
        UIManager.Instance.TextManager.timerReset -= RestartTimer;
    }
}
