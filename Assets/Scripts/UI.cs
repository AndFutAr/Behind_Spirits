using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject LoadBut;

    private void Start()
    {
        LoadBut.SetActive(true);
    }
    public void RateBtn()
    {
        Application.OpenURL("https://vk.com/increatives");
    }
}
