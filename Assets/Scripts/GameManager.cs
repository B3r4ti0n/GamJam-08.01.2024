using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_number_block;
    public ChunkScript ChunkInstantiate;
    
    // Start is called before the first frame update
    void Start()
    {
        Settings.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Settings._isAlive){
            if(Time.time - Settings.startTime >= Settings.width_block / (Settings.speed_game * Settings.speed_block)){
                Instantiate(ChunkInstantiate, new Vector3(0,0,-25), transform.rotation);
                Settings.startTime = Time.time;
            }
        }
    }
}
