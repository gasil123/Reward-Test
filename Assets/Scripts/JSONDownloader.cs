using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using Newtonsoft.Json;
public class JSONDownloader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainTimer;
    private void Start()
    {
        StartCoroutine(GetRewards());
    }
    public ContentData[] datas;
    public void SetMainTimer(float time)
    {
        mainTimer.text = time.ToString("F2");
    }
    IEnumerator GetRewards()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://epicmindarena.com/inteview_api/get_all_hourlyrewards.json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;

            try
            {
                Reward rewardsResponse = JsonConvert.DeserializeObject<Reward>(jsonResponse);
                SetMainTimer(rewardsResponse.next_reward_minutes);
                if (rewardsResponse != null && rewardsResponse.rewards != null)
                {
                    for(int i= 0;i< rewardsResponse.rewards.Count; i++)
                    {
                        datas[i].id = rewardsResponse.rewards[i].id;
                        datas[i].award_every = rewardsResponse.rewards[i].award_every;
                        datas[i].minimum_connection_time = rewardsResponse.rewards[i].minimum_connection_time;
                        datas[i].show_claim = rewardsResponse.rewards[i].show_claim;
                        datas[i].currency_required = rewardsResponse.rewards[i].currency_required;
                        datas[i].currency_image_url = rewardsResponse.rewards[i].currency_image;
                        datas[i].loggedin_time = rewardsResponse.rewards[i].loggedin_time;
                        datas[i].curr_earned = rewardsResponse.rewards[i].curr_earned;
                        datas[i].is_cooling_down = rewardsResponse.rewards[i].is_cooling_down;
                        datas[i].cool_down_time = rewardsResponse.rewards[i].cool_down_time;
                    }
                }
                else
                {
                    Debug.LogError("JSON parsing error: rewardsResponse or rewards array is null.");
                }
            }
            catch (JsonException e)
            {
                Debug.LogError("JSON parsing error: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("API request failed: " + request.error);
        }
    }
}
