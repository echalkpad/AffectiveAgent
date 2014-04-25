using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Data
{
    public enum Emotion
    {
        ANGER,
        CONTEMPT,
        DISGUST,
        FEAR,
        JOY,
        SADNESS,
        SURPRISE
    };
    public enum Valence
    {
        POSITIVE, NEGATIVE, NEUTRAL
    }

    public static class Constants
    {
        public static IEnumerable<Emotion> GetEmotions()
        {
            return Enum.GetValues(typeof(Emotion)).Cast<Emotion>();
        }

        public static Emotion ParseEmotion(string emotion)
        {
            switch (emotion)
            {
                case "ANGER":
                    return Emotion.ANGER;
                case "CONTEMPT":
                    return Emotion.CONTEMPT;
                case "DISGUST":
                    return Emotion.DISGUST;
                case "FEAR":
                    return Emotion.FEAR;
                case "JOY":
                    return Emotion.JOY;
                case "SADNESS":
                    return Emotion.SADNESS;
                case "SURPRISE":
                    return Emotion.SURPRISE;
                default:
                    throw new Exception("Emotion '" + emotion + "' cannot be parsed");
            }
        }

        public static String PrintEmotion(Emotion emotion)
        {
            switch (emotion)
            {
                case Emotion.ANGER:
                    return "Anger";
                case Emotion.CONTEMPT:
                    return "Contempt";
                case Emotion.DISGUST:
                    return "Disgust";
                case Emotion.FEAR:
                    return "Fear";
                case Emotion.JOY:
                    return "Joy";
                case Emotion.SADNESS:
                    return "Sadness";
                case Emotion.SURPRISE:
                    return "Suprise";
                default:
                    throw new Exception("Emotion '" + emotion + "' cannot be parsed");
            }
        }

        public static Valence ParseValence(string valence)
        {
            switch (valence)
            {
                case "POSITIVE":
                    return Valence.POSITIVE;
                case "NEGATIVE":
                    return Valence.NEGATIVE;
                case "NEUTRAL":
                    return Valence.NEUTRAL;
                default:
                    throw new Exception("Valence '" + valence + "' cannot be parsed");
            }
        }
    }
}
