# Azure DevOps Pipeline Readme

## Introduction

This readme document provides an overview of the Azure DevOps pipeline used in this project. The pipeline is designed to build a .NET Core project, publish the build output as artifacts, and push NuGet packages to an internal feed. It also incorporates version incrementation and SonarQube code analysis for maintaining code quality.

* If you want to see the other pipeline please switch to the sonar branch and see the yaml file that represent the pipeline for the branch.

## Project Setup

1. **Azure Account**: To begin the project, an Azure account with a subscription and a designated region for resource usage was created.

2. **Hello World App**: A simple "Hello World" application was created using the .NET SDK by running the following command:
   ```bash
   dotnet new console -o MyApp -f net7.0
   ```
3. csproj file was also created to manage project information.

4.  Version Control: A Git repository was initialized using the command git init to store the project for future use.

5. Development Environment: Visual Studio Code (VS Code) was installed for developing the application and the YAML pipeline.

6. Agent VMs: Two Azure VMs were created, one for running the pipelines and another for SonarQube. These VMs were configured to connect to Azure organizations and set up as pipeline agents.

7. VM Setup: On the agent VM, Docker, .NET SDK, and NuGet were installed to create C# images and push them to Docker Hub.
8.  A feed is created to store the c# artifacts.


## Pipeline Configuration

Version Incrementation

Version incrementation was implemented in the pipeline using the following lines of code:

yaml

semanticVersion: $[counter(variables['majorMinorVersion'], 0)]

The majorMinorVersion is a pipeline variable that is automatically incremented with each pipeline execution.
Main Pipeline

The main pipeline is triggered by changes to the main branch. When there is a new commit or pull request to the main branch, the pipeline is triggered to run. The pipeline consists of the following steps:

1. **Build Step**: This step uses the DotNetCoreCLI task to build the .NET Core project. It specifies the projects to build and the build configuration.

2. **Publish Step**: This step also uses the DotNetCoreCLI task but with the 'publish' command. It does not publish web projects (publishWebProjects: false). It publishes the project output to a specified directory and zips it (zipAfterPublish: true).
3. **Publish Artifact Step**: This step uses the PublishBuildArtifacts task to publish the build artifacts. It publishes the contents of the specified directory ($(Build.ArtifactStagingDirectory)) as a build artifact with the name 'drop'.
4. **Publish NuGet Packages Step**: This step uses the DotNetCoreCLI task with the 'push' command. It pushes NuGet packages to an internal feed (nuGetFeedType: 'internal') based on the build artifacts previously created.


# Conditioned Pipeline (SonarQube)

A separate branch named 'sonar' was created, and a new job in Azure DevOps was also named 'sonar'. The pipeline trigger was changed to use the 'sonar' branch.

To enable SonarQube analysis, the following steps were taken:

* SonarQube was installed, and the SonarQube plugin was added to Azure DevOps pipeline for conditioned analysis.
* SonarQube version 8 was used to support multiple branches, and Docker Compose was used to create and run the SonarQube image.
* An access key was generated to connect the pipeline to Azure, and a pipeline secret variable with Azure was created to store the keys.



The conditioned pipeline performs the following actions:
1. Prepare Environment for SonarQube Analysis
2. Build .NET Core Project
3. Analyze Code using SonarQube
4. Publish Analysis Results
5. Package Project as NuGet Package - sonar_1.0.X
6. Publish NuGet Packages
7. Send Email Notification - Azure devops organization feature
