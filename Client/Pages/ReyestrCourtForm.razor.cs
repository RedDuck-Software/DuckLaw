using System;
using Duck.Shared;
using Duck.Shared.Requests;
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

        private bool Search { get; set; }
        private bool Loading { get; set; }
        
        public CourtSearchRequest CourtSearchRequest { get; set; }

        protected void HandleValidSubmit()
        {
            Loading = true;

            Logger.LogInformation("HandleValidSubmit called: Processing the form");

            Logger.LogInformation(openDataBotModel.ToString());

            CourtSearchRequest = OpenDataModelToCourtSearchRequest(openDataBotModel);

            Search = true;
            Loading = false;

            StateHasChanged();
        }

        private CourtSearchRequest OpenDataModelToCourtSearchRequest(OpenDataBotModel model) 
            => new()
            {
                JudgmentCode = model.JudgmentCode,
                JusticeCode = model.JusticeCode,
                // CourtCode = model.CourtCode, (+1 request) Код суда (перелік в судових реєстрах по /institutions) 
                // CompanyCode = model. ,
                Text = model.Text,
                Stage = model.Stage,
                TextIntro = model.TextIntro,
                TextResolution = model.TextResolution,
                // Offset = model. , for pagination
                // Limit = model. ,
                DateFrom = model.DateFrom?.ToString("yyyy-MM-dd 00:00:00+03"),
                DateTo = model.DateTo?.ToString("yyyy-MM-dd 00:00:00+03"),
                Number = model.Number,
                SearchCriteria = "words_in_a_row"
            };

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
