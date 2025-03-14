using LearningProject.Context;
using LearningProject.Pages;
using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LearningProject.Steps


{

    class Credentials
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    [Binding]

   
    public class StepDefenitions
    {
        private readonly UserContext _userContext;
        private LoginPage _Loginpage { get; set; }

        private DataContext DataContext;

        private HomePage _Homepage { get; set; }

        public StepDefenitions(LoginPage loginPage, DataContext dataContext, HomePage homePage, UserContext userContext)
        {
            _Loginpage = loginPage;
            DataContext = dataContext;
            _Homepage = homePage;
            _userContext = userContext;
        }


        [Then(@"I close the application")]
        public void ThenICloseTheApplication()
        {
            _Loginpage.CloseApplication();
        }

        [When(@"I open the buggy application home page")]
        [Then(@"I open the buggy application home page")]
        [Given(@"I open the buggy application home page")]
        public void GivenIOpenTheBuggyApplication()
        {
            _Loginpage.NavigatetoBuggyHome();
            _Loginpage.Waitfor5seconds();
        }


        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            _Loginpage.clickLoginButton();
        }

        [Then(@"I Validate error message for invalid login")]
        public void ThenIValidateErrorMessageForInvalidLogin()
        {
            string expectedvalidationmessage = "Invalid username/password";
            string actualvalidationmessage = _Loginpage.ValidationMessageforLogin();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "validation message not found or doesnt match");
        }


        [When(@"I fill in login Information")]
        public void WhenIFillInLoginInformation(Table table)
        {

            foreach (var item in table.Rows)

            {
                string login = item.GetString("login");
                string password = item.GetString("password");
                if (_userContext.GeneratedUsername != null && _userContext.GeneratedUsername != string.Empty)
                {
                    _Loginpage.SetUsername(_userContext.GeneratedUsername);
                    _Loginpage.Waitfor2seconds();
                }
                else 
                { 
                    _Loginpage.SetUsername(login);
                    _Loginpage.Waitfor2seconds();
                }

                if (password != null && password != string.Empty)
                {
                    _Loginpage.SetPassword(password);
                    _Loginpage.Waitfor2seconds();
                }
               


            }
        }

        [When(@"I fill in login Information from the list")]
        public void WhenIFillInLoginInformationFromTheList()
       {
            List<Credentials> credentialsList = new List<Credentials>();
           credentialsList.Add(new Credentials { Login = "johnderek", Password = "Specialpassword_2" });
           credentialsList.Add(new Credentials { Login = "johnderek2", Password = "Specialpassword_1" });
            credentialsList.Add(new Credentials { Login = "johnderek3", Password = "Specialpassword_2" });
           foreach (var credentials in credentialsList)
            {
                string login = credentials.Login;
               string password = credentials.Password;
                _Loginpage.clearLoginField();
                _Loginpage.clearPasswordField();
                _Loginpage.SetUsername(login);
               _Loginpage.SetPassword(password);
                _Loginpage.clickLoginButton();


            }
        }

      

        [Then(@"Home screen is opened")]
        public void ThenHomeScreenIsOpened()
        {
            string expectedlabel = "Logout";
            string actuallabel = _Homepage.LogouttextVisible();
            Assert.AreEqual(expectedlabel, actuallabel, "Home screen is opened");
        }

        [Then(@"I click Logout button")]
        public void ThenIClickLogoutButton()
        {
            _Homepage.clickLogoutButton();
        }


        [Then(@"The buggy application home page with Login button is opened")]
        public void ThenTheBuggyApplicationHomePageWithLoginButtonIsOpened()
        {
            string expectedlabel = "Login";
            string actuallabel = _Homepage.LoginButtontextVisible();
            Assert.AreEqual(expectedlabel, actuallabel, "Home screen with Login button is opened");
        }



    }
}
