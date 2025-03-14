using LearningProject.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Pages
{
    public class HomePage: BasePage
    {
protected new IWebDriver Driver { get; set; }
        public HomePage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }

        //Home page fields

        private readonly By profileNameField = By.XPath("//li[@class='nav-item']//span[1]");
        private readonly By profileLabel = By.XPath("//a[contains(text(),'Profile')]");
        private readonly By logoutButton = By.XPath("//a[contains(text(),'Logout')]");
        private readonly By login = By.XPath("//button[text()='Login']");
        


        public string LogouttextVisible()
        {
            return GetElementText(logoutButton);
            
        }

        public void clickLogoutButton()
        {
            ClickOnElement(logoutButton);
        }

        public string LoginButtontextVisible()
        {
            return GetElementText(login);

        }
    }
}
