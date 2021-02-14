using OpenQA.Selenium;

namespace WebAdressbookTests
{
    class LoginAction
    {
        private IWebDriver driver;
        private string baseURL;

        public LoginAction (IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }
        public void Login(AccountData account)
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
