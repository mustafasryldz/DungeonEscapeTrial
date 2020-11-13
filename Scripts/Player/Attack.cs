using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    private bool can_Damage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (can_Damage == true)
            {
                hit.Damage();
                can_Damage = false;
                StartCoroutine(ResetDamage());
            }

        }
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        can_Damage = true;
    }
}
