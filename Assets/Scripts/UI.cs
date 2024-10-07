using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject Text1, Text2, Text3, Text4, Text5;
    [SerializeField] private GameObject But1, But2, But3, But4, But5;

    private void Start()
    {
        Text1.SetActive(true);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Text5.SetActive(false);

        But1.SetActive(true);
        But2.SetActive(false);
        But3.SetActive(false);
        But4.SetActive(false);
        But5.SetActive(false);
    }
    public void On2()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        But1 .SetActive(false);
        But2 .SetActive(true);
    }
    public void On3()
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
        But2.SetActive(false);
        But3.SetActive(true);
    }
    public void On4()
    {
        Text3.SetActive(false);
        Text4.SetActive(true);
        But3.SetActive(false);
        But4.SetActive(true);
    }
    public void On5()
    {
        Text4.SetActive(false);
        Text5.SetActive(true);
        But4.SetActive(false);
        But5.SetActive(true);
    }
    public void GotoNewScene()
    {
        SceneManager.LoadScene("PlayableAdd");
    }

    public void RateBtn()
    {
        Application.OpenURL("https://vk.com/increatives");
    }
}
