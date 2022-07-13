using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += LoadState; 
            DontDestroyOnLoad(gameObject);
            // PlayerPrefs.DeleteAll();    //清除所有数据
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    public int currentWeaponId;
    public Image weaponImage;
    
    //references
    public Player player;
    public FloatingTextManager floatingTextManager;
    
    public void showFloatingText(string msg, Vector3 position,Vector3 motion, int fontSize, Color color, float duration)
    {
        floatingTextManager.Show(msg, position, motion, fontSize, color, duration);
    }
    
    
    //Logic 
    public int gems;
    public int xp;

    /*
     * int perferSkin ;
     * int WeaponLevel ;
     * int gems ;
     * int xp ;
     */
     
    
    public void SaveState()
    {
          Debug.Log("Saving state");
          string s = "";
          s +="0" + ",";
          s +="0" + ",";
          s += gems.ToString() + ",";
          s += xp.ToString() + ",";
          PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode  )
    {
        Debug.Log("Loading state");
        string[] data = PlayerPrefs.GetString("SaveState").Split(',');
        // player.perferSkin = int.Parse(data[0]);
        // player.WeaponLevel = int.Parse(data[1]);
        gems = int.Parse(data[2]);
        xp = int.Parse(data[3]);
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
 

}
