using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadGame : MonoBehaviour
{
    public Image img;
    public Text author;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                author.color = new Color(1,1,1,i);
                yield return null;
            }
        
        SceneManager.LoadScene("Menu");
    }
}
