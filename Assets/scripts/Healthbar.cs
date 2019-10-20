using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    Transform bar; 
    private void Awake()
    {
        bar = transform.Find("bar");
        //bar.localScale = new Vector3(2f, 1f);
        EventManager.AddDamageFalconListener(ShrinkBar);
    }
    public void ShrinkBar(int damage)
    {
        bar.localScale -= new Vector3((float)damage / 2f, 0f);
    }

    
}
