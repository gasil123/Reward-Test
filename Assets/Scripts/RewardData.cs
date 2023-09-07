using System.Collections.Generic;
public class RewardData
{
    public int id { get; set; }
    public int award_every { get; set; }
    public int minimum_connection_time { get; set; }
    public int show_claim { get; set; }
    public int currency_required { get; set; }
    public string currency_image { get; set; }
    public int loggedin_time { get; set; }
    public int curr_earned { get; set; }
    public int is_cooling_down { get; set; }
    public int cool_down_time { get; set; }
}

public class Reward
{
    public string status { get; set; }
    public string assetsurl { get; set; }
    public int next_reward_minutes { get; set; }
    public List<RewardData> rewards { get; set; }
}
