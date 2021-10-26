using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Resgistration.Tests
{
    public class RegisterationViewModel
    {
        public RegisterationViewModel()
        {

        }

        public RegisterationViewModel(string username, string email, string password)
        {
            this.UserName = username;
            this.Email = email;
            this.Password = password;
        }
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }


    public class UserAuthentication
    {
        public UserAuthentication()
        {
        }

        public bool RegisterUser(RegisterationViewModel userVm, List<RegisterationViewModel> UsersList)
        {
            var userExist = UsersList.Find(ss => ss.UserName == userVm.UserName || ss.Email == userVm.Email);
            if (userExist == null)
            {
                UsersList.Add(userVm);
                return true;
            }
            else
            {
                Console.WriteLine("Username or Email already exists");
                return false;
            }
        }
    }


    public class RegisterationTests
    {
        private readonly List<RegisterationViewModel> UsersList;
        public RegisterationTests()
        {
            this.UsersList = new()
            {
                new RegisterationViewModel() { UserName = "Ahmed123", Email = "Ahmed123@test", Password = "Ahmed123" },
                new RegisterationViewModel() { UserName = "Hesham123", Email = "Hesham123@test", Password = "Hesham123" },
                new RegisterationViewModel() { UserName = "Salem123", Email = "Salem123@test", Password = "Salem123" },
            };
        }

        [Theory]
        [InlineData("Ahmed123", "qwer123", "123", false)]
        [InlineData("Ayman123", "Hesham123@test", "123", false)]
        [InlineData("Ayman123", "Ayman123@test", "123", true)]
        public void RegisterUser_InsertsNewUsertoPersistence(string Username, string Email, string Password, bool expected)
        {
            //Arrange
            var sut = new UserAuthentication();
            var userVm = new RegisterationViewModel(Username, Email, Password);

            //Act
            var result = sut.RegisterUser(userVm, this.UsersList);
            //Assert
            result.Should().Be(expected);
        }





    }


}
