using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Dal.Entities;
using Onlab.Transfer;

namespace Onlab_v2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController(ITaskItemService taskItemService) : ControllerBase
    {
        [HttpGet]
        public async Task<IList<TaskItemData>> GetTaskItemsAsync()
        {
            return await taskItemService.GetTaskItemsAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTaskItemAsync([FromBody] CreateTaskItemData createTaskItemData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await taskItemService.CreateTaskItemAsync(createTaskItemData);
            return Ok();
        }

        [HttpPut("{taskItemId}/status")]
        public async Task<IActionResult> UpdateTaskItemStatus(int taskItemId, [FromBody]TaskItemStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await taskItemService.UpdateTaskItemStatusAsync(taskItemId, status);
            return Ok();
        }

        [HttpDelete("{taskItemId}")]
        public async Task<IActionResult> DeleteTaskItem(int taskItemId)
        {
            await taskItemService.DeleteTaskItemAsync(taskItemId);
            return Ok();
        }

    }
}
