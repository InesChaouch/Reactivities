using application.Activities.Commands;
using application.Activities.DTOs;
using application.Activities.Queries;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ActivityDto>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id) 
        {
            return HandleResult(await Mediator.Send(new GetActivityDetails.Query{Id = id}));
          
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto) {
            return HandleResult(await Mediator.Send(new CreateActivity.Command{ActivityDto = activityDto}));
        }

        [HttpPut("{id}")]
        // [Authorize(Policy = "IsActivityHost")]
        public async Task<ActionResult> EditActivity(EditActivityDto activity) {
            return HandleResult(await Mediator.Send(new EditActivity.Command{ActivityDto = activity}));
        }

        // [HttpDelete("{id}")]
        // [Authorize(Policy = "IsActivityHost")]
        // public async Task<ActionResult> DeleteActivity(string id) {
        //      await Mediator.Send(new DeleteActivity.Command{Id = id});
            
        // }

        [HttpPost("{id}/attend")]
        public async Task<ActionResult> Attend(string id) {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command{Id = id}));
        }
    }
}
