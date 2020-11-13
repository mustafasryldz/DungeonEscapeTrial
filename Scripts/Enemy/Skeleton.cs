using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Initialization()
    {
        base.Initialization();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();

        
    }
    public void Damage()
    {
        if (is_Dead)
        {
            return;
        }
        Debug.Log("Damaged()-Skeleton");
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
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
}
