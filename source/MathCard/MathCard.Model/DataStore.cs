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

        private static readonly ILog Log = LogManager.GetLogger(typeof (DataStore));

        #endregion

        #region [ Static Fields ]

        public static DataStore Instance = new DataStore();

        #endregion

        #region [ Constructors ]

        private DataStore()
        {
        }

        #endregion

        #region [ Properties ]

        public IList<SimpleAdditionCard> Flashcards { get; set; }

        #endregion

        #region [ Public Methods ]

        public void Load()
        {
            Load("DataStore.json.txt");
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
                Instance = JsonConvert.DeserializeObject<DataStore>(jsonText);
            }
            catch (JsonReaderException readerEx)
            {
                Instance = GetBlankInstance();
                Log.ErrorFormat("Unable to read data from file '{0}'", filename);
                throw new InvalidOperationException("Unable to load request file", readerEx);
            }
        }

        public void Save()
        {
            Save("DataStore.json.txt");
        }

        public void Save(string filename)
        {
            using (var sw = new StreamWriter(filename))
            {
                sw.WriteLine(
                    JsonConvert.SerializeObject(this, Formatting.Indented));
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