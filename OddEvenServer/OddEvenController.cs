﻿using Microsoft.AspNetCore.Mvc;

namespace OddEvenServer
{
    [ApiController]
    [Route("api/[controller]")]
    public class OddEvenController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOddEven()
        {
            string message = GetDateTimeOddEven();
            return Ok(new { message });
        }
        private string GetDateTimeOddEven()
        {
            var now = DateTime.Now;
            int[] dateTimeParts = [now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second];
            int evenCount = 0;
            int oddCount = 0;
            foreach (var part in dateTimeParts)
            {
                if (part % 2 == 0) evenCount++;
                else oddCount++;
            }
            if (evenCount > oddCount)
            {
                return "чет!";
            }
            else if (oddCount > evenCount)
            {
                return "нечет!";
            }
            else
            {
                return "равно!";
            }
        }
    }
}
