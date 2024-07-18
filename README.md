# Follow-Up Task Plugin for Microsoft Dataverse

## Overview
This plugin automates the creation of a follow-up task within Microsoft Dataverse whenever a new account is created. The primary function of this plugin is to ensure that new accounts are engaged with a structured follow-up process, aimed at enhancing customer service and account management efficiency.

Upon the creation of a new account, the plugin schedules a task for 7 days in the future. This task includes instructions for sending an email to the new customer, checking for any unresolved issues, and generally following up on their initial experience or requirements.

## Features
- **Automated Task Creation**: Automatically creates a follow-up task when a new account is created.
- **Customizable Follow-Up Schedule**: By default, schedules tasks for 7 days after account creation, but this can be easily adjusted in the plugin code.
- **Context-Aware**: Utilizes information from the account creation context to tailor the follow-up task, including linking the task directly to the created account for easy reference.


### Configuration
After installation, your plugin will automatically be triggered upon the creation of new accounts. If you wish to adjust the timing of the follow-up task or modify its details, you will need to edit the plugin's source code accordingly.

## Contributing
We welcome contributions to improve this plugin. Please ensure your submissions are well-documented and follow existing coding conventions.

## License
This project is provided under an open-source license, allowing free use, modification, and distribution. However, it is provided "as is" without warranty of any kind, either express or implied.

