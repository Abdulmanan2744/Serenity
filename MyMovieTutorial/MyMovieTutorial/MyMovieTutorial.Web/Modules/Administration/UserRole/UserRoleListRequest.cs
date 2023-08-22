using Serenity.Services;

namespace MyMovieTutorial.Administration
{
    public class UserRoleListRequest : ServiceRequest
    {
        public int? UserID { get; set; }
    }
}