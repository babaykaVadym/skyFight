using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour
{

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            if (PlayerPrefs.GetInt("noads") != 1)
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                int coins = PlayerPrefs.GetInt("coin");
                coins += 100;
                PlayerPrefs.SetInt("coin", coins);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}