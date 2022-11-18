using System;
using System.Collections.Generic;
using System.Text;

namespace FlareApiTest.Models
{
    public class FavouriteGetResponseModel
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string image_id { get; set; }
        public string sub_id { get; set; }
        public DateTime created_at { get; set; }
        public Image image { get; set; }
        public class Image
        {
        }

    }
}
