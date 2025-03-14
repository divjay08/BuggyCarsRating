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
    public class WorkflowSteps
    {
        private readonly UserContext _userContext;
        private LoginPage _Loginpage { get; set; }

        private DataContext DataContext;

        private HomePage _Homepage { get; set; }

        private RegistrationPage _RegistrationPage { get; set; }

        private WorkflowPage _WorkflowPage { get; set; }


        public WorkflowSteps(LoginPage loginPage, DataContext dataContext, HomePage homePage, RegistrationPage registrationPage, WorkflowPage workflowPage, UserContext userContext)
        {
            _Loginpage = loginPage;
            DataContext = dataContext;
            _Homepage = homePage;
            _RegistrationPage = registrationPage;
            _WorkflowPage = workflowPage;
            _userContext = userContext;
        }







    }
}

