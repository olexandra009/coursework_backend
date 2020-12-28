using System;
using System.Collections.Generic;
using System.Text;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Providers
{
    public interface IDbProvider
    {
        #region All Info
        List<User> GetAllUsers();
        List<Petition> GetAllPetitions();
        List<Application> GetAllApplications();
        List<Event> GetAllEvents();
        List<News> GetAllNews();
        List<Organization> GetAllOrganizations();
        #endregion

        #region Petition Filter
        List<Petition> GetSuccessfulPetitions(); //return close and open petition that vote count are greater than minimum
        List<Petition> GetUnsuccessfulPetitions(); //return close petition that vote count are less than minimum
        List<Petition> GetClosePetitions(); 
        List<Petition> GetOpenPetitions();
        #endregion

    }
}
