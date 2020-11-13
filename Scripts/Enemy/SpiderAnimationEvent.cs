using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider spider;
    // Start is called before the first frame update
    private void Start()
    {
        spider = transform.parent.GetComponent<Spider>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        spider.Attack();
    }
}
