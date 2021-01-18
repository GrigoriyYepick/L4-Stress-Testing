using System;

namespace StressTesting.UI.DataModel
{ 
    public sealed class MediaData
    {
        public int Id { get; set; }

        public Guid MediaKey { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
