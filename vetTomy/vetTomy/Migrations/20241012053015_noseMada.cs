using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace vet_tomy.Migrations
{
    /// <inheritdoc />
    public partial class noseMada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pet");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "branchs",
                schema: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                schema: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Store",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                schema: "Store",
                columns: table => new
                {
                    SaleNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReceiptType = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.SaleNumber);
                    table.ForeignKey(
                        name: "FK_sales_branchs_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Pet",
                        principalTable: "branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productServices",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productServices_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Store",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productServices_brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Store",
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                schema: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoryNumber = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pets_breeds_BreedId",
                        column: x => x.BreedId,
                        principalSchema: "Pet",
                        principalTable: "breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Security",
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Security",
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Security",
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_RolId",
                        column: x => x.RolId,
                        principalSchema: "Security",
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "images",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_productServices_ProductServiceId",
                        column: x => x.ProductServiceId,
                        principalSchema: "Store",
                        principalTable: "productServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saleDetails",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saleDetails_productServices_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Store",
                        principalTable: "productServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saleDetails_sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "Store",
                        principalTable: "sales",
                        principalColumn: "SaleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                schema: "Pet",
                columns: table => new
                {
                    AppointmentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.AppointmentNumber);
                    table.ForeignKey(
                        name: "FK_appointments_branchs_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Pet",
                        principalTable: "branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicalHistory",
                schema: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalHistory_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "Pet",
                        principalTable: "appointments",
                        principalColumn: "AppointmentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "persons",
                columns: new[] { "Id", "Address", "BussinessName", "CellPhoneNumber", "DocumentNumber", "DocumentType", "LastName", "Name", "State" },
                values: new object[,]
                {
                    { 1, "nose", "Nose", "999666331", "45454545", "dni", "Madero", "Jose", true },
                    { 2, "nose", "Nose", "999666332", "45454546", "dni", "Damian", "Arturo", true },
                    { 3, "nose", "Nose", "999666333", "45454547", "dni", "Pereira", "Roberto", true }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "roles",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Administrador del sistema", "Administrador", true },
                    { 2, "Vendedor del sistema", "Vendedor", true },
                    { 3, "Cliente del sistema", "Cliente", true }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "users",
                columns: new[] { "Id", "Mail", "Password", "PersonId", "RolId", "Salt", "State" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "123456", 1, 1, "qweretrt21212", true },
                    { 2, "user1@user.com", "123456", 2, 2, "qweretrt21213", true },
                    { 3, "user2@user.com", "123456", 3, 3, "qweretrt21213", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_BranchId",
                schema: "Pet",
                table: "appointments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PetId",
                schema: "Pet",
                table: "appointments",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                schema: "Store",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_images_ProductServiceId",
                schema: "Store",
                table: "images",
                column: "ProductServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalHistory_AppointmentId",
                schema: "Pet",
                table: "medicalHistory",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_BreedId",
                schema: "Pet",
                table: "pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_CustomerId",
                schema: "Pet",
                table: "pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_productServices_BrandId",
                schema: "Store",
                table: "productServices",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_productServices_CategoryId",
                schema: "Store",
                table: "productServices",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_CustomerId",
                schema: "Store",
                table: "reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_saleDetails_ProductId",
                schema: "Store",
                table: "saleDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_saleDetails_SaleId",
                schema: "Store",
                table: "saleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_BranchId",
                schema: "Store",
                table: "sales",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_users_PersonId",
                schema: "Security",
                table: "users",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_RolId",
                schema: "Security",
                table: "users",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "images",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "medicalHistory",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "reviews",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "saleDetails",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "appointments",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "productServices",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "sales",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "persons",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "pets",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "branchs",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "breeds",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "Security");
        }
    }
}
