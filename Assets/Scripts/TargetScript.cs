using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject gameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(Settings.score);
        if (other.CompareTag("Ammo")){
            Settings.score+=1;
        }
    }
}
