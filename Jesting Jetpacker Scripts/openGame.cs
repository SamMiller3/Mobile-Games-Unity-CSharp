using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void click()
    {
        bannerAd.on = 0;
        SceneManager.LoadScene("Game");
    }
}
