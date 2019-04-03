using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SeleniumSayisal
{
    class EntriyPoint
    {
        static void Main(string[] args)
        {
          
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.mpi.gov.tr/sonuclar/_cs_sayisal.php");
            IWebElement date = driver.FindElement(By.Id("sayisal-tarihList"));
            ReadOnlyCollection<IWebElement> tarihler = date.FindElements(By.TagName("option"));

            foreach (var item in tarihler)
            {
                string cekilisTarihi = item.GetAttribute("value");
                item.Click();
                Thread.Sleep(1000);
                string cekilisHaftasi = driver.FindElement(By.Id("sayisal-hafta")).Text;
                IWebElement numaraList = driver.FindElement(By.Id("sayisal-numaralar"));
                string il_ilce = driver.FindElement(By.Id("sayisal-buyukIkramiyeKazananIl")).Text;
                string kazananPara = driver.FindElement(By.Id("sayisal-bilenkisikisibasidusenikramiye-6_BILEN")).Text;

                if (il_ilce.Length > 0)
                {

                    Console.WriteLine(cekilisTarihi + " " + cekilisHaftasi + " " + numaraList.Text + " " + il_ilce + " " + kazananPara);
                }
                else
                {
                    string bilenKisi = driver.FindElement(By.Id("sayisal-bilenkisisayisi-6_BILEN")).Text;

                    if (bilenKisi.Contains("Devir"))
                    {
                        Console.WriteLine(cekilisTarihi + " " + cekilisHaftasi + " " + numaraList.Text + " " + "Devir");
                    }
                }

                //foreach (var numara in numaraList.FindElements(By.TagName("li")))
                //{
                //     string[] nmr =  numara.Text.Split('-');

                //}
                }
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
