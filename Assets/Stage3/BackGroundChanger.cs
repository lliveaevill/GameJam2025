using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundChanger : MonoBehaviour
{
    public RawImage backgroundImage; // ”wŒi‰æ‘œ‚ÌUI—v‘f
    public Texture[] backgroundTextures; // •ÏX‚·‚éƒeƒNƒXƒ`ƒƒ
    public float changeInterval = 1.0f; // •ÏXŠÔŠu

    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (backgroundTextures.Length > 0)
        {
            StartCoroutine(ChangeBackground());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);
            if (backgroundTextures.Length == 0) continue;
            currentIndex = (currentIndex + 1) % backgroundTextures.Length;
            backgroundImage.texture = backgroundTextures[currentIndex];
        }
    }
}
