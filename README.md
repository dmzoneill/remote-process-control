# Remote Process Control

<p align="center">
  <img src=".github/logo.png" alt="remote-process-control logo" width="128" />
</p>

A VB.NET Windows Forms tool for viewing and stopping processes on other
computers in a Windows workgroup.

## What it does

- Lists the computers in a workgroup with `net view`.
- Runs `tasklist` against a selected computer with the username and password you
  enter, and shows its processes.
- Ends a selected process with `taskkill`.
- Keeps a task log of the commands it has run.

## Tech

- Visual Basic .NET (Windows Forms)
- Windows `net`, `tasklist` and `taskkill` commands

## Building

Open the `.sln` file in Visual Studio and build it. Windows only.

## License

Licensed under the Apache License 2.0. See [LICENSE](LICENSE).
