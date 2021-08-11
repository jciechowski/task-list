namespace TaskListFSharp

open TaskListFSharp.RealConsole

module TaskList =
    let quit = "quit"
    let help = "help"
    let addProjectCommand = "add project"
    let addTaskCommand = "add task"
    let checkCommand = "check"
    let uncheckCommand = "uncheck"

    let console = RealConsole()

    let showHelp() =
        console.WriteLine "Commands: "
        console.WriteLine "\t show"
        console.WriteLine "\t add project <project name>"
        console.WriteLine "\t add task <project name> <task description>"
        console.WriteLine "\t check <task ID>"
        console.WriteLine "\t uncheck <task ID>"

    let addProject projectName =
        console.WriteLine $"adding project {projectName}"

    let addTask projectName taskDescription =
        console.WriteLine $"adding {taskDescription} to {projectName}"

    let check taskId =
        console.WriteLine $"Task with id {taskId} done!"

    let uncheck taskId =
        console.WriteLine $"Task with id {taskId} unchecked!"

    let execute command =
        if command = help then showHelp()
        else if command.StartsWith(addProjectCommand) then addProject "project name"
        else if command.StartsWith(addTaskCommand) then addTask "project name" "task id"
        else if command.StartsWith(checkCommand) then check "task id"
        else if command.StartsWith(uncheckCommand) then uncheck "task id"
        else showHelp()

    let mutable continueLooping = true

    let write() =
        while continueLooping do
            console.Write " >"
            let command = console.ReadLine()

            if command = quit then
                continueLooping <- false
            else
                execute (command)
