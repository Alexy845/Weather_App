<!---->

<div align="center">
    <h1>WEATHER-APP</h1>
    <h3>◦ Storm or shine, Weather-App has you covered!</h3>
    <h3>◦ Developed with the software and tools below.</h3>
</div>

<p align="center">
  <a href="https://skillicons.dev">
    <img src=https://skillicons.dev/icons?i=cs,git,github />
  </a>
</p>

---

## 📖 Table of Contents
- [📖 Table of Contents](#-table-of-contents)
- [📍 Overview](#-overview)
- [📦 Features](#-features)
- [📂 repository Structure](#-repository-structure)
- [⚙️ Modules](#modules)
- [🚀 Getting Started](#-getting-started)
    - [🔧 Installation](#-installation)
    - [🤖 Running Weather-App](#-running-Weather-App)
    - [🧪 Tests](#-tests)
- [🛣 Roadmap](#-roadmap)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [👏 Acknowledgments](#-acknowledgments)

---


## 📍 Overview

The Weather-App repository is a project that allows users to retrieve weather forecast data for a specified location. It includes features like retrieving weather data from an API, displaying weather information, allowing users to change temperature units and language preferences, saving settings to a JSON file, and performing searches for weather information based on user input. It also handles network availability and displays relevant error messages.

---

## 📦 Features

Exception: 

---


## 📂 Repository Structure

```sh
└── Weather-App/
    ├── API/
    │   ├── WeatherApi.cs
    │   └── WeatherFiveDays.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── App.config
    ├── Conversion.cs
    ├── Enum/
    │   ├── Country.cs
    │   └── UnitTemp.cs
    ├── Folder.DotSettings
    ├── Folder.DotSettings.user
    ├── Icones.axaml
    ├── Images/
    ├── Lang/
    │   └── Lang.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── NoInternet.axaml
    ├── NoInternet.axaml.cs
    ├── Program.cs
    ├── SetCountry.cs
    ├── Weather App.csproj
    ├── Weather App.csproj.DotSettings.user
    ├── Weather_App.sln
    ├── app.manifest
    └── style.axaml.cs

```

---


## ⚙️ Modules

<details closed><summary>Root</summary>

| File                                                                                                                       | Summary                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| ---                                                                                                                        | ---                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| [style.axaml.cs](https://github.com/Ahliko/Weather-App/blob/main/style.axaml.cs)                                           | The code represents a partial class called MainWindow, which is a part of the Weather_App namespace. This class is extending the Window class from the Avalonia.Controls namespace. It is likely that this code file contains the logic and code related to the styling of the main window of the Weather App.                                                                                                                                    |
| [app.manifest](https://github.com/Ahliko/Weather-App/blob/main/app.manifest)                                               | The code represents the directory structure of a Weather App project, organized into different folders and files. The "app.manifest" file contains XML code that defines the compatibility of the application with different versions of Windows. It ensures that the application has been tested and designed to work on Windows 10.                                                                                                             |
| [Weather_App.sln](https://github.com/Ahliko/Weather-App/blob/main/Weather_App.sln)                                         | This code represents the directory structure of a Weather App project. It includes various files and folders such as API for weather data, App.axaml for the application interface, Enum for country and temperature unit options, Lang for language translations, MainWindow for the main window interface, and NoInternet for handling internet connectivity issues. The code also includes project configurations for different CPU platforms. |
| [Weather App.csproj.DotSettings.user](https://github.com/Ahliko/Weather-App/blob/main/Weather App.csproj.DotSettings.user) | The code is a snippet from the Weather App project's.csproj.DotSettings.user file. It defines two entries for ignored paths and paths with incorrect casing during code inspection. One entry points to the "icon.png" file located in the project directory, and the other entry specific to the user's home directory.                                                                                                                          |
| [Weather App.csproj](https://github.com/Ahliko/Weather-App/blob/main/Weather App.csproj)                                   | The code is a project file for a Weather App written in C#. It includes references to various Avalonia packages for UI development, as well as Newtonsoft.Json for JSON parsing. The app supports.NET 6.0 and includes an application manifest. It also includes item groups for the solution file and resources like images.                                                                                                                     |
| [SetCountry.cs](https://github.com/Ahliko/Weather-App/blob/main/SetCountry.cs)                                             | The code in SetCountry.cs provides a method, "SetCountryEnum", that sets the chosen country based on the provided index. It uses a switch statement to assign the appropriate country enum value to the "Country" property in the "MainWindow" class. If the index provided is not within the range of available countries, it defaults to English.                                                                                               |
| [Program.cs](https://github.com/Ahliko/Weather-App/blob/main/Program.cs)                                                   | The code in the Program.cs file initializes and configures an Avalonia application for a Weather App. It ensures that the necessary dependencies and fonts are detected and used. The application is then started with a classic desktop lifetime. The code also includes comments explaining the purpose and usage of the different sections.                                                                                                    |
| [NoInternet.axaml.cs](https://github.com/Ahliko/Weather-App/blob/main/NoInternet.axaml.cs)                                 | This code is part of a weather app project. The code represents the functionality of the "NoInternet" page in the app. It checks if there is an internet connection available using the NetworkInterface class. If an internet connection is available, it opens the MainWindow and closes the current page.                                                                                                                                      |
| [NoInternet.axaml](https://github.com/Ahliko/Weather-App/blob/main/NoInternet.axaml)                                       | The code above represents the XAML markup for a window titled "NoInternet". The window contains a grid with one row, and within the row, there is a text block displaying the message "No Internet Connection" with a font size of 20. There is also a button within the grid that triggers an event when clicked.                                                                                                                                |
| [MainWindow.axaml.cs](https://github.com/Ahliko/Weather-App/blob/main/MainWindow.axaml.cs)                                 | This code represents the main functionality of a Weather App. It includes features such as retrieving weather data from an API, displaying weather information, allowing the user to change temperature units and language preferences, saving settings to a JSON file, and performing searches for weather information based on user input. The code also handles network availability and displays error messages when necessary.               |
| [MainWindow.axaml](https://github.com/Ahliko/Weather-App/blob/main/MainWindow.axaml)                                       | HTTPStatus Exception: 400                                                                                                                                                                                                                                                                                                                                                                                                                         |
| [Icones.axaml](https://github.com/Ahliko/Weather-App/blob/main/Icones.axaml)                                               | The code is a XAML file that contains styles for an application's user interface. It defines a preview container with a border and allows for the addition of controls for previewing purposes. Additionally, the file provides a section for defining styles that can be applied to various UI elements within the application.                                                                                                                  |
| [Folder.DotSettings.user](https://github.com/Ahliko/Weather-App/blob/main/Folder.DotSettings.user)                         | This code applies a specific exclusion rule in a DotSettings.user file located in the Folder.DotSettings.user path. The rule excludes a specific file (MainWindow.axaml.cs) from code inspections in the Visual Studio IDE.                                                                                                                                                                                                                       |
| [Folder.DotSettings](https://github.com/Ahliko/Weather-App/blob/main/Folder.DotSettings)                                   | The code in Folder.DotSettings is a resource dictionary in XAML format. It sets the value of a property called "/Default/CodeEditing/SuppressNullableWarningFix/Enabled/@EntryValue" to False. This property is related to suppressing Nullable Warning Fix in code editing.                                                                                                                                                                      |
| [Conversion.cs](https://github.com/Ahliko/Weather-App/blob/main/Conversion.cs)                                             | The "Conversion.cs" file contains a class called "Conversion" that provides several static methods for unit conversion and other operations. The methods include converting Kelvin temperature to Celsius or Fahrenheit, getting the two-letter country code based on a country name, and downloading an image from a URL to a specified location.                                                                                                |
| [App.config](https://github.com/Ahliko/Weather-App/blob/main/App.config)                                                   | The code represents a directory tree structure of a Weather App project, containing various files and folders. The App.config file contains configuration settings for the application, including an API key.                                                                                                                                                                                                                                     |
| [App.axaml.cs](https://github.com/Ahliko/Weather-App/blob/main/App.axaml.cs)                                               | The code represents the main entry point of the Weather App application. It checks if the device has an active network connection using the NetworkInterface class. If there is a network connection, it creates an instance of the MainWindow class and sets it as the main window of the application. If there is no network connection, it creates an instance of the NoInternet class and sets it as the main window.                         |
| [App.axaml](https://github.com/Ahliko/Weather-App/blob/main/App.axaml)                                                     | This code is an XML file that belongs to an Avalonia UI project for a Weather App. It defines the application's main window layout and styling. The code imports the FluentTheme and references an Icones.axaml file for additional styles. It also specifies the RequestedThemeVariant as "Default", which means the app will follow the system's theme variant (e.g., Dark or Light).                                                           |

</details>

<details closed><summary>Lang</summary>

| File                                                                    | Summary                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| ---                                                                     | ---                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| [Lang.cs](https://github.com/Ahliko/Weather-App/blob/main/Lang/Lang.cs) | The code in the Lang/Lang.cs file provides a method to convert a language name into its corresponding language code. It includes a switch statement that takes a language name as an input and returns the corresponding language code based on that name. The supported language names and their corresponding codes are listed in the switch cases. If the input language name does not match any of the supported names, the method defaults to returning "en" as the language code, representing English. |

</details>

<details closed><summary>Enum</summary>

| File                                                                            | Summary                                                                                                                                                                                                           |
| ---                                                                             | ---                                                                                                                                                                                                               |
| [UnitTemp.cs](https://github.com/Ahliko/Weather-App/blob/main/Enum/UnitTemp.cs) | The code defines an enumeration called UnitTemp within the Enum namespace of the Weather_App project. The enumeration represents three different temperature units: Celsius, Fahrenheit, and Kelvin.              |
| [Country.cs](https://github.com/Ahliko/Weather-App/blob/main/Enum/Country.cs)   | The code in the "Enum/Country.cs" file defines an enumeration called "Country". It contains a list of country names in different languages that are used as options for selecting the country in the Weather App. |

</details>

<details closed><summary>Api</summary>

| File                                                                                         | Summary                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ---                                                                                          | ---                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| [WeatherFiveDays.cs](https://github.com/Ahliko/Weather-App/blob/main/API/WeatherFiveDays.cs) | The code represents a WeatherFiveDays class that is responsible for making API requests to retrieve weather data for the next five days. It uses the OpenWeatherMap API and requires an API key to authorize the requests. The GetWeatherFiveDays method takes in the location (name and country) and returns the weather forecast for the specified location. The response is deserialized into a Weather5Days object, which contains various details about the weather for each day. The class also includes nested classes that represent the different properties of the weather forecast. |
| [WeatherApi.cs](https://github.com/Ahliko/Weather-App/blob/main/API/WeatherApi.cs)           | The code represents a WeatherApi class that is responsible for making API calls to retrieve weather forecast data. It uses the HttpClient class to send HTTP requests and the Newtonsoft.Json library to deserialize the response into an instance of the ApiClass model. The GetWeatherForecast method takes in the name of a location and its country and returns weather forecast data for that location. The API key is obtained from the configuration settings.                                                                                                                          |

</details>

---

## 🚀 Getting Started

***Dependencies***

Please ensure you have the following dependencies installed on your system:

`- ℹ️ Dependency 1`

`- ℹ️ Dependency 2`

`- ℹ️ ...`

### 🔧 Installation

1. Clone the Weather-App repository:
```sh
git clone https://github.com/Ahliko/Weather-App
```

2. Change to the project directory:
```sh
cd Weather-App
```

3. Install the dependencies:
```sh
dotnet build
```

### 🤖 Running Weather-App

```sh
dotnet run
```

### 🧪 Tests
```sh
dotnet test
```

---


## 🛣 Project Roadmap

> - [X] `ℹ️  Task 1: Implement X`
> - [ ] `ℹ️  Task 2: Implement Y`
> - [ ] `ℹ️ ...`


---

## 🤝 Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Submit Pull Requests](https://github.com/Ahliko/Weather-App/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/Ahliko/Weather-App/discussions)**: Share your insights, provide feedback, or ask questions.
- **[Report Issues](https://github.com/Ahliko/Weather-App/issues)**: Submit bugs found or log feature requests for AHLIKO.

#### *Contributing Guidelines*

<details closed>
<summary>Click to expand</summary>

1. **Fork the Repository**: Start by forking the project repository to your GitHub account.
2. **Clone Locally**: Clone the forked repository to your local machine using a Git client.
   ```sh
   git clone <your-forked-repo-url>
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear and concise message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to GitHub**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.

Once your PR is reviewed and approved, it will be merged into the main branch.

</details>

---

## 📄 License


This project is protected under the [SELECT-A-LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

## 👏 Acknowledgments

- List any resources, contributors, inspiration, etc. here.

[**Return**](#Top)

---

