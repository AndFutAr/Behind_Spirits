using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ppak2 : MonoBehaviour
{
    public GameObject popupWindow; // Всплывающее окно
    public Button openButton; // Кнопка для открытия окна
    public Button closeButton; // Кнопка для закрытия окна
    public float fadeDuration = 0.5f; // Длительность затемнения

    void Start()
    {
        // Подписка на события
        openButton.onClick.AddListener(OpenPopup);
        closeButton.onClick.AddListener(ClosePopup);

        // Скрываем элементы изначально
        popupWindow.SetActive(false);
    }

    void OpenPopup()
    {
        popupWindow.SetActive(true);
    }

    void ClosePopup()
    {
        popupWindow?.SetActive(false);
    }
}