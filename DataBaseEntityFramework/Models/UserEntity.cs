using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class UserEntity : DbModel<int>
    {
        #region Properties

        public string FirstName { get; set; }
        public string SecondName { get;  set; }
        public string LastName { get;  set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        #region Authentification and authorization information

        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public bool EmailConfirm { get; set; }
        #endregion


        #region Foriegn key and principal entity 

        public OrganizationEntity UserOrganization { get; set; }
        public int? UserOrganizationId { get; set; }
        #endregion


        #region Dependent entities

        public List<NewsEntity> CreatedNews { get; set; }
        public List<EventEntity> CreatedEvents { get; set; }
        public List<ApplicationEntity> CreatedApplications { get; set; }
        public List<ApplicationEntity> AnswerApplications { get; set; }
        public List<PetitionEntity> CreatedPetitions { get; set; }
        public List<VotesEntity> VotedPetitions { get; set; }
        public EmailConfirmEntity EmailConfirmEntity { get; set; }
        #endregion

        #endregion

    }
}
