using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.BusinessLogic.Models
{
    public enum LoginType
    {
        MobileNumber,
        Email
    }
}