# BlazorDesk  
![Blazor](https://img.shields.io/badge/blazor-purple?logo=blazor&logoColor=white)
![NuGet](https://img.shields.io/nuget/vpre/DeskUI?label=nuget&logo=nuget)  
![Stars](https://img.shields.io/github/stars/guillaC/BlazorDesk?style=flat)
![License](https://img.shields.io/badge/license-MIT-green)

**OS like multi window system for Blazor applications.**  
A reusable Razor Class Library (DeskUI) with a Blazor Server demo showcasing draggable, resizable, focusable windows.

## Features
- Multi-window system with WindowManager
- Windows can be opened, moved, resized, and focused
- Drag works with JS tracking, no extra dependencies
- Built-in dark mode support
- Modular Razor Class Library

## Demo
![Démo](https://github.com/user-attachments/assets/7ecaa10e-845f-4ab3-8c03-98e40571f253)

## Projects
- **DeskUI (RCL)** : reusable component library, compatible with Blazor Server, WASM, and Hybrid  
- **DeskUI.Demo (App)** : Blazor Server demo showcasing the library in action

## ToDo 
- [ ] Support Esc key to close windows
- [ ] Save open windows locally (browser localStorage)
- [ ] Write full README with badges and usage
- [ ] Add window icon support

## NuGet
DeskUI is available on [NuGet.org](https://www.nuget.org/packages/DeskUI/)

Install via .NET CLI:
```bash
dotnet add package DeskUI
```

## License
This project is licensed under the **MIT License** – see the [LICENSE](LICENSE.txt) file for details.