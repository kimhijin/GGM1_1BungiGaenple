using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    [SerializeField] GameObject _setting;
    [SerializeField] GameObject _inventory;
    [SerializeField] GameObject _shutter;

    public event Action OnTurn;
    public event Action OnDestroy;
    public event Action OnInventory;
    public bool isRoll { get; set; } = true;


    public void OnClickSetting(bool close)
    {
        _setting.SetActive(close);
    }

    public void OnClickInventory(bool close)
    {
        if(close)
        {
            OnInventory?.Invoke();
        }
        _inventory.SetActive(close);
    }

    //µ¹¸®±â
    public void OnSwingBtn()
    {
        if(isRoll)
        {
            OnDestroy?.Invoke();
            isRoll =false;
            OnTurn?.Invoke();
        }
    }

    public void OnClickStart()
    {
        _shutter.SetActive(true);
        StartCoroutine(ComeShutter());
    }
    IEnumerator ComeShutter()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Start");
    }

    public void OnClickReGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickFirstWindow()
    {
        SceneManager.LoadScene("Title");
    }

}
