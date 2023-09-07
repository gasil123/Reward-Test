using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class ContentManagerUI : MonoBehaviour
{
    [SerializeField] private Button rewardButton;

#nullable enable
    [SerializeField] ContentData? contentData;
    [SerializeField] TextMeshProUGUI? id;
    [SerializeField] TextMeshProUGUI? award;
    [SerializeField] TextMeshProUGUI? minimumConnectionTime;
    [SerializeField] TextMeshProUGUI? showClaim;
    [SerializeField] TextMeshProUGUI? currency_Required;
    [SerializeField] RawImage? currency_image;
    [SerializeField] TextMeshProUGUI? loggedin_time;
    [SerializeField] TextMeshProUGUI? currency_Earned;
    [SerializeField] TextMeshProUGUI? is_coolingdown;
    [SerializeField] TextMeshProUGUI? coolDownTime;
#nullable disable

    private string imageURL; 
    private string hour = " H";
    private void Start()
    {
        imageURL = contentData.currency_image_url;
        StartCoroutine(GetTexture());
        StartCoroutine(UpdateContents());
    }
    IEnumerator UpdateContents()
    {
        if (id != null) id.text = contentData?.id.ToString() + hour;
        if (award != null) award.text = contentData?.award_every.ToString() + hour;
        if (minimumConnectionTime != null) minimumConnectionTime.text = contentData?.minimum_connection_time.ToString();
        if (currency_Required != null) currency_Required.text = contentData?.currency_required.ToString();
        if (loggedin_time != null) loggedin_time.text = contentData?.loggedin_time.ToString() + hour;
        if (currency_Earned != null) currency_Earned.text = contentData?.curr_earned.ToString();
        if (is_coolingdown != null) is_coolingdown.text = contentData?.is_cooling_down.ToString();
        if (coolDownTime != null) coolDownTime.text = contentData?.cool_down_time.ToString("F2");
        if (contentData?.show_claim == 1) {
            SetClaim("Claim!");
        }
        else if(contentData.is_cooling_down == 1)
        {
            SetClaim($"cooling \n down");
        }
        else
        {
            SetClaim("Go!");
        }
        yield return null;
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
           if(currency_image != null) currency_image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
    private void SetClaim(string status)
    {
        if (showClaim != null) showClaim.text = status;
    }
}