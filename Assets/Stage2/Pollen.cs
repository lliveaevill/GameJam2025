using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; // これを追加

public class Pollen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float blowDuration = 1f;
    [SerializeField] private float blowDistanceMin = 100f;
    [SerializeField] private float blowDistanceMax = 150f;
    
    // UI要素がクリックされたときに呼ばれる
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(BlowAway());
    }
    
    IEnumerator BlowAway()
    {
        Vector3 startPos = transform.position;
        float randomX = Random.Range(-1f, 1f);
        float randomDistance = Random.Range(blowDistanceMin, blowDistanceMax);
        // new Vector3(randomX, 1f, 0)を正規化してtargetベクトルを作成
        Vector3 target = startPos + new Vector3(randomX, 1f, 0).normalized * randomDistance;
        
        float elapsed = 0f;
        while (elapsed < blowDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target, elapsed / blowDuration);
            yield return null;
        }
        
        // 必要なら吹っ飛んだ後オブジェクトを削除する
        // Destroy(gameObject);
    }
}
