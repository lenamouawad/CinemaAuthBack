using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Config
{
    public class CinemaApiDatabaseSettings : ICinemaApiDatabaseSettings
    {
        public string MovieCollectionName { get; set; }
        public string RoomCollectionName { get; set; }
        public string CinemaCollectionName { get; set; }
        public string ScreeningCollectionName { get; set; }
        public string ReviewCollectionName { get; set; }
        public string LoginCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICinemaApiDatabaseSettings
    {
        public string MovieCollectionName { get; set; }
        public string RoomCollectionName { get; set; }
        public string CinemaCollectionName { get; set; }
        public string ScreeningCollectionName { get; set; }
        public string ReviewCollectionName { get; set; }
        public string LoginCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
