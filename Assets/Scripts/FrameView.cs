using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameView : MonoBehaviour
{
    [SerializeField]
    protected InputField pair1;

    [SerializeField]
    protected InputField pair2;

    public virtual string GetFrameString() 
    {
        if (BowlingBoard.IsStrike(pair2.text)) {
            return pair2.text;
        } else {
            return pair1.text + pair2.text;
        }
    }

}
