using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBiz_Business.Exceptions
{
    public class ImageRequireException : Exception
    {
        public string PropertyName { get; set; }
        public ImageRequireException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
