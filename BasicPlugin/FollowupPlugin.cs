using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;

namespace BasicPlugin
{
    /// <summary>
    /// A basic plugin for Microsoft Dataverse to create a follow-up task for a new account.
    /// </summary>

    public class FollowupPlugin : IPlugin

    {
        /// <summary>
        /// Executes the plugin logic.
        /// </summary>
        /// <param name="serviceProvider">Provides access to service methods.</param>

        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service to log information during plugin execution
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context to access input parameters, user info, etc.
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Ensure the Target input parameter is present and is of type Entity
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];  //Not used in this code, kept in for reference

                // Obtain the IOrganizationService instance which you will need for  
                // web service calls.  
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {
                    // Plug-in business logic goes here.  
                    // Create a task activity to follow up with the account customer in 7 days. 
                    Entity followup = new Entity("task");

                    followup["subject"] = "Send e-mail to the new customer.";
                    followup["description"] =
                        "Check in with the customer to ensure their satisfaction and address any new issues or questions. Offer solutions and highlight any relevant updates or services. Reaffirm our commitment to their needs and document feedback for prompt action.";
                    followup["scheduledstart"] = DateTime.Now.AddDays(7);
                    followup["scheduledend"] = DateTime.Now.AddDays(7);
                    followup["category"] = context.PrimaryEntityName;

                    // Refer to the account in the task activity.
                    if (context.OutputParameters.Contains("id"))
                    {
                        //Get the id of the account record, we will use this to set the regarding object id on the task record.
                        Guid regardingobjectid = new Guid(context.OutputParameters["id"].ToString());
                        
                        //We will need to set what table the id is on, in this case it is on the account table
                        string regardingobjectidType = "account";

                        //Set the regarding object field
                        followup["regardingobjectid"] = new EntityReference(regardingobjectidType, regardingobjectid);
                    }

                    // Create the task in Dataverse
                    tracingService.Trace("FollowupPlugin: Creating the task activity.");
                    service.Create(followup);
                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("FollowUpPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
