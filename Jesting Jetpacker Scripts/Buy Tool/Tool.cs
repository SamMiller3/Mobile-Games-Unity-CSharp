using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public int ID;
    public void Click(){
        BuyUI.tool = ID;
        BuyUI.buy = 1;
    }
}
