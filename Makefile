CSC=/Library/Frameworks/Mono.framework/Commands/csc-dim
COMPILE_ARGS=/nologo /langversion:7.1

coffee::
	$(CSC) coffee.cs $(COMPILE_ARGS)
	mono coffee.exe
	
coffee_do_not_work::
	$(CSC) coffee_do_not_work.cs $(COMPILE_ARGS)
	mono coffee_do_not_work
	
clean::
	rm main.exe
	rm lib.dll


