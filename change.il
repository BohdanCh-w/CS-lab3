.method private hidebysig static 
	class [mscorlib]System.Threading.Tasks.Task Main (
		string[] args
	) cil managed 
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.AsyncStateMachineAttribute::.ctor(class [mscorlib]System.Type) = (
		01 00 21 43 53 5f 6c 61 62 33 5f 32 61 73 79 6e
		63 2e 50 72 6f 67 72 61 6d 2b 3c 4d 61 69 6e 3e
		64 5f 5f 30 00 00
	)
	.custom instance void [mscorlib]System.Diagnostics.DebuggerStepThroughAttribute::.ctor() = (
		01 00 00 00
	)
	// Method begins at RVA 0x2050
	// Code size 56 (0x38)
	.maxstack 2
	.locals init (
		[0] class CS_lab3_2async.Program/'<Main>d__0'
	)

	IL_0000: newobj instance void CS_lab3_2async.Program/'<Main>d__0'::.ctor()
	IL_0005: stloc.0
	IL_0006: ldloc.0
	IL_0007: call valuetype [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder::Create()
	IL_000c: stfld valuetype [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder CS_lab3_2async.Program/'<Main>d__0'::'<>t__builder'
	IL_0011: ldloc.0
	IL_0012: ldarg.0
	IL_0013: stfld string[] CS_lab3_2async.Program/'<Main>d__0'::args
	IL_0018: ldloc.0
	IL_0019: ldc.i4.m1
	IL_001a: stfld int32 CS_lab3_2async.Program/'<Main>d__0'::'<>1__state'
	IL_001f: ldloc.0
	IL_0020: ldflda valuetype [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder CS_lab3_2async.Program/'<Main>d__0'::'<>t__builder'
	IL_0025: ldloca.s 0
	IL_0027: call instance void [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder::Start<class CS_lab3_2async.Program/'<Main>d__0'>(!!0&)
	IL_002c: ldloc.0
	IL_002d: ldflda valuetype [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder CS_lab3_2async.Program/'<Main>d__0'::'<>t__builder'
	IL_0032: call instance class [mscorlib]System.Threading.Tasks.Task [mscorlib]System.Runtime.CompilerServices.AsyncTaskMethodBuilder::get_Task()
	IL_0037: ret
} // end of method Program::Main