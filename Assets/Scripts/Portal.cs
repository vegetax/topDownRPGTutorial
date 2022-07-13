using UnityEngine;
public class Portal : Collidable
{
    public string[] scenes;
    
    protected override void OnCollision(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            string secen = scenes[Random.Range(0, scenes.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(secen);
        }
    }
    
}
