using AleatorikUI.Services.DTO.plm;
using TriggerJobService;

namespace AleatorikUI.Services.Helper
{
	public static class TriggerJobHelper
	{
		public async static void RunTaskService(PlmPlanExecuteInfo param, ILogger logger) {
            KeyValue starttime = new KeyValue();
            starttime.Key = "start-time";
            starttime.Value = param.planStartDate;

            KeyValue period = new KeyValue();
            period.Key = "period";
            period.Value = param.planPeriod;

            KeyValue scenario = new KeyValue();
            scenario.Key = "PlanScenario";
            scenario.Value = param.scenarioID;

            KeyValue ver = new KeyValue();
            ver.Key = "PlanVersion";
            ver.Value = param.planVer;

            KeyValue[] args = new KeyValue[4] { starttime, period, scenario, ver };

            try
            {
                await TriggerRun("Engine", "sa", "mozart", args);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
		}

        public static Task TriggerRun(string triggerName, string userID, string password, KeyValue[] args)
        {
            var client = new TriggerJobServiceClient();
            return client.FireUserAsync(triggerName, userID, password, 3, false, args);
        }

    }
}
