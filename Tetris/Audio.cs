using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Tetris
{
    class Audio
    {
        public enum Wav { start, theme, contact, goodJob, fallingDown, gameOver, youWon };

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public static void Effect(Wav sound)
        {
            switch (sound)
            {
                case Wav.fallingDown:
                    mciSendString(@"open Sound/FallingDown.wav type waveaudio alias fallingdown", null, 0, IntPtr.Zero);
                    mciSendString(@"play fallingdown", null, 0, IntPtr.Zero);
                    Thread.Sleep(250);
                    mciSendString(@"stop fallingdown", null, 0, IntPtr.Zero);
                    mciSendString(@"close fallingdown", null, 0, IntPtr.Zero);
                    break;

                case Wav.goodJob:
                    mciSendString(@"open Sound/GoodJob.wav type waveaudio alias goodjob", null, 0, IntPtr.Zero);
                    mciSendString(@"play goodjob", null, 0, IntPtr.Zero);
                    Thread.Sleep(400);
                    mciSendString(@"stop goodjob", null, 0, IntPtr.Zero);
                    mciSendString(@"close goodjob", null, 0, IntPtr.Zero);
                    break;

                case Wav.contact:
                    mciSendString(@"open Sound/Contact.wav type waveaudio alias contact", null, 0, IntPtr.Zero);
                    mciSendString(@"play contact", null, 0, IntPtr.Zero);
                    Thread.Sleep(250);
                    mciSendString(@"stop contact", null, 0, IntPtr.Zero);
                    mciSendString(@"close contact", null, 0, IntPtr.Zero);
                    break;
            }
        }

        public static void Music(Wav song)
        {
            SoundPlayer theme = new SoundPlayer("Sound/ShantrisTheme.wav");
            SoundPlayer start = new SoundPlayer("Sound/Start.wav");
            SoundPlayer gameOver = new SoundPlayer("Sound/GameOver.wav");
            SoundPlayer youWon = new SoundPlayer("Sound/YouWon.wav");

            switch (song)
            {
                case Wav.start:
                    start.PlayLooping();
                    break;

                case Wav.theme:
                    theme.PlayLooping();
                    break;

                case Wav.gameOver:
                    gameOver.Play();
                    break;

                case Wav.youWon:
                    youWon.Play();
                    break;
            }
        }
    }
}
