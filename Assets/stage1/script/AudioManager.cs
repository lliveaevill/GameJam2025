using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;


    AudioSource bgmAudioSource;
    AudioSource seAudioSource;

    //public String name;
    //[SerializeField] int a;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        bgmAudioSource = instance.gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true;

        seAudioSource = instance.gameObject.AddComponent<AudioSource>();
        seAudioSource.loop = false;

    }

    public void PlayBGM(AudioClip audioClip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = audioClip;
        bgmAudioSource.Play();
    }

    public void PlaySE(AudioClip audioClip)
    {
        seAudioSource.PlayOneShot(audioClip);
    }

}
