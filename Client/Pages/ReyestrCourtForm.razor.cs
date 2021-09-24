using System;
using Duck.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;

namespace Duck.Client.Pages
{
    public partial class ReyestrCourtForm
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]
        public ILogger<ReyestrCourtForm> Logger { get; set; }
        
        private EditContext editContext;
        private OpenDataBotModel openDataBotModel = new();


        protected void HandleValidSubmit()
        {
            Logger.LogInformation("HandleValidSubmit called: Processing the form");

            Logger.LogInformation(openDataBotModel.ToString());
            serv.CreateNewBlogPost(openDataBotModel);
            NavigationManager.NavigateTo("/Result");

            // Process the form
        }

        protected DateTime? CheckDate(DateTime? date)
        {
            if (date != null
                && date > new DateTime(1991, 01, 01)
                && date < DateTime.Now)
            {
                return date;
            }
            else
            {
                return null;
            }
        }
    }
}
