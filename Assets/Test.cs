using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    [SerializeField] RectTransform rect;
    [SerializeField] GameObject coinObj;
    [SerializeField] GameObject coinObj1;
    [SerializeField] Dictionary<GameObject, string> test = new Dictionary<GameObject, string>();

    public void OnClick()
    {
        Debug.Log("눌렀다");
    }
    public void OnClickUp()
    {
        Debug.Log("놓았다");
    }
}
