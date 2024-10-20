using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioClip mainMenuMusic; // Музыка главного меню
    public AudioClip[] gameMusicTracks; // Массив треков для игры
    public AudioSource audioSource; // Источник аудио
    public AudioMixerGroup mixerGroup; // Смешивающая группа для регулировки громкости (опционально)
    public AudioMixer audioMixer; // Ссылка на AudioMixer
   
    public string musicMixerParameter = "MusicVolume"; // Имя параметра громкости музыки

    private float currentTime; // Время текущего трека
    private bool isGameMusicPlaying = false; // Флаг, для отслеживания состояния музыки игры

    private void Start()
    {
        // Играет музыку главного меню при старте
        PlayMainMenuMusic();
        audioSource.volume = 0.15f;
    }

    public void PlayMainMenuMusic()
    {
        audioSource.clip = mainMenuMusic;
        audioSource.loop = true; // Зацикливаем музыку
        audioSource.Play();
        isGameMusicPlaying = false; // Устанавливаем флаг на false
    }

    public void StartGameMusic()
    {
        PlayRandomTrack(); // Начинаем воспроизведение случайного трека
    }

    public void PauseMusic()
    {
        if (isGameMusicPlaying)
        {
            currentTime = audioSource.time; // Сохраняем текущее время трека
            audioSource.Pause(); // Пауза музыки
        }
    }

    public void ResumeMusic()
    {
        if (isGameMusicPlaying)
        {
            audioSource.time = currentTime; // Возвращаемся к сохраненному времени
            audioSource.UnPause(); // Возобновляем воспроизведение
        }
    }

    public void PlayPauseSound(AudioClip pauseSound)
    {
        audioSource.PlayOneShot(pauseSound); // Воспроизводим звук паузы
        StartCoroutine(WaitAndRestoreMainMenuMusic(pauseSound.length)); // После паузы возвращаем к главному меню
    }

    private IEnumerator WaitAndRestoreMainMenuMusic(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayMainMenuMusic(); // Включаем музыку главного меню
    }

    public void PlayRandomTrack()
    {
        int randomIndex = Random.Range(0, gameMusicTracks.Length);
        audioSource.clip = gameMusicTracks[randomIndex];
        audioSource.loop = true; // Зацикливаем трек
        audioSource.Play();
        isGameMusicPlaying = true; // Устанавливаем флаг на true
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(musicMixerParameter, volume); // Устанавливаем громкость
    }

    // Новый метод для изменения громкости музыки (например: -10 дБ)
    public void ChangeMusicVolume(float newVolume)
    {
        SetMusicVolume(newVolume);
    }
    private void Update()
    {
        // Проверка, закончился ли текущий трек, и смена на новый
        if (isGameMusicPlaying && !audioSource.isPlaying)
        {
            PlayRandomTrack();      
        }
    }
}