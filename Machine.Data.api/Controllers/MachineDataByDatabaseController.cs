using Machine.Data.api.Entity;
using Machine.Data.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Machine.Data.api.Controllers
{
    [ApiController]
    [Route("assets")]
    
    public class MachineDataByDatabaseController : Controller
    {
        private readonly IMachineDataFromDatabase _machineData;

        public MachineDataByDatabaseController(IMachineDataFromDatabase machineData)
        {
            _machineData = machineData;
        }

        [HttpPost("uploaddata")]
       
        public async Task<ActionResult> InsertMachineData()
        {
            await _machineData.InsertMachineData();

            return  Ok();
        }

        /// <summary>
        /// Get all machine data
        /// </summary>

        /// <returns>all machine data with asset name and version</returns>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Asset>>> GetMachinesData()
        {
            var allMachineData = await _machineData.GetAllMachineData();

            return new OkObjectResult(allMachineData);
        }

        /// <summary>
        /// Get asset names by machine types
        /// </summary>
       
        /// <param name="machineType">value of machine name</param>
        /// <returns>assets of given machine types</returns>
        [HttpGet("machinetypes")]
        public async  Task<ActionResult<IEnumerable<Asset>>> GetAssetNamesByMachineTypes(string machineType)
        {
            var assetNameByMachineType = await _machineData.AssetNamesByMachineType(machineType);

            return new OkObjectResult(assetNameByMachineType);
        }

        /// <summary>
        /// Get all machines by asset names
        /// </summary>
       
        /// <param name="assetName">value of asset name</param>
        /// <returns>machines of given asset names</returns>
        [HttpGet("assetname")]
        public async  Task<ActionResult<IEnumerable<Asset>>> GetMachineByAssetName(string assetName)
        {
            var machineTypeByAssetName = await  _machineData.MachineTypesByAssestName(assetName);

           return new OkObjectResult(machineTypeByAssetName);
        }

        /// <summary>
        /// Get latest series of machine
        /// </summary>
       
        /// <returns>latest version of machine</returns>

        [HttpGet("latestseries")]
        public async Task<ActionResult<IEnumerable<Asset>>> GetLatestSeries()
        {
            var GetLatestSeries = await _machineData.MachineTypesByLatestSeriesOfAsset();

            return new OkObjectResult(GetLatestSeries);
        }

        [HttpDelete("deletedata")]
        public async Task<ActionResult> DeleteMachineData()
        {
            await _machineData.DeleteMachineData();

            return Ok();
        }

    }
}
