using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] soundClips1; // Массив звуков
    public AudioMixer audioMixer; // Ссылка на AudioMixer
    public string sfxMixerParameter = "SFXVolume"; // Имя параметра громкости SFX
    public AudioSource audioSource; // Источник аудио

    private void Start()
    {
        
        audioSource.volume = 5f;
    }
    public void SBuilding()
    {
        if (soundClips1.Length == 0) return; // Проверка на наличие звуков

        int randomIndex = Random.Range(0, soundClips1.Length); // Генерация случайного индекса
        AudioSource.PlayClipAtPoint(soundClips1[randomIndex], Camera.main.transform.position); // Воспроизведение звука
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfxMixerParameter, volume); // Устанавливаем громкость SFX
    }

    // Новый метод для изменения громкости звуковых эффектов
    public void ChangeSFXVolume(float newVolume)
    {
        SetSFXVolume(newVolume);
    }

}

