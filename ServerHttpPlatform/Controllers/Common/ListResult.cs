using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common
{
    public class ListResult<T>
    {
        public List<T> Result;
        public int Total; 
    }
}
