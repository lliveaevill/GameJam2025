using UnityEngine;
using System.Collections;

public class Stage2Button : MonoBehaviour
{
    int clickNum = 0;
    bool isCooldown = false;

    [SerializeField] Vector3 speed;
    [SerializeField] float cooldownTime = 2.0f; // クールタイムの時間（秒）
    [SerializeField] AudioClip clickSound; // クリック時のサウンドエフェクト

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            speed *= -1;
        }
    }

    public void Button1Click() {
        if (isCooldown) return;

        clickNum += 1;
        GManager.instance.sample_score += 1;

        // サウンドエフェクトを再生
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // 5回クリックされたらオブジェクトを破壊する
        if(clickNum >= 5)
        {
            Destroy(gameObject);
        }

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}