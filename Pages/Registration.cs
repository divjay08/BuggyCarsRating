using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningProject.Framework;
using OpenQA.Selenium.DevTools;

namespace LearningProject.Pages
{
    public class RegistrationPage : BasePage
    {
        protected new IWebDriver Driver { get; }
       

        public RegistrationPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }

        //Registration page fields

        private readonly By registerButton = By.XPath("//a[contains(text(),'Register')]");
        private readonly By registerLabel = By.XPath("//h2[text()='Register with Buggy Cars Rating']");
        private readonly By loginField = By.Id("username");
        private readonly By firstNameField = By.Id("firstName");
        private readonly By lastNameField = By.Id("lastName");
        private readonly By registerpasswordField = By.Id("password");
        private readonly By confirmPasswordField = By.Id("confirmPassword");
        private readonly By register = By.XPath("//button[@class='btn btn-default']");
        private readonly By cancel = By.XPath("//a[@role='button']");
        private readonly By message = By.XPath("//div[text()[normalize-space()='Registration is successful']]");
        private readonly By failmessage = By.XPath("//div[contains(@class,'result alert alert-danger')]");
        private readonly By passwordmismatchmessage = By.XPath("//div[text()[normalize-space()='Passwords do not match']]");
       

        public string RegistrationScreenHeader()
        {

            return GetElementText(registerLabel);
        }

        public void clickLoginField()
        {
            ClickOnElement(loginField);
        }
        public void clearLoginField()
        {
            ClearElement(loginField);
        }


        public void enterDataInLogin(string loginWithTime)
        {
            TypeOnElement(loginField, loginWithTime);
        }

        public void clickFirstNameField()
        {
            ClickOnElement(firstNameField);
        }
        public void clearFirstNameField()
        {
            ClearElement(firstNameField);
        }
        public void enterDataInFirstName(string firstname)
        {
            TypeOnElement(firstNameField, firstname);
        }

        public void clickLastNameField()
        {
            ClickOnElement(lastNameField);
        }
        public void clearLastNameField()
        {
            ClearElement(lastNameField);
        }
        public void enterDataInLastName(string lastname)
        {
            TypeOnElement(lastNameField, lastname);
        }

        public void clickPasswordField()
        {
            ClickOnElement(registerpasswordField);
        }
        public void clearPasswordField()
        {
            ClearElement(registerpasswordField);
        }
        public void enterDataInPassword(string password)
        {
            TypeOnElement(registerpasswordField, password);
        }

        public void clickConfirmPasswordField()
        {
            ClickOnElement(confirmPasswordField);
        }
        public void clearConfirmPasswordField()
        {
            ClearElement(confirmPasswordField);
        }
        public void enterDataInConfirmPassword(string confirmpassword)
        {
            TypeOnElement(confirmPasswordField, confirmpassword);
        }

        public void clickRegisterButton()
        {
            ClickOnElement(register);
        }

       public string getRegisterUsername()
        {
           return GetElementValue(loginField);
        }

        public string getRegisterPassword()
        {
            return GetElementValue(registerpasswordField);
        }

        public string registrationsuccessfulMessage()
        {
            return GetElementText(message);

        }
        public string passwordMisMatchMessage()
        {
            return GetElementText(passwordmismatchmessage);
        }

        public string registerFailMessage()
        {
            return GetElementText(failmessage);
        }

        public void registedButtonVisibility()
        {
            isElementDisabled(register);
        }

        public void clickCancelButton()
        {
            ClickOnElement(cancel);
        }
    }
}
