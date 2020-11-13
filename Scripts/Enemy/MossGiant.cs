using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{

    public int Health { get; set; }
    public override void Initialization()
    {
        base.Initialization();
        Health = base.health;
    }
    public void Damage()
    {
        if (is_Dead)
        {
            return;
        }
        Debug.Log("Damaged()-Moss");
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        is_Hit = true;
        if (Health < 1)
        {
            //Destroy(this.gameObject);
            anim.SetTrigger("Death");
            is_Dead = true;
            GameObject diamond = Instantiate(diamond_Prefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }





}
