using System;
using System.Collections.Generic;
using System.Text;

namespace RedPaperEMS.Application.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string name, object key): base($"{name} is not found")
        {
            
        }

    }
}
