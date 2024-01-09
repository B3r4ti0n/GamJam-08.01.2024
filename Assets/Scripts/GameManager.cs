using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int m_Score = 0;
    public float m_speed_game = 1;
    public float m_speed_block = 5;
    public float m_width_block = 5;
    public int m_number_block;
    public ChunkScript ChunkInstantiate;
    public float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= m_width_block / (m_speed_game * m_speed_block)){
            Instantiate(ChunkInstantiate, new Vector3(0,0,-25), transform.rotation);
            ChunkInstantiate.speed = m_speed_block;
            startTime = Time.time;
        }
    }
}
