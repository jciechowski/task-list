namespace TaskListFSharp

open TaskListFSharp.RealConsole

module TaskList =
    let quit = "quit"
    let help = "help"

    let showHelp =
        let console = RealConsole()
        console.WriteLine "Commands: "
        console.WriteLine "\t show"
        console.WriteLine "\t add project <project name>"
        console.WriteLine "\t add task <project name> <task description>"
        console.WriteLine "\t check <task ID>"
        console.WriteLine "\t uncheck <task ID>"

    let execute command = if command = help then showHelp

    let mutable continueLooping = true

    let write =
        while continueLooping do
            let console = RealConsole()
            console.Write " >"
            let command = console.ReadLine()

            if command = quit then
                continueLooping <- false
            else
                execute (command)
