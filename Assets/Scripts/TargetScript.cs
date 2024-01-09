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
        GetGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        GetGameManager();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(gameManager.m_Score);
        if (other.CompareTag("Ammo")){
            gameManager.m_Score+=1;
        }
    }

    private void GetGameManager(){
        gameManagerObject = GameObject.FindWithTag("GameManager");
        if (gameManagerObject != null){
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
    }
}
