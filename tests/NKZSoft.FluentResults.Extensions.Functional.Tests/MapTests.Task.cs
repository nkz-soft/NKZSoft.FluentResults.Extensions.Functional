namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTestsTask : MapTestsBase
{
    [Test]
    public async Task MapTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapTaskWithValueTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskWithValueTaskFuncSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapTaskTWithValueTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskTWithValueTaskFuncSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapTaskAndValueTaskVariantsHaveParityForSuccess()
    {
        var taskOutput = await TaskOkResultTAsync().MapAsync(TaskMapFuncAsync);
        var valueTaskOutput = await ValueTaskOkResultTAsync().MapAsync(ValueTaskMapFuncAsync);

        taskOutput.IsSuccess.Should().BeTrue();
        valueTaskOutput.IsSuccess.Should().BeTrue();
        taskOutput.Value.Should().BeSameAs(valueTaskOutput.Value);
    }
}
