using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BurstNeuron : MonoBehaviour
{
    public static event Action AddNeuronScore;
    [SerializeField] float speed;
    private Transform targetpos;
    void OnEnable()
    {
        targetpos = GameObject.Find("Totalneuron").transform;
        
    }
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var mainneuron = collision.gameObject.GetComponentInChildren<NeuronCount>();
        if (mainneuron != null)
        {
            AddNeuronScore.Invoke();
            gameObject.SetActive(false);
        }
    }
}