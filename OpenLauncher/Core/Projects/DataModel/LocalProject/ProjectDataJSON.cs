using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    public class ProjectDataJSON
    {
        private string _imageURL;
        public string ImageUrl
        {
            get
            {
                return _imageURL;
            }
            set
            {
                _imageURL = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _homeURL;
        public string HomeURL
        {
            get
            {
                return _homeURL;
            }
            set
            {
                _homeURL = value;
            }
        }

        
        private Bitmap _displayImage;
        [JsonIgnore]
        public Bitmap DisplayImage => _displayImage;

        [JsonIgnore]
        private Uri _webURL;
        public Uri WebURL => _webURL;

        public ProjectDataJSON()
        {
            
        }

        public void CreateEnrichedContent()
        {
            DownloadImage();
            CreateURL();
        }

        public void DownloadImage()
        {
            WebRequest request = WebRequest.Create(ImageUrl);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            _displayImage = new Bitmap(responseStream);
        }

        public void CreateURL()
        {
            Uri.TryCreate(_homeURL, UriKind.Absolute, out _webURL);
        }
    }
}
