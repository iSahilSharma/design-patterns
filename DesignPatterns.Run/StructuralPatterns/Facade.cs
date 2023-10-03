using System;

namespace DesignPatterns.StructuralPatterns.Facade
{
    // Subsystem 1: AudioPlayer
    public class AudioPlayer
    {
        public void PlayAudio(string audioFile)
        {
            Console.WriteLine($"Playing audio: {audioFile}");
        }
    }

    // Subsystem 2: VideoPlayer
    public class VideoPlayer
    {
        public void PlayVideo(string videoFile)
        {
            Console.WriteLine($"Playing video: {videoFile}");
        }
    }

    // Subsystem 3: SubtitleService
    public class SubtitleService
    {
        public void LoadSubtitles(string subtitleFile)
        {
            Console.WriteLine($"Loading subtitles: {subtitleFile}");
        }
    }

    // Facade: MultimediaPlayerFacade
    public class MultimediaPlayerFacade
    {
        private AudioPlayer audioPlayer;
        private VideoPlayer videoPlayer;
        private SubtitleService subtitleService;

        public MultimediaPlayerFacade()
        {
            audioPlayer = new AudioPlayer();
            videoPlayer = new VideoPlayer();
            subtitleService = new SubtitleService();
        }

        public void PlayMovie(string videoFile, string audioFile, string subtitleFile)
        {
            Console.WriteLine("=== Starting Movie ===");
            videoPlayer.PlayVideo(videoFile);
            audioPlayer.PlayAudio(audioFile);
            subtitleService.LoadSubtitles(subtitleFile);
            Console.WriteLine("=== Movie Finished ===");
        }
    }

    public class TestFacadePattern
    {
        public void EntryPoint()
        {
            // Client code interacts with the MultimediaPlayerFacade
            MultimediaPlayerFacade player = new MultimediaPlayerFacade();

            // Playing a movie with the facade
            string videoFile = "movie.mp4";
            string audioFile = "sound.mp3";
            string subtitleFile = "subtitles.srt";

            player.PlayMovie(videoFile, audioFile, subtitleFile);
        }
    }
}