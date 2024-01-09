using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 7f;

    [SerializeField] 
    private List<Mesh> list_mesh;
    private MeshFilter meshFilter;
    private GameManager gameManager;
    private GameObject gameManagerObject;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = list_mesh[Random.Range(0, list_mesh.Count)];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){

        }
    }
}
