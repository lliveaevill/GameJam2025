using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    [SerializeField] private Image imageComponent; // 表示する画像のUIコンポーネント
    [SerializeField] private Sprite[] sprites;     // スコア増加量に応じて表示するスプライトの配列

    private int initialScore;

    void Start()
    {
        // シーン開始時のスコアを記録
        initialScore = GManager.instance.stage1_score;
    }

    void Update()
    {
        // 現在のスコア増加量を計算
        int scoreIncrease = GManager.instance.stage1_score - initialScore;

        // 5回押すごとに画像を変更
        int spriteIndex = scoreIncrease / 5;

        // スプライトインデックスが範囲内か確認
        if (spriteIndex >= 0 && spriteIndex < sprites.Length)
        {
            imageComponent.sprite = sprites[spriteIndex];
        }
    }
}
