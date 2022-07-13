using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()  
    {
        foreach (FloatingText floatingText in floatingTexts)
        {
            floatingText.update();
        }
       
    }

    public void Show(string msg, Vector3 position,Vector3 motion, int fontSize, Color color, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg; 
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);//transfer world to screen point
        
        floatingText.motion = motion;
        floatingText.duration = duration;
        
        floatingText.Show();
    }
    
    
    
    private FloatingText GetFloatingText(  )
    {
        FloatingText txt = floatingTexts.Find(x => !x.isActive);
        if (txt == null)
        {
            txt = new FloatingText(); 
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TextMeshProUGUI>();
            floatingTexts.Add(txt);
        }
        return txt;
    }
}
