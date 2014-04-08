using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class VideoPacket
    {
        string person;
        List<VideoFrame> videoFrames;

        public VideoPacket(string person)
        {
            this.person = person;
            this.videoFrames = new List<VideoFrame>();
        }

        public void addVideoFrame(VideoFrame videoFrame)
        {
            videoFrames.Add(videoFrame);
        }
    }
}
