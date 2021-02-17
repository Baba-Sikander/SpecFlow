using SpecFlow.Pages;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    class LoginAndLogout
    {
        string Username = EnvironVariables.username;

        LoginPage loginPage = new LoginPage();


        [Given(@"I login to the Pegasus Application")]
        public void GivenILoginToThePegasusApplication()
        {
            loginPage.LoginToApplication(Username);
        }
    }
}
