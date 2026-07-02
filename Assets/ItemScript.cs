using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //接触した瞬間だけ
        Debug.Log("Enter");
        DestroySelf();
    }

    private void OnTriggerStay(Collider other)
    {
        //接触している間ずっと
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //接触が終わった瞬間だけ
        Debug.Log("Exit");
    }


    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
