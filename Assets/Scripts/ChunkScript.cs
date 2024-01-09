using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedAction());
        }
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
