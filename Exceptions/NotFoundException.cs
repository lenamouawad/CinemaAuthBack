using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException() : base()
        {

        }
        public NotFoundException(string message) : base()
        {

        }
    }
}
