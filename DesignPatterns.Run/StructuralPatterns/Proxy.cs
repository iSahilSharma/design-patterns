using System;

namespace DesignPatterns.StructuralPatterns.Proxy
{
    // Step 1: Define a common interface for the RealVideo and VideoProxy
    public interface IVideo
    {
        void Play();
    }

    // Step 2: Create the RealVideo class representing the actual video content
    public class RealVideo : IVideo
    {
        private string videoUrl;

        public RealVideo(string url)
        {
            videoUrl = url;
            LoadVideoFromUrl();
        }

        private void LoadVideoFromUrl()
        {
            Console.WriteLine($"Loading video from {videoUrl}");
            // Simulate loading video data from the URL
        }

        public void Play()
        {
            Console.WriteLine($"Playing video from {videoUrl}");
            // Perform the actual video playback
        }
    }

    // Step 3: Create the VideoProxy class as a proxy for RealVideo
    public class VideoProxy : IVideo
    {
        private RealVideo realVideo;
        private string videoUrl;

        public VideoProxy(string url)
        {
            videoUrl = url;
        }

        public void Play()
        {
            // Lazy load the real video when Play is called for the first time
            if (realVideo == null)
            {
                realVideo = new RealVideo(videoUrl);
            }

            realVideo.Play();
        }
    }

    // Step 4: Client code that uses the proxy and real video
    class Program
    {
        static void Main()
        {
            // Use the VideoProxy to play a video
            IVideo video = new VideoProxy("https://example.com/video.mp4");

            // Video is loaded and played only when Play is called
            Console.WriteLine("User clicks Play button...");
            video.Play();

            // Subsequent plays do not reload the video
            Console.WriteLine("User clicks Play button again...");
            video.Play();
        }
    }
}