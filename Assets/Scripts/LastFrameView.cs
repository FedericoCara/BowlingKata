using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastFrameView : FrameView
{
    [SerializeField]
    private InputField pair3;

    public override string GetFrameString() {
        if (BowlingBoard.IsStrike(pair1.text)) {
            return $"{pair1.text} {pair2.text} {pair3.text}";
        } else {
            return $"{pair1.text}{pair2.text}{(BowlingBoard.IsSpare($"{pair1.text}{pair2.text}") ? pair3.text : "")}";
        }
    }

}
