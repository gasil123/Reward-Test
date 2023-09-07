using UnityEngine;

public class CanvasManger : MonoBehaviour
{
    #region serializefields
    [SerializeField] GameObject rewardButton;
    [SerializeField] GameObject rewardPanel;
   
    #endregion
   
    private void Start()
    {
        rewardButton.SetActive(true);
        rewardPanel.SetActive(false);
    }
}
