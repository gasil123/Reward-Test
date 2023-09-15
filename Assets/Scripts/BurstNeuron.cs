using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BurstNeuron : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float time = 1f;

    private void Start()
    {
        StartCoroutine(Disable());
    }
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,transform.up, speed * Time.deltaTime);
    }
    
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}