using System.Data.Entity.Migrations;
using VideoCollection.Data;

namespace VideoCollection.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(VideoCollectionDataContext context) {

            context.SaveChanges();
        }
    }
}