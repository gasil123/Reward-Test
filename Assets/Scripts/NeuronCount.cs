using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NeuronCount : MonoBehaviour
{
    [SerializeField] int nuronCount;
    [SerializeField] TextMeshProUGUI nueronCountText;
    private int count = 0;
    private void Start()
    {
        nueronCountText.text = count.ToString();    
    }
    private void OnEnable()
    {
        BurstNeuron.AddNeuronScore += UpdateNueronCount;
    }
    private void OnDisable()
    {
        BurstNeuron.AddNeuronScore -= UpdateNueronCount;
    }
    private void UpdateNueronCount()
    {
        AudioManager.instance.PlayPopEffect();
        count += nuronCount;
        nueronCountText.text = "x "+count.ToString();
    }
}
