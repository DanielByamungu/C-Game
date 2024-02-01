﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeGame
{
    public class ScoreManager
    {
       
        private static string fileName = "scores.xml";
        public List<Score> HighScores { get; private set; }
        public List<Score> Scores { get; private set; }

        public ScoreManager(List<Score> scores)
        {
            Scores = scores;
            UpdateHighscores();
        }

        private void UpdateHighscores()
        {
            HighScores = Scores.Take(5).ToList();
        }

        public ScoreManager(): this(new List<Score>())
        {
                
        }
        public void Add(Score score)
        {
            Scores.Add(score);
            Scores = Scores.OrderByDescending(c => c.Value).ToList();
            UpdateHighscores();
        }

        public static ScoreManager Load()
        {
            if (!File.Exists(fileName))
                return new ScoreManager();

            using(var reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                var serilizer = new XmlSerializer(typeof(List<Score>));
                var scores = (List < Score >)serilizer.Deserialize(reader);
                return new ScoreManager(scores);

            }
        }
        public static void Save(ScoreManager scoreManager)
        {
            using(var writer = new StreamWriter(new FileStream(fileName, FileMode.Create)))
            {
                var serilizer = new XmlSerializer(typeof(List<Score>));
                serilizer.Serialize(writer, scoreManager.Scores);
            }
        }
    }
}
