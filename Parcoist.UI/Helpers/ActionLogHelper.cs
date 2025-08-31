using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;

namespace Parcoist.UI.Helpers
{
    public static class ActionLogHelper
    {
        public static void LogAction(IActionLogService actionLogService,string actionType, string description,int? id = null)
        {
            var actionLog = new ActionLog
            {
                UserID = id, 
                ActionType = actionType,
                Description = description,
                Date = DateTime.Now
            };
            actionLogService.TAdd(actionLog);
        }
    }
}
