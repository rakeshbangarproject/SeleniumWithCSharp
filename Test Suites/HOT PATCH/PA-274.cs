using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.HOT_PATCH
{
    public class OutputsFileInformation : BaseClass
    {
        private readonly List<string> assemblyData = new();
        public string[] elementNameOfSheathingDrawing = { "Roof-1", "Roof-2", "EXT_1", "EXT_2", "EXT_3", "EXT_4" };
        public string folderPath = FolderPath.Download();

        [Test]
        public void CheckOutputsFileData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Fix issues with hidden materials");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("OutputsFile");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickDrawingButton();

            foreach (var clickAssembly in elementNameOfSheathingDrawing)
            {
                ClickSheathingDrawingElement(clickAssembly);
                ProcessAssemblySheathingData();
            }

            DefaultJobElement.DownloadFileFromOutputFrame("Assembly Drawings");
            string pdfFileName = CommonMethod.GetThePdfFileName("OutputsFile");
            string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
            FolderPath.WaitForFileDownload(pdfFilePath, 60);

            string getThePDFFileData = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);


            int status = 0;
            var count = assemblyData.Count;

            foreach( var assembly in assemblyData)
            {
                if(assembly.Contains(getThePDFFileData))
                {
                    status++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (assemblyData[i] != null && getThePDFFileData.Equals(assemblyData[i]))
                {
                    status++;
                }
            }
        }

        private void ClickSheathingDrawingElement(string sheathingElement)
        {
            switch (sheathingElement)
            {
                case "Roof-1":
                    DefaultJobElement.ClickAssemblyDrawingROOF_1();
                    break;
                case "Roof-2":
                    DefaultJobElement.ClickAssemblyDrawingROOF_2();
                    break;
                case "EXT_1":
                    DefaultJobElement.ClickAssemblyDrawingEXT_1();
                    break;
                case "EXT_2":
                    DefaultJobElement.ClickAssemblyDrawingEXT_2();
                    break;
                case "EXT_3":
                    DefaultJobElement.ClickAssemblyDrawingEXT_3();
                    break;
                case "EXT_4":
                    DefaultJobElement.ClickAssemblyDrawingEXT_4();
                    break;
                case "INT_1":
                    DefaultJobElement.ClickAssemblyDrawingINT_1();
                    break;
                default:
                    Console.WriteLine($"{sheathingElement} is not shown in the drawing");
                    break;
            }
        }

        private void AddAssemblySheathingData()
        {
            CommonMethod.Wait(1);
            IList<IWebElement> list = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and @line]"));

            foreach (IWebElement element in list)
            {
                string getLineNumber = element.GetAttribute("line");

                if (getLineNumber != null && !getLineNumber.Equals("top") && !getLineNumber.Equals("bottom"))
                {
                    string result = string.Join(" ", element.FindElements(By.XPath(".//td")).Select(td => td.Text.Trim()));
                    assemblyData.Add(result + "\n");
                    Console.WriteLine(result + "\n");
                }
            }
        }

        private void ProcessAssemblySheathingData()
        {
            CommonMethod.Wait(1);
            IList<IWebElement> list = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and @line]"));

            foreach (IWebElement element in list)
            {
                string getLineNumber = element.GetAttribute("line");

                if (getLineNumber != null && !getLineNumber.Equals("top") && !getLineNumber.Equals("bottom"))
                {
                    IList<IWebElement> tdElements = element.FindElements(By.XPath(".//td"));

                    List<string> resultList = new List<string>();

                    for (int i = 0; i < tdElements.Count; i++)
                    {
                        if (i != 2)
                        {
                            string text = tdElements[i].Text.Trim();
                            if (!string.IsNullOrEmpty(text))
                            {
                                resultList.Add(text);
                            }
                        }
                    }

                    string result = string.Join(" ", resultList);

                    assemblyData.Add(result);
                    Console.WriteLine(result + "\n");
                }
            }
        }
    }
}
