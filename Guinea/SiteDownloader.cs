using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Guinea
{
    class SiteDownloader
    {
        public static void getter()
        {
            IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://apip.gov.gn/?q=content/annonces-l%C3%A9gales");
            Regex RCCM = new Regex("\\d{3}[.]\\d{3}[A-Z]|\\d{6}[A-Z]");
            Regex Date = new Regex("\\d{2}[/]\\d{2}[/]\\d{4}|\\d{1,2}\\s\\w{3,10}[,]\\s\\d{4}");

            List<string> output = new List<string>();

            try
            {
                int iter = 2;
                string title = "Go to page ";
                while (true)
                {
                    ReadOnlyCollection<IWebElement> list = Browser.FindElements(By.ClassName("views-field-title"));
                    ReadOnlyCollection<IWebElement> listDates = Browser.FindElements(By.ClassName("views-field-body-1"));

                    for (int i = 0; i < list.Count; i++)
                    {
                        string combine = "";
                        string date = listDates[i].Text.ToString();
                        combine += list[i].Text.ToString() + "|";
                        Match match = RCCM.Match(date);
                        string tmp = match.Value.ToString();
                        combine += tmp + "|";
                        match = Date.Match(date);
                        tmp = match.Value.ToString();
                        combine += tmp;
                        output.Add(combine);
                    }

                    string tempTitle = title + iter.ToString();

                    Browser.FindElement(By.XPath("//button[starts-with(@title, " + tempTitle + ")]")).Click();

                }

            }
            catch
            {
                MessageBox.Show("something gone wrong!!!");
            }


        }
    }
}
