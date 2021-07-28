namespace TaskListFSharp

open TaskListFSharp.RealConsole

module TaskList =
    [<EntryPoint>]
    let main =
        let quit = "quit"

        let mutable continueLooping = true

        let write =
            while continueLooping do
                let console = RealConsole()
                console.Write " >"
                let command = console.ReadLine()

                if command = quit then
                    continueLooping <- false

        write
        0
