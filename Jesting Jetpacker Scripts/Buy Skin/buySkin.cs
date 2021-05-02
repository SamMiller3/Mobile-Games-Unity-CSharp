using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buySkin : MonoBehaviour
{
    public int ID;
    public void Click(){
        skinUI.skin = ID;
        skinUI.buy = 1;
    }
}
