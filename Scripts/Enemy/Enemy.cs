using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject diamond_Prefab;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    protected bool is_Hit;
    protected bool is_Dead;

    [SerializeField]
    protected Transform point_A, point_B;
    protected Vector3 current_Target;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected Player the_Player;
    private void Start()
    {
        Initialization();
    }

    public virtual void Update()
    {
        if(is_Dead)
        {
            return;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false) 
        {
            return;
        }
        Movement();
    }
    public virtual void Initialization()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        the_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public virtual void Movement()
    {
        if (current_Target == point_A.position)
        {
            sprite.flipX = true;
        }
        if (current_Target == point_B.position)
        {
            sprite.flipX = false;
        }
        if (transform.position == point_A.position)
        {
            current_Target = point_B.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == point_B.position)
        {
            current_Target = point_A.position;
            anim.SetTrigger("Idle");
        }
        if(is_Hit==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, current_Target, speed * Time.deltaTime);
        }
        float distance = Vector3.Distance(transform.localPosition, the_Player.transform.localPosition);
        if (distance > 3f) 
        {
            is_Hit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = the_Player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }
    // Start is called before the first frame update

}
