using TMPro;
using UnityEngine;
using UnityEngine.UI;

 public class FloatingText
{
    public bool isActive;
    public GameObject go;
    public TextMeshProUGUI txt;
    public Vector3 motion;
    public float duration;
    public float lastTime;
    

    public void Show()
    {
        isActive  = true;
        lastTime = Time.time;
        go.SetActive(isActive);
    }
    
    public void hide()
    {
        isActive = false;
        go.SetActive(isActive);
         

    } 

    public void update()
    {
        if (isActive)
        {
            if (Time.time - lastTime > duration)
            {
                hide();
            }
            else
            {
                go.transform.position += motion * Time.deltaTime;
            }
        }
    } 

}
