using AutomationPipeline.Example;

var startingFilter = new Filter1()
{
    PipeOut = new PipeA()
    {
        TargetFilter = new Filter2()
    }
};

startingFilter.Run();


Console.ReadLine();