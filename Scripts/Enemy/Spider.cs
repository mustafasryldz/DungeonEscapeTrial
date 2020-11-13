using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acid_Effect_Prefab;
    // Start is called before the first frame update
    public int Health { get; set; }

    public override void Initialization()
    {
        base.Initialization();
        Health = base.health;
    }

    public override void Update()
    {
        //base.Update();
    }
    public void Damage()
    {
        if (is_Dead)
        {
            return;
        }
        Debug.Log("Damaged()-Spider");
        Health--;
        //nim.SetTrigger("Hit");
        //anim.SetBool("InCombat", true);
        is_Hit = true;
        if (Health < 1)
        {
            is_Dead = true;
            //Destroy(this.gameObject);
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamond_Prefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public void Attack()
    {
        Instantiate(acid_Effect_Prefab, transform.position, Quaternion.identity);
    }
}
