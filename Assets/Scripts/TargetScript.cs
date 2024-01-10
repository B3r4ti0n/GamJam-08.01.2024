using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject trigger;
    [SerializeField] 
    private TriggerScript triggerScript;
    [SerializeField] 
    private GameObject door1;
    [SerializeField] 
    private GameObject door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ammo")){
            trigger.SetActive(false);
        }
    }
}
