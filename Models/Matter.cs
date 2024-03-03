using Microsoft.Data.SqlClient;

namespace Slate.Models
{
    public class Matter
    {
        // Properties
        public int MatterID { get; set; }
        public string EntityID { get; set; }
        public string MatterType { get; set; }
        public string MatterStatus { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}

        // Constuctor
        public Matter(int matterID, string entityID, string matterType, string matterStatus, DateTime createdAt, DateTime lastUpdatedAt)
        {
            MatterID = matterID;
            EntityID = entityID;
            MatterType = matterType;
            MatterStatus = matterStatus;
            CreatedAt = createdAt;
            LastUpdatedAt = lastUpdatedAt;

        }

    // Methods

    // Add a new matter to the database
    public static void Add(Matter matter)
        {
            // Create a connection string
            string connectionString = "Data Source=. ;Initial Catalog=Slate;Integrated Security=True";

            // Create a SQL query
            string query = "INSERT INTO MATTERS (EntityID, MatterType, MatterStatus, CreatedAt, LastUpdatedAt) VALUES (@EntityID, @MatterType, @MatterStatus, @CreatedAt, @LastUpdatedAt)";

            // Create a SQL command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@EntityID", matter.EntityID);
                    command.Parameters.AddWithValue("@MatterType", matter.MatterType);
                    command.Parameters.AddWithValue("@MatterType", matter.MatterType);
                    command.Parameters.AddWithValue("@CreatedAt", matter.CreatedAt);
                    command.Parameters.AddWithValue("@LastUpdatedAt", matter.LastUpdatedAt); // Don't forget to set UpdatedAt

                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
