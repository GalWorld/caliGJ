using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [System.Serializable]
    public class AudioEntry 
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1f;
    }
    
    [Header("Audio Configurations")]
    public List<AudioEntry> soundEffects = new List<AudioEntry>();
    public List<AudioEntry> backgroundMusic = new List<AudioEntry>();
    
    [Header("Volume Controls")]
    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;
    
    // Simplified audio sources
    private AudioSource musicSource;
    private AudioSource sfxSource;
    
    private string currentMusicName = "";
    
    private void Awake() 
    {
        // Singleton pattern
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Single sources for music and SFX
            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();
            
            sfxSource.playOnAwake = false;
            
            LoadSettings();
        } 
        else 
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Reproducir música inicial según la escena actual
        PlayMusicForCurrentScene();
        
        // Registrar el evento para futuros cambios de escena
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        // Es buena práctica desregistrar eventos
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
    
    private void OnSceneChanged(Scene current, Scene next)
    {
        // Reproducir música para la nueva escena
        PlayMusicForScene(next.name);
    }

    private void PlayMusicForCurrentScene()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        Debug.Log("Cambiando música para escena: " + sceneName);
        
        switch (sceneName)
        {
            case "MainMenu":
                PlayMusic("Submarino");
                break;
            case "LevelOne":
                PlayMusic("Ambiente");
                break;
        }
    }
    
    private void LoadSettings() 
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
    
    public void PlayMusic(string name) 
    {
        if (currentMusicName == name) return;
        
        AudioEntry music = backgroundMusic.Find(m => m.name == name);
        if (music?.clip != null) 
        {
            currentMusicName = name;
            musicSource.clip = music.clip;
            musicSource.volume = music.volume * musicVolume * masterVolume;
            musicSource.loop = true;
            musicSource.Play();
        }
        else 
        {
            Debug.LogError($"Music '{name}' not found");
        }
    }
    
    public void PlaySFX(string name) 
    {
        AudioEntry effect = soundEffects.Find(s => s.name == name);
        if (effect?.clip != null) 
        {
            sfxSource.clip = effect.clip;
            sfxSource.volume = effect.volume * sfxVolume * masterVolume;
            sfxSource.loop = false;
            sfxSource.Play();
        }
        else 
        {
            Debug.LogError($"SFX '{name}' not found");
        }
    }
    
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            currentMusicName = "";
        }
    }
    
    public void UpdateVolumes(float value)
    {
        // Actualizar todos los volúmenes con el mismo valor
        masterVolume = value;
        musicVolume = value;
        sfxVolume = value;
        
        // Update current playing audio
        if (musicSource.isPlaying)
        {
            AudioEntry currentMusic = backgroundMusic.Find(m => m.clip == musicSource.clip);
            if (currentMusic != null)
                musicSource.volume = currentMusic.volume * musicVolume * masterVolume;
        }
        
        // Update SFX volume if currently playing
        if (sfxSource.isPlaying)
        {
            AudioEntry currentSFX = soundEffects.Find(s => s.clip == sfxSource.clip);
            if (currentSFX != null)
                sfxSource.volume = currentSFX.volume * sfxVolume * masterVolume;
        }
        
        // Save settings
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }

    // Métodos separados para actualización individual de volúmenes
    public void UpdateMasterVolume(float value)
    {
        masterVolume = value;
        UpdateVolumesInternal();
    }

    public void UpdateMusicVolume(float value)
    {
        musicVolume = value;
        UpdateVolumesInternal();
    }

    public void UpdateSFXVolume(float value)
    {
        sfxVolume = value;
        UpdateVolumesInternal();
    }

    private void UpdateVolumesInternal()
    {
        // Update current playing audio
        if (musicSource.isPlaying)
        {
            AudioEntry currentMusic = backgroundMusic.Find(m => m.clip == musicSource.clip);
            if (currentMusic != null)
                musicSource.volume = currentMusic.volume * musicVolume * masterVolume;
        }

        // Update SFX volume if currently playing
        if (sfxSource.isPlaying)
        {
            AudioEntry currentSFX = soundEffects.Find(s => s.clip == sfxSource.clip);
            if (currentSFX != null)
                sfxSource.volume = currentSFX.volume * sfxVolume * masterVolume;
        }

        // Save individual volume settings
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}