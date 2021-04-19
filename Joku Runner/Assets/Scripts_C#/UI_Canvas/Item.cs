using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture icon;

    public enum ItemType {
        Token,
        HealthPotion,
        Coin
    }

    public ItemType itemType;
    public int amount;

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

}
