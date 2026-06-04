using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Territory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescinText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DescinHTML = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OfficeCode = table.Column<int>(type: "int", nullable: true),
                    ReportsTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "Offices",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Scale = table.Column<int>(type: "int", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PdtDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QtyInStock = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(19,0)", nullable: false),
                    MSRP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductLineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Products_ProductLines_ProductLineID",
                        column: x => x.ProductLineID,
                        principalTable: "ProductLines",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(19,0)", nullable: true),
                    SalesRepEmployeeNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_SalesRepEmployeeNum",
                        column: x => x.SalesRepEmployeeNum,
                        principalTable: "Employees",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CheckNum = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,0)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.CheckNum);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders_products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    PriceEach = table.Column<decimal>(type: "decimal(19,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_products", x => new { x.OrderID, x.ID, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_Orders_products_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orders_products_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code");
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Code", "Address1", "Address2", "City", "Country", "Phone", "PostalCode", "State", "Territory" },
                values: new object[,]
                {
                    { 1, "100 Broadway", null, "New York", "USA", "212-555-0100", 10001, "NY", null },
                    { 2, "200 Oxford St", null, "London", "UK", "020-555-0200", null, null, null },
                    { 3, "300 Champs", null, "Paris", "France", "033-555-0300", 75001, null, null },
                    { 4, "400 Shibuya", null, "Tokyo", "Japan", "081-555-0400", null, null, null },
                    { 5, "500 Tahrir Sq", null, "Cairo", "Egypt", "020-555-0500", 11511, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductLines",
                columns: new[] { "ID", "DescinHTML", "DescinText", "Image" },
                values: new object[,]
                {
                    { 1, "<p>Classic Cars</p>", "Classic Cars", "classic.jpg" },
                    { 2, "<p>Motorcycles</p>", "Motorcycles", "moto.jpg" },
                    { 3, "<p>Trucks and Buses</p>", "Trucks and Buses", "trucks.jpg" },
                    { 4, "<p>Vintage Cars</p>", "Vintage Cars", "vintage.jpg" },
                    { 5, "<p>Ships</p>", "Ships", "ships.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Email", "Extension", "FirstName", "JobTitle", "LastName", "OfficeCode", "ReportsTo" },
                values: new object[] { 1, "john@cm.com", "x101", "John", "CEO", "Smith", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Code", "BuyPrice", "MSRP", "Name", "PdtDescription", "ProductLineID", "QtyInStock", "Scale", "Vendor" },
                values: new object[,]
                {
                    { 101, 150m, "200", "1969 Mustang", "Classic muscle car", 1, 50, 18, "Ford" },
                    { 102, 200m, "280", "Harley Davidson", "Iconic motorcycle", 2, 30, 12, "Harley" },
                    { 103, 300m, "400", "Mack Truck", "Heavy duty truck", 3, 20, 24, "Mack" },
                    { 104, 250m, "350", "1932 Ford Model B", "Vintage classic car", 4, 15, 18, "Ford" },
                    { 105, 500m, "700", "Titanic Ship", "Famous ocean liner", 5, 10, 50, "WhiteStar" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Email", "Extension", "FirstName", "JobTitle", "LastName", "OfficeCode", "ReportsTo" },
                values: new object[,]
                {
                    { 2, "sara@cm.com", "x102", "Sara", "Sales Manager", "Johnson", 1, 1 },
                    { 3, "mike@cm.com", "x103", "Mike", "Sales Rep", "Brown", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address1", "Address2", "City", "Country", "CreditLimit", "FirstName", "LastName", "Name", "Phone", "PostalCode", "SalesRepEmployeeNum", "State" },
                values: new object[,]
                {
                    { 1, "10 Main St", null, "Boston", "USA", 50000m, "Tom", "Alpha", "Alpha Corp", "555-1001", 2101, 3, "MA" },
                    { 2, "20 King St", null, "Chicago", "USA", 30000m, "Anna", "Beta", "Beta LLC", "555-1002", 60601, 3, "IL" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Email", "Extension", "FirstName", "JobTitle", "LastName", "OfficeCode", "ReportsTo" },
                values: new object[,]
                {
                    { 4, "emily@cm.com", "x104", "Emily", "Sales Rep", "Davis", 3, 2 },
                    { 5, "james@cm.com", "x105", "James", "Sales Rep", "Wilson", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address1", "Address2", "City", "Country", "CreditLimit", "FirstName", "LastName", "Name", "Phone", "PostalCode", "SalesRepEmployeeNum", "State" },
                values: new object[,]
                {
                    { 3, "30 Karl St", null, "Berlin", "Germany", 75000m, "Hans", "Gamma", "Gamma GmbH", "555-1003", null, 4, null },
                    { 4, "40 Rue St", null, "Lyon", "France", 40000m, "Marie", "Delta", "Delta SA", "555-1004", 69001, 4, null },
                    { 5, "50 Sakura St", null, "Osaka", "Japan", 60000m, "Yuki", "Epsilon", "Epsilon Co", "555-1005", null, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Comments", "CustomerID", "OrderDate", "RequiredDate", "ShippedDate", "Status" },
                values: new object[,]
                {
                    { 1, "First order", 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Urgent", 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "CheckNum", "Amount", "CustomerID", "PaymentDate" },
                values: new object[,]
                {
                    { "CHK001", 300m, 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "CHK002", 900m, 2, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Comments", "CustomerID", "OrderDate", "RequiredDate", "ShippedDate", "Status" },
                values: new object[,]
                {
                    { 3, "Pending", 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 4, "Handle carefully", 4, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Awaiting stock", 5, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders_products",
                columns: new[] { "ID", "OrderID", "ProductCode", "PriceEach", "Qty" },
                values: new object[,]
                {
                    { 0, 1, 101, 150m, 2 },
                    { 0, 1, 102, 200m, 1 },
                    { 0, 2, 103, 300m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "CheckNum", "Amount", "CustomerID", "PaymentDate" },
                values: new object[,]
                {
                    { "CHK003", 250m, 3, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "CHK004", 1000m, 4, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "CHK005", 600m, 5, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders_products",
                columns: new[] { "ID", "OrderID", "ProductCode", "PriceEach", "Qty" },
                values: new object[,]
                {
                    { 0, 3, 104, 250m, 1 },
                    { 0, 4, 105, 500m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesRepEmployeeNum",
                table: "Customers",
                column: "SalesRepEmployeeNum");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_products_ProductCode",
                table: "Orders_products",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerID",
                table: "Payments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLineID",
                table: "Products",
                column: "ProductLineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_products");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductLines");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
