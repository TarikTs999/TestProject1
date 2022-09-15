using OpenQA.Selenium;


namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _loginInputButton = By.XPath("//input[@name='login']");
        private readonly By _passInputButton = By.XPath("//input[@type='password']");
        private readonly By _goInputButton = By.XPath("//input[@value='”‚≥ÈÚË']");
        private readonly By _newletterButton = By.XPath("//html/body/div[2]/div[5]/ul/li[2]/a");
        private readonly By _toButton = By.XPath("//textarea[@name='to']");
        private readonly By _toThemeButton = By.XPath("//input[@name='subject']");
        private readonly By _textPole = By.XPath("//textarea[@id='text']");
        private readonly By _sendLetterButton = By.XPath("//input[@type='submit']");
        private readonly By _userLogin = By.XPath("//span[@class='user_name']");

        private const string _login = "TsTa13@ua.fm";
        private const string _password = "TsTa1313";
        private const string _expectedLogin = "Taras";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.i.ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var loginIn = driver.FindElement(_loginInputButton);
            loginIn.SendKeys(_login);

            var passIn = driver.FindElement(_passInputButton);
            passIn.SendKeys(_password);

            var goIn = driver.FindElement(_goInputButton);
            goIn.Click();

            Thread.Sleep(1000);

            var newletterIn = driver.FindElement(_newletterButton);
            newletterIn.Click();

            var toButton = driver.FindElement(_toButton);
            toButton.SendKeys("TsTa13@i.ua");

            var toThemeButton = driver.FindElement(_toThemeButton);
            toThemeButton.SendKeys("Hi!");

            var text = driver.FindElement(_textPole);
            text.SendKeys("Hello World!");

            var send = driver.FindElement(_sendLetterButton);
            send.Click();

            

            var actualLogin = driver.FindElement(_userLogin).Text;

            Assert.That(actualLogin, Is.EqualTo(_expectedLogin), "login is invalid or Enter was not complieted");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}