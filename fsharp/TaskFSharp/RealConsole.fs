module TaskListFSharp.RealConsole

open System

type RealConsole() =
    member this.ReadLine() = Console.ReadLine()

    member this.Write(format: string, [<ParamArray>] args: string []) =
        Console.Write(format, args)

    member this.WriteLine(format: string, [<ParamArray>] args: string []) =
        Console.WriteLine(format, args)

    member this.WriteLine() = Console.WriteLine()
