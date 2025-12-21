# DeskUI
OS-like multi-window system

Full documentation & demo: https://github.com/guillaC/DeskUI

## Setup (Blazor Server / WebAssembly)

- Import the namespace in `_Imports.razor` (DeskUI)
```razor
@using DeskUI
```
- Add the window host in your main page (e.g. `Index.razor`):
```html
<WindowHost />
```
- Register scripts:
```html
<script src="_content/DeskUI/drag.js"/>
```

## Usage
```csharp
async Task OpenFirstWindow()
{
    await WindowManager.OpenWindowAsync("FirstComponent", builder =>
    {
        builder.OpenComponent<FirstForm>(0);
        builder.CloseComponent();
    }, width: 240, height: 320);
}

async Task OpenSecondWindow()
{
    await WindowManager.OpenWindowAsync("SecondComponent (Modal)", builder =>
    {
        builder.OpenComponent<SecondForm>(0);
        builder.CloseComponent();
    }, width: 550, height: 250, allowClose: false, overlayed:true);
}

```