using AutomationPipeline.Example;

// Create filters
var filter1 = new Filter1();
var filter2 = new Filter2();
var filter2A = new Filter2A();
var filter2B = new Filter2B();
var filter2C = new Filter2C();
var filter3 = new Filter3();

// Create pipes
var pipeA = new PipeA();
var pipeB1 = new PipeB1();
var pipeB2 = new PipeB2();
var pipeB3 = new PipeB3();
var pipeC1 = new PipeC1();
var pipeC2 = new PipeC2();
var pipeC3 = new PipeC3();

// Connect pipes and filters
filter1.OutboundPipe = pipeA;
pipeA.TargetFilter = filter2;

filter2.OutboundPipes.Add(pipeB1);
filter2.OutboundPipes.Add(pipeB2);
filter2.OutboundPipes.Add(pipeB3);

pipeB1.TargetFilter = filter2A;
pipeB2.TargetFilter = filter2B;
pipeB3.TargetFilter = filter2C;

filter2A.OutboundPipe = pipeC1;
filter2B.OutboundPipe = pipeC2;
filter2C.OutboundPipe = pipeC3;

pipeC1.TargetFilter = filter3;
pipeC2.TargetFilter = filter3;
pipeC3.TargetFilter = filter3;


filter1.Run();


Console.ReadLine();