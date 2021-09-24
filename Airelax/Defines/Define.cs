using System.Collections.Generic;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Defines
{
    public struct Define
    {
        public struct Database
        {
            public const string LOCAL_CONNECT_STRING = "LocalConnect";
            public const string ENTITY_FRAMEWORK = "Airelax.EntityFramework";
            public const string DB_CONNECT_STRING = "DBConnectString";
        }

        public struct Authorization
        {
            public const string JWT_COOKIE_KEY = "yee_mother_fucker";
        }
        
       
    }
}