using System;
using System.ComponentModel;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Slate.Models
{
    public class Entity
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        // Properties
        public string EntityID { get; set; }
        public int EntityTypeID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateOnly DOB { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Constructor
        public Entity(string entityId, int entityTypeId, string firstName, string surname, DateOnly dob, string addressLine1, string addressLine2, string town, string postcode, string phoneNumber, string mobileNumber, string emailAddress, DateTime createdAt, DateTime updatedAt)
        {
            EntityID = entityId;
            EntityTypeID = entityTypeId;
            FirstName = firstName;
            Surname = surname;
            DOB = dob;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Town = town;
            Postcode = postcode;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        // Methods

        // Add a new client to the database
        public static void Add(Entity entity)
        {
            // Create a connection string
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Create a SQL query
            string query = "INSERT INTO Entities (EntityID, EntityTypeID, FirstName, Surname, DOB, AddressLine1, AddressLine2, Town, Postcode, PhoneNumber, MobileNumber, EmailAddress, CreatedAt, UpdatedAt) VALUES (@FirstName, @Surname, @DOB, @AddressLine1, @AddressLine2, @Town, @Postcode, @PhoneNumber, @MobileNumber, @EmailAddress, @CreatedAt, @UpdatedAt)";

            // Create a SQL command
            using Microsoft.Data.SqlClient.SqlConnection connection = new(connectionString);
            using Microsoft.Data.SqlClient.SqlCommand command = new(query, connection);
            // Add parameters
            command.Parameters.AddWithValue("@EntityID", entity.EntityID);
            command.Parameters.AddWithValue("@EntityTypeID", entity.EntityTypeID);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@Surname", entity.Surname);
            command.Parameters.AddWithValue("@DOB", entity.DOB);
            command.Parameters.AddWithValue("@AddressLine1", entity.AddressLine1);
            command.Parameters.AddWithValue("@AddressLine2", entity.AddressLine2);
            command.Parameters.AddWithValue("@Town", entity.Town);
            command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            command.Parameters.AddWithValue("@MobileNumber", entity.MobileNumber);
            command.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt);

            // Open the connection
            connection.Open();

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }

        // Update an existing entity in the database
        public static void Update(Entity entity)
        {
            // Create a connection string
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Create a SQL query
            string query = "UPDATE Entities SET EntityID = @EntityID, EntityTypeID = EntityTypeID, FirstName = @FirstName, Surname = @Surname, DOB = @DOB, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, Town = @Town, Postcode = @Postcode, PhoneNumber = @PhoneNumber, MobileNumber = @MobileNumber, EmailAddress = @EmailAddress, createdAt = @CreatedAt, UpdatedAt = @UpdatedAt WHERE Id = @Id";

            // Create a SQL command
            using Microsoft.Data.SqlClient.SqlConnection connection = new(connectionString);
            using Microsoft.Data.SqlClient.SqlCommand command = new(query, connection);
            // Add parameters
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@Surname", entity.Surname);
            command.Parameters.AddWithValue("@DOB", entity.DOB);
            command.Parameters.AddWithValue("@AddressLine1", entity.AddressLine1);
            command.Parameters.AddWithValue("@AddressLine2", entity.AddressLine2);
            command.Parameters.AddWithValue("@Town", entity.Town);
            command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            command.Parameters.AddWithValue("@MobileNumber", entity.MobileNumber);
            command.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt);

            // Open the connection
            connection.Open();

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }

        // Delete an existing entity from the database
        public static void Delete(string EntityID)
        {
            // Create a connection string
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Create a SQL query
            string query = "DELETE FROM Entities WHERE EntityID = @EntityId";

            // Create a SQL command
            using Microsoft.Data.SqlClient.SqlConnection connection = new(connectionString);
            using Microsoft.Data.SqlClient.SqlCommand command = new(query, connection);
            // Add parameters
            command.Parameters.AddWithValue("@EntityID", EntityID);

            // Open the connection
            connection.Open();

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }

        // Get a Entity by id from the database
        public static Entity GetById(string entityId)
        {
            // Create a connection string
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Create a SQL query
            string query = "SELECT * FROM Entities WHERE EntityID = @EntityID";

            // Create a SQL command
            using Microsoft.Data.SqlClient.SqlConnection connection = new(connectionString);
            using Microsoft.Data.SqlClient.SqlCommand command = new(query, connection);
            // Add parameters
            command.Parameters.AddWithValue("@EntityID", entityId);

            // Open the connection
            connection.Open();

            // Execute the command and get the data reader
            using Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            // Check if the reader has any rows
            if (reader.HasRows)
            {
                // Read the first row
                reader.Read();

                // Get the values from the row
                string EntityID = reader.GetString(0);
                int EntityTypeID = reader.GetInt16(1);
                string FirstName = reader.GetString(2);
                string Surname = reader.GetString(3);
                DateTime DOB = reader.GetDateTime(4); // Get DateTime Value
                string AddressLine1 = reader.GetString(5);
                string AddressLine2 = reader.GetString(6);
                string Town = reader.GetString(7);
                string Postcode = reader.GetString(8);
                string PhoneNumber = reader.GetString(9);
                string MobileNumber = reader.GetString(10);
                string EmailAddress = reader.GetString(11);
                DateTime CreatedAt = reader.GetDateTime(12);
                DateTime UpdatedAt = reader.GetDateTime(13);

                // Convert DateTime to DateOnly for DOB
                DateOnly dateOfBirth = new DateOnly(DOB.Year, DOB.Month, DOB.Day);

                // Create a entity object
                Entity entity = new(EntityID, EntityTypeID, FirstName, Surname, dateOfBirth, AddressLine1, AddressLine2, Town, Postcode, PhoneNumber, MobileNumber, EmailAddress, CreatedAt, UpdatedAt);

                // Close the connection
                connection.Close();

                // Return the entity object
                return entity;
            }
            else
            {
                // Close the connection
                connection.Close();

                // Return null
                return null;
            }
        }

        // Get all entities from the database
        public static List<Entity> GetAll()
        {
            // Create a connection string
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Create a SQL query
            string query = "SELECT * FROM Entites";

            // Create a SQL command
            using Microsoft.Data.SqlClient.SqlConnection connection = new(connectionString);
            using Microsoft.Data.SqlClient.SqlCommand command = new(query, connection);
            // Open the connection
            connection.Open();

            // Execute the command and get the data reader
            using Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            // Check if the reader has any rows
            if (reader.HasRows)
            {
                // Create a list of entites
                List<Entity> entities = new List<Entity>();

                // Loop through the rows
                while (reader.Read())
                {
                    // Get the values from the row
                    string EntityID = reader.GetString(0);
                    int EntityTypeID = reader.GetInt16(1);
                    string FirstName = reader.GetString(2);
                    string Surname = reader.GetString(3);
                    DateTime DOB = reader.GetDateTime(4);
                    string AddressLine1 = reader.GetString(5);
                    string AddressLine2 = reader.GetString(6);
                    string Town = reader.GetString(7);
                    string Postcode = reader.GetString(8);
                    string PhoneNumber = reader.GetString(9);
                    string MobileNumber = reader.GetString(10);
                    string EmailAddress = reader.GetString(11);
                    DateTime CreatedAt = reader.GetDateTime(12);
                    DateTime UpdatedAt = reader.GetDateTime(13);

                    // Convert DateTime to DateOnly for DOB
                    DateOnly dateOfBirth = new DateOnly(DOB.Year, DOB.Month, DOB.Day);

                    // Create a entity object
                    Entity entity = new(EntityID, EntityTypeID, FirstName, Surname, dateOfBirth, AddressLine1, AddressLine2, Town, Postcode, PhoneNumber, MobileNumber, EmailAddress, CreatedAt, UpdatedAt);

                    // Add the entity object to the list
                    entities.Add(entity);
                }

                // Close the connection
                connection.Close();

                // Return the list of clients
                return entities;
            }
            else
            {
                // Close the connection
                connection.Close();

                // Return an empty list
                return new List<Entity>();
            }
        }
    }
}
