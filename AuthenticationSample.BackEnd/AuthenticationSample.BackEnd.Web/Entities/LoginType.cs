using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.Web.Entities
{
    public enum LoginType
    {
        MobileNumber,
        Email
    }
}