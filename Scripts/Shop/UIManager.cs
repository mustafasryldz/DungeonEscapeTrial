using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null) 
            {
                Debug.LogError("UI Manager is null!");
            }
            return _instance;
        }
    }

    public Text player_Gem_Count_Text;
    public Image selection_Img;
    public Text gem_Count_Text;
    public Image[] life_Units;
    public void OpenShop(int getCount)
    {
        player_Gem_Count_Text.text = getCount + "G";
    }
    private void Awake()
    {
        _instance = this;
    }
    public void Update_Shop_Selection(int yPos)
    {
        selection_Img.rectTransform.anchoredPosition = new Vector2(selection_Img.rectTransform.anchoredPosition.x, yPos);
    }
    public void Update_Gem_Count(int count)
    {
        gem_Count_Text.text = ("" + count);
    }
    public void Update_Life_Remainig(int life_Remaining)
    {
        for (int i = 0; i <= life_Remaining; i++)
        {
            if (i == life_Remaining)
            {
                life_Units[i].enabled = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
