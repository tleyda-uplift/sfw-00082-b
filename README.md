# SFW-00082 — MSP430 GPIO/LED Firmware & HID Test Application

This repository contains two paired projects: embedded firmware for an MSP430-based GPIO/LED controller and a Windows desktop application for testing and controlling the device over USB HID.

---

## Projects

### 1. `sfw-00082` — MSP430 Firmware

Firmware for the **ELA-00572 GPIO controller** targeting BBS-00430/BBS-00431. Runs on a **Texas Instruments MSP430F5529** microcontroller.

**Features:**
- Legacy command message drives nine PWM channels controlling three tri-color LEDs
- PC-based control via USB HID interface
- 24 GPIO inputs with RTC-based debouncing across ports P3, P4, P6 read at 64 Hz
- 24 GPIO outputs managed across ports P1, P2, P7 with 11 PWM-capable outputs
- Low-power sleep modes (LPM0/LPM3) between USB activity

**PWM-Capable Outputs**
- Port 1 - Outputs 3, 4, 5, 6
- Port 2 - Outputs 1, 2, 5, 6
- Port 7 - Outputs 5, 6, 7

**Clock configuration:**
- MCLK / SMCLK / FLL: 8 MHz
- ACLK / REFO: 32 kHz

**HID report protocol:**
| Report ID | Packet ID | Direction | Purpose |
|-----------|-----------|---------|
| `0x3F` | `0x37` | Host → Device | output control |
| `0x3F` | `0x38` | Host → Device | Input configuration |
| `0x40` |  N/A   | Device → Host | Input status |

**Build environment:** Texas Instruments Code Composer Studio (Eclipse CDT). Open the `.project` file in `sfw-00082/` to import.

---

### 2. `HID-Test-App` — Windows Test Application

A .NET 10.0 Windows Forms application for communicating with the SFW-00082 firmware over USB HID. Follows the **MVP (Model-View-Presenter)** pattern.

**Features:**
- Connect to the USB HID device by vendor/product ID
- Send output commands across 8 channels per port
- Configure input behavior
- Run automated LED test sequences
- View live input statuses

**Solution file:** `HID-Test-App/HID-Test-App.slnx`

**Dependencies:**
- [HidSharp 2.6.4](https://github.com/IntergatedCircuits/HidSharp) — USB HID communication
- .NET 10.0 (Windows)

**Projects in solution:**

| Project | Description |
|---------|-------------|
| `HID-Test-App` | Main Windows Forms application |
| `Hid-Test-App-Tests` | XUnit unit tests with FluentAssertions |

#### Building

```powershell
cd HID-Test-App
dotnet build
```

#### Running Tests

```powershell
cd HID-Test-App
dotnet test
```

#### Publishing (single self-contained executable)

```powershell
cd HID-Test-App
dotnet publish -r win-x64
```

---

## Repository Structure

```
├── sfw-00082/               # MSP430 firmware (C)
│   ├── main.c               # Main loop and USB state machine
│   ├── inputs.c             # GPIO input handling with debouncing
│   ├── outputs.c            # PWM output and LED control
│   ├── P8_LED_CONFIG.h      # Hardware pin configuration for three tri-color LEDs
│   ├── USB_config/          # USB descriptor configuration
│   ├── USB_app/             # USB HID application layer
│   └── USB_API/             # TI USB stack
│
└── HID-Test-App/            # Windows test application (.NET/C#)
    ├── HID-Test-App/
    │   ├── Commands/         # HID report builders (output, input config)
    │   ├── Models/           # OutputParams, InputStatus, InputConfig
    │   ├── Presenters/       # MVP presenters
    │   ├── Services/         # HidService — USB HID device communication
    │   └── Views/            # Windows Forms views
    └── Hid-Test-App-Tests/   # XUnit unit tests with fakes
```

---

## Hardware

| Item | Description |
|------|-------------|
| MCU | MSP430F5529 |
| Board | ELA-00572 |
| Target assemblies | BBS-00430, BBS-00431 |
| Interface | USB HID (full-speed) |

---

## Version

HID Test App: **0.0.1**
