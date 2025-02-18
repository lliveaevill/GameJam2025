using UnityEngine;

public class SampleStage_Button1 : MonoBehaviour
{
    int clickNum = 0;

    [SerializeField] Vector3 speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        clickNum += 1;
        GManager.instance.sample_score += 1;

        // 5‰ñƒNƒŠƒbƒN‚µ‚½‚çÁ‚¦‚é
        if(clickNum >= 5)
        {
            Destroy(gameObject);
        }

    }

}
