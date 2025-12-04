using UnityEngine;
using UnityEngine.UI;

public class AC4 : MonoBehaviour
{
    public Animator animator1; // Ссылка на компонент Animator
    
    public Button playAnimationButton; // Ссылка на кнопку

    void Start()
    {
        // Подписка на событие нажатия кнопки
        playAnimationButton.onClick.AddListener(PlayAnimation);
    }

    void PlayAnimation()
    {
        // Воспроизведение анимации
        animator1.SetTrigger("PA2");
        
    }
}