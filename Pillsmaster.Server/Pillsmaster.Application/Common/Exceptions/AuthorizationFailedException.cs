using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Application.Common.Exceptions
{
    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException() : base("Authorization failed! Wrong username or password.") { }
    }
}
