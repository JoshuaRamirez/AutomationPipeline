using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    public class Filter2 : Filter
    {
        public string Message { get; set; } = "Running Filter 2";
        public override void Run()
        {
            Console.WriteLine(Message);
            Continue();
        }
    }
}
