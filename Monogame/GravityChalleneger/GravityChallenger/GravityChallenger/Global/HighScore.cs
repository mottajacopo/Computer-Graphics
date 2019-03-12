using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GravityChallenger.Global
{
    public class HighScore
    {
        // STATIC FIELDS
        private static string fileName = "highscore";
        private List<int> highScore = new List<int>();

        // STATIC METHODS
        public static int GetHighScore()
        {
            int score = 0;

            try
            {
                var store = IsolatedStorageFile.GetUserStoreForApplication();

                if (store.FileExists(fileName))
                {
                    var fs = store.OpenFile(fileName, FileMode.Open);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        score = Convert.ToInt16(sr.ReadLine());
                    }
                }
                else
                {
                    var fs = store.CreateFile(fileName);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write("0");
                    }
                    score = 0;
                }
            }
            catch (EndOfStreamException)
            {
                return 0;
            }

            return score;
        }

        public static void SetHighScore(int score)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();

            if (store.FileExists(fileName))
            {
                var fs = store.OpenFile(fileName, FileMode.Open);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(score);
                }
            }

        }
    }
}