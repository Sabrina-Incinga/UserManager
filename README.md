<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->

<a name="readme-top"></a>

<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
<h3 align="center">User Manager</h3>

  <p align="center">
   Service designed to manage user data
    <br />
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

UserManager is a RESTful API built to manage user information. It exposes a complete CRUD of the User entity and a complete documentation of each action via Swagger. The repository and unit of work patterns are implemented in this solution to leverage the insulation it provides.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

- .NET Core 7.0

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

### Prerequisites

To run this project you'll need to have installed .NET 7.0 SDK or above. You can follow this link to get the installation file:

- SDK
  ```sh
  [https://dotnet.microsoft.com/en-us/download/dotnet/7.0]
  ```

You'll need Git to clone the project, it can be downloaded from:

- GIT
  ```sh
  [https://git-scm.com/downloads]
  ```

### Installation

1. Clone the repository using this command:

```sh
 git clone https://github.com/Sabrina-Incinga/UserManager.git
```

2.  Once it's downloaded, you can use Visual Studio to open and run the project. It requires a Sql Server database server, to configure the connection string you should create an appsettings.local.json in the UserManager-Server/UserManager-Server folder, at the same level of appsettings.json, and replace the connection string there:

        ```json
        {
            "ConnectionStrings": {
                "constring": "Server=acdbsgo02.grupocapsa.net;Database=CapsaSGP3;User ID=CapsaSGP;Password=CapsaSGP;TrustServerCertificate=True"
            }
        }

        ```

Migration are run automatically when the project starts.

3.  In case you decide to use Visual Studio Code, some extentions are required: "C#", "C# Dev Kit" should be installed in depicted order.

4.  The project uses the 5038 port by default, it can be modified in launchsettings.json

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->

## Usage

Once it's running, you can go to the following link to try out every action in swagger: [text](http://localhost:5038/swagger/index.html)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

See the [open issues](https://github.com/Sabrina-incinga/UserManager/issues) for a full list of proposed features (and known issues).

<!-- CONTACT -->

## Contact

Sabrina Giuliana Incinga - sabrinagincinga@gmail.com

Project Link: [https://github.com/Sabrina-incinga/UserManager](https://github.com/Sabrina-incinga/UserManager)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/Sabrina-incinga/UserManager.svg?style=for-the-badge
[contributors-url]: https://github.com/Sabrina-incinga/UserManager/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Sabrina-incinga/UserManager.svg?style=for-the-badge
[forks-url]: https://github.com/Sabrina-incinga/UserManager/network/members

```

```
