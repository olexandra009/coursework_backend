﻿using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class User : IDbModel
    {
        #region Fields
        private Guid _guid;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private string _login;
        private string _password;
        private Organization _userOrganization;
        private Rights _userRights;
        private List<News> _createdNews;
        private List<Event> _createdEvents;
        private List<Application> _createdApplications;
        private List<Application> _answerApplications;
        private List<Petition> _createdPetitions;
        private List<Petition> _votedPetitions; //many to many

        #endregion

        #region Properties
        public Guid Id
        {
            get => _guid;
            private set => _guid = value;
        }

        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value;
        }

        public string SecondName
        {
            get=>_secondName;
            private set => _secondName = value;
        }

        public string LastName
        {
            get => _lastName ;
            private set => _lastName = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public string Login
        {
            get => _login;
            private set => _login = value;
        }

        public string Password
        {
            get => _password;
            private set => _password = value;
        }

        public Organization UserOrganization
        {
            get => _userOrganization;
            private set => _userOrganization = value;
        }

        public Rights UserRights
        {
            get => _userRights;
            private set => _userRights = value;
        }

        public List<News> CreatedNews
        {
            get => _createdNews;
            private set => _createdNews = value;
        }

        public List<Event> CreatedEvents
        {
            get => _createdEvents;
            private set => _createdEvents = value;
        }

        public List<Application> CreatedApplications
        {
            get => _createdApplications;
            private set => _createdApplications = value;
        }

        public List<Application> AnswerApplications
        {
            get => _answerApplications;
            private set => _answerApplications = value;
        }

        public List<Petition> CreatedPetitions
        {
            get => _createdPetitions;
            private set => _createdPetitions = value;
        }

        public List<Petition> VotedPetitions
        {
            get => _votedPetitions;
            private set => _votedPetitions = value;
        }

        #endregion



    }
}
