using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("game_man is not found");
            }
            return instance;
        }
    }
    public bool CastleKey { get; set; }
    public Player the_Player { get; private set; }
    private void Awake()
    {
        instance = this;
        the_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

}
