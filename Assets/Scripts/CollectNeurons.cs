using UnityEngine;
using UnityEngine.UI;
using System;
public class CollectNeurons : MonoBehaviour
{
    public static event Action collectAction;
    [SerializeField] Button collect;
    // Start is called before the first frame update
    void Start()
    {
        collect.onClick.AddListener(collectAllNeurons);
    }

    public void collectAllNeurons()
    {
        collectAction?.Invoke();
    }
}
