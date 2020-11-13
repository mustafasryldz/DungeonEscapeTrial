using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems;
    private Player the_Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            the_Player = other.GetComponent<Player>();

            if (the_Player)
            {
                the_Player.Add_Gems(gems);
                //the_Player.diamonds += gems;
                Destroy(this.gameObject);
            }
        }

    }
}
