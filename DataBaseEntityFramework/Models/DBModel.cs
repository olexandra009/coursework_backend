using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    //interface IDbModel
    //{
    //    int Id { get; }
    //}

    public abstract class DbModel<TKey>
    {
        public TKey Id { get;  }
    }
}
