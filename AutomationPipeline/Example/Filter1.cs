using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    public class Filter1 : Filter
    {
        public string Message { get; set; } = "Running Filter 1";
        public override void Run()
        {
            Console.WriteLine(Message);
            Continue();
        }
    }
}
