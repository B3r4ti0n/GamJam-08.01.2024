using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = ""+Settings.score;
    }
}
