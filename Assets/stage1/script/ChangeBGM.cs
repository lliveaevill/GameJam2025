using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    [SerializeField] AudioClip bgmClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(bgmClip);
    }

    // Update is called once per frame
    void Update()
    {

    }
}