# Follow-Up Task Plugin for Microsoft Dataverse

## Overview
This plugin automates the creation of a follow-up task within Microsoft Dataverse whenever a new account is created. The primary function of this plugin is to ensure that new accounts are engaged with a structured follow-up process, aimed at enhancing customer service and account management efficiency.

Upon the creation of a new account, the plugin schedules a task for 7 days in the future. This task includes instructions for sending an email to the new customer, checking for any unresolved issues, and generally following up on their initial experience or requirements.

## Features
- **Automated Task Creation**: Automatically creates a follow-up task when a new account is created.
- **Customizable Follow-Up Schedule**: By default, schedules tasks for 7 days after account creation, but this can be easily adjusted in the plugin code.
- **Context-Aware**: Utilizes information from the account creation context to tailor the follow-up task, including linking the task directly to the created account for easy reference.

## Installation Using PAC Tools

### Prerequisites
- Microsoft Power Apps CLI (PAC)
- Visual Studio 2019 or later
- Access to a Microsoft Dataverse environment

### Steps

1. **Build Your Plugin**
   - Open your plugin project in Visual Studio.
   - Compile the project to generate the .dll assembly required for deployment.

2. **Initialize a PAC Solution Project**
   - Open a command prompt or PowerShell.
   - Navigate to your project directory and run:
     ```
     pac solution init --name YourSolutionName --publisher-name YourPublisherName --publisher-prefix YourPublisherPrefix
     ```
   - Replace the placeholders with your solution, publisher name, and prefix.

3. **Add Your Plugin Assembly to the Solution**
   - Add your compiled plugin assembly to the solution with:
     ```
     pac solution add-reference --path path\to\your\plugin\assembly.dll
     ```

4. **Authenticate with Your Dataverse Environment**
   - Authenticate using:
     ```
     pac auth create --url https://yourorg.crm.dynamics.com
     ```
   - Follow the prompts to complete authentication.

5. **Deploy Your Solution**
   - Deploy the solution to Dataverse:
     ```
     pac solution deploy --path ./YourSolutionName
     ```

### Configuration
After installation, your plugin will automatically be triggered upon the creation of new accounts. If you wish to adjust the timing of the follow-up task or modify its details, you will need to edit the plugin's source code accordingly.

## Contributing
We welcome contributions to improve this plugin. Please ensure your submissions are well-documented and follow existing coding conventions.

## License
This project is provided under an open-source license, allowing free use, modification, and distribution. However, it is provided "as is" without warranty of any kind, either express or implied.

