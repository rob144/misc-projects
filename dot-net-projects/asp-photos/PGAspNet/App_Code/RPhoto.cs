using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGAspNet
{
    public class RPhoto
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public string FileRef { get; set; }
        public string Description { get; set; }

        public RPhoto()
        {
            ID = -1;
            Title = "";
            FileRef = "";
            Description = "";
        }

        public RPhoto(int id, string title, string fileRef, string description)
        {
            ID = id;
            Title = title;
            FileRef = fileRef;
            Description = description;
        }

    }
}