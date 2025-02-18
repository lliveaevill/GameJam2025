using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundChanger : MonoBehaviour
{
    public RawImage backgroundImage; // 背景画像のUI要素
    public Texture[] backgroundTextures; // 変更するテクスチャ
    public float changeInterval = 1.0f; // 変更間隔

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
