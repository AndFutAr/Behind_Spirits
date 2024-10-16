using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackMenedger1 : MonoBehaviour
{
    public GameObject darkBackground; // Затемняющий фон
    public GameObject popupWindow; // Всплывающее окно
    public Button openButton; // Кнопка для открытия окна
    public Button closeButton; // Кнопка для закрытия окна
    public float fadeDuration = 0.5f; // Длительность затемнения
    public Animator animator1;

    void Start()
    {
        // Подписка на события
        openButton.onClick.AddListener(OpenPopup);
        closeButton.onClick.AddListener(ClosePopup);

        // Скрываем элементы изначально
        darkBackground.SetActive(false);
        
    }

    void OpenPopup()
    {
        darkBackground.SetActive(true);
        animator1.SetTrigger("PA1");
        StartCoroutine(FadeIn(darkBackground.GetComponent<Image>()));
    }

    void ClosePopup()
    {
        StartCoroutine(FadeOut(darkBackground.GetComponent<Image>()));
    }

    private IEnumerator FadeIn(Image image)
    {
        Color bgColor = image.color;
        bgColor.a = 0;

        while (bgColor.a < 0.98f) // Достижение нужной прозрачности
        {
            bgColor.a += Time.deltaTime / fadeDuration;
            image.color = bgColor;
            yield return null;
        }
    }

    private IEnumerator FadeOut(Image image)
    {
        Color bgColor = image.color;
        animator1.SetTrigger("PA2");
        while (bgColor.a > 0)
        {
            bgColor.a -= Time.deltaTime / fadeDuration;
            image.color = bgColor;
            yield return null;
        }

        darkBackground.SetActive(false); // Скрываем фон после исчезновения
        
    }
}
