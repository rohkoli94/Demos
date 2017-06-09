.assembly Hello {}
.assembly extern mscorlib {}

.method public static void Start() cil managed
{
	.entrypoint // Programs executes with this method
	.maxstack 1

	ldstr	"Hello World!"
	call	void [mscorlib]System.Console::WriteLine(string)
	ret
}