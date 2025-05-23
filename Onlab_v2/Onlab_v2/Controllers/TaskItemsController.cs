using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Transfer;

namespace Onlab_v2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController(ITaskItemService taskItemService) : ControllerBase
    {
        [HttpGet]
        public async Task<IList<TaskItemData>> GetTaskItems()
        {
            return await taskItemService.GetTaskItems();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTaskItem([FromBody] CreateTaskItemData createTaskItemData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await taskItemService.CreateTaskItemAsync(createTaskItemData);
            return Ok();
        }

        [HttpPut("{taskItemId}/status")]
        public async Task<IActionResult> UpdateTaskItemStatus(int taskItemId, [FromBody] Onlab.Dal.Entities.TaskStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await taskItemService.UpdateTaskItemStatus(taskItemId, status);
            return Ok();
        }
    }
}
