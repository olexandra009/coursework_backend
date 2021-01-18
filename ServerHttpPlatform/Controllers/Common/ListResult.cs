using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common
{
    public class ListResult<T>
    {
        public List<T> Result { get; set; }
        public int Total { get; set; }
    }
}
