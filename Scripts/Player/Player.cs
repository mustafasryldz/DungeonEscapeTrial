using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float jump_Force = 7.0f;
    [SerializeField]
    private float jump_fix = 0.8f;
    [SerializeField]
    private float move_Speed = 3.0f;
    [SerializeField]
    private LayerMask ground_Layer;
    public int diamonds;

    private bool reset_Jump;
    private SpriteRenderer player_Sprite;
    private SpriteRenderer sword_Sprite;
    private PlayerAnimation player_Anim;
    [SerializeField]
    private Transform sword_Box;

    public int Health { get; set ; }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player_Anim = GetComponent<PlayerAnimation>();
        player_Sprite = GetComponentInChildren<SpriteRenderer>();
        sword_Sprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        sword_Box = transform.GetChild(0).transform.GetChild(0).GetComponent<Transform>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (CrossPlatformInputManager.GetButton("A_Button") && is_Grounded())
        {
            player_Anim.Attack();
        }
    }
    void Movement()
    {

        float move = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            FlipX(true);
        }
        else if (move < 0) 
        {
            FlipX(false);
        }

        Debug.DrawRay(transform.position, Vector2.down * jump_fix, Color.green);
        if (is_Grounded() && (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("B_Button")))  
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump_Force);
            StartCoroutine(Reset_Jump_Routine());
            player_Anim.Jump(true);
        }
        rigid.velocity = new Vector2(move * move_Speed, rigid.velocity.y);

        player_Anim.Move(move);
    }
    void FlipX(bool face_Right)
    {
        if (face_Right == true)
        {
            player_Sprite.flipX = false;
            player_Sprite.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            sword_Sprite.flipX = false;
            sword_Sprite.flipY = false;
            sword_Box.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            player_Sprite.flipX = true;
            player_Sprite.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            sword_Sprite.flipX = true;
            sword_Sprite.flipY = true;
            sword_Box.transform.localScale = new Vector3(-1,1,1);
        }
    }
    bool is_Grounded()
    {
        RaycastHit2D hit_Info = Physics2D.Raycast(transform.position, Vector2.down, jump_fix, ground_Layer.value);

        if (hit_Info.collider != null) 
            if(!reset_Jump)
            {
                player_Anim.Jump(false);
                return true;
            }

        return false;
    }
   IEnumerator Reset_Jump_Routine()
    {
        reset_Jump = true;
        yield return new WaitForSeconds(0.1f);
        reset_Jump = false;
    }

    public void Damage()
    {
        Debug.Log("Player().Damage()");
        Health--;
        UIManager.Instance.Update_Life_Remainig(Health);
    }
    public void Add_Gems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.Update_Gem_Count(diamonds);
    }
}
