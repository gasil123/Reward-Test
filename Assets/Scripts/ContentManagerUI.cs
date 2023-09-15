using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Pool;
using UnityEngine.Experimental.Playables;

public class ContentManagerUI : MonoBehaviour
{
#nullable enable
    [SerializeField] GameObject? scoreMinusEffect;

    [SerializeField] Image? buttonImage;
    [SerializeField] GameObject? coolingDownProgress;
    [SerializeField] GameObject? coolingDownTimer;


    [SerializeField] GameObject? requirementAdditionalInfo;

    [SerializeField] RawImage? currency_image;
    [SerializeField] ContentData? contentData;
    [SerializeField] TextMeshProUGUI? id;
    [SerializeField] TextMeshProUGUI? award;
    [SerializeField] TextMeshProUGUI? minimumConnectionTime;
    [SerializeField] TextMeshProUGUI? showClaim;
    [SerializeField] TextMeshProUGUI? currency_Required;
    [SerializeField] TextMeshProUGUI? loggedin_time;
    [SerializeField] TextMeshProUGUI? currency_Earned;
    [SerializeField] TextMeshProUGUI? is_coolingdown;
#nullable disable

    private  int newCurrency;
    private string imageURL;
    private string hour = " H";
    private bool iscooling = false;
    private bool canPlayBurstAnimation = true;
    private void Start()
    {
     
        imageURL = contentData.currency_image_url;
        StartCoroutine(UpdateContents());
    }
    IEnumerator UpdateContents()
    {
        SetButtonImage();
        if (id != null) id.text = contentData?.id.ToString() + hour;
        if (award != null) award.text = contentData?.award_every.ToString() + hour;
      
        if (loggedin_time != null) loggedin_time.text = contentData?.loggedin_time.ToString() + hour;
        if (currency_Earned != null) currency_Earned.text = contentData?.curr_earned.ToString();
        if (is_coolingdown != null) is_coolingdown.text = contentData?.is_cooling_down.ToString();
        //if (coolDownTime != null) coolDownTime.text = contentData?.cool_down_time.ToString("F2");
        yield return null;
    }
    private void SetButtonImage()
    {
        if (contentData?.show_claim == 1)
        {
            requirementAdditionalInfo.SetActive(false);
            SetClaim("Claim!");
            buttonImage.sprite = contentData.img[0];
            coolingDownProgress.SetActive(false);
            coolingDownTimer.SetActive(false);
            GetComponentInChildren<Button>().onClick.AddListener(StartCooldown);

        }
        else if (contentData.is_cooling_down == 1)
        {
            canPlayBurstAnimation = false;
            requirementAdditionalInfo.SetActive(false);
            SetClaim($"cooling \n down");
            buttonImage.sprite = contentData.img[1];
            coolingDownProgress.GetComponent<RadialProgress>().initialCooldownMinutes = contentData.cool_down_time;
            coolingDownProgress.SetActive(true);
            coolingDownTimer.SetActive(true);
            coolingDownTimer.GetComponent<TimerManager>().timeInMinutes = contentData.cool_down_time;
          
        }
        else
        {
            requirementAdditionalInfo.SetActive(true);
            if (minimumConnectionTime != null) minimumConnectionTime.GetComponent<TimerManager>().timeInMinutes = (float)(contentData?.minimum_connection_time);
            newCurrency = contentData.currency_required;
            if (currency_Required != null) currency_Required.text = newCurrency.ToString();
            StartCoroutine(GetTexture());
            SetClaim("Go!");
            buttonImage.sprite = contentData.img[2];
            coolingDownProgress.SetActive(false);
            coolingDownTimer.SetActive(false);
        }
    }
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (currency_image != null) currency_image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
    private void SetClaim(string status)
    {
        if (showClaim != null) showClaim.text = status;
    }
    public void StartCooldown()
    {
        if (!iscooling)
        {
            requirementAdditionalInfo.SetActive(false);
            AudioManager.instance.PlayRewardEffect();
            iscooling = true;
            SetClaim($"cooling \n down");
            buttonImage.sprite = contentData.img[1];
            coolingDownProgress.GetComponent<RadialProgress>().initialCooldownMinutes = contentData.cool_down_time;
            coolingDownProgress.SetActive(true);
            coolingDownTimer.GetComponent<TimerManager>().timeInMinutes = contentData.cool_down_time;
            coolingDownTimer.SetActive(true);
        }
    }
    private void OnEnable()
    {
        CollectNeurons.collectAction += StartCollectingNeurons;
    }
    private void OnDisable()
    {
        CollectNeurons.collectAction -= StartCollectingNeurons;
    }
    public void StartCollectingNeurons()
    {
        int currentCurrency = newCurrency - 5;
        Instantiate(scoreMinusEffect, currency_image.rectTransform.position,currency_image.rectTransform.rotation, currency_image.rectTransform);
        currency_Required.text = currentCurrency.ToString();
        newCurrency = currentCurrency;
      
    }
}