using System;
using System.Collections.Generic;
using System.Text;

namespace AkademiPlusMicroServiceProject.Shared.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserID { get; }
    }
}
