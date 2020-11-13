using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop_Panel;
    public int current_Selected_Item;
    public int current_Item_Cost;
    private Player the_Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            shop_Panel.SetActive(true);
            the_Player = other.GetComponent<Player>();
            if (the_Player != null)
            {
                UIManager.Instance.OpenShop(the_Player.diamonds); 
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shop_Panel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {

        switch (item)
        {
            case 0:
                UIManager.Instance.Update_Shop_Selection(63);//63
                current_Selected_Item = 0;
                current_Item_Cost = 200;
                break;

            case 1:
                UIManager.Instance.Update_Shop_Selection(-45);//-45
                current_Selected_Item = 1;
                current_Item_Cost = 400;
                break;

            case 2:
                UIManager.Instance.Update_Shop_Selection(-137);//-137
                current_Selected_Item = 2;
                current_Item_Cost = 100;
                break;
        }

    }
    public void BuyItem()
    {
        if (the_Player.diamonds >= current_Item_Cost)
        {
            if (current_Selected_Item == 2) 
            {
                GameManager.Instance.CastleKey = true;
            }
            the_Player.diamonds -= current_Item_Cost;
            Debug.Log("purchased " +current_Selected_Item);
            shop_Panel.SetActive(false);

        }
        else
        {
            Debug.Log("Not enough money");
            shop_Panel.SetActive(false);
        }
    }
}
