using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingView : MonoBehaviour
{
    [SerializeField]
    private List<FrameView> frameViewList;

    [SerializeField]
    private Text totalPointsTxt;

    public void CalculateTotalPoints() 
    {
        string pointsString = "";
        for (int i = 0; i < 10; i++) 
        {
            pointsString += frameViewList[i].GetFrameString()+" ";
        }
        Debug.Log("Points string builded: "+pointsString);
        totalPointsTxt.text = BowlingBoard.CalculateScore(pointsString).ToString();
    }

}
