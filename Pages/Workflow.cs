using LearningProject.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Pages
{
    public class WorkflowPage : BasePage
    {

        protected new IWebDriver Driver { get; }

        public WorkflowPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }
        


    }
}
