using UnityEngine;
using UnityEngine.UI;

public class AC1 : MonoBehaviour
{
    public Animator animator1; // Ссылка на компонент Animator
    public Animator animator2; // Ссылка на компонент Animator
    public Animator animator3; // Ссылка на компонент Animator
    public Animator animator4; // Ссылка на компонент Animator
    public Button playAnimationButton; // Ссылка на кнопку
    public Button playAnimationButton1; // Ссылка на кнопку

    void Start()
    {
        // Подписка на событие нажатия кнопки
       // playAnimationButton.onClick.AddListener(PlayAnimation);
       // playAnimationButton1.onClick.AddListener(PlayAnimation);
    }

    void PlayAnimation()
    {
        // Воспроизведение анимации
        animator1.SetTrigger("PA1");
        animator2.SetTrigger("PA1");
        animator3.SetTrigger("PA1");
        animator4.SetTrigger("PA1");// Убедитесь, что у вас есть триггер с таким именем в Animator
    }
}