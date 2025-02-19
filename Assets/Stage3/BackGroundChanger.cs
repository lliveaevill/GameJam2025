using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundChanger : MonoBehaviour
{
    public RawImage backgroundImage; // 背景画像のUI要素
    public Texture[] backgroundTextures; // 変更するテクスチャ

    private int currentIndex = 0;

    [SerializeField] float cooldownDuration = 0.5f; // クールタイムの秒数
    private float lastChangeTime = -10f; // 最後に変更した時間

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (backgroundTextures.Length > 0  && backgroundImage != null)
        {
            backgroundImage.texture = backgroundTextures[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackground()
    {
        if (backgroundTextures.Length == 0 || backgroundImage == null) return;

        //クールタイム中なら何もしない
        if (Time.time - lastChangeTime < cooldownDuration)
        {
            Debug.Log("クールタイム中！ 背景変更できません");
            return;
        }

        currentIndex = (currentIndex + 1) % backgroundTextures.Length;
        backgroundImage.texture = backgroundTextures[currentIndex];

        //最後に変更した時間を更新
        lastChangeTime = Time.time;
    }
}
