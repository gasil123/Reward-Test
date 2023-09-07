using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ContentData", menuName = "content", order = 1)]
public class ContentData : ScriptableObject
{
    public int id;
    public int award_every;
    public int minimum_connection_time;
    public int show_claim;
    public int currency_required;
    public string currency_image_url;
    public int loggedin_time;
    public int curr_earned;
    public int is_cooling_down;
    public int cool_down_time;
}
