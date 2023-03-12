using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IndianStatesCensusAnalyzerTest
{
    [TestClass]
    public class IndianCensusTest
    {
        //Arrange
        CSVAdapterFactory factory = new CSVAdapterFactory();
        Dictionary<string, CensusDTO> dict = new Dictionary<string, CensusDTO>();

        string IndianPopulation = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\IndianPopulationData.csv";
        string FileIncorrect = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\IndianPopulatio.csv";
        string FileTypeWrong = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\IndianPopulationData.txt";
        string FileWithoutDelimeter = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\FileWithoutDelemter.csv";
        string WrongHeaders = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\WrongHeaderPopulationData.csv";
        string IndianStates = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\IndianStatesData.csv";
        string StatesFileIncorrect = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\Population.csv";
        string StateFileTypeWrong = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\IndianStatesData.txt";
        string StateDelemiter = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\StateFileDelemiter.csv";
        string StatesHeaderWrong = "E:\\Rahul's WorkSpace\\New VisualStudio\\IndianStatesCensusAnalyserProblem\\IndianStatesCensusAnalyserProblem\\CSV Data\\StateHeaderData.csv";

        //TC 1.1 check to ensure the records are matches 
        [TestMethod]
        [TestCategory("Indian Population")]
        public void Given_CSV_Should_Return_No_Of_Records()
        {
            //Act
            dict = factory.LoadCSVData(CensusAnalyzer.Country.INDIA,IndianPopulation,"States,Population,AreaInSqkm,DensityPerSqKm");
            //Assert
            Assert.AreEqual(28, dict.Count);
        }

        //TC 1.2 CSV File if incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian Population")]
        public void File_Incorrect_Return_Custom_Exception()
        {
            //Act
            var result = Assert.ThrowsException<CensusAnalyserException>(()=>factory.LoadCSVData(CensusAnalyzer.Country.INDIA, FileIncorrect, "States,Population,AreaInSqkm,DensityPerSqKm"));
            //Assert
            Assert.AreEqual("File Not Found", result.Message);
            Console.WriteLine("File Not Found");
        }

        //TC1.3 CSV File when correct but type incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian Population")]
        public void File_Correct_But_Type_Not_Correct_Return_Exception()
        {
            var res=Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, FileTypeWrong, "States,Population,AreaInSqkm,DensityPerSqKm"));
            Assert.AreEqual("Invalid file type", res.Message);
            Console.WriteLine("Invalid file type");
        }

        //TC1.4 CSV File when correct but delimiter incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian Population")]
        public void Files_Delimiter_Incorrect_Return_Custom_Exception()
        {
           var result1=Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, FileWithoutDelimeter, "States,Population,AreaInSqkm,DensityPerSqKm"));
            Assert.AreEqual("Files Contains wrong Delimiter", result1.Message);
            Console.WriteLine("Files Contains wrong Delimiter");
        }

        //TC1.5 CSV File when correct but csv header incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian Population")]
        public void File_Contain_Wrong_Header_Return_Cutom_Exception()
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, WrongHeaders, "States,Population,AreaInSqkm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header in Data", result.Message);
            Console.WriteLine("Incorrect header in Data");
        }

        //TC 2.1 check to ensure the records are matches 
        [TestMethod]
        [TestCategory("Indian States")]
        public void Given_File_Return_Records()
        {
            dict=factory.LoadCSVData(CensusAnalyzer.Country.INDIA,IndianStates,"SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, dict.Count);
        }

        //TC 2.2 CSV File if incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("IndianState")]
        public void Given_File_Not_Present_Return_Custom_Exception()
        {
            var result=Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA,StatesFileIncorrect,"SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual("File Not Found", result.Message);
            Console.WriteLine("File Not Found");
        }

        //TC 2.3  CSV File when correct but type incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian States")]
        public void File_Type_Incorrect_Return_Custom_Exception()
        {
            var result=Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, StateFileTypeWrong,"SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual("Invalid file type", result.Message);
            Console.WriteLine("Invalid file type");
        }

        //TC2.4 CSV File when correct but delimiter incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian States")]
        public void Files_Delemiter_Not_Correct_Return_Custom_Exception()
        {
           var result=Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, StateDelemiter,"SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual("Files Contains wrong Delimiter", result.Message);
            Console.WriteLine("Files Contains wrong Delimiter");
        }


        //TC 2.5 CSV File when correct but csv header incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Indian Population")]
        public void File_Contains_Incorrect_Headers_Return_Custom_Exception()
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCSVData(CensusAnalyzer.Country.INDIA, StatesHeaderWrong,"SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual("Incorrect header in Data", result.Message);
            Console.WriteLine("Incorrect header in Data");
        }
    }
}
