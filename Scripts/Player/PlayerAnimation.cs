using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator player_Anim;
    private Animator sword_Anim;
    void Start()
    {
        player_Anim = GetComponentInChildren<Animator>();
        sword_Anim = transform.GetChild(1).GetComponent<Animator>();
    }
    public void Move(float move)
    {
        player_Anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool jumping)
    {
        player_Anim.SetBool("Jumping", jumping);
    }
    public void Attack()
    {
        player_Anim.SetTrigger("Attack");
        sword_Anim.SetTrigger("Swing");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
