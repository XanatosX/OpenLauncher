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
    /// <summary>
    /// This is a data model for the project data. This is what is getting shown to the left in the main window
    /// </summary>
    public class ProjectDataJson
    {
        private string _guid;
        public string Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

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
        public string HomeUrl
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

        
        private Uri _webUrl;

        [JsonIgnore]
        public Uri WebUrl => _webUrl;

        /// <summary>
        /// This will create the enriched content. Filling up the WebURL and the DisplayImage
        /// </summary>
        public void CreateEnrichedContent()
        {
            DownloadImage();
            CreateUrl();
        }

        /// <summary>
        /// This will download the image from the path entered in den ImageURL
        /// </summary>
        public void DownloadImage()
        {
            WebRequest request = WebRequest.Create(ImageUrl);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                return;
            }

            Stream responseStream = response.GetResponseStream();
            _displayImage = new Bitmap(responseStream);
        }

        /// <summary>
        /// This will check the _homeURL and will create a Uri out of it
        /// </summary>
        public void CreateUrl()
        {
            Uri.TryCreate(_homeURL, UriKind.Absolute, out _webUrl);
        }
    }
}
