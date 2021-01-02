using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    //interface IDbModel
    //{
    //    int Id { get; }
    //}

    public abstract class DbModel<TKey>
    {
        TKey Id { get;  }
    }
}
