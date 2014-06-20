using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Newtonsoft.Json;

namespace MathCard.Model
{
    public class DataStore
    {
        #region [ Logging ]

        private static readonly ILog Log = LogManager.GetLogger(typeof(DataStore));

        #endregion

        #region [ Static Fields ]

        public static string DefaultFilename = "DataStore.json.txt";
        public static DataStore Instance = new DataStore();

        #endregion

        #region [ Constructors ]

        private DataStore()
        {
            Flashcards = new List<IFlashCard>();
        }

        #endregion

        #region [ Properties ]

        public IEnumerable<IFlashCard> Flashcards { get; set; }

        #endregion

        #region [ Public Methods ]

        public void Load()
        {
            Load(DefaultFilename);
        }

        public void Load(string filename)
        {
            string jsonText;
            using (var sr = new StreamReader(filename))
            {
                jsonText = sr.ReadToEnd();
            }

            try
            {
                var options = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                Instance = JsonConvert.DeserializeObject<DataStore>(jsonText, options);
            }
            catch (JsonReaderException readerEx)
            {
                Instance = GetBlankInstance();
                Log.ErrorFormat("Unable to read data from file '{0}'", filename);
                throw new InvalidOperationException("Unable to load request file", readerEx);
            }
        }

        public static void Reset()
        {
            Instance = new DataStore();
        }

        public void Save()
        {
            Save(DefaultFilename);
        }

        public void Save(string filename)
        {
            using (var sw = new StreamWriter(filename))
            {
                var options = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                sw.WriteLine(
                    JsonConvert.SerializeObject(this, options));
            }
        }

        #endregion

        #region [ Methods ]

        private static DataStore GetBlankInstance()
        {
            return new DataStore();
        }

        #endregion
    }
}