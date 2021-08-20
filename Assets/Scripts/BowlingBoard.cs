using System.Collections.Generic;

public class BowlingBoard
{
    public static int CalculateScore(string points)
    {

        List<string> frameList = new List<string>(points.Split(' ')); 
        int totalPoints = 0;
        int prevScore = 0;

        for (int i = 0; i < 10; i++)
        {
            string frame = frameList[i];

            if(IsStrike(frame))
            {
                totalPoints += 10;

                var nextFrame = frameList[i + 1];
                var afterNextFrame = frameList[i + 2];

                if(IsStrike(nextFrame))
                {
                    totalPoints += 10;

                    CheckFrame(afterNextFrame, 0, ref totalPoints);
                }
                else
                {

                    prevScore = SumIfNumber(nextFrame[0].ToString(), ref totalPoints);

                    if (!IsLastFrame(i)) 
                    {
                        if (IsSpare(nextFrame)) 
                        {
                            totalPoints += 10 - prevScore;
                        } 
                        else 
                        {
                            SumIfNumber(nextFrame[1].ToString(), ref totalPoints);
                        }
                    }
                    else 
                    {
                        if (IsSpare(afterNextFrame)) {
                            totalPoints += 10 - prevScore;
                        } else {
                            SumIfNumber(afterNextFrame[0].ToString(), ref totalPoints);
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < 2; j++)
                {
                    if (IsSpare(frame)) 
                    {

                        totalPoints += 10;

                        if (!IsLastFrame(i)) 
                        {
                            var nextFrame = frameList[i + 1];

                            CheckFrame(nextFrame, 0, ref totalPoints);
                        } 
                        else 
                        {
                            CheckFrame(frame, 2, ref totalPoints);
                        }

                        break;
                    } 
                    else 
                    {
                        SumIfNumber(frame[j].ToString(), ref totalPoints);
                    }
                }
                             
            }    

        }


        return totalPoints;
    }

    public static void CheckFrame(string frame, int frameIndex, ref int totalPoints) {
        if (IsStrike(frame)) {
            totalPoints += 10;
        } else {
            SumIfNumber(frame[frameIndex].ToString(), ref totalPoints);
        }
    }

    public static int SumIfNumber(string frameFragment, ref int totalPoints) {
        int scored;
        if (int.TryParse(frameFragment, out scored)) {
            totalPoints += scored;
        }
        return scored;
    }

    public static bool IsStrike(string frame) {
        return frame == "X";
    }

    public static bool IsSpare(string frame) {
        return frame.Contains("/");
    }

    public static bool IsLastFrame(int frameIndex) {
        return frameIndex == 9;
    }
}