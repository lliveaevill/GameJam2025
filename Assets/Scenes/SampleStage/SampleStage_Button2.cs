using UnityEngine;

public class SampleStage_Button2_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button2Click()
    {
        GManager.instance.sample_score += 1;

        Destroy(gameObject);

    }


}
