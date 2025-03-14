using LearningProject.Context;
using LearningProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LearningProject.Steps
{
    [Binding]
    internal class HomeSteps
    {
        private readonly UserContext _userContext;
        private LoginPage _Loginpage { get; set; }

        private DataContext DataContext;

        private HomePage _Homepage { get; set; }

        private RegistrationPage _RegistrationPage { get; set; }

        public HomeSteps(LoginPage loginPage, DataContext dataContext, HomePage homePage, RegistrationPage registrationPage, UserContext userContext)
        {
            _Loginpage = loginPage;
            DataContext = dataContext;
            _Homepage = homePage;
            _RegistrationPage = registrationPage;
            _userContext = userContext;
        }
    }
}
