using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bug_Tracking_Application
{
    class LiveRepo
    {        
        public LiveRepo() {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://github.com/login";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("login_field")).SendKeys("luck_sunilthapa@yahoo.com");
            driver.FindElement(By.Id("password")).SendKeys("Sunil1995");
            driver.FindElement(By.Name("commit")).Click();
            driver.FindElement(By.XPath("//*[@id='dashboard']/div[1]/div[1]/div[2]/ul/li/div/a/span[2]")).Click();
        }
        

        
    }
}
