# FirewallConsoleApp

A command-line interface for managing Windows Firewall rules, built with .NET 8 and MagicOnion.

## Features

- Manage firewall inbound and outbound rules via CLI.
- Single-executable, self-contained distribution.
- Automated releases and Winget publication.

## Usage

Example command (conceptual):

```bash
FirewallConsoleApp list
FirewallConsoleApp add --name "Test Rule" --port 8080 --action Allow
```

## Development

Build requirements:
- .NET 8 SDK
- Windows 10/11

To publish a single-file executable locally:

```bash
dotnet publish -c Release
```
