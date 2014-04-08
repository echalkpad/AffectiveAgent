using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class VideoFrame
    {
        int time;
        string emotion;
        double emotionIntensity;
        string valence;
        double valenceIntensity;

        public VideoFrame(int time, string emotion, double emotionIntensity, string valence, double valenceIntensity)
        {
            this.time = time;
            this.emotion = emotion;
            this.emotionIntensity = emotionIntensity;
            this.valence = valence;
            this.valenceIntensity = valenceIntensity;
        }
    }
}
