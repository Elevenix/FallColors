using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private Slider volume;

    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
        }

        music = FindObjectOfType<SoundManager>().MusicManager();

        volume.value = PlayerPrefs.GetFloat("Volume");
        SetVolume();
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
        music.volume = volume.value;
    }
}
