Instructions:

- How to build the code : Download/Clone the code from below git repository and open the solution in Visual studio 2019. (https://github.com/sundeepsspgupta/tflSourceCode).

- How to run the output : Build the solution in VS studio 2019. Project can be executed through powershell or command prompt.
 
- User should go to this location in the project using powershell or command window : \RoadStatus\RoadStatus\bin\Debug\net5.0\RoadStatus.exe <Enter RoadCde>

- For executing it through powershell, go to this location in the project : "\RoadStatus\RoadStatus\bin\Debug\net5.0\RoadStatus.exe <Enter RoadCde>" and provide the input parameters. (Example - Input parameters would A21, A2, A3 (any Invalid Road types)

- How to run any tests that you have written : The test cases can be run through VS studio 2019. Go to RoadStatus.UnitTest project and open TFLServiceTest.cs class.
  Then test can be run through method or test explorer window.

- Any assumptions that you’ve made : It is expected that it takes only one input as RoadType. It is assumed that response from API is only one. If multiple response is there ,   then it will display a user freindly message.

- Anything else you think is relevant : NA

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Application Details:

1. This application has developed in .NET Core 5.0 , C# as backend language. A decoupled architect is used with dependency injection as design pattern.

2. Primary and secondry keys are configured in appsetting.json file which is available on the root of the project RoadStatus\appsetting.json.

3. Rodstatus is the main console application which is a startup project.

4. Once Console application gets started, it takes "RoadCode" parameter as a single input.

5. Only one RoadCode is valid, otherwise it will return exit code and provide a freindly message as "More than one parameters in RoadCode".

6. Second project is TFL.Config. This project contains the configurations details in appsetting.json i.e. Keys like primary, secondry, base url api, and api endpoint.

7. TFL.Domain project contains all the entities of response of API and response of console output.

8. TFL.Service contains the class which consume TFL Api and get the response and return the data.

9. A Unit test project is also added. "xUnit project type" has been used for tets project which contains three test cases and config file appsetting.json file. 

10. Three test cases names are TFLService_Valid_RoadType_A21(), TFLService_Valid_RoadType_A2(), FLService_InValid_RoadType_A221().

11. This project can be executed via console. Inputs are road code.

