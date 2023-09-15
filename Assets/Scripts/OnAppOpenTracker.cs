using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
public class OnAppOpenTracker : MonoBehaviour
{
    private string apiURL = "https://leeloolxp.epicmindarena.com/api/attendance/clockin";
    private string authToken = "2dMl9jlzHnQNgOqsGFHyN4g4d4UFVlGl1T02EH2OEegamLKaB4XbvWOB42ZuxO96";

    void Start()
    {
        StartCoroutine(TrackAppOpen());
        InvokeRepeating("TrackAppOpen", 0f, 60f); // 300 seconds = 5 minutes
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
        else
        {
            Debug.Log("App open tracking request Success");
        }
    }
}
