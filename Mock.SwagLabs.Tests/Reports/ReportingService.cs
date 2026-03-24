using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Mock.SwagLabs.Tests.Reports;

public class ReportingService
{
    private readonly ExtentReports _extentReports;
    private ExtentTest? _currentTest;

    public ReportingService(string reportPath)
    {
        var sparkReporter = new ExtentSparkReporter(reportPath);
        _extentReports = new ExtentReports();
        _extentReports.AttachReporter(sparkReporter);
    }

    public void CreateTest(TestContext testContext)
    {
        _currentTest = _extentReports.CreateTest(testContext.Test.Name);
    }

    public void LogTestResult(TestContext testContext)
    {
        if (_currentTest == null)
            throw new InvalidOperationException("Test has not been initialized.");

        var status = testContext.Result.Outcome.Status;
        var message = testContext.Result.Message;

        _currentTest.Log(status switch
        {
            TestStatus.Passed => Status.Pass,
            TestStatus.Failed => Status.Fail,
            TestStatus.Skipped => Status.Skip,
            _ => Status.Warning
        }, status == TestStatus.Failed ? $"Test failed: {message}" : "Test executed");
    }

    public void FlushReports()
    {
        _extentReports.Flush();
    }
}
