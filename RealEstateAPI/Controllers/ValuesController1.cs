using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private readonly string connectionString = "Server=localhost;Database=realestate;Integrated Security=True;TrustServerCertificate=True;";

        [HttpGet("brands")]
        public IActionResult GetBrands()
        {
            var brands = new List<Dictionary<string, string>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Brands";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var brand = new Dictionary<string, string>
                            {
                                ["Id"] = reader["Id"].ToString() ?? "null",
                                ["Name"] = reader["Name"].ToString() ?? "null",
                                ["Country"] = reader["Country"].ToString() ?? "null",
                                ["FoundedYear"] = reader["FoundedYear"].ToString() ?? "null",
                                ["IsActive"] = reader["IsActive"].ToString() ?? "null"
                            };
                            brands.Add(brand);
                        }
                    }
                }
            }

            return Ok(brands);
        }

    [HttpGet("projects")]
    public IActionResult GetProjects()
    {
        var projects = new List<Dictionary<string, string>>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Projects";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var project = new Dictionary<string, string>
                        {
                            ["ProjectId"] = reader["ProjectId"].ToString() ?? "null",
                            ["ProjectName"] = reader["ProjectName"].ToString() ?? "null", 
                            ["Location"] = reader["Location"].ToString() ?? "null",
                            ["StartDate"] = reader["StartDate"].ToString() ?? "null",
                            ["CompanyId"] = reader["CompanyId"].ToString() ?? "null"
                        };
                        projects.Add(project);
                    }
                }
            }
        }

        return Ok(projects);
    }

}
