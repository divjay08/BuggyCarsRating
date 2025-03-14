using LearningProject.Context;
using LearningProject.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
    public class UserContext
    {
        public string GeneratedUsername { get; set; }
        public bool IsLoggedIn { get; set; }
    }

    


    [Binding]
    public class RegistrationSteps
    {
        private readonly UserContext _userContext;
        private LoginPage _Loginpage { get; set; }

        private DataContext DataContext;

        private HomePage _Homepage { get; set; }

        private RegistrationPage _RegistrationPage { get; set; }

        private string inputField;



        public RegistrationSteps(LoginPage loginPage, DataContext dataContext, HomePage homePage, RegistrationPage registrationPage, UserContext userContext)
        {
            _Loginpage = loginPage;
            DataContext = dataContext;
            _Homepage = homePage;
            _RegistrationPage = registrationPage;
            _userContext = userContext;
        }

        [When(@"I click Register button")]
        public void WhenIClickRegisterButton()
        {
            _Loginpage.Waitfor5seconds();
            _Loginpage.clickRegisterButton();
        }



   

        [Then(@"I validate Register with Buggy Cars Rating label")]
        public void ThenIValidateRegisterWithBuggyCarsRatingLabel()
        {
            string expectedvalidationmessage = "Register with Buggy Cars Rating";
            string actualvalidationmessage = _RegistrationPage.RegistrationScreenHeader();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Registration screen shows with header");
        }

        [When(@"click on Login Field")]
        public void GivenClickOnLoginField()
        {
            _Loginpage.Waitfor5seconds();
            _RegistrationPage.clickLoginField();
        }

        [Then(@"clear data if available")]
        public void ThenClearDataIfAvailable()
        {

            _RegistrationPage.clearLoginField();
        }

        [When(@"Enter data in registration fields")]
        public void WhenEnterDataInRegistrationFields(Table table)
        {
            foreach (var item in table.Rows)

            {
                DateTime currentTime = DateTime.Now;
                string login = item.GetString("login");
                string loginWithTime = login + "_" + currentTime.ToString("yyyyMMddHHmmss");
                string firstname = item.GetString("firstname");
                string lastname = item.GetString("lastname");
                string password = item.GetString("password");
                string confirmpassword = item.GetString("confirmpassword");

                if (loginWithTime != null && loginWithTime != string.Empty)
                {
                    _RegistrationPage.enterDataInLogin(loginWithTime);
                   // _RegistrationPage.EnterDataInRegistrationFields(loginWithTime);
                    _Loginpage.Waitfor2seconds();
                    _userContext.GeneratedUsername = loginWithTime;
                }
                if (firstname != null && firstname != string.Empty)
                {
                    _RegistrationPage.enterDataInFirstName(firstname);
                    _Loginpage.Waitfor2seconds();
                }
                if (lastname != null && lastname != string.Empty)
                {
                    _RegistrationPage.enterDataInLastName(lastname);
                    _Loginpage.Waitfor2seconds();
                }
                if (password != null && password != string.Empty)
                {
                    _RegistrationPage.enterDataInPassword(password);
                    _Loginpage.Waitfor2seconds();
                }
                if (confirmpassword != null && confirmpassword != string.Empty)
                {
                    _RegistrationPage.enterDataInConfirmPassword(confirmpassword);
                    _Loginpage.Waitfor2seconds();
                }

            }
        }

            [Then(@"click on First Name field")]
            public void ThenClickOnFirstNameField()
            {
            _RegistrationPage.clickFirstNameField();
        }


            [Then(@"clear data in FN if available")]
        public void ThenClearDataInFNIfAvailable()
        {
            _RegistrationPage.clearFirstNameField();
        }


        
        [Then(@"click on Last Name field")]
        public void ThenClickOnLastNameField()
        {
            _RegistrationPage.clickLastNameField();
        }

        [Then(@"clear data in LN if available")]
        public void ThenClearDataInLNIfAvailable()
        {
            _RegistrationPage.clearLastNameField();
        }


       
        [Then(@"click on Password field")]
        public void ThenClickOnPasswordField()
        {
            _RegistrationPage.clickPasswordField();
        }

        [Then(@"clear data in Password if available")]
        public void ThenClearDataInPasswordIfAvailable()
        {
            _RegistrationPage.clearPasswordField();
        }


        
        [Then(@"click on Confirm Password field")]
        public void ThenClickOnConfirmPasswordField()
        {
            _RegistrationPage.clickConfirmPasswordField();
        }

        [Then(@"clear data in CP if available")]
        public void ThenClearDataInCPIfAvailable()
        {
            _RegistrationPage.clearConfirmPasswordField();
        }

        [When(@"I validate the warning message")]
        public void WhenIValidateTheWarningMessage()
        {
            string expectedlabel = "Passwords do not match";
            string actuallabel = _RegistrationPage.passwordMisMatchMessage();
            Assert.AreEqual(expectedlabel, actuallabel, "Warning message is matching with expected value");
        }



        [Then(@"I clicked Register button below the fields")]
        public void ThenIClickedRegisterButtonBelowTheFields()
        {
            _RegistrationPage.clickRegisterButton();
           
        }

        [Then(@"I validate registered login and password")]
        public void ThenIValidateRegisteredLoginAndPassword()
        {
            String newUserName=_RegistrationPage.getRegisterUsername();
            String newPassword = _RegistrationPage.getRegisterPassword();
           
        }


        [Then(@"I validate the success message")]
        public void ThenIValidateTheSuccessMessage()
        {
            string expectedvalidationmessage = "Registration is successful";
            string actualvalidationmessage = _RegistrationPage.registrationsuccessfulMessage();
            if (actualvalidationmessage == expectedvalidationmessage)
            {
                Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Registration is successful");
                
            }
            else
            {
                Assert.Fail("Unsuccessful Registration");
            }

        }

        [Then(@"I validate the message")]
        public void ThenIValidateTheMessage()
        {
            string expectedvalidationmessage = "InvalidParameter: 1 validation error(s) found. - minimum field size of 6, SignUpInput.Password.";
            string actualvalidationmessage = _RegistrationPage.registerFailMessage();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Registration Failed");
        }


        [Then(@"I validate the error message '([^']*)'")]
        public void ThenIValidateTheErrorMessage(string message)
        {
            string expectedvalidationmessage = message;
            string actualvalidationmessage = _RegistrationPage.registerFailMessage();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Message doesn't match");
        }


        [Then(@"I Validate password criteria errormessage")]
        public void ThenIValidatePasswordCriteriaErrormessage(Table table)
        {
            foreach (var item in table.Rows)
            {
                string expectedvalidationmessage = item.GetString("errormessage");
                string actualvalidationmessage = _RegistrationPage.registerFailMessage();
                Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Registration Failed");
            }
        }


        

        [Then(@"I click Cancel button")]
        public void ThenIClickCancelButton()
        {
            _RegistrationPage.clickCancelButton();
        }




        [When(@"I validate Register button")]
        public void WhenIValidateRegisterButton()
        {
            _RegistrationPage.registedButtonVisibility();
        }


        //[When(@"I enter a text with special characters ""([^""]*)"" in the text field")]
       // public void WhenIEnterATextWithSpecialCharactersInTheTextField(string specialcharacters)

       // {
         //   inputField = _RegistrationPage.enterDataInLogin(specialcharacters);
        //   inputField = _RegistrationPage.enterDataInFirstName(specialcharacters);
         //   inputField = _RegistrationPage.enterDataInLastName(specialcharacters);
         //   inputField = _RegistrationPage.enterDataInPassword(specialcharacters);
          //  inputField = _RegistrationPage.enterDataInConfirmPassword(specialcharacters);


       // }

       // [Then(@"the text field should only contain allowed special characters")]
       // public void ThenTheTextFieldShouldOnlyContainAllowedSpecialCharacters()
     //   {
        //    throw new PendingStepException();
      //  }

    }
}
