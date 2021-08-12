namespace TaskListFSharp

open System.Collections.Generic
open TaskListFSharp.RealConsole

module TaskList =
    let tasks = Dictionary<string, List<Task>>()
    let lastId = 0
    let console = RealConsole()

    let help() =
        console.WriteLine "Commands: "
        console.WriteLine "\t show"
        console.WriteLine "\t add project <project name>"
        console.WriteLine "\t add task <project name> <task description>"
        console.WriteLine "\t check <task ID>"
        console.WriteLine "\t uncheck <task ID>"

    let show() =
        console.WriteLine "Showing all tasks and projects"

    let addProject projectName =
        console.WriteLine $"adding project {projectName.ToString()}"

    let addTask projectName taskDescription =
        console.WriteLine $"adding {taskDescription.ToString()} to {projectName.ToString()}"

    let check taskId =
        console.WriteLine $"Task with id {taskId.ToString()} done!"

    let uncheck taskId =
        console.WriteLine $"Task with id {taskId.ToString()} unchecked!"

    let error command =
        console.WriteLine $"I don't know what the command {command} is."

    let add (command:string) =
        console.WriteLine $"add {command}"
        let subcommandRest = command.Split(" ", 2)
        let subcommand = subcommandRest.[0]
        if subcommand = "project" then addProject subcommandRest.[1]
        else if subcommand = "task" then
            let projectTask = subcommandRest.[1].Split(" ", 2)
            addTask projectTask.[0] projectTask.[1]
        ()

    let execute (commandLine:string)=
        let commandRest = commandLine.Split(" ", 2)
        let command = commandRest.[0]

        if command = "help" then help()
        else if command = "add" then add commandRest.[1]
        else if command = "check" then check commandRest
        else if command = "uncheck" then uncheck commandRest
        else if command = "show" then show()
        else error command

    let mutable continueLooping = true

    let write() =
        while continueLooping do
            console.Write " >"
            let command = console.ReadLine()

            if command = "quit" then
                continueLooping <- false
            else
                execute command
