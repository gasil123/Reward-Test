using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
public class OnAppOpenTracker : MonoBehaviour
{
    private string apiURL = "https://leeloolxp.epicmindarena.com/api/attendance/clockin";
    private string authToken = "";

    void Start()
    {
        StartCoroutine(TrackAppOpen());
    }

    IEnumerator TrackAppOpen()
    {
        UnityWebRequest request = new UnityWebRequest(apiURL, "POST");
        request.SetRequestHeader("Authorization", "Bearer " + authToken);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("App open tracking request failed: " + request.error);
        }
    }
}
